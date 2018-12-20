using CosmosInvaders.Library;
using System.Drawing;

namespace CosmosInvaders.Client.Visitor.Cars
{
    public class Truck : IVehicleType
    {
        public Bitmap Display(IVehicleTypeVisitor vehicleTypeVisitor, DrivingDirection direction)
        {
            return vehicleTypeVisitor.Visit(this, direction);
        }
    }
}