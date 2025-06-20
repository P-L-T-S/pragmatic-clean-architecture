namespace Bookify.Domain.Bookings;

public record DateRange
{
    public DateOnly Start { get; private set; }
    public DateOnly End { get; private set; }

    private DateRange()
    {
    }

    public static DateRange Create(DateOnly start, DateOnly end)
    {
        if (start > end)
        {
            throw new ArgumentOutOfRangeException(nameof(start), "Start must be less than End");
        }

        return new()
        {
            Start = start,
            End = end,
        };
    }

    public int LengthInDays => End.DayNumber - Start.DayNumber;
}