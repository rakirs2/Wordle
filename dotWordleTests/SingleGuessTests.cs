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
        wordleBot.GetGuessNumber().Should().Be(1);
        wordleBot.HasWon().Should().BeFalse();
        wordleBot.GetGuessesRemaining().Should().Be(6);
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
    [TestMethod]
    public void ValidGuessIncrementsGuessesRemainingByOne()
    {
        wordleBot.GuessWord("slate").isValidGuess.Should().BeTrue();
        wordleBot.GetGuessesRemaining().Should().Be(5);
    }

    [TestMethod]
    public void ValidGuessIncrementsSixTimes()
    {
        wordleBot.GuessWord("slate").isValidGuess.Should().BeTrue();
        wordleBot.GetGuessesRemaining().Should().Be(5);
        wordleBot.GuessWord("slate").isValidGuess.Should().BeTrue();
        wordleBot.GetGuessesRemaining().Should().Be(4);
        wordleBot.GuessWord("slate").isValidGuess.Should().BeTrue();
        wordleBot.GetGuessesRemaining().Should().Be(3);
        wordleBot.GuessWord("slate").isValidGuess.Should().BeTrue();
        wordleBot.GetGuessesRemaining().Should().Be(2);
        wordleBot.GuessWord("slate").isValidGuess.Should().BeTrue();
        wordleBot.GetGuessesRemaining().Should().Be(1);
        wordleBot.GuessWord("slate").isValidGuess.Should().BeTrue();
        wordleBot.GetGuessesRemaining().Should().Be(0);
    }
}