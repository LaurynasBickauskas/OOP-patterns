using CosmosInvaders.Library;
using System.Drawing;

namespace CosmosInvaders.Client.Visitor.Bikes
{
    public class Motorbike : IShipType
    {
        public Bitmap Display(IShipTypeVisitor shipTypeVisitor, DrivingDirection direction)
        {
            return shipTypeVisitor.Visit(this, direction);
        }
    }
}