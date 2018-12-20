using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Racing2D.Client.Iterator;

namespace Racing2D.Client.Interpreter
{
    class TerminalExpression : Expression, IIterator
    {
        string s;
        public TerminalExpression(string command)
        {
            s = command;
        }
        public Boolean HasNext()
        {
            return false;
        }
        public IIterator Next()
        {
            return null;
        }
        public string Interpret()
        {
            return s;
        }
        public override string ToString()
        {
            return "T_exp , Value = " + s + "\n";
        }

    }
        
}
