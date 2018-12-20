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

        public Bitmap Visit(Rangers.SmallShip smallShip, FlyingDirection direction)
        {
            ShipL = ProxyImageFactory.GetProxyImage(@"..\..\Images\smallShipL.png");
            ShipB = ProxyImageFactory.GetProxyImage(@"..\..\Images\smallShipB.png");
            ShipF = ProxyImageFactory.GetProxyImage(@"..\..\Images\smallShipF.png");
            ShipR = ProxyImageFactory.GetProxyImage(@"..\..\Images\smallShipR.png");

            return DirectionSwitcher(direction);
        }

        public Bitmap Visit(Destroyers.MediumShip mediumShip, FlyingDirection direction)
        {
            ShipL = ProxyImageFactory.GetProxyImage(@"..\..\Images\mediumShipL.png");
            ShipB = ProxyImageFactory.GetProxyImage(@"..\..\Images\mediumShipB.png");
            ShipF = ProxyImageFactory.GetProxyImage(@"..\..\Images\mediumShipF.png");
            ShipR = ProxyImageFactory.GetProxyImage(@"..\..\Images\mediumShipR.png");

            return DirectionSwitcher(direction);
        }

        public Bitmap Visit(Destroyers.BigShip bigShip, FlyingDirection direction)
        {
            ShipL = ProxyImageFactory.GetProxyImage(@"..\..\Images\bigShipL.png");
            ShipB = ProxyImageFactory.GetProxyImage(@"..\..\Images\bigShipB.png");
            ShipF = ProxyImageFactory.GetProxyImage(@"..\..\Images\bigShipF.png");
            ShipR = ProxyImageFactory.GetProxyImage(@"..\..\Images\bigShipR.png");

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