using Logic;
namespace TestProject;
[TestClass]
public class Runner1TimeUnitTestPart2{
    [TestMethod]
    public void TestIncrement(){
        Runner1Time runner2 = new Runner1Time(3.5, 2);
        Assert.AreEqual(runner2++, new Runner1Time(speed: 3.5, distance: 2));
        Assert.AreEqual(runner2, new Runner1Time(speed: 3.5, distance: 2.1));
        Assert.AreEqual(++runner2, new Runner1Time(speed: 3.5, distance: 2.2));
        Assert.AreEqual(runner2, new Runner1Time(speed: 3.5, distance: 2.2));
    }
    [TestMethod]
    public void TestDecrement(){
        Runner1Time runner2 = new Runner1Time(speed: 3.5, distance: 2.2);
        Assert.AreEqual(runner2--, new Runner1Time(speed: 3.5, distance: 2.2));
        Assert.AreEqual(runner2, new Runner1Time(speed: 3.45, distance: 2.2));
        Assert.AreEqual((--runner2).avgSpeed, 3.4, 0.001);
        Assert.AreEqual(runner2.avgSpeed, 3.4, 0.001);
    }
    [TestMethod]
    public void TestDecrementNegative(){
        Runner1Time runner2 = new Runner1Time();
        Assert.ThrowsException<Runner1Time.NegativeSpeedException>(()=>runner2--);
        Assert.ThrowsException<Runner1Time.NegativeSpeedException>(()=>--runner2);
    }
    [TestMethod]
    public void TestDoubleExplicit(){
        var runner2= new Runner1Time(speed: 3.4, distance: 2.2);
        Assert.AreEqual((double) runner2, 0.1789473684210523, 0.001);
    }
    [TestMethod]
    public void TestDoubleExplicitSpeedZero(){
        var runner2= new Runner1Time();
        Assert.ThrowsException<Runner1Time.ZeroSpeedException>(()=>(double)runner2);
    }
    [TestMethod]
    public void TestDoubleExplicitZeroTime(){
        var runner2= new Runner1Time(5,0);
        Assert.ThrowsException<Runner1Time.ZeroTimeException>(()=>(double)runner2);
    }
    [TestMethod]
    public void TestStringImplicit(){
        Runner1Time runner3 = new Runner1Time(3.5, 2);
        string r3 = runner3;
        Assert.AreEqual(r3, "0:34:17");
    }
    [TestMethod]
    public void TestBinaryMinus(){
        Runner1Time runner1 = new Runner1Time();
        Runner1Time runner2= new Runner1Time(speed: 3.4, distance: 2.2);
        Assert.AreEqual(runner1-runner2, -1);
        Assert.AreEqual(runner2-new Runner1Time(6,13), 1.5957446808510638, 0.001);
    }
    [TestMethod]
    public void TestBinaryMinusZeroSpeed(){
        Runner1Time run=new Runner1Time(0,10);
        Assert.AreEqual(-1,run-run);
    }
    [TestMethod]
    public void TestCaret(){
        Runner1Time runner1 = new Runner1Time();
        Assert.AreEqual(runner1^10.3, new Runner1Time(speed: 10.3, distance: 0));
    }
}