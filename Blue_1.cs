using System;

namespace Lab_8
{
    public class Blue_1 : Blue
    {
        private string[] _output;
        private const int maxLength = 50;

        public string[] Output => _output;

        public Blue_1(string input) : base(input)
        {
            _output = null;
        }

        public override void Review()
        {
            if (string.IsNullOrEmpty(Input))
            {
                _output = null;
                return;
            }

            string[] words = Input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            if (words.Length == 0)
            {
                _output = null;
                return;
            }

            string[] tempLines = new string[words.Length];
            int lineCount = 0;
            string currentLine = words[0];

            for (int i = 1; i < words.Length; i++)
            {
                string word = words[i];

                if (currentLine.Length + 1 + word.Length <= maxLength)
                {
                    currentLine += " " + word;
                }
                else
                {
                    tempLines[lineCount++] = currentLine;
                    currentLine = word;
                }
            }

            if (!string.IsNullOrEmpty(currentLine))
            {
                tempLines[lineCount++] = currentLine;
            }

            _output = new string[lineCount];
            Array.Copy(tempLines, _output, lineCount);
        }

        public override string ToString()
        {
            if (_output == null || _output.Length == 0)
            {
                return "";
            }

            return string.Join(Environment.NewLine, _output);
        }
    }
}

