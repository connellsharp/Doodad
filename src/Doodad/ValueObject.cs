using System;
using System.Collections.Generic;
using System.Linq;

namespace Doodad
{
    public abstract class ValueObject<T> : IEquatable<T>
        where T : ValueObject<T>
    {
        protected abstract IEnumerable<object> GetValues();

        public bool Equals(T other) =>
            GetValues()
                .Zip(other.GetValues(), (o1, o2) => o1.Equals(o2))
                .All(x => x);

        public override bool Equals(object obj) =>
            obj is T other && Equals(other);

        public override int GetHashCode()
        {
            return GetValues()
             .Select(x => x != null ? x.GetHashCode() : 0)
             .Aggregate((x, y) => x ^ y);
        }

        public static bool operator ==(ValueObject<T> left, ValueObject<T> right) => left.Equals(right);
        public static bool operator !=(ValueObject<T> left, ValueObject<T> right) => !left.Equals(right);
    }
}
