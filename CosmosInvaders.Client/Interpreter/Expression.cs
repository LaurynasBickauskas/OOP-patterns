using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Racing2D.Client.Interpreter
{
    interface Expression
    {
        string Interpret();
        string ToString();
    }
}
