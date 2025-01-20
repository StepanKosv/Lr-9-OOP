using Microsoft.VisualBasic;

internal class Program
{
    private static void Main(string[] args)
    {
        Runner1Time runner1=new Runner1Time();
        Runner1Time runner2=new Runner1Time(3.0,2);
        Runner1Time runner3=new Runner1Time(runner2);
        Runner1Time[] rns={runner1,runner2,runner3};
        foreach(var e in rns){
            Console.WriteLine(e.ToString());
            try{
                Console.WriteLine(Runner1Time.StaticAvgTime(e.avgSpeed,e.distance));
            }
            catch(Exception exp){
                Console.WriteLine(exp);
            }
            try{
                Console.WriteLine(e.AvgTimeToRun());
            }
            catch(Exception exp){
                Console.WriteLine(exp);
            }
        }
    }
}
