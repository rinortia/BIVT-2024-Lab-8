using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_8
{
    public class LetterStat
    {
        public char Letter { get; set; }
        public double Percentage { get; set; }

        public LetterStat(char letter, double percentage)
        {
            Letter = letter;
            Percentage = percentage;
        }
    }

    public class Blue_3 : Blue
    {
        private LetterStat[] _output;

        public LetterStat[] Output => _output?.ToArray();

        public Blue_3(string input) : base(input)
        {
            _output = null;
        }

        public override void Review()
        {
            if (string.IsNullOrEmpty(Input))
            {
                _output = new LetterStat[0];
                return;
            }
                        
            char[] separators = { ' ', '.', '!', '?', ',', ':', '\"', ';', '–', '(', ')', '[', ']', '{', '}', '/' };
            var words = Input
                .Split(separators, StringSplitOptions.RemoveEmptyEntries)
                .Where(w => w.Length > 0 && char.IsLetter(w[0])) 
                .ToArray();

            if (words.Length == 0)
            {
                _output = new LetterStat[0];
                return;
            }
                        
            char[] letters = new char[words.Length];
            int[] counts = new int[words.Length];
            int uniqueCount = 0;
                        
            foreach (var w in words)
            {
                char c = char.ToLower(w[0]);
                int idx = -1;
                for (int i = 0; i < uniqueCount; i++)
                    if (letters[i] == c) { idx = i; break; }

                if (idx >= 0)
                    counts[idx]++;
                else
                {
                    letters[uniqueCount] = c;
                    counts[uniqueCount] = 1;
                    uniqueCount++;
                }
            }
            
            _output = Enumerable
                .Range(0, uniqueCount)
                .Select(i => new LetterStat(
                    letters[i],
                    counts[i] * 100.0 / words.Length
                ))
                .OrderByDescending(s => s.Percentage)
                .ThenBy(s => s.Letter)
                .ToArray();
        }

        public override string ToString()
        {
            if (_output == null || _output.Length == 0)
                return string.Empty;

            return string.Join(Environment.NewLine,
                _output.Select(s =>
                    $"{s.Letter} - {Math.Round(s.Percentage, 4):F4}"
                      .Replace('.', ',')
                ));
        }
    }
}
