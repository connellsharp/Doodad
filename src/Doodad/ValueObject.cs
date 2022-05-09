using System;
using System.Collections.Generic;
using System.Linq;

namespace Doodad
{
    public abstract class ValueObject<T> : IEquatable<T>
        where T : ValueObject<T>
    {
        protected abstract IEnumerable<object> GetEqualityComponents();

        public bool Equals(T other) =>
            GetEqualityComponents()
                .SequenceEqual(other.GetEqualityComponents());

        public override bool Equals(object obj) =>
            obj is T other && Equals(other);

        public override int GetHashCode() =>
            GetEqualityComponents()
                .Select(x => x != null ? x.GetHashCode() : 0)
                .Aggregate((x, y) => x ^ y);

        public static bool operator ==(ValueObject<T> left, ValueObject<T> right) =>
            left.Equals(right);

        public static bool operator !=(ValueObject<T> left, ValueObject<T> right) =>
            !left.Equals(right);
    }
}
