namespace Logic
{
    public class Runner1TimeArray : DinamicArray<Runner1Time>
    {
        public Runner1TimeArray(Func<int, Runner1Time> source, int count) : base(source, count)
        { }
        public Runner1TimeArray(Runner1Time val, int count) : this(
            (i) => new Runner1Time(val),
            count
        )
        { }
        public Runner1TimeArray(Runner1TimeArray origin) : this(
            (i) => new Runner1Time(origin[i]),
            origin.Len()
        )
        { }
        public Runner1TimeArray() : base()
        { }
        public Runner1TimeArray(Random rand, int count, double max_speed, double max_dist) : base(
            (i) => new Runner1Time(rand.NextDouble() * max_speed, rand.NextDouble() * max_dist),
            count
        )
        { }
    }
}