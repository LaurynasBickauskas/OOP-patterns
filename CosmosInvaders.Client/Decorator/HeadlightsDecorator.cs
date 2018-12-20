using CosmosInvaders.Client.Proxy;
using CosmosInvaders.Library;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static CosmosInvaders.Client.GameDraw;

namespace CosmosInvaders.Client
{
    internal class CannonDecorator : DrawDecorator
    {
        public IImage Cannon { get; set; }

        public CannonDecorator(IDrawDecorator drawing, List<MinimalShip> _tempShips) : base(drawing, _tempShips)
        {
            Cannon = ProxyImageFactory.GetProxyImage(@"..\..\headlights.png");
        }

        public override void DrawCar(object sender, PaintEventArgs e)
        {
            base.DrawCar(sender, e);
            var g = e.Graphics;

            foreach (var v in _tempShips)
            {
                g.DrawImage(Cannon.GetImage(),
                        v.ShipX,
                        v.ShipY,
                        v.ShipWidth,
                        v.ShipHeight);
            }
        }
    }
}