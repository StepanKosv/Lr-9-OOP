using Logic;
namespace TestProject;
[TestClass]
public class ArraysUnitTest{
    [TestMethod]
    public void TestConstructors(){
        Runner1TimeArray arr0=new Runner1TimeArray();
        Assert.AreEqual(arr0.Len(),0);
        Runner1TimeArray arr1=new Runner1TimeArray(new Runner1Time(3,4), 10);
        Assert.AreEqual(arr1.Len(),10);
        Assert.IsTrue(arr1.All((i,r)=>r.Equals(new Runner1Time(3,4))));
        Runner1TimeArray arr2=new Runner1TimeArray(arr1);
        Assert.IsTrue(arr1.All((i,r)=>r.Equals(arr1[i])));
        Runner1TimeArray arr3=new Runner1TimeArray(new Random(), 50, 10,20);
        Assert.IsTrue(arr3.All((i,r)=>r.avgSpeed<=10&&r.distance<=20));
    }
    [TestMethod]
    public void TestIndexNormal(){
        Runner1TimeArray arr1=new Runner1TimeArray(new Runner1Time(3,4), 10);
        arr1[1]=null;
        arr1[3]=new Runner1Time(0,0);
        Assert.AreEqual(arr1[1],null);
        Assert.AreEqual(arr1[3],new Runner1Time(0,0));
    }
    [TestMethod]
    public void TestIndexError(){
        Runner1TimeArray arr1=new Runner1TimeArray(new Runner1Time(3,4), 10);
        Assert.ThrowsException<IndexOutOfRangeException>(()=>arr1[-1]);
        Assert.ThrowsException<IndexOutOfRangeException>(()=>arr1[10]);
    }
    [TestMethod]
    public void TestAddRemove(){
        Runner1TimeArray arr=new Runner1TimeArray();
        int n=1000000;
        for(int i=0; i<n; i++){
            arr.Add(new Runner1Time(i,i));
        }
        bool success;
        Runner1Time run;
        for(int i=n-1;i>=0;i--){
            arr.PopLast(out success, out run);
            Assert.IsTrue(success);
            Assert.AreEqual(run,new Runner1Time(i,i));
        }
        arr.PopLast(out success, out run);
        Assert.IsFalse(success);
        Assert.AreEqual(run, null);
    }
}