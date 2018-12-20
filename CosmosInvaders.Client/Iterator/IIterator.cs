using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Racing2D.Client.Iterator
{
    public interface IIterator
    {
        Boolean HasNext();
        IIterator Next();
        string ToString();
    }
}
