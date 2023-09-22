namespace dotWordleTests;

internal class ForcedWordleBot : EasyWordleBot
{
    internal ForcedWordleBot(string word)
    {
        _word = new Word(word);
    }
}