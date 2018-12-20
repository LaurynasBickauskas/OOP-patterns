using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosmosInvaders.Library.Controllers.Memento
{
    public class Originator
    {
        private Coordinates Coordinates;

        public void setState(Coordinates state)
        {
            this.Coordinates = state;
        }

        public Coordinates getState()
        {
            return Coordinates;
        }

        public Memento saveStateToMemento()
        {
            return new Memento(Coordinates);
        }

        public void getStateFromMemento(Memento memento)
        {
            Coordinates = memento.getState();
        }
    }
}
