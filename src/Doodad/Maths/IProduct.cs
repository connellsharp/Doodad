namespace Doodad
{
    public interface IProduct<TProduct, TFactor1, TFactor2>
        where TProduct : IProduct<TProduct, TFactor1, TFactor2>, IProduct<TProduct, TFactor2, TFactor1>
        where TFactor1 : IQuotient<TFactor1, TProduct, TFactor2>
        where TFactor2 : IQuotient<TFactor2, TProduct, TFactor1>
    {
        TFactor2 DivideBy(TFactor1 other);
        TFactor1 DivideBy(TFactor2 other);
    }
}