namespace dotWordle;

public class GuessResult
{
    public Dictionary<char, int> Yellows = new();

    internal GuessResult(Dictionary<char, int> yellows, bool isValidGuess, List<char> greens, uint guessNumber)
    {
        Yellows = yellows;
        this.isValidGuess = isValidGuess;
        Greens = greens;
        this.guessNumber = guessNumber;
    }

    public bool isValidGuess { get; set; }
    public List<char> Greens { get; set; } = new() { '0', '0', '0', '0', '0' };
    public uint guessNumber { get; set; }
}