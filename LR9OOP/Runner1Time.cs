class Runner1Time{
    static int count=0;
    double _avgSpeed, _distance;
    public double avgSpeed{
        get{
            return _avgSpeed;
        }
        set{
            if(value<0){
                throw new NegativeSpeedException(value);
            }
            _avgSpeed=value;
        }
    }
    public double distance{
        get{
            return _distance;
        }
        set{
            if(value<0){
                throw new NegativeDistanceException($"distance: {distance}");
            }
            _distance=value;
        }
    }
    public Runner1Time(double speed, double distance){
        this.avgSpeed=speed;
        this.distance=distance;
        count++;
    }
    public Runner1Time():this(0,0){
    }
    public Runner1Time(Runner1Time origin):this(origin.avgSpeed,origin.distance){
    }
    public double AvgTimeToRun(){
        if(avgSpeed==0){
            throw new ZeroSpeedException($"time is infinity or not determinated. speed:{avgSpeed}, distance:{distance}");
        }
        return distance/avgSpeed;
    }
    public static double StaticAvgTime(double avgSpeed, double distance){
        if(avgSpeed<0){
            throw new NegativeSpeedException($"speed: {avgSpeed}");
        }
         if(distance<0){
            throw new NegativeDistanceException($"speed:{avgSpeed}, distance:{distance}");
        }
        if(avgSpeed==0){
            throw new ZeroSpeedException($"time is infinity or not determinated. speed:{avgSpeed}, distance:{distance}");
        }
        return distance/avgSpeed;
    }
    public override string ToString(){
        return $"Runner1Time(speed: {avgSpeed}, distance: {distance})";
    }
    public static Runner1Time operator ++(Runner1Time run){
        var nr=new Runner1Time(run);
        nr.distance+=0.1;
        return nr;
    }
    public static Runner1Time operator --(Runner1Time run){
        var nr=new Runner1Time(run);
        nr.avgSpeed-=0.05;
        return nr;
    }
    public static explicit operator double(Runner1Time run){
        var time=run.AvgTimeToRun()*0.95;
        if(time==0){
            throw new ZeroTimeException($"time is zero=>speed can't be determinated");
        }
        var speed=run.distance/time;
        return speed-run.avgSpeed;
    }
    public static implicit operator string(Runner1Time run){
        var time=run.AvgTimeToRun();
        int hours=(int)time;
        int minutes=(int)((time-hours)*60);
        int seconds=(int)(((time-hours)*60-minutes)*60);
        return $"{hours}:{minutes}:{seconds}";
    }
    public class NegativeSpeedException:Exception{
        public NegativeSpeedException(double _val):base($"value: {_val}"){}
        public NegativeSpeedException(string message):base(message){}
    }
    public class ZeroSpeedException:Exception{
        public ZeroSpeedException(string message):base(message){}
    }
    public class NegativeDistanceException:Exception{
        public NegativeDistanceException(string message):base(message){}
    }
    public class ZeroTimeException:Exception{
        public ZeroTimeException(string message):base(message){}
    }
}