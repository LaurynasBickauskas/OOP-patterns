using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Racing2D.Library.Controllers.Memento
{
    public class Memento
    {
        private Coordinates Coordinates; //state

        public Memento(Coordinates coordinates)
        {
            this.Coordinates = coordinates;
        }

        public Coordinates getState()
        {
            return Coordinates;
        }
    }
}
