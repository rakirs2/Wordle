namespace dotWordle;

public class GuessResult
{
    public Dictionary<char, int> Yellows = new();
    public bool isValidGuess { get; set; }
    public List<char> Greens { get; set; } = new() { '0', '0', '0', '0', '0' };
}