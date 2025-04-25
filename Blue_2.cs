using System;
using System.Text;

namespace Lab_8
{
    public class Blue_2 : Blue
    {
        private string _sequenceToRemove;
        private string _output;

        public string Output => _output;

        public Blue_2(string input, string sequenceToRemove) : base(input)
        {
            _sequenceToRemove = sequenceToRemove ?? "";
            _output = null;
        }

        public override void Review()
        {
            if (string.IsNullOrEmpty(Input) || string.IsNullOrEmpty(_sequenceToRemove))
            {
                _output = string.Empty;
                return;
            }

            var words = Input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var result = new StringBuilder();

            foreach (var word in words)
            {
                var low = word.ToLower();
                var seq = _sequenceToRemove.ToLower();

                if (!low.Contains(seq))
                {                    
                    if (result.Length > 0) result.Append(" ");
                    result.Append(word);
                }
                else
                {                    
                    if (word.Length > 0 && char.IsPunctuation(word[0]))
                    {
                        if (result.Length > 0) result.Append(" ");
                        result.Append(word[0]);
                    }
                    if (word.Length > 1 && char.IsPunctuation(word[word.Length - 2]))
                    {
                        result.Append(word[word.Length - 2]);
                    }
                    if (word.Length > 0 && char.IsPunctuation(word[word.Length - 1]))
                    {
                        result.Append(word[word.Length - 1]);
                    }
                }
            }

            _output = result.ToString().Trim();
        }

        public override string ToString()
        {
            return _output ?? string.Empty;
        }
    }
}
