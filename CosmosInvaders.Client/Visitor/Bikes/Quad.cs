using CosmosInvaders.Library;
using System.Drawing;

namespace CosmosInvaders.Client.Visitor.Bikes
{
    public class Quad : IShipType
    {
        public Bitmap Display(IShipTypeVisitor shipTypeVisitor, DrivingDirection direction)
        {
            return shipTypeVisitor.Visit(this, direction);
        }
    }
}