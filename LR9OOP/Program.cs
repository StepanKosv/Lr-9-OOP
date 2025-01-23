
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
    static void DemoPart1(){
        Runner1Time runner1=new Runner1Time();
        Runner1Time runner2=new Runner1Time(3.5,2);
        Runner1Time runner3=new Runner1Time(runner2);
        Console.WriteLine($"runner1.Equals(runner2): {runner1.Equals(runner2)}");
        Console.WriteLine($"runner2.Equals(runner3): {runner2.Equals(runner3)}");
        Runner1Time[] rns={runner1,runner2,runner3};
        foreach(var e in rns){
            Console.WriteLine(e.ToString());
            Console.WriteLine("static method time:");
            tryPrint(()=>Runner1Time.StaticAvgTime(e.avgSpeed,e.distance));
            Console.WriteLine("method time:");
            tryPrint(()=>e.AvgTimeToRun());
        }
        Runner1Time run=new Runner1Time(0,0);
        Console.WriteLine("try set speed or distance under zero:");
        tryDo(()=>run.distance=-10);
        tryDo(()=>run.avgSpeed=-10);
        Console.WriteLine($"count: {Runner1Time.count}");
    }
    static void DemoPart2(){
        Runner1Time runner1=new Runner1Time();
        Runner1Time runner2=new Runner1Time(3.5,2);
        Runner1Time runner3=new Runner1Time(runner2);
        Console.WriteLine($"runner1:{runner1},runner2:{runner2},runner3:{runner3}");
        Console.WriteLine("demo Equals");
        Console.WriteLine($"\trunner1.Equals(runner2): {runner1.Equals(runner2)}");
        Console.WriteLine($"\trunner2.Equals(runner3): {runner2.Equals(runner3)}");
        Console.WriteLine("demo '++'");
        Console.WriteLine($"\t(runner2++): {runner2++}; -> runner2: {runner2}");
        Console.WriteLine($"\t(++runner2): {++runner2}; -> runner2: {runner2}");
        Console.WriteLine("demo '--'");
        Console.WriteLine($"\t(runner2--): {runner2--}; -> runner2: {runner2}");
        Console.WriteLine($"\t(--runner2): {--runner2}; -> runner2: {runner2}");
        Console.WriteLine($"demo '(double)'");
        //double r2=runner2;
        double r2=(double) runner2;
        Console.WriteLine($"\t(double)runner2: {r2}");
        
        Console.WriteLine($"demo '(string)'");
        string r3=runner3;
        r3=(string) runner3;
        Console.WriteLine($"\t(string)runner3: {r3}");
    }
    private static void Main(string[] args)
    {
        //DemoPart1();
        DemoPart2();
    }
}
