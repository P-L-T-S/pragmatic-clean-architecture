namespace Bookify.Domain.Apartments;

public record Currency(string Code)
{
    internal static readonly Currency None = new Currency("");
    public static readonly Currency Usd = new Currency("USD");
    public static readonly Currency Brl = new Currency("BRL");

    public static readonly IReadOnlyCollection<Currency> All = [Usd, Brl];

    public static Currency FromCode(string code)
    {
        return All.FirstOrDefault(c => c.Code.Equals(code))
               ?? throw new ArgumentException($"Code {code} is invalid");
    }
};