using System;

namespace Doodad
{
    public abstract class ProductValueObject<T, TValue, T1, T2> :
        NumericalValueObject<T, TValue>,
        IProduct<T, T1, T2>
        where T : ProductValueObject<T, TValue, T1, T2>, IProduct<T, T2, T1>
        where TValue : IComparable<TValue>
        where T1 : NumericalValueObject<T1, TValue>, IQuotient<T1, T, T2>, new()
        where T2 : NumericalValueObject<T2, TValue>, IQuotient<T2, T, T1>, new()
    {
        protected ProductValueObject(TValue value) : base(value) { }

        protected abstract T1 CreateT1(TValue value);
        protected abstract T2 CreateT2(TValue value);

        protected abstract TValue Divide(TValue dividend, TValue divisor);

        public T1 DivideBy(T2 other) => CreateT1(Divide(this.Value, other.Value));
        public T2 DivideBy(T1 other) => CreateT2(Divide(this.Value, other.Value));

        public static T2 operator /(ProductValueObject<T, TValue, T1, T2> vp, T1 v1) => vp.DivideBy(v1);
        public static T1 operator /(ProductValueObject<T, TValue, T1, T2> vp, T2 v2) => vp.DivideBy(v2);
    }
}