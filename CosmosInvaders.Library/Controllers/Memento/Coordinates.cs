using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Racing2D.Library.Controllers.Memento
{
    public class Coordinates
    {
        public int CoordinateX { get; set; }
        public int CoordinateY { get; set; }

        public Coordinates(int x, int y)
        {
            CoordinateX = x;
            CoordinateY = y;
        }
    }
}
