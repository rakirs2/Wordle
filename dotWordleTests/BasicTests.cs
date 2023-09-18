namespace dotWordleTests;

[TestClass]
public class BasicTests
{
    private readonly EasyWordleBot wordleBot = new();

    [TestMethod]
    public void TestInitialization()
    {
        wordleBot.Should().NotBeNull();
        wordleBot.GetRemainingWords().Count.Should().Be(Constants.TotalNumberOfValidGuesses);
        wordleBot.GuessNumber().Should().Be(1);
        wordleBot.HasWon().Should().BeFalse();
        wordleBot.GuessesRemaining().Should().Be(6);
    }

    [TestMethod]
    public void InvalidGuess()
    {
        wordleBot.GuessWord("aaaaa").isValidGuess.Should().BeFalse();
    }

    [TestMethod]
    public void ValidGuess()
    {
        wordleBot.GuessWord("slate").isValidGuess.Should().BeTrue();
    }
}