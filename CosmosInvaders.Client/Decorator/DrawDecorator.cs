using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Racing2D.Library;
using static Racing2D.Client.GameDraw;

namespace Racing2D.Client
{
    internal abstract class DrawDecorator : IDrawDecorator
    {
        protected IDrawDecorator drawing;
        protected List<MinimalVehicle> _tempVehicles;

        protected DrawDecorator(IDrawDecorator drawing, List<MinimalVehicle> _tempVehicles)
        {
            this.drawing = drawing;
            this._tempVehicles = _tempVehicles;
        }

        public virtual void DrawCar(object sender, PaintEventArgs e)
        {
            drawing.DrawCar(sender, e);
        }
    }
}