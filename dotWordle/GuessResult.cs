using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotWordle
{
    public class GuessResult
    {
        public bool isValidGuess { get; set; }
        public List<char> Greens { get; set; } = new List<char>{ '0', '0', '0', '0', '0' };
        public Dictionary<char, int> Yellows = new Dictionary<char, int>();
    }


}
