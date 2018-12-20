using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Racing2D.Client.Iterator
{
    interface IContainer
    {
        IIterator getIterator();
    }
}
