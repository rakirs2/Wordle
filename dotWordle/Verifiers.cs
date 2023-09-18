namespace dotWordle;

internal class Verifiers
{
    internal static bool VerifyFiveChars(string guess)
    {
        foreach (var character in guess)
        {
            if (!char.IsAsciiLetter(character))
            {
                return false;
            }
        }

        return guess.Length == Constants.NumberOfLetters;
    }
}