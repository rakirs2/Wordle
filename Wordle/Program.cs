// See https://aka.ms/new-console-template for more information

using Wordle;

IGame Game = new WordleGame();
var Cli = new Cli(Game);


var c = '\u2713';

Console.WriteLine(c);