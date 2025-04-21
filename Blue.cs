using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_8
{
    public abstract class Blue
    {
        private string _input;
        
        public string Input => _input;        

        public Blue(string Input)
        {
            _input = Input;
        }
        public abstract void Review();
        

    }
}
