namespace Logic
{
    public class Runner1Time
    {
        static int _count = 0;
        public static int count
        {
            get
            {
                return _count;
            }
            private set
            {
                _count = value;
            }
        }
        double _avgSpeed, _distance;
        public double avgSpeed
        {
            get
            {
                return _avgSpeed;
            }
            set
            {
                if (value < 0)
                {
                    throw new NegativeSpeedException($"avgSpeed:{value}");
                }
                _avgSpeed = value;
            }
        }
        public double distance
        {
            get
            {
                return _distance;
            }
            set
            {
                if (value < 0)
                {
                    throw new NegativeDistanceException($"distance: {value}");
                }
                _distance = value;
            }
        }
        public Runner1Time(double speed, double distance)
        {
            this.avgSpeed = speed;
            this.distance = distance;
            count++;
        }
        public Runner1Time() : this(0, 0)
        {
        }
        public Runner1Time(Runner1Time origin) : this(origin.avgSpeed, origin.distance)
        {
        }
        public double AvgTimeToRun()
        {
            if (avgSpeed == 0)
            {
                throw new ZeroSpeedException($"time is infinity or not determined. speed:{avgSpeed}, distance:{distance}");
            }
            return distance / avgSpeed;
        }
        public static double StaticAvgTime(double avgSpeed, double distance)
        {
            if (avgSpeed < 0)
            {
                throw new NegativeSpeedException($"speed: {avgSpeed}");
            }
            if (distance < 0)
            {
                throw new NegativeDistanceException($"speed:{avgSpeed}, distance:{distance}");
            }
            if (avgSpeed == 0)
            {
                throw new ZeroSpeedException($"time is infinity or not determined. speed:{avgSpeed}, distance:{distance}");
            }
            return distance / avgSpeed;
        }
        public override string ToString()
        {
            return $"Runner1Time(speed: {avgSpeed}, distance: {distance})";
        }
        public static Runner1Time operator ++(Runner1Time run)
        {
            var nr = new Runner1Time(run);
            nr.distance += 0.1;
            return nr;
        }
        public static Runner1Time operator --(Runner1Time run)
        {
            var nr = new Runner1Time(run);
            nr.avgSpeed -= 0.05;
            return nr;
        }
        public static explicit operator double(Runner1Time run)
        {
            var time = run.AvgTimeToRun() * 0.95;
            if (time == 0)
            {
                throw new ZeroTimeException($"time is zero=>speed can't be determined");
            }
            var speed = run.distance / time;
            return speed - run.avgSpeed;
        }
        public static implicit operator string(Runner1Time run)
        {
            var time = run.AvgTimeToRun();
            int hours = (int)time;
            int minutes = (int)((time - hours) * 60);
            int seconds = (int)(((time - hours) * 60 - minutes) * 60);
            return $"{hours}:{minutes}:{seconds}";
        }
        public static double operator -(Runner1Time a, Runner1Time b)
        {
            if (a.distance + b.distance < 15)
            {
                return -1;
            }
            if (a.avgSpeed + b.avgSpeed == 0)
            {
                return -1;
            }
            return 15 / (a.avgSpeed + b.avgSpeed);
        }
        public static Runner1Time operator ^(Runner1Time r, double sp)
        {
            return new Runner1Time(r) { avgSpeed = r.avgSpeed + sp };
        }
        public override bool Equals(object? obj)
        {
            if (obj is not null && obj is Runner1Time runner)
            {
                return runner.avgSpeed == this.avgSpeed && runner.distance == this.distance;
            }
            return false;
        }
        /*
        ~Runner1Time(){
            _count--;
        }
        */
        public class NegativeSpeedException : Exception
        {
            public NegativeSpeedException(double _val) : base($"value: {_val}") { }
            public NegativeSpeedException(string message) : base(message) { }
        }
        public class ZeroSpeedException : Exception
        {
            public ZeroSpeedException(string message) : base(message) { }
        }
        public class NegativeDistanceException : Exception
        {
            public NegativeDistanceException(string message) : base(message) { }
        }
        public class ZeroTimeException : Exception
        {
            public ZeroTimeException(string message) : base(message) { }
        }
    }
}