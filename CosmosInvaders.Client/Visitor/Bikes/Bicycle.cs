using CosmosInvaders.Library;
using System.Drawing;

namespace CosmosInvaders.Client.Visitor.Bikes
{
    public class Bicycle : IShipType
    {
        public Bitmap Display(IShipTypeVisitor shipTypeVisitor, FlyingDirection direction)
        {
            return shipTypeVisitor.Visit(this, direction);
        }
    }
}