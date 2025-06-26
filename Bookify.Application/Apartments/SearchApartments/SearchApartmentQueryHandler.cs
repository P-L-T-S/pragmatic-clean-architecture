using Bookify.Application.Abstractions.Data;
using Bookify.Application.Abstractions.Messaging;
using Bookify.Domain.Abstractions;
using Bookify.Domain.Bookings;
using Dapper;

namespace Bookify.Application.Apartments.SearchApartments;

internal sealed class SearchApartmentQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
    : IQueryHandler<SearchApartmentsQuery, IReadOnlyList<ApartmentResponse>>
{
    private readonly ISqlConnectionFactory _sqlConnectionFactory = sqlConnectionFactory;

    private static readonly int[] ActiveBookingStatuses =
    [
        (int)EBookingStatus.Reserved,
        (int)EBookingStatus.Confirmed,
        (int)EBookingStatus.Completed,
    ];

    public async Task<Result<IReadOnlyList<ApartmentResponse>>> Handle(
        SearchApartmentsQuery request,
        CancellationToken cancellationToken
    )
    {
        if (request.StartDate > request.EndDate)
        {
            return new List<ApartmentResponse>();
        }

        const string sql = """
                           SELECT
                           a.id AS Id,
                           a.name AS Name,
                           a.description AS Description,
                           a.price_amount AS Price,
                           a.price_currency AS Currency,
                           a.address_country AS Country,
                           a.address_city AS City,
                           a.address_state AS State,
                           a.address_zip_code AS ZipCode,
                           a.address_street AS Street,
                           FROM apartments AS a
                           WHERE NOT Exists(
                               SELECT 1
                               FROM bookings AS b
                               WHERE b.apartment_id = a.id AND
                                     b.duration_start <= @endDate AND
                                     b.duration_end >= @startDate AND
                                     b.status = ANY(@ActiveBookingStatuses)
                           )
                           """;

        var connection = _sqlConnectionFactory.CreateConnection();

        var apartments = await connection
            .QueryAsync<ApartmentResponse, AddressResponse, ApartmentResponse>(
                sql,
                (apartment, address) =>
                {
                    apartment.Address = address;
                    return apartment;
                },
                new
                {
                    startDate = request.StartDate,
                    endDate = request.EndDate,
                    ActiveBookingStatuses
                },
                splitOn: "Country"
            );

        return apartments.ToList();
    }
}