namespace dotWordleTests;

[TestClass]
public class InstantiationTests
{
    [TestMethod]
    public void TestWordCount()
    {
        var erb = new EasyWordleBot();
        erb.Should().NotBeNull();
        erb.GetRemainingWords().Count.Should().Be(10665);
    }
}