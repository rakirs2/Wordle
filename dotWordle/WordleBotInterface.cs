using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("dotWordleTests")]

namespace dotWordle;

internal interface IWordleBot
{
    /// <summary>
    ///     1. rules of the game,
    ///     2. is not a duplicate, and
    ///     3. is in the list of possible guesses list
    ///     4. If Invalid Guess, returns false, doesn't do any counting
    /// </summary>
    /// <param name="guess"></param>
    /// <returns></returns>
    public GuessResult GuessWord(string guess);

    /// <summary>
    /// </summary>
    /// <returns></returns>
    public uint GetGuessNumber();

    /// <summary>
    /// </summary>
    /// <returns></returns>
    public List<Word> GetRemainingWords();

    public uint GetGuessesRemaining();
}