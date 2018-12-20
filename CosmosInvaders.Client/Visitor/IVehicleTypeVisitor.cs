using CosmosInvaders.Library;
using System.Drawing;

namespace CosmosInvaders.Client.Visitor
{
    public interface IShipTypeVisitor
    {
        Bitmap Visit(Bikes.Bicycle bicycle, DrivingDirection direction);

        Bitmap Visit(Bikes.Motorbike motorbike, DrivingDirection direction);

        Bitmap Visit(Bikes.Quad quad, DrivingDirection direction);

        Bitmap Visit(Cars.Jeep jeep, DrivingDirection direction);

        Bitmap Visit(Cars.RaceCar careCar, DrivingDirection direction);

        Bitmap Visit(Cars.Truck truck, DrivingDirection direction);
    }
}