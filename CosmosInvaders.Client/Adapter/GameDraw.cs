using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using CosmosInvaders.Library;
using System.Drawing.Drawing2D;
using System.Reflection;
using CosmosInvaders.Client.Proxy;
using CosmosInvaders.Client.Visitor;

namespace CosmosInvaders.Client
{
    public class GameDraw : IDraw, IDrawDecorator
    {
        public class MinimalShip
        {
            public int ShipX { get; set; }
            public int ShipY { get; set; }
            public int ShipWidth { get; set; } = 20;
            public int ShipHeight { get; set; } = 40;
            public int MaxSpeed { get; set; }
            public FlyingDirection FlyingDirection { get; set; } = FlyingDirection.Up;
        }

        public SplitContainer Canvas { get; set; }
        private List<MinimalShip> _ships { get; set; }
        protected List<MinimalShip> _tempShips { get; set; }

        public GameDraw(SplitContainer canvas)
        {
            Canvas = canvas;
        }

        public void DrawShips(List<Ship> ships)
        {
            _ships = ships
                .Select(x => new MinimalShip
                {
                    ShipX = x.CoordinateX,
                    ShipY = x.CoordinateY,
                    MaxSpeed = x.MaxSpeed,
                    FlyingDirection = x.CurrentDirection,
                    ShipHeight = x.CurrentDirection == FlyingDirection.Up || x.CurrentDirection == FlyingDirection.Down ? 40 : 20,
                    ShipWidth = x.CurrentDirection == FlyingDirection.Up || x.CurrentDirection == FlyingDirection.Down ? 20 : 40,
                }).ToList();

            _tempShips = new List<MinimalShip>();

            foreach (MinimalShip v in _ships)
            {
                _tempShips.Add(v);
            }

            IDrawDecorator drawDecorator = new CannonDecorator(this, _tempShips);
            var a = new PaintEventHandler(drawDecorator.DrawShip);
            Canvas.Panel1.Paint += a;

            Canvas.Panel1.Invalidate();

            Canvas.Panel1.Invalidated += (c, b) => { Canvas.Panel1.Paint -= a; };

            //var a = new PaintEventHandler(DrawCar);
        }

        public void DrawShip(object sender, PaintEventArgs e)
        {
            var p = sender as Panel;
            var g = e.Graphics;

            foreach (var v in _tempShips)
            {
                g.DrawImage(
                        GetShipByType(v.MaxSpeed, v.FlyingDirection),
                        v.ShipX,
                        v.ShipY,
                        v.ShipWidth,
                        v.ShipHeight
                    );
            }
        }

        public Bitmap GetShipByType(int maxSpeed, FlyingDirection direction)
        {
            switch (maxSpeed)
            {
                case 50:
                    IShipType smallShipType = new Visitor.Rangers.SmallShip();
                    return smallShipType.Display(new ShipTypeDisplayVisitor(), direction);

                case 30:
                    IShipType mediumShipType = new Visitor.Destroyers.MediumShip();
                    return mediumShipType.Display(new ShipTypeDisplayVisitor(), direction);

                case 20:
                    IShipType bigShipType = new Visitor.Destroyers.BigShip();
                    return bigShipType.Display(new ShipTypeDisplayVisitor(), direction);
            }
            return null;
        }
    }
}