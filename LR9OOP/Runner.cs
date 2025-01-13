class Runner{
    public static int count{
        get{
            return count;
        }
        private set{
            count=value;
        }
    }
    public double avgSpeed{
        get{
            return avgSpeed;
        }
        set{
            if(value<0){
                throw new NegativeSpeedException(value);
            }
            avgSpeed=value;
        }
    }
    public Runner(double speed){
        this.avgSpeed=speed;
        count++;
    }
    public Runner():this(0){}
    public Runner(Runner origin):this(origin.avgSpeed){}
    public double AvgTimeToRun(double distance){
        if(distance<0){
            throw new NegativeDistanceException($"speed:{avgSpeed}, distance:{distance}");
        }
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
        return $"Runner(speed:{avgSpeed})";
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
}