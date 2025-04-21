using System;
using System.Collections.Generic;


namespace Lab_8
{
    public class Blue_2 : Blue
    {
        private string _output;
        private readonly string _sequenceToRemove;

        public string Output => _output;
               
        public Blue_2(string input, string sequenceToRemove) : base(input)
        {
            _sequenceToRemove = sequenceToRemove ?? "";
            _output = string.Empty;
        }
        
        public override void Review()
        {
            if (string.IsNullOrEmpty(Input))
            {
                _output = string.Empty;
                return;
            }

            var words = Input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var filteredWords = new List<string>();

            foreach (var word in words)
            {               
                if (!word.Contains(_sequenceToRemove))
                {
                    filteredWords.Add(word);
                }
            }
            
            _output = string.Join(" ", filteredWords).Trim();
        }
        
        public override string ToString()
        {
            return _output ?? string.Empty;
        }
    }
  }
