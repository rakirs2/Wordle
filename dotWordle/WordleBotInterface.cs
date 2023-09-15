namespace dotWordle;

internal interface IWordleBot
{
    /// <summary>
    /// 1. rules of the game,
    /// 2. is not a duplicate, and
    /// 3. is in the list of possible guesses list
    /// </summary>
    /// <param name="guess"></param>
    /// <returns></returns>
    public bool IsValidGuess(string guess);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="guess"></param>
    /// <returns></returns>
    public bool GuessWord(string guess);
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public uint GuessNumber();
    public List<Word> GetRemainingWords();
}