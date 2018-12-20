using CosmosInvaders.Library;
using System.Drawing;

namespace CosmosInvaders.Client.Visitor
{
    public interface IShipTypeVisitor
    {
        Bitmap Visit(Rangers.SmallShip smallShip, FlyingDirection direction);

        Bitmap Visit(Destroyers.MediumShip mediumShip, FlyingDirection direction);

        Bitmap Visit(Destroyers.BigShip bigShip, FlyingDirection direction);
    }
}