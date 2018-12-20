using System.Drawing;
using CosmosInvaders.Client.Proxy;
using CosmosInvaders.Library;

namespace CosmosInvaders.Client.Visitor
{
    public class ShipTypeDisplayVisitor : IShipTypeVisitor
    {
        private IImage ShipL;
        private IImage ShipB;
        private IImage ShipR;
        private IImage ShipF;

        public Bitmap Visit(Bikes.Bicycle bicycle, FlyingDirection direction)
        {
            ShipL = ProxyImageFactory.GetProxyImage(@"..\..\Images\bicycleL.png");
            ShipB = ProxyImageFactory.GetProxyImage(@"..\..\Images\bicycleB.png");
            ShipF = ProxyImageFactory.GetProxyImage(@"..\..\Images\bicycleF.png");
            ShipR = ProxyImageFactory.GetProxyImage(@"..\..\Images\bicycleR.png");

            return DirectionSwitcher(direction);
        }

        public Bitmap Visit(Bikes.Motorbike motorbike, FlyingDirection direction)
        {
            ShipL = ProxyImageFactory.GetProxyImage(@"..\..\Images\motorbikeL.png");
            ShipB = ProxyImageFactory.GetProxyImage(@"..\..\Images\motorbikeB.png");
            ShipF = ProxyImageFactory.GetProxyImage(@"..\..\Images\motorbikeF.png");
            ShipR = ProxyImageFactory.GetProxyImage(@"..\..\Images\motorbikeR.png");

            return DirectionSwitcher(direction);
        }

        public Bitmap Visit(Bikes.Quad quad, FlyingDirection direction)
        {
            ShipL = ProxyImageFactory.GetProxyImage(@"..\..\Images\quadL.png");
            ShipB = ProxyImageFactory.GetProxyImage(@"..\..\Images\quadB.png");
            ShipF = ProxyImageFactory.GetProxyImage(@"..\..\Images\quadF.png");
            ShipR = ProxyImageFactory.GetProxyImage(@"..\..\Images\quadR.png");

            return DirectionSwitcher(direction);
        }

        public Bitmap Visit(Cars.Jeep jeep, FlyingDirection direction)
        {
            ShipL = ProxyImageFactory.GetProxyImage(@"..\..\Images\jeepL.png");
            ShipB = ProxyImageFactory.GetProxyImage(@"..\..\Images\jeepB.png");
            ShipF = ProxyImageFactory.GetProxyImage(@"..\..\Images\jeepF.png");
            ShipR = ProxyImageFactory.GetProxyImage(@"..\..\Images\jeepR.png");

            return DirectionSwitcher(direction);
        }

        public Bitmap Visit(Cars.RaceCar careCar, FlyingDirection direction)
        {
            ShipL = ProxyImageFactory.GetProxyImage(@"..\..\Images\carL.png");
            ShipB = ProxyImageFactory.GetProxyImage(@"..\..\Images\carB.png");
            ShipF = ProxyImageFactory.GetProxyImage(@"..\..\Images\carF.png");
            ShipR = ProxyImageFactory.GetProxyImage(@"..\..\Images\carR.png");

            return DirectionSwitcher(direction);
        }

        public Bitmap Visit(Cars.Truck truck, FlyingDirection direction)
        {
            ShipL = ProxyImageFactory.GetProxyImage(@"..\..\Images\truckL.png");
            ShipB = ProxyImageFactory.GetProxyImage(@"..\..\Images\truckB.png");
            ShipF = ProxyImageFactory.GetProxyImage(@"..\..\Images\truckF.png");
            ShipR = ProxyImageFactory.GetProxyImage(@"..\..\Images\truckR.png");

            return DirectionSwitcher(direction);
        }

        private Bitmap DirectionSwitcher(FlyingDirection direction)
        {
            switch (direction)
            {
                case FlyingDirection.Left:
                    return ShipL.GetImage();

                case FlyingDirection.Up:
                    return ShipF.GetImage();

                case FlyingDirection.Right:
                    return ShipR.GetImage();

                case FlyingDirection.Down:
                    return ShipB.GetImage();

                default:
                    return null;
            }
        }
    }
}