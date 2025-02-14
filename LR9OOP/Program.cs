namespace Logic
{
    public class Program
    {
        static void DemoPart1()
        {
            MyConsole.WriteLine("demo part 1");
            Runner1Time runner1 = new Runner1Time();
            Runner1Time runner2 = new Runner1Time(3.5, 2);
            Runner1Time runner3 = new Runner1Time(runner2);
            MyConsole.WriteLine($"runner1:{runner1},\nrunner2:{runner2},\nrunner3:{runner3}");
            MyConsole.WaitUser();
            MyConsole.WriteLine($"runner1.Equals(runner2): {runner1.Equals(runner2)}");
            MyConsole.WriteLine($"runner2.Equals(runner3): {runner2.Equals(runner3)}");
            MyConsole.WaitUser();
            Runner1Time[] rns = { runner1, runner2, runner3 };
            foreach (var e in rns)
            {
                MyConsole.WriteLine(e.ToString());
                MyConsole.WriteLine("static method time:");
                MyInpOut.tryPrint(() => Runner1Time.StaticAvgTime(e.avgSpeed, e.distance));
                MyConsole.WriteLine("method time:");
                MyInpOut.tryPrint(() => e.AvgTimeToRun());
                MyConsole.WaitUser();
            }
            Runner1Time run = new Runner1Time(0, 0);
            MyConsole.WriteLine("try set speed or distance under zero:");
            MyInpOut.tryDo(() => run.distance = -10);
            MyInpOut.tryDo(() => run.avgSpeed = -10);
            MyConsole.WaitUser();
            MyConsole.WriteLine($"count: {Runner1Time.count}");
            MyConsole.WaitUser();
        }
        static void DemoPart2()
        {
            MyConsole.WriteLine("demo part 2");
            Runner1Time runner1 = new Runner1Time();
            Runner1Time runner2 = new Runner1Time(3.5, 2);
            Runner1Time runner3 = new Runner1Time(runner2);
            MyConsole.WriteLine($"runner1:{runner1},\nrunner2:{runner2},\nrunner3:{runner3}");
            MyConsole.WaitUser();
            MyConsole.WriteLine("demo Equals");
            MyConsole.WriteLine($"\trunner1.Equals(runner2): {runner1.Equals(runner2)}");
            MyConsole.WriteLine($"\trunner2.Equals(runner3): {runner2.Equals(runner3)}");
            MyConsole.WaitUser();
            MyConsole.WriteLine("demo '++'");
            MyConsole.WriteLine($"\t(runner2++): {runner2++}; -> runner2: {runner2}");
            MyConsole.WriteLine($"\t(++runner2): {++runner2}; -> runner2: {runner2}");
            MyConsole.WaitUser();
            MyConsole.WriteLine("demo '--'");
            MyConsole.WriteLine($"\t(runner2--): {runner2--}; -> runner2: {runner2}");
            MyConsole.WriteLine($"\t(--runner2): {--runner2}; -> runner2: {runner2}");
            MyConsole.WaitUser();
            MyConsole.WriteLine($"demo '(double)'");
            //double r2=runner2;
            double r2 = (double)runner2;
            MyConsole.WriteLine($"\t(double)runner2: {r2}");
            Runner1Time runner22 = new Runner1Time(runner2);
            runner22.avgSpeed += r2;
            MyConsole.WriteLine($"\trunner2: {runner2}");
            MyConsole.WriteLine($"\trunner22: {runner22}");
            MyConsole.WriteLine($"\trunner22.AvgTimeToRun(): {runner22.AvgTimeToRun()}");
            MyConsole.WriteLine($"\trunner2.AvgTimeToRun(): {runner2.AvgTimeToRun()}");
            MyConsole.WriteLine($"\t(runner22.AvgTimeToRun()-runner2.AvgTimeToRun())/runner2.AvgTimeToRun(): {(runner22.AvgTimeToRun() - runner2.AvgTimeToRun()) / runner2.AvgTimeToRun()}");
            MyConsole.WaitUser();
            MyConsole.WriteLine($"demo '(string)'");
            string r3 = runner3;
            r3 = (string)runner3;
            MyConsole.WriteLine($"\t(string)runner3: {r3}");
            MyConsole.WriteLine($"\trunner3.AvgTimeToRun(): {runner3.AvgTimeToRun()}");
            MyConsole.WaitUser();
            MyConsole.WriteLine($"runner1-runner2: {runner1 - runner2}");
            MyConsole.WriteLine($"runner2-new Runner1Time(6,13): {runner2 - new Runner1Time(6, 13)}");
            MyConsole.WaitUser();
            MyConsole.WriteLine($"runner1^10.3: {runner1 ^ 10.3}");
            MyConsole.WaitUser();
        }
        static void DemoPart3()
        {
            Random random=new Random();
            string menu="menu:\n"+
            "input - input list\n"+
            "input random - input random list\n"+
            "print - print list\n"+
            "add - add element to list\n"+
            "rm - remove last element to list\n"+
            "get - get element by index (from 0)\n"+
            "set - set element by index\n"+
            "menu - print menu\n"+
            "stop - stop working";
            Runner1TimeArray arr=null;
            bool end=false;
            MyConsole.WriteLine("demo part 3");
            MyConsole.WriteLine(menu);
            do{
                string command;
                MyConsole.WriteLine("input command");
                command=MyConsole.ReadLine();
                switch(command){
                    case "input":
                        arr=MyInpOut.InputRunner1TimeArrayConsole();
                        break;
                    case "input random":
                        arr=MyInpOut.InputRunner1TimeArrayRandom(random);
                        break;
                    case "print":
                        if(arr is null){
                            MyConsole.WriteLine("list does not exist");
                        }else{
                            MyConsole.WriteLine($"list lenght: {arr.Len()}");
                            for(int i=0;i<arr.Len();i++){
                                MyConsole.WriteLine(arr[i].ToString());
                            }
                        }
                        break;
                    case "add":
                        if(arr is null){
                            MyConsole.WriteLine("list does not exist");
                        }else{
                            arr.Add(MyInpOut.InputRunner1Time());
                        }
                        break;
                    case "rm":
                        if(arr is null){
                            MyConsole.WriteLine("list does not exist");
                        }else{
                            bool success;
                            Runner1Time? val;
                            arr.PopLast(out success, out val);
                            if(!success){
                                MyConsole.WriteLine("array is empty");
                            }else{
                                MyConsole.WriteLine($"deleted element {val.ToString()}");
                            }
                        }
                        break;
                    case "get":
                        if(arr is null){
                            MyConsole.WriteLine("list does not exist");
                        }else{
                            int i=MyInpOut.InputInt("input index of element (from 0)");
                            MyInpOut.tryPrint(()=>arr[i]);
                        }
                        break;
                    case "set":
                        if(arr is null){
                            MyConsole.WriteLine("list does not exist");
                        }else{
                            int i=MyInpOut.InputInt("input index of element (from 0)");
                            MyInpOut.tryDo(()=>{arr[i]=MyInpOut.InputRunner1Time();});
                        }
                        break;
                    case "menu":
                        MyConsole.WriteLine(menu);
                        break;
                    case "stop":
                        end=true;
                        break;
                    default:
                        MyConsole.WriteLine("unknown command\ninput 'menu' to show menu");
                        break;
                }
            }while(!end);
        }
        public static void Main(string[] args)
        {
            DemoPart1();
            DemoPart2();
            DemoPart3();
        }
    }
}