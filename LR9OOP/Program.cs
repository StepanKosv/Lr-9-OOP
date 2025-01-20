
internal class Program
{
    static void tryPrint<T>(Func<T> func){
        try{
            Console.WriteLine(func());
        }catch(Exception e){
            Console.WriteLine(e);
        }
    }
    static void tryDo(Action act){
        try{
            act();
        }catch(Exception e){
            Console.WriteLine(e);
        }
    }
    private static void Main(string[] args)
    {
        Runner1Time runner1=new Runner1Time();
        Runner1Time runner2=new Runner1Time(3.5,2);
        Runner1Time runner3=new Runner1Time(runner2);
        Runner1Time[] rns={runner1,runner2,runner3};
        foreach(var e in rns){
            Console.WriteLine(e.ToString());
            tryPrint(()=>Runner1Time.StaticAvgTime(e.avgSpeed,e.distance));
            tryPrint(()=>e.AvgTimeToRun());
        }
        Runner1Time run=new Runner1Time(0,0);
        tryDo(()=>run.distance=-10);
        tryDo(()=>run.avgSpeed=-10);
        Console.WriteLine($"count: {Runner1Time.count}");
    }
}
