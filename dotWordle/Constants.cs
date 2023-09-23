namespace dotWordle;

internal class Constants
{
    internal static uint TotalNumberOfGuesses = 6;
    internal static uint NumberOfLetters = 5;
    internal static int TotalNumberOfValidGuesses = 12974;
    internal static string DefaultValidGuess = "slate";
    internal static string DefaultInvalidGuess = "aaaaa";
    internal static string DefaultWordForTest = "toxic";
    internal static string DefaultValidFourGreens = "toxin";
    internal static string DefaultValidOneYellow = "annex";
    internal static List<char> DefaultGreens = new() { '0', '0', '0', '0', '0' };
}