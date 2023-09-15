// See https://aka.ms/new-console-template for more information

using dotWordle;

Console.WriteLine("Hello, Welcome To EasyWordleBot");
Console.WriteLine("The list of possible guesses is");
var ValidGuesses = new EasyWordleBot();

Console.WriteLine(ValidGuesses.GetRemainingWords().Count);
Console.WriteLine("What is your first guess");