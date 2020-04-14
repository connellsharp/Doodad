namespace Doodad
{
    public interface IQuotient<TQuotient, TDividend, TDivisor>
        where TQuotient : IQuotient<TQuotient, TDividend, TDivisor>
        where TDividend : IProduct<TDividend, TQuotient, TDivisor>, IProduct<TDividend, TDivisor, TQuotient>
        where TDivisor : IQuotient<TDivisor, TDividend, TQuotient>
    {
        TDividend MultiplyBy(TDivisor other);
    }
}