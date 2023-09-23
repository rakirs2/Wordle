using System.Globalization;
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
    private List<char> greens = new List<char>{'0', '0', '0', '0', '0'};
    private Dictionary<char, int> yellows = new Dictionary<char, int>();
    internal EasyWordleBot()
    {
        GenerateStartingListOfWords();
        _word = _remainingValues[_random.Next(_remainingValues.Count)];
    }

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

    public bool HasWon()
    {
        return _hasWon;
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
        return new GuessResult(yellows, true, greens, _guessNumber);
    }

    private void CalculateGreens(string guess)
    {
        for (int i = 0; i < guess.Length; i++)
        {
            if (guess[i] == _word.Value[i])
            {
                greens[i] = guess[i];
            }
        }   
    }

    private void CalculateYellows(string guess)
    {
        //reset yellows
        yellows = new Dictionary<char, int>();
        var tempMap = new Dictionary<char, int>();

        // get the non greened letters
        for (int i = 0; i < _word.Value.Length; i++)
        {
            if (greens[i] == '0')
            {
                if (tempMap.ContainsKey(_word.Value[i]))
                {
                    tempMap[_word.Value[i]]++;
                }
                else
                {
                    tempMap.Add(_word.Value[i], 1);
                }
            }
        }

        for (int i = 0; i < guess.Length; i++)
        {
            if (greens[i] != 0)
            {
                if (tempMap.ContainsKey(guess[i]) && tempMap[guess[i]]>0)
                {
                    tempMap[_word.Value[i]]--;
                    if (yellows.ContainsKey(guess[i]))
                    {
                        yellows[guess[i]]++;
                    }
                    else
                    {
                        yellows.Add(guess[i], 1);
                    }
                }
            }
        }


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