namespace dotWordleTests;

[TestClass]
public class FunctionalityTests
{
    private ForcedWordleBot _forcedWordleBot = new(Constants.DefaultWordForTest);
    private int remainingInitial;
    [TestMethod]
    public void TestInitialization()
    {
        _forcedWordleBot.Should().NotBeNull();
        remainingInitial = _forcedWordleBot.GetRemainingWords().Count;
    }

    [TestMethod]
    [Ignore]
    public void ValidGuessIncrementsSixTimes()
    {
        _forcedWordleBot.GuessWord(Constants.DefaultValidGuess).IsValidGuess.Should().BeTrue();
        // TODO: calculating wrong
        var remainingAfter = _forcedWordleBot.GetRemainingWords().Count;
        Assert.IsTrue(remainingAfter < remainingInitial);


    }
}