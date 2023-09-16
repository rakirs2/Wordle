namespace dotWordleTests;

[TestClass]
public class InstantiationTests
{
    EasyWordleBot wordleBot=  new EasyWordleBot();
    [TestMethod]
    public void TestInitiation()
    {
        
        wordleBot.Should().NotBeNull();
        wordleBot.GetRemainingWords().Count.Should().Be(10665);
        wordleBot.GuessNumber().Should().Be(1);
        wordleBot.HasWon().Should().BeFalse();
        wordleBot.GuessesRemaining().Should().Be(6);
    }
}