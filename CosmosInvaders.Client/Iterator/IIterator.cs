using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosmosInvaders.Client.Iterator
{
    public interface IIterator
    {
        Boolean HasNext();
        IIterator Next();
        string ToString();
    }
}
