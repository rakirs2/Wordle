namespace dotWordle;

public class GuessResult
{
    internal GuessResult(Dictionary<char, int> yellows, bool isValidGuess, List<char> greens, uint guessNumber,
        bool hasWon, bool isGoodGuess)
    {
        Greens = greens;
        Yellows = yellows;
        GuessNumber = guessNumber;
        HasWon = hasWon;
        IsGoodGuess = isGoodGuess;
    }

    public List<char> Greens { get; set; } = ['0', '0', '0', '0', '0'];
    public uint GuessNumber { get; set; }
    public Dictionary<char, int> Yellows { get; set; }
    public bool HasWon { get; set; }
    public bool IsGoodGuess { get; set; }
}