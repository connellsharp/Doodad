using System;
using System.Collections.Generic;

namespace Doodad
{
    public abstract class NumericalValueObject<T, TValue> : ComparableValueObject<T>
        where T : NumericalValueObject<T, TValue>
        where TValue : IComparable<TValue>
    {
        protected NumericalValueObject(TValue value) => Value = value;

        public TValue Value { get; }

        protected override IEnumerable<object> GetValues() => new object[] { Value };

        public override int CompareTo(T other) => this.Value.CompareTo(other.Value);
    }
}