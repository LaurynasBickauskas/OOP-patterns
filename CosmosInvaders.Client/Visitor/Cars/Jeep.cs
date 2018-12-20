using CosmosInvaders.Library;
using System.Drawing;

namespace CosmosInvaders.Client.Visitor.Cars
{
    public class Jeep : IShipType
    {
        public Bitmap Display(IShipTypeVisitor shipTypeVisitor, DrivingDirection direction)
        {
            return shipTypeVisitor.Visit(this, direction);
        }
    }
}