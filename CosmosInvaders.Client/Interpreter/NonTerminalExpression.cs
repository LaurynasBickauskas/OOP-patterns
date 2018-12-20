using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CosmosInvaders.Client.Iterator;


namespace CosmosInvaders.Client.Interpreter
{
    class NonTerminalExpression : Expression, IIterator
    {
        public delegate void ResetDelegate(string playername);
        public event ResetDelegate Reset;
        public delegate string GetNameDelegate(int position);
        public event GetNameDelegate GetName;
        string s;
        Stack<Expression> args;
        public NonTerminalExpression(string command)
        {
            args = new Stack<Expression>();
            s = command;
        }
        public void add(Expression exp)
        {
            args.Push(exp);
        }
        public string Interpret()
        {
            if (s.ToLower().Equals("/reset"))
            {
                if (args.Count >= 1)
                {
                    Expression argument = args.Pop();
                    return CallReset(argument.Interpret());
                }
                return CallReset("%default%");
            }  else if (s.ToLower().Equals("/getname"))
            {
                Expression argument = args.Pop();
                int parseResult;
                if (int.TryParse(argument.Interpret(), out parseResult))
                    return CallGetName(parseResult);
            }
            return "ERROR : commandUnhandled";
        }
        public override string ToString()
        {
            return "NT_exp commandValue = " + s + " ,\n         argumentCount = " + args.Count +" \n";
        }
        private string CallReset(string name)
        {
            Reset(name);
            return "reset Done";
        }
        private string CallGetName(int position)
        {
            return GetName(position);
        }

        public Boolean HasNext()
        {
            return args.Count >=1;
        }
        public IIterator Next()
        {
            Expression exp = args.Pop();
            args.Push(exp);
            return (IIterator)exp;
        }
    }
        
}
