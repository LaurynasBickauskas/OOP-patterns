﻿using CosmosInvaders.Client.Proxy;
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
    internal class HeadlightsDecorator : DrawDecorator
    {
        public IImage HeadLight { get; set; }

        public HeadlightsDecorator(IDrawDecorator drawing, List<MinimalVehicle> _tempVehicles) : base(drawing, _tempVehicles)
        {
            HeadLight = ProxyImageFactory.GetProxyImage(@"..\..\headlights.png");
        }

        public override void DrawCar(object sender, PaintEventArgs e)
        {
            base.DrawCar(sender, e);
            var g = e.Graphics;

            foreach (var v in _tempVehicles)
            {
                g.DrawImage(HeadLight.GetImage(),
                        v.CarX,
                        v.CarY,
                        v.CarWidth,
                        v.CarHeight);
            }
        }
    }
}