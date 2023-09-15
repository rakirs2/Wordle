using System;
using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;

namespace dotWordle;

internal class ValidGuesses : IWordleBot
{
    private readonly List<Word> _remainingValues = new();
    private readonly Word _word;
    readonly Random _random = new();
    private uint _guessNumber = 1;

    internal ValidGuesses()
    {
        GenerateStartingListOfWords();
        _word = _remainingValues[_random.Next(_remainingValues.Count)];
    }

    public bool IsValidGuess(string guess)
    {
        return _remainingValues.Contains(new Word(guess));
    }

    public bool GuessWord(string guess)
    {
        _guessNumber++;
        throw new NotImplementedException();
    }

    public uint GuessNumber()
    {
        return _guessNumber;
    }

    public List<Word> GetRemainingWords()
    {
        return _remainingValues.ToList();
    }

    private void GenerateStartingListOfWords()
    {
        var config = new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            HasHeaderRecord = false
        };
        using var reader = new StreamReader("../../../valid_guesses.csv");
        using var csv = new CsvReader(reader, config);
        var words = csv.GetRecords<Word>();
        foreach (var word in words)
        { _remainingValues.Add(word);}
    }
}