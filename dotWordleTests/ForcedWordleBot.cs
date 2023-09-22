using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotWordleTests
{
    internal class ForcedWordleBot:EasyWordleBot
    {
        internal ForcedWordleBot(string word)
        {
            _word = new Word(word);
        }
    }
}
