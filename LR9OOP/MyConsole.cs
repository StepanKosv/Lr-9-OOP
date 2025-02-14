namespace Logic
{
    class MyConsole{
        public static void WriteLine(Object s){
            Console.WriteLine(s);
        }
        public static string? ReadLine(){
            return Console.ReadLine();
        }
        public static void WaitUser(){
            Console.Write("press enter to continue: ");
            Console.ReadLine();
        }
    }
}