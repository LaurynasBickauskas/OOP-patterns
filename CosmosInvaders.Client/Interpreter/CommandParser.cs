using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CosmosInvaders.Client.Iterator;

namespace CosmosInvaders.Client.Interpreter
{
    public class CommandParser : IContainer
    {
        public delegate void ResetDelegate (string playername);
        public event ResetDelegate Reset;
        public delegate string GetNameDelegate(int playerindex);
        public event GetNameDelegate GetName;

        Stack<Expression> stack = new Stack<Expression>();
        public CommandParser() { }

        public void Parse(string chatLine)
        {
            if (Prasable(chatLine))
            {
                char[] splitters = new char[] { ' ' };
                string[] tokenList = chatLine.Split(splitters, StringSplitOptions.RemoveEmptyEntries);
                Array.Reverse(tokenList);
                foreach (string token in tokenList) {
                    if (IsTerminal(token)) {
                        Expression exp = new TerminalExpression(token);
                        
                        stack.Push(exp);
                        Console.WriteLine(string.Format("added terminal expression {0}", token));
                    } else {
                        NonTerminalExpression exp = new NonTerminalExpression(token);
                        exp.Reset += (a) => Reset(a);
                        exp.GetName += (a) => GetName(a);
                        for (int i = 0; i < stack.Count; i++)
                        {
                            exp.add(stack.Pop());
                        }
                        stack.Push(exp);                        
                    }
                }
            }
        }
        public void Execute()
        {
            stack.Pop().Interpret();
        }
        private Boolean Prasable(string chatLine)
        {
            return chatLine!= null && chatLine.Length != 2 && chatLine[0]== '/';
        }
        private Boolean IsTerminal(string token) {
            if (token != null  && token[0]=='/')
            {
                return false;
            }
            return true;

        }
        public IIterator getIterator()
        {
            NonTerminalExpression tempExp = (NonTerminalExpression)stack.Pop();
            stack.Push(tempExp);
            return (IIterator)tempExp;
        }
    }
}
