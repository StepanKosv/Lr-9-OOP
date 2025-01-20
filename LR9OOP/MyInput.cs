using System.Text.RegularExpressions;
using InpCompMessage=(
    string preinp,
    string postinp,
    string repeatinp,
    string maxerr,
    string minerr,
    string parseerr
);
static class MyInput{
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
    
}