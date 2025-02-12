using Logic;
namespace TestProject;
[TestClass]
public class Runner1TimeUnitTest
{
    [TestMethod]
    public void TestEquals()
    {
        Runner1Time runner1 = new Runner1Time();
        Runner1Time runner2 = new Runner1Time(3.5, 2);
        Runner1Time runner3 = new Runner1Time(runner2);
        Runner1Time runner4 = new Runner1Time(3.5, 0);
        Runner1Time runner5 = null;
        string s="";
        Assert.AreNotEqual(runner1, runner2);
        Assert.AreNotEqual(runner2, runner4);
        Assert.AreNotEqual(runner2, runner5);
        Assert.AreNotEqual(runner2, s);
        Assert.AreEqual(runner2, runner3);
    }
    [TestMethod]
    public void TestStaticTimeZeroSpeed(){
        Runner1Time runner1 = new Runner1Time();
        Assert.ThrowsException<Runner1Time.ZeroSpeedException>(
            ()=>Runner1Time.StaticAvgTime(runner1.avgSpeed, runner1.distance)
        );
    }
    [TestMethod]
    public void TestTimeZeroSpeed(){
        Runner1Time runner1 = new Runner1Time();
        Assert.ThrowsException<Runner1Time.ZeroSpeedException>(
            ()=>runner1.AvgTimeToRun()
        );
    }
    [TestMethod]
    public void TestStaticTimeNormal(){
        Runner1Time runner2 = new Runner1Time(3.5, 2);
        Assert.AreEqual(Runner1Time.StaticAvgTime(runner2.avgSpeed,runner2.distance),0.5714285714285714,0.0001);
    }
    [TestMethod]
    public void TestTimeNormal(){
        Runner1Time runner2 = new Runner1Time(3.5, 2);
        Assert.AreEqual(runner2.AvgTimeToRun(),0.5714285714285714,0.0001);
    }
    [TestMethod]
    public void TestNegativeSpeed(){
        Assert.ThrowsException<Runner1Time.NegativeSpeedException>(()=>new Runner1Time(-1,0));
        Runner1Time run = new Runner1Time(0, 0);
        Assert.ThrowsException<Runner1Time.NegativeSpeedException>(()=>run.avgSpeed=-50);
    }
    [TestMethod]
    public void TestNegativeDistance(){
        Assert.ThrowsException<Runner1Time.NegativeDistanceException>(()=>new Runner1Time(0,-1));
        Runner1Time run = new Runner1Time(0, 0);
        Assert.ThrowsException<Runner1Time.NegativeDistanceException>(()=>run.distance=-50);
    }
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
    public void TestCaret(){
        Runner1Time runner1 = new Runner1Time();
        Assert.AreEqual(runner1^10.3, new Runner1Time(speed: 10.3, distance: 0));
    }
}