using System.Drawing;
using CosmosInvaders.Client.Proxy;
using CosmosInvaders.Library;

namespace CosmosInvaders.Client.Visitor
{
    public class VehicleTypeDisplayVisitor : IVehicleTypeVisitor
    {
        private IImage VehicleL;
        private IImage VehicleB;
        private IImage VehicleR;
        private IImage VehicleF;

        public Bitmap Visit(Bikes.Bicycle bicycle, DrivingDirection direction)
        {
            VehicleL = ProxyImageFactory.GetProxyImage(@"..\..\Images\bicycleL.png");
            VehicleB = ProxyImageFactory.GetProxyImage(@"..\..\Images\bicycleB.png");
            VehicleF = ProxyImageFactory.GetProxyImage(@"..\..\Images\bicycleF.png");
            VehicleR = ProxyImageFactory.GetProxyImage(@"..\..\Images\bicycleR.png");

            return DirectionSwitcher(direction);
        }

        public Bitmap Visit(Bikes.Motorbike motorbike, DrivingDirection direction)
        {
            VehicleL = ProxyImageFactory.GetProxyImage(@"..\..\Images\motorbikeL.png");
            VehicleB = ProxyImageFactory.GetProxyImage(@"..\..\Images\motorbikeB.png");
            VehicleF = ProxyImageFactory.GetProxyImage(@"..\..\Images\motorbikeF.png");
            VehicleR = ProxyImageFactory.GetProxyImage(@"..\..\Images\motorbikeR.png");

            return DirectionSwitcher(direction);
        }

        public Bitmap Visit(Bikes.Quad quad, DrivingDirection direction)
        {
            VehicleL = ProxyImageFactory.GetProxyImage(@"..\..\Images\quadL.png");
            VehicleB = ProxyImageFactory.GetProxyImage(@"..\..\Images\quadB.png");
            VehicleF = ProxyImageFactory.GetProxyImage(@"..\..\Images\quadF.png");
            VehicleR = ProxyImageFactory.GetProxyImage(@"..\..\Images\quadR.png");

            return DirectionSwitcher(direction);
        }

        public Bitmap Visit(Cars.Jeep jeep, DrivingDirection direction)
        {
            VehicleL = ProxyImageFactory.GetProxyImage(@"..\..\Images\jeepL.png");
            VehicleB = ProxyImageFactory.GetProxyImage(@"..\..\Images\jeepB.png");
            VehicleF = ProxyImageFactory.GetProxyImage(@"..\..\Images\jeepF.png");
            VehicleR = ProxyImageFactory.GetProxyImage(@"..\..\Images\jeepR.png");

            return DirectionSwitcher(direction);
        }

        public Bitmap Visit(Cars.RaceCar careCar, DrivingDirection direction)
        {
            VehicleL = ProxyImageFactory.GetProxyImage(@"..\..\Images\carL.png");
            VehicleB = ProxyImageFactory.GetProxyImage(@"..\..\Images\carB.png");
            VehicleF = ProxyImageFactory.GetProxyImage(@"..\..\Images\carF.png");
            VehicleR = ProxyImageFactory.GetProxyImage(@"..\..\Images\carR.png");

            return DirectionSwitcher(direction);
        }

        public Bitmap Visit(Cars.Truck truck, DrivingDirection direction)
        {
            VehicleL = ProxyImageFactory.GetProxyImage(@"..\..\Images\truckL.png");
            VehicleB = ProxyImageFactory.GetProxyImage(@"..\..\Images\truckB.png");
            VehicleF = ProxyImageFactory.GetProxyImage(@"..\..\Images\truckF.png");
            VehicleR = ProxyImageFactory.GetProxyImage(@"..\..\Images\truckR.png");

            return DirectionSwitcher(direction);
        }

        private Bitmap DirectionSwitcher(DrivingDirection direction)
        {
            switch (direction)
            {
                case DrivingDirection.Left:
                    return VehicleL.GetImage();

                case DrivingDirection.Up:
                    return VehicleF.GetImage();

                case DrivingDirection.Right:
                    return VehicleR.GetImage();

                case DrivingDirection.Down:
                    return VehicleB.GetImage();

                default:
                    return null;
            }
        }
    }
}