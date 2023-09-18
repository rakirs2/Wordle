using CsvHelper.Configuration.Attributes;

namespace dotWordle;

internal class Word
{
    // ReSharper disable once UnusedMember.Global
    // This is used by the CSV reader
    internal Word()
    {
    }

    internal Word(string word)
    {
        Value = word;
    }

    [Index(0)] public string Value { get; set; }

    public bool IsValidWord(string word)
    {
        // TODO fix
        return true;
    }
}