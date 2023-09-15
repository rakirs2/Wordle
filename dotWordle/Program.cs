// See https://aka.ms/new-console-template for more information

using dotWordle;

Console.WriteLine("Hello, Welcome To WordleBot");
Console.WriteLine("The list of possible guesses is");
var ValidGuesses = new ValidGuesses();
Console.WriteLine(ValidGuesses.GetRemainingWords().Count);
Console.WriteLine("What is your first guess");