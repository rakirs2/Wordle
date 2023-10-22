namespace dotWordle;

internal static class Constants
{
    internal const string DefaultValidOneYellow = "annex";
    internal static readonly uint TotalNumberOfGuesses = 6;
    internal static readonly uint NumberOfLetters = 5;
    internal static readonly int TotalNumberOfValidGuesses = 12974;
    internal static readonly string DefaultValidGuess = "slate";
    internal static readonly string DefaultInvalidGuess = "aaaaa";
    internal static readonly string DefaultWordForTest = "toxic";
    internal static readonly string DefaultValidFourGreens = "toxin";
    internal static readonly List<char> DefaultGreens = new() { '0', '0', '0', '0', '0' };
}