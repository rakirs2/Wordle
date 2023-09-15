using CsvHelper.Configuration;
using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotWordle
{
    internal class EasyWordleBot:IWordleBot
    {
        private readonly List<Word> _remainingValues = new();
        private readonly Word _word;
        private readonly bool _hasWon = false;
        readonly Random _random = new();
        private uint _guessNumber = 1;

        internal EasyWordleBot()
        {
            GenerateStartingListOfWords();
            _word = _remainingValues[_random.Next(_remainingValues.Count)];
        }

        public bool IsValidGuess(string guess)
        {
            return true;
        }

        public GuessResult GuessWord(string guess)
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
            { _remainingValues.Add(word); }
        }

        public bool HasWon()
        {
            return _hasWon;
        }

        public uint GuessesRemaining()
        {
            return Constants.TotalNumberOfGuesses - _guessNumber;
        }

    }
}
