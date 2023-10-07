﻿using System.Globalization;
using System.Reflection;
using CsvHelper;
using CsvHelper.Configuration;

namespace dotWordle;

internal class EasyWordleBot : IWordleBot
{
    private readonly List<char> _greens = new() { '0', '0', '0', '0', '0' };
    private readonly Random _random = new();
    private readonly List<Word> _remainingValues = new();
    private uint _guessNumber = 1;
    private bool _isGoodGuess;
    private Dictionary<char, int> _yellows = new();
    protected Word Word;

    internal EasyWordleBot()
    {
        GenerateStartingListOfWords();
        Word = _remainingValues[_random.Next(_remainingValues.Count)];
    }

    public bool HasWon { get; private set; }

    public GuessResult GuessWord(string guess)
    {
        if (IsValidGuess(guess))
        {
            return GenerateValidGuessResult(guess);
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

    public uint GetGuessesRemaining()
    {
        // adding one because we're starting at guess 1
        return Constants.TotalNumberOfGuesses - _guessNumber + 1;
    }

    private GuessResult GenerateValidGuessResult(string guess)
    {
        _guessNumber++;
        CalculateGreens(guess);
        CalculateYellows(guess);
        CalculateVictory();
        CalculateIsGoodGuess(guess);
        RecalculateValidWords(guess);
        return new GuessResult(_yellows, true, _greens, _guessNumber, HasWon, _isGoodGuess);
    }

    private void RecalculateValidWords(string guess)
    {
        // TODO create method
        // remove greens
        if (!HasWon)
        {
            _remainingValues.RemoveAll(x => x.Value == guess);
        }

        for (var i = 0; i < guess.Length; i++)
        {
            if (_greens[i] != 0)
            {
                _remainingValues.RemoveAll(x => x.Value[i] != _greens[i]);
            }
        }
        // remove yellows
    }

    private void CalculateIsGoodGuess(string guess)
    {
        _isGoodGuess = _remainingValues.Find(x => x.Value == guess) != null;
    }

    private void CalculateVictory()
    {
        foreach (var character in _greens)
        {
            if (character == '0')
            {
                HasWon = false;
                return;
            }
        }

        HasWon = true;
    }

    private void CalculateGreens(string guess)
    {
        for (var i = 0; i < guess.Length; i++)
        {
            if (guess[i] == Word.Value[i])
            {
                _greens[i] = guess[i];
            }
        }
    }

    private void CalculateYellows(string guess)
    {
        //reset yellows
        _yellows = new Dictionary<char, int>();
        var tempMap = new Dictionary<char, int>();

        // get the non greened letters
        for (var i = 0; i < Word.Value.Length; i++)
        {
            if (_greens[i] == '0')
            {
                if (tempMap.ContainsKey(Word.Value[i]))
                {
                    tempMap[Word.Value[i]]++;
                }
                else
                {
                    tempMap.Add(Word.Value[i], 1);
                }
            }
        }

        for (var i = 0; i < guess.Length; i++)
        {
            if (_greens[i] != 0)
            {
                if (tempMap.ContainsKey(guess[i]))
                {
                    tempMap[guess[i]]--;
                    if (tempMap[guess[i]] == 0)
                    {
                        tempMap.Remove(guess[i]);
                    }

                    if (_yellows.ContainsKey(guess[i]))
                    {
                        _yellows[guess[i]]++;
                    }
                    else
                    {
                        _yellows.Add(guess[i], 1);
                    }
                }
            }
        }
    }

    private GuessResult GenerateInvalidGuessResult()
    {
        return new GuessResult(
            new Dictionary<char, int>(),
            false,
            new List<char>(),
            _guessNumber,
            HasWon,
            _isGoodGuess);
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

        var exeDir = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);

        using var reader = new StreamReader(Path.Combine(exeDir, "..", "..", "..", "..", "valid_guesses.csv"));
        using var csv = new CsvReader(reader, config);
        var words = csv.GetRecords<Word>();
        foreach (var word in words)
        {
            _remainingValues.Add(word);
        }

        using var reader2 = new StreamReader(Path.Combine(exeDir, "..", "..", "..", "..", "valid_answers.csv"));
        using var csv2 = new CsvReader(reader2, config);
        var words2 = csv2.GetRecords<Word>();
        foreach (var word in words2)
        {
            _remainingValues.Add(word);
        }
    }
}