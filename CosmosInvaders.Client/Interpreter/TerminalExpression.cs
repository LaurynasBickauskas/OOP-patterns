using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CosmosInvaders.Client.Iterator;

namespace CosmosInvaders.Client.Interpreter
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
