using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_8
{
    public class Blue_4 : Blue
    {
        private int _output;
        public int Output => _output;

        public Blue_4(string input) : base(input)
        {
            _output = 0;
        }

        public override void Review()
        {
            _output = 0;
            string s = Input;
            int i = 0;

            while (i < s.Length)
            {               
                int sign = 1;
                if (s[i] == '-' && i + 1 < s.Length && char.IsDigit(s[i + 1]))
                {
                    sign = -1;
                    i++;
                }
                               
                if (i < s.Length && char.IsDigit(s[i]))
                {
                    int num = 0;
                    while (i < s.Length && char.IsDigit(s[i]))
                    {
                        num = num * 10 + (s[i] - '0');
                        i++;
                    }
                    _output += sign * num;
                }
                else
                {
                    i++;
                }
            }
        }

        public override string ToString()
        {
            return _output.ToString();
        }
    }
}