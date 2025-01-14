class Runner1TimeArray{
    Runner1Time[] runs;
    public Runner1Time this[int index]{
        get{
            if(index<0||index>=Len()){
                throw new IndexOutOfRangeException($"index:{index}, len:{Len()}");
            }
            return runs[index];
        }
        set{
            if(index<0||index>=Len()){
                throw new IndexOutOfRangeException($"index:{index}, len:{Len()}");
            }
            runs[index]=value;
        }
    }
    int ln;
    public Runner1TimeArray(Runner1Time val, int count):this(
        (i)=>new Runner1Time(val),
        count
    ){}
    public Runner1TimeArray(Runner1TimeArray origin):this(
        (i)=>new Runner1Time(origin[i]),
        origin.Len()
    ){}
    public Runner1TimeArray(Func<int,Runner1Time> source, int count){
        runs=new Runner1Time[count];
        ln=count;
        for(int i=0; i<count; i++){
            this[i]=source(i);
        }
    }
    public Runner1TimeArray(Random rand, int count,double max_speed, double max_dist):this(
        (i)=>new Runner1Time(rand.NextDouble()*max_speed,rand.NextDouble()*max_dist),
        count
    ){}
    public int Len()=>ln;
    void Fill(Runner1Time[] arr){
        for(int i=0; i<Len(); i++){
            arr[i]=this[i];
        }
    }
    public void Add(Runner1Time run){
        if(Len()==runs.Length){
            Runner1Time[] newruns=new Runner1Time[(ln+1)*2];
            Fill(newruns);
            this.runs=newruns;
        }
        ln++;
        this[Len()-1]=run;
    }
    public void PopLast(out bool success){
        if(Len()==0){
            success=false;
            return;
        }
        if(runs.Length/4>=Len()){
            Runner1Time[] newruns=new Runner1Time[runs.Length/2];
            Fill(newruns);
            runs=newruns;
        }
        ln--;
        success=true;
    }
    public void PopLast(out bool success, out Runner1Time? val){
        if(Len()==0){
            success=false;
            val=null;
            return;
        }
        val=this[Len()-1];
        PopLast(out success);
    }
}