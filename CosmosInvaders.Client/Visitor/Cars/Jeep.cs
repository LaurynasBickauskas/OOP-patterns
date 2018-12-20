using CosmosInvaders.Library;
using System.Drawing;

namespace CosmosInvaders.Client.Visitor.Cars
{
    public class Jeep : IShipType
    {
        public Bitmap Display(IShipTypeVisitor shipTypeVisitor, FlyingDirection direction)
        {
            return shipTypeVisitor.Visit(this, direction);
        }
    }
}