using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Doodad
{
    public abstract class Enumeration<T> : IEquatable<T>
        where T : Enumeration<T>
    {
        public object Id { get; }

        protected Enumeration(object id) => Id = id;

        private static IEnumerable<FieldInfo> GetFields() =>
            typeof(T).GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly);

        public static IEnumerable<T> GetAll() =>
            GetFields().Select(f => f.GetValue(null)).Cast<T>();

        public static T Get(string name) =>
            GetFields().FirstOrDefault(e => e.Name == name)?.GetValue(null) as T ?? 
                throw new InvalidOperationException($"'{name}' is not a valid {typeof(T)}");

        public bool Equals(T other) => Id.Equals(other.Id);

        public override bool Equals(object obj) => obj is T other && Equals(other);

        public override string ToString() => Id.ToString();

        public override int GetHashCode() => Id.GetHashCode();

        public static bool operator ==(Enumeration<T> left, Enumeration<T> right) => left.Equals(right);
        public static bool operator !=(Enumeration<T> left, Enumeration<T> right) => !left.Equals(right);
    }
}
