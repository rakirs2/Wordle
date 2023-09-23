namespace dotWordleTests;

[TestClass]
public class BasicTests
{
    private readonly ForcedWordleBot _wordleBot = new(Constants.DefaultWordForTest);

    [TestMethod]
    public void TestInitialization()
    {
        _wordleBot.Should().NotBeNull();
        _wordleBot.GetRemainingWords().Count.Should().Be(Constants.TotalNumberOfValidGuesses);
        _wordleBot.GetGuessNumber().Should().Be(1);
        _wordleBot.HasWon().Should().BeFalse();
        _wordleBot.GetGuessesRemaining().Should().Be(6);
    }

    [TestMethod]
    public void InvalidGuess()
    {
        _wordleBot.GuessWord(Constants.DefaultInvalidGuess).isValidGuess.Should().BeFalse();
    }

    [TestMethod]
    public void ValidGuess()
    {
        _wordleBot.GuessWord(Constants.DefaultValidGuess).isValidGuess.Should().BeTrue();
    }

    [TestMethod]
    public void ValidGuessIncrementsGuessesRemainingByOne()
    {
        _wordleBot.GuessWord(Constants.DefaultValidGuess).isValidGuess.Should().BeTrue();
        _wordleBot.GetGuessesRemaining().Should().Be(5);
    }

    [TestMethod]
    public void ValidGuessIncrementsSixTimes()
    {
        _wordleBot.GuessWord(Constants.DefaultValidGuess).isValidGuess.Should().BeTrue();
        _wordleBot.GetGuessesRemaining().Should().Be(5);
        _wordleBot.GuessWord(Constants.DefaultValidGuess).isValidGuess.Should().BeTrue();
        _wordleBot.GetGuessesRemaining().Should().Be(4);
        _wordleBot.GuessWord(Constants.DefaultValidGuess).isValidGuess.Should().BeTrue();
        _wordleBot.GetGuessesRemaining().Should().Be(3);
        _wordleBot.GuessWord(Constants.DefaultValidGuess).isValidGuess.Should().BeTrue();
        _wordleBot.GetGuessesRemaining().Should().Be(2);
        _wordleBot.GuessWord(Constants.DefaultValidGuess).isValidGuess.Should().BeTrue();
        _wordleBot.GetGuessesRemaining().Should().Be(1);
        _wordleBot.GuessWord(Constants.DefaultValidGuess).isValidGuess.Should().BeTrue();
        _wordleBot.GetGuessesRemaining().Should().Be(0);
        _wordleBot.GuessWord(Constants.DefaultValidGuess).isValidGuess.Should().BeFalse();
        _wordleBot.GetGuessesRemaining().Should().Be(0);
    }

    [TestMethod]
    public void ValidGuessNoCorrectOutput()
    {
        var output = _wordleBot.GuessWord(Constants.DefaultValidGuess);
        output.Greens.Should().BeEquivalentTo(Constants.DefaultGreens);
        output.Yellows.Should().BeEquivalentTo(new Dictionary<char, int>());
    }
}