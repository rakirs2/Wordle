namespace dotWordle;

public class GuessResult
{
    internal GuessResult(Dictionary<char, int> yellows, bool isValidGuess, List<char> greens, uint guessNumber, bool hasWon)
    {
        IsValidGuess = isValidGuess;
        Greens = greens;
        Yellows = yellows;
        GuessNumber = guessNumber;
        HasWon = hasWon;
    }

    public bool IsValidGuess { get; set; }
    public List<char> Greens { get; set; } = new() { '0', '0', '0', '0', '0' };
    public uint GuessNumber { get; set; }
    public Dictionary<char, int> Yellows { get; set; }
    public bool HasWon { get; set; }
}