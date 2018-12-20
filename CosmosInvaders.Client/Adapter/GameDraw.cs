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
            public DrivingDirection DrivingDirection { get; set; } = DrivingDirection.Up;
        }

        public SplitContainer Canvas { get; set; }
        private List<MinimalShip> _ships { get; set; }
        protected List<MinimalShip> _tempShips { get; set; }

        public GameDraw(SplitContainer canvas)
        {
            Canvas = canvas;
        }

        public void DrawShips(List<Vehicle> ships)
        {
            _ships = ships
                .Select(x => new MinimalShip
                {
                    ShipX = x.CoordinateX,
                    ShipY = x.CoordinateY,
                    MaxSpeed = x.MaxSpeed,
                    DrivingDirection = x.DrivingDirection,
                    ShipHeight = x.DrivingDirection == DrivingDirection.Up || x.DrivingDirection == DrivingDirection.Down ? 40 : 20,
                    ShipWidth = x.DrivingDirection == DrivingDirection.Up || x.DrivingDirection == DrivingDirection.Down ? 20 : 40,
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
                        GetShipByType(v.MaxSpeed, v.DrivingDirection),
                        v.ShipX,
                        v.ShipY,
                        v.ShipWidth,
                        v.ShipHeight
                    );
            }
        }

        public Bitmap GetShipByType(int maxSpeed, DrivingDirection direction)
        {
            switch (maxSpeed)
            {
                case 10:
                    IVehicleType bicycleType = new Visitor.Bikes.Bicycle();
                    return bicycleType.Display(new VehicleTypeDisplayVisitor(), direction);

                case 20:
                    IVehicleType motorbikeType = new Visitor.Bikes.Motorbike();
                    return motorbikeType.Display(new VehicleTypeDisplayVisitor(), direction);

                case 30:
                    IVehicleType quadType = new Visitor.Bikes.Quad();
                    return quadType.Display(new VehicleTypeDisplayVisitor(), direction);

                case 40:
                    IVehicleType truckType = new Visitor.Cars.Truck();
                    return truckType.Display(new VehicleTypeDisplayVisitor(), direction);

                case 50:
                    IVehicleType jeepType = new Visitor.Cars.Jeep();
                    return jeepType.Display(new VehicleTypeDisplayVisitor(), direction);

                case 60:
                    IVehicleType raceCarType = new Visitor.Cars.RaceCar();
                    return raceCarType.Display(new VehicleTypeDisplayVisitor(), direction);
            }
            return null;
        }
    }
}