using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CosmosInvaders.Client
{
    interface IDrawDecorator
    {
        void DrawShip(object sender, PaintEventArgs e);
    }
}
