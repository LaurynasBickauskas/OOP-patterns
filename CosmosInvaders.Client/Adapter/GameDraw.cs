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
using Racing2D.Library;
using System.Drawing.Drawing2D;
using System.Reflection;
using Racing2D.Client.Proxy;
using Racing2D.Client.Visitor;

namespace Racing2D.Client
{
    public class GameDraw : IDraw, IDrawDecorator
    {
        public class MinimalVehicle
        {
            public int CarX { get; set; }
            public int CarY { get; set; }
            public int CarWidth { get; set; } = 20;
            public int CarHeight { get; set; } = 40;
            public int MaxSpeed { get; set; }
            public DrivingDirection DrivingDirection { get; set; } = DrivingDirection.Up;
        }

        public SplitContainer Canvas { get; set; }
        private List<MinimalVehicle> _vehicles { get; set; }
        protected List<MinimalVehicle> _tempVehicles { get; set; }
        private IVehicleTypeVisitor BicycleVisitor = new VehicleTypeDisplayVisitor();
        private IVehicleTypeVisitor MotorbikeVisitor = new VehicleTypeDisplayVisitor();
        private IVehicleTypeVisitor QuadVisitor = new VehicleTypeDisplayVisitor();
        private IVehicleTypeVisitor JeepVisitor = new VehicleTypeDisplayVisitor();
        private IVehicleTypeVisitor RaceCarVisitor = new VehicleTypeDisplayVisitor();
        private IVehicleTypeVisitor TruckVisitor = new VehicleTypeDisplayVisitor();

        public GameDraw(SplitContainer canvas)
        {
            Canvas = canvas;
        }

        public void DrawCars(List<Vehicle> vehicles)
        {
            _vehicles = vehicles
                .Select(x => new MinimalVehicle
                {
                    CarX = x.CoordinateX,
                    CarY = x.CoordinateY,
                    MaxSpeed = x.MaxSpeed,
                    DrivingDirection = x.DrivingDirection,
                    CarHeight = x.DrivingDirection == DrivingDirection.Up || x.DrivingDirection == DrivingDirection.Down ? 40 : 20,
                    CarWidth = x.DrivingDirection == DrivingDirection.Up || x.DrivingDirection == DrivingDirection.Down ? 20 : 40,
                }).ToList();

            _tempVehicles = new List<MinimalVehicle>();

            foreach (MinimalVehicle v in _vehicles)
            {
                _tempVehicles.Add(v);
            }

            IDrawDecorator drawDecorator = new HeadlightsDecorator(this, _tempVehicles);
            var a = new PaintEventHandler(drawDecorator.DrawCar);
            Canvas.Panel1.Paint += a;

            Canvas.Panel1.Invalidate();

            Canvas.Panel1.Invalidated += (c, b) => { Canvas.Panel1.Paint -= a; };

            //var a = new PaintEventHandler(DrawCar);
        }

        public void DrawCar(object sender, PaintEventArgs e)
        {
            var p = sender as Panel;
            var g = e.Graphics;

            foreach (var v in _tempVehicles)
            {
                g.DrawImage(
                        GetVehicleByType(v.MaxSpeed, v.DrivingDirection),
                        v.CarX,
                        v.CarY,
                        v.CarWidth,
                        v.CarHeight
                    );
            }
        }

        public Bitmap GetVehicleByType(int maxSpeed, DrivingDirection direction)
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