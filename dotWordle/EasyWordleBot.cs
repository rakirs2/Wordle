using System.Globalization;
using System.Reflection;
using CsvHelper;
using CsvHelper.Configuration;

namespace dotWordle;

internal class EasyWordleBot : IWordleBot
{
    private readonly List<char> _greens = ['0', '0', '0', '0', '0'];
    // private readonly List<Word> _likelyWords = new();
    private readonly Random _random = new();
    private readonly List<Word> _remainingWords = [];
    private readonly HashSet<char> _unusedCache = [];
    private readonly HashSet<char> _unusedList = [];
    private List<Word> _allWords = [];
    private uint _guessNumber = 1;
    private bool _isGoodGuess;
    private Dictionary<char, int> _yellows = [];
    protected Word Word;

    internal EasyWordleBot()
    {
        GenerateStartingListsOfWords();
        Word = _remainingWords[_random.Next(_remainingWords.Count)];
    }

    public bool HasWon { get; private set; }

    public bool IsValidGuess(string guess)
    {
        if (GetGuessesRemaining() <= 0)
        {
            return false;
        }

        foreach (var word in _allWords)
        {
            if (word.Value.Equals(guess))
            {
                return Verifiers.VerifyFiveChars(guess);
            }
        }

        return false;
    }

    public GuessResult GuessWord(string guess)
    {
        return GenerateGuessResult(guess);
    }

    public uint GetGuessNumber()
    {
        return _guessNumber;
    }

    public List<Word> GetAllWords()
    {
        return _allWords;
    }

    public List<Word> GetRemainingWords()
    {
        return _remainingWords;
    }

    public uint GetGuessesRemaining()
    {
        // adding one because we're starting at guess 1
        return Constants.TotalNumberOfGuesses - _guessNumber + 1;
    }

    private GuessResult GenerateGuessResult(string guess)
    {
        _guessNumber++;
        CalculateGreens(guess);
        CalculateYellows(guess);
        CalculateClears(guess);
        CalculateVictory();
        CalculateIsGoodGuess(guess);
        RecalculateValidWords(guess);
        UpdateUnusedLetters();
        return new GuessResult(_yellows, true, _greens, _guessNumber, HasWon, _isGoodGuess);
    }

    private void UpdateUnusedLetters()
    {
        foreach (var letter in _unusedCache)
        {
            _unusedList.Add(letter);
        }
    }

    private void RecalculateValidWords(string guess)
    {
        RemoveGuess(guess);
        RemoveGreens(guess);
        // TODO: remove yellows
        RemoveUnusedCharacters();
    }

    private void RemoveUnusedCharacters()
    {
        foreach (var letter in _unusedCache)
        {
            _remainingWords.RemoveAll(x => x.Yellows.ContainsKey(letter));
        }
    }

    private void RemoveGreens(string guess)
    {
        for (var i = 0; i < guess.Length; i++)
        {
            if (_greens[i] != 0)
            {
                _remainingWords.RemoveAll(x => x.Value[i] != _greens[i]);
            }
        }
    }

    private void RemoveGuess(string guess)
    {
        if (!HasWon)
        {
            _remainingWords.RemoveAll(x => x.Value.Equals(guess));
        }
    }

    private void CalculateIsGoodGuess(string guess)
    {
        _isGoodGuess = _remainingWords.Exists(x => x.Value.Equals(guess));
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

    private void CalculateClears(string guess)
    {
        for (var i = 0; i < guess.Length; i++)
        {
            if (_greens[i] != '0' && !_yellows.ContainsKey(guess[i]))
            {
                _unusedCache.Add(guess[i]);
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

    private void GenerateStartingListsOfWords()
    {
        var config = new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            HasHeaderRecord = false
        };

        var exeDir = Path.GetDirectoryName(Assembly.GetEntryAssembly()?.Location);

        if (exeDir != null)
        {
            using var reader = new StreamReader(Path.Combine(exeDir, "..", "..", "..", "..", "valid_guesses.csv"));
            using var csv = new CsvReader(reader, config);
            var words = csv.GetRecords<Word>();
            foreach (var word in words)
            {
                _remainingWords.Add(word);
            }
        }

        using var reader2 = new StreamReader(Path.Combine(exeDir!, "..", "..", "..", "..", "valid_answers.csv"));
        using var csv2 = new CsvReader(reader2, config);
        var words2 = csv2.GetRecords<Word>();
        foreach (var word in words2)
        {
            _remainingWords.Add(word);
        }

        _allWords = _remainingWords.ConvertAll(x => x);
    }
}