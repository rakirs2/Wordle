namespace dotWordleTests;

[TestClass]
public class BasicTests
{
    private readonly ForcedWordleBot _forcedWordleBot = new(Constants.DefaultWordForTest);

    [TestMethod]
    public void TestInitialization()
    {
        _forcedWordleBot.Should().NotBeNull();
        _forcedWordleBot.GetRemainingWords().Count.Should().Be(Constants.TotalNumberOfValidGuesses);
        _forcedWordleBot.GetGuessNumber().Should().Be(1);
        _forcedWordleBot.HasWon().Should().BeFalse();
        _forcedWordleBot.GetGuessesRemaining().Should().Be(6);
    }

    [TestMethod]
    public void InvalidGuess()
    {
        _forcedWordleBot.GuessWord(Constants.DefaultInvalidGuess).IsValidGuess.Should().BeFalse();
    }

    [TestMethod]
    public void ValidGuess()
    {
        _forcedWordleBot.GuessWord(Constants.DefaultValidGuess).IsValidGuess.Should().BeTrue();
    }

    [TestMethod]
    public void ValidGuessIncrementsGuessesRemainingByOne()
    {
        _forcedWordleBot.GuessWord(Constants.DefaultValidGuess).IsValidGuess.Should().BeTrue();
        _forcedWordleBot.GetGuessesRemaining().Should().Be(5);
    }

    [TestMethod]
    public void ValidGuessIncrementsSixTimes()
    {
        _forcedWordleBot.GuessWord(Constants.DefaultValidGuess).IsValidGuess.Should().BeTrue();
        _forcedWordleBot.GetGuessesRemaining().Should().Be(5);
        _forcedWordleBot.GuessWord(Constants.DefaultValidGuess).IsValidGuess.Should().BeTrue();
        _forcedWordleBot.GetGuessesRemaining().Should().Be(4);
        _forcedWordleBot.GuessWord(Constants.DefaultValidGuess).IsValidGuess.Should().BeTrue();
        _forcedWordleBot.GetGuessesRemaining().Should().Be(3);
        _forcedWordleBot.GuessWord(Constants.DefaultValidGuess).IsValidGuess.Should().BeTrue();
        _forcedWordleBot.GetGuessesRemaining().Should().Be(2);
        _forcedWordleBot.GuessWord(Constants.DefaultValidGuess).IsValidGuess.Should().BeTrue();
        _forcedWordleBot.GetGuessesRemaining().Should().Be(1);
        _forcedWordleBot.GuessWord(Constants.DefaultValidGuess).IsValidGuess.Should().BeTrue();
        _forcedWordleBot.GetGuessesRemaining().Should().Be(0);
        _forcedWordleBot.GuessWord(Constants.DefaultValidGuess).IsValidGuess.Should().BeFalse();
        _forcedWordleBot.GetGuessesRemaining().Should().Be(0);
    }

    [TestMethod]
    public void ValidGuessNoCorrectOutput()
    {
        //toxic
        //snare
        var output = _forcedWordleBot.GuessWord("snare");
        output.Greens.Should().BeEquivalentTo(Constants.DefaultGreens);
        output.Yellows.Should().BeEquivalentTo(new Dictionary<char, int>());
    }

    [TestMethod]
    public void ValidGuessOnlyYellows()
    {
        //toxic
        //annex
        var output = _forcedWordleBot.GuessWord(Constants.DefaultValidOneYellow);
        output.Greens.Should().BeEquivalentTo(Constants.DefaultGreens);
        var expectedYellows = new Dictionary<char, int> { { 'x', 1 } };
        output.Yellows.Should().BeEquivalentTo(expectedYellows);

    }

    [TestMethod]
    public void ValidGuessOnlyGreens()
    {
        //toxic
        //toxin
        var output = _forcedWordleBot.GuessWord(Constants.DefaultValidFourGreens);
        var expectedGreens = new []{'t','o','x','i','0' };
        output.Greens.Should().BeEquivalentTo(expectedGreens);
        output.Yellows.Should().BeEquivalentTo(new Dictionary<char, int>());
    }
}