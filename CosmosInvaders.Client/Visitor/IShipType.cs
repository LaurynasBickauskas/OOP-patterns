using CosmosInvaders.Library;
using System.Drawing;

namespace CosmosInvaders.Client.Visitor
{
    public interface IShipType
    {
        Bitmap Display(IShipTypeVisitor shipTypeVisitor, FlyingDirection direction);
    }
}