using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Racing2D.Library.Controllers.Memento
{
    public class CareTaker
    {
        private ArrayList mementoList = new ArrayList();

        public void add(Memento state)
        {
            mementoList.Add(state);
        }

        public Memento get(int index)
        {
            return (Memento)mementoList[index];
        }

        public Memento getLast()
        {
            return (Memento)mementoList[mementoList.Count - 1];
        }
    }
}
