namespace Doodad
{
    public abstract class Singleton<T>
        where T : Singleton<T>, new()
    {
        public static T Value { get; } = new T();

        public override bool Equals(object obj) => obj is T;

        public override int GetHashCode() => typeof(T).GetHashCode();

        public override string ToString() => typeof(T).Name;
    }
}