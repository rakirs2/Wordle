namespace Wordle;

internal class Cli : ICli
{
    internal Cli(IGame Game)
    {
        StartGame(Game);
    }

    private IGame Game { get; set; } = null!;

    public void StartGame(IGame game)
    {
        Game = game;
        Console.WriteLine($"Starting new game of {game.GameName}");
    }
}