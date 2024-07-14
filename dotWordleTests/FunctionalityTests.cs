namespace dotWordleTests;

[TestClass]
public class FunctionalityTests
{
    private readonly ForcedWordleBot _forcedWordleBot = new(Constants.DefaultWordForTest);
    private int remainingInitial;

    [TestMethod]
    public void TestInitialization()
    {
        _forcedWordleBot.Should().NotBeNull();
        remainingInitial = _forcedWordleBot.GetRemainingWords().Count;
    }
}