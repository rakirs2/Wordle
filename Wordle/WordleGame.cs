namespace Wordle;

internal class WordleGame : IGame
{
    internal WordleGame()
    {
        GameName = "Wordle, single Player";
    }

    public string GameName { get; }
}