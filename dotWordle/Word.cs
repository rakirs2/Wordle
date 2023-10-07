using CsvHelper.Configuration.Attributes;

namespace dotWordle;

internal class Word
{
    private readonly Dictionary<char, int> Yellows = new();

    // ReSharper disable once UnusedMember.Global
    // This is used by the CSV reader
    internal Word()
    {
        CreateYellows("empty");
    }

    internal Word(string word)
    {
        Value = word;
        CreateYellows(word);
    }

    [Index(0)] public string Value { get; set; }

    private void CreateYellows(string word)
    {
        foreach (var letter in word)
        {
            if (Yellows.ContainsKey(letter))
            {
                Yellows[letter]++;
            }
            else
            {
                Yellows.Add(letter, 1);
            }
        }
    }
}