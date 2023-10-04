// See https://aka.ms/new-console-template for more information

using dotWordle;

Console.WriteLine("Hello, Welcome To EasyWordleBot");
Console.WriteLine("The list of possible guesses is");
var wordleConsole = new WordleConsole();
var validGuesses = new EasyWordleBot();

Console.WriteLine($"You have {validGuesses.GetGuessesRemaining()} guesses remaining");
Console.WriteLine(validGuesses.GetRemainingWords().Count);
Console.WriteLine("What is your first guess");