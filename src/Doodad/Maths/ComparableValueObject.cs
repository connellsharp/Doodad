using System;

namespace Doodad
{
    public abstract class ComparableValueObject<T> : ValueObject<T>, IComparable<T>
        where T : ComparableValueObject<T>
    {
        public abstract int CompareTo(T other);

        public static bool operator >=(ComparableValueObject<T> p1, T p2) => p1.CompareTo(p2) >= 0;
        public static bool operator <=(ComparableValueObject<T> p1, T p2) => p1.CompareTo(p2) <= 0;
        public static bool operator >(ComparableValueObject<T> p1, T p2) => p1.CompareTo(p2) > 0;
        public static bool operator <(ComparableValueObject<T> p1, T p2) => p1.CompareTo(p2) <= 0;
    }
}
