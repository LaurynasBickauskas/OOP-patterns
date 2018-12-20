using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Racing2D.Client
{
    interface IDrawDecorator
    {
        void DrawCar(object sender, PaintEventArgs e);
    }
}
