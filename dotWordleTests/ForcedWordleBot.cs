namespace dotWordleTests;

internal class ForcedWordleBot : EasyWordleBot
{
    internal ForcedWordleBot(string word)
    {
        Word = new Word(word);
    }
}