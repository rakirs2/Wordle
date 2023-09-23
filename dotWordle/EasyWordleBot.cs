﻿using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;

namespace dotWordle;

internal class EasyWordleBot : IWordleBot
{
    private const bool _hasWon = false;
    private readonly Random _random = new();
    private readonly List<Word> _remainingValues = new();
    private uint _guessNumber = 1;
    protected Word _word;

    internal EasyWordleBot()
    {
        GenerateStartingListOfWords();
        _word = _remainingValues[_random.Next(_remainingValues.Count)];
    }

    public GuessResult GuessWord(string guess)
    {
        if (IsValidGuess(guess))
        {
            return GenerateValidGuessResult();
        }

        return GenerateInvalidGuessResult();
    }

    public uint GetGuessNumber()
    {
        return _guessNumber;
    }

    public List<Word> GetRemainingWords()
    {
        return _remainingValues.ToList();
    }

    public bool HasWon()
    {
        return _hasWon;
    }

    public uint GetGuessesRemaining()
    {
        // adding one because we're starting at guess 1
        return Constants.TotalNumberOfGuesses - _guessNumber + 1;
    }

    private GuessResult GenerateValidGuessResult()
    {
        _guessNumber++;
        return new GuessResult(new Dictionary<char, int>(), true, Constants.DefaultGreens, _guessNumber);
    }

    private GuessResult GenerateInvalidGuessResult()
    {
        return new GuessResult(new Dictionary<char, int>(), false, new List<char>(), GetGuessNumber());
    }

    protected bool IsValidGuess(string guess)
    {
        if (GetGuessesRemaining() <= 0)
        {
            return false;
        }

        var Words = GetRemainingWords();
        foreach (var word in Words)
        {
            if (word.Value.Equals(guess))
            {
                return Verifiers.VerifyFiveChars(guess);
            }
        }

        return false;
    }

    private void GenerateStartingListOfWords()
    {
        var config = new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            HasHeaderRecord = false
        };
        // TODO fix this so we use relative paths
        using var reader = new StreamReader("C:\\Users\\srmylavarapu\\github\\Wordle\\dotWordle\\valid_guesses.csv");
        using var csv = new CsvReader(reader, config);
        var words = csv.GetRecords<Word>();
        foreach (var word in words)
        {
            _remainingValues.Add(word);
        }

        using var reader2 = new StreamReader("C:\\Users\\srmylavarapu\\github\\Wordle\\dotWordle\\valid_answers.csv");
        using var csv2 = new CsvReader(reader2, config);
        var words2 = csv2.GetRecords<Word>();
        foreach (var word in words2)
        {
            _remainingValues.Add(word);
        }
    }
}