namespace dotWordle;

public class GuessResult
{

    internal GuessResult(Dictionary<char, int> yellows, bool isValidGuess, List<char> greens, uint guessNumber)
    {
        this.isValidGuess = isValidGuess;
        Greens = greens;
        Yellows = yellows;
        this.guessNumber = guessNumber;
    }

    public bool isValidGuess { get; set; }
    public List<char> Greens { get; set; } = new() { '0', '0', '0', '0', '0' };
    public uint guessNumber { get; set; }
    public Dictionary<char, int> Yellows { get; set; } = new Dictionary<char, int>();
}