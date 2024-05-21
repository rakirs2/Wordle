using dotWordle;

Console.WriteLine("Hello, Welcome To EasyWordleBot");
Console.WriteLine("The list of possible guesses is");
var wordleConsole = new WordleConsole();
var validGuesses = new EasyWordleBot();

while (validGuesses.GetGuessesRemaining() > 0)
{
    Console.WriteLine($"You have {validGuesses.GetGuessesRemaining()} guesses remaining");
    Console.WriteLine(validGuesses.GetAllWords().Count);

    Console.WriteLine("What is your first guess");
    var guess = Console.ReadLine();

    while (guess!= null &&!validGuesses.IsValidGuess(guess))
    {
        Console.WriteLine("Please guess again");
        guess = Console.ReadLine();
    }

    if (guess!= null)
    {
        var guessResult = validGuesses.GuessWord(guess);

        Console.WriteLine(guessResult);
    }
 
    
}

