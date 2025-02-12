using System.Text.RegularExpressions;
/*
using InpCompMessage=(
    string preinp,
    string postinp,
    string repeatinp,
    string maxerr,
    string minerr,
    string parseerr
);
*/

static class MyInpOut
{
    /*
    public delegate T Inp<T>();
    public delegate bool TryParse<T>(string? inp, out T res);
    public static T ConsoleInpComp<T>(T min, T max, TryParse<T> parse, InpCompMessage mess)
    where T:IComparable
    {
        Console.WriteLine(mess.preinp);
        T res;
        bool isCorrect=false;
        do{
            if(!parse(Console.ReadLine(), out res)){
                Console.WriteLine(mess.parseerr);
            }else if(min is not null && res.CompareTo(min)<0){
                Console.WriteLine(mess.minerr);
            }else if(max is not null && res.CompareTo(max)>0){
                Console.WriteLine(mess.maxerr);
            }else{
                isCorrect=true;
            }
            if(!isCorrect){
                Console.WriteLine(mess.repeatinp);
            }
        }while(!isCorrect);
        Console.WriteLine(mess.postinp);
        return res;
    }
    static List<T> InpList<T>(int max, Inp<T> inpel){
        int numel=ConsoleInpComp<int>(0, max, int.TryParse, InpLenghtMessage(max));
        List<T> res=new List<T>();
        for(int i=0;i<max;i++){
            res.Add(inpel());
        }
        return res;
    }
    public static InpCompMessage InpLenghtMessage(int? max){
        int mmax=(max is not null)?(int)max:int.MaxValue;
        return InpNumMessage(0, mmax, "int", "длинну");
    }
    public static InpCompMessage InpNumMessage<T>(T min, T max, string typename, string valname){
        return (
            preinp:$"Введите {valname} - число от {max} до {min}",
            postinp:"Ввод завершен",
            repeatinp:"Повторите ввод",
            maxerr:$"Ошибка: число не может быть больше {max}",
            minerr:$"Ошибка: число не может быть меньше {min}",
            parseerr:$"Ошибка: ввод должен являться числом в пределах {typename}"
        );
    }
    */
    public static void tryPrint<T>(Func<T> func)
    {
        try
        {
            Console.WriteLine(func());
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }
    public static void tryDo(Action act)
    {
        try
        {
            act();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }
    public static double InputDouble(string input_promt, double min=double.NegativeInfinity, double max=double.PositiveInfinity)
    {
        double res;
        Console.WriteLine(input_promt);
        bool is_correct = false;
        do
        {
            if (!double.TryParse(Console.ReadLine(), out res))
            {
                Console.WriteLine("ошибка: ввод - число в пределах double");
            }
            else if (res < min)
            {
                Console.WriteLine($"ошибка: ввод не меньше {min}");
            }
            else if (res > max)
            {
                Console.WriteLine($"ошибка: ввод не больше {max}");
            }
            else
            {
                is_correct = true;
            }
        } while (!is_correct);
        return res;
    }
    public static Runner1Time InputRunner1Time()
    {
        Console.WriteLine("введите информацию об одноразовом бегуне");
        var res = new Runner1Time(
            InputDouble("введите скорость - число в пределах double", min: 0),
            InputDouble("введите расстояние - число в пределах double", min: 0)
            );
        Console.WriteLine("ввод завершен");
        return res;
    }
    public static int InputLenght(string input_promt, int? max=null)
    {
        max = max ?? Array.MaxLength;
        int res;
        Console.WriteLine(input_promt);
        bool is_correct = false;
        do
        {
            if (!int.TryParse(Console.ReadLine(), out res))
            {
                Console.WriteLine("ошибка: длинна - целое число");
            }
            else if (res < 0)
            {
                Console.WriteLine("ошибка: длинна - неотрицательное число");
            }
            else if (res > max)
            {
                Console.WriteLine($"ошибка: длинна не боьше {max}");
            }
            else
            {
                is_correct = true;
            }
        } while (!is_correct);
        return res;
    }
    public static Runner1TimeArray InputRunner1TimeArrayConsole()
    {
        return new Runner1TimeArray(
            (i) => InputRunner1Time(),
            InputLenght("введите длинну списка")
            );
    }
    public static Runner1TimeArray InputRunner1TimeArrayRandom(Random rand)
    {
        return new Runner1TimeArray(
            (i) => new Runner1Time(rand.NextDouble() * 200, rand.NextDouble() * 200),
            InputLenght("введите длинну списка")
            );
    }
    public static int InputInt(string input_promt)
    {
        int res;
        Console.WriteLine(input_promt);
        bool is_correct = false;
        do
        {
            if (!int.TryParse(Console.ReadLine(), out res))
            {
                Console.WriteLine("ошибка: ввод - целое число");
            }
            else
            {
                is_correct = true;
            }
        } while (!is_correct);
        return res;
    }
}
