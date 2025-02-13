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
    public void TestStaticTimeNegativeSpeed(){
        Assert.ThrowsException<Runner1Time.NegativeSpeedException>(
            ()=>Runner1Time.StaticAvgTime(-10, 0)
        );
    }
    [TestMethod]
    public void TestStaticTimeNegativeDistance(){
        Assert.ThrowsException<Runner1Time.NegativeDistanceException>(
            ()=>Runner1Time.StaticAvgTime(1, -25)
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
    public void TestToString(){
        Assert.AreEqual(new Runner1Time(3.5,2).ToString(),"Runner1Time(speed: 3.5, distance: 2)");
    }
}