using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosmosInvaders.Client.Iterator
{
    interface IContainer
    {
        IIterator getIterator();
    }
}
