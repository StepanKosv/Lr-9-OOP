public class Program
{
    static void DemoPart1()
    {
        Console.WriteLine("demo part 1");
        Runner1Time runner1 = new Runner1Time();
        Runner1Time runner2 = new Runner1Time(3.5, 2);
        Runner1Time runner3 = new Runner1Time(runner2);
        Console.WriteLine($"runner1:{runner1},\nrunner2:{runner2},\nrunner3:{runner3}");
        Console.ReadLine();
        Console.WriteLine($"runner1.Equals(runner2): {runner1.Equals(runner2)}");
        Console.WriteLine($"runner2.Equals(runner3): {runner2.Equals(runner3)}");
        Console.ReadLine();
        Runner1Time[] rns = { runner1, runner2, runner3 };
        foreach (var e in rns)
        {
            Console.WriteLine(e.ToString());
            Console.WriteLine("static method time:");
            MyInpOut.tryPrint(() => Runner1Time.StaticAvgTime(e.avgSpeed, e.distance));
            Console.WriteLine("method time:");
            MyInpOut.tryPrint(() => e.AvgTimeToRun());
            Console.ReadLine();
        }
        Runner1Time run = new Runner1Time(0, 0);
        Console.WriteLine("try set speed or distance under zero:");
        MyInpOut.tryDo(() => run.distance = -10);
        MyInpOut.tryDo(() => run.avgSpeed = -10);
        Console.ReadLine();
        Console.WriteLine($"count: {Runner1Time.count}");
        Console.ReadLine();
    }
    static void DemoPart2()
    {
        Console.WriteLine("demo part 2");
        Runner1Time runner1 = new Runner1Time();
        Runner1Time runner2 = new Runner1Time(3.5, 2);
        Runner1Time runner3 = new Runner1Time(runner2);
        Console.WriteLine($"runner1:{runner1},\nrunner2:{runner2},\nrunner3:{runner3}");
        Console.ReadLine();
        Console.WriteLine("demo Equals");
        Console.WriteLine($"\trunner1.Equals(runner2): {runner1.Equals(runner2)}");
        Console.WriteLine($"\trunner2.Equals(runner3): {runner2.Equals(runner3)}");
        Console.ReadLine();
        Console.WriteLine("demo '++'");
        Console.WriteLine($"\t(runner2++): {runner2++}; -> runner2: {runner2}");
        Console.WriteLine($"\t(++runner2): {++runner2}; -> runner2: {runner2}");
        Console.ReadLine();
        Console.WriteLine("demo '--'");
        Console.WriteLine($"\t(runner2--): {runner2--}; -> runner2: {runner2}");
        Console.WriteLine($"\t(--runner2): {--runner2}; -> runner2: {runner2}");
        Console.ReadLine();
        Console.WriteLine($"demo '(double)'");
        //double r2=runner2;
        double r2 = (double)runner2;
        Console.WriteLine($"\t(double)runner2: {r2}");
        Runner1Time runner22 = new Runner1Time(runner2);
        runner22.avgSpeed += r2;
        Console.WriteLine($"\trunner2: {runner2}");
        Console.WriteLine($"\trunner22: {runner22}");
        Console.WriteLine($"\trunner22.AvgTimeToRun(): {runner22.AvgTimeToRun()}");
        Console.WriteLine($"\trunner2.AvgTimeToRun(): {runner2.AvgTimeToRun()}");
        Console.WriteLine($"\t(runner22.AvgTimeToRun()-runner2.AvgTimeToRun())/runner2.AvgTimeToRun(): {(runner22.AvgTimeToRun() - runner2.AvgTimeToRun()) / runner2.AvgTimeToRun()}");
        Console.ReadLine();
        Console.WriteLine($"demo '(string)'");
        string r3 = runner3;
        r3 = (string)runner3;
        Console.WriteLine($"\t(string)runner3: {r3}");
        Console.WriteLine($"\trunner3.AvgTimeToRun(): {runner3.AvgTimeToRun()}");
        Console.ReadLine();
        Console.WriteLine($"runner1-runner2: {runner1 - runner2}");
        Console.WriteLine($"runner2-new Runner1Time(6,13): {runner2 - new Runner1Time(6, 13)}");
        Console.ReadLine();
        Console.WriteLine($"runner1^10.3: {runner1 ^ 10.3}");
        Console.ReadLine();
    }
    public static void Main(string[] args)
    {
        DemoPart1();
        DemoPart2();
    }
}