using CosmosInvaders.Library;
using System.Drawing;

namespace CosmosInvaders.Client.Visitor.Bikes
{
    public class Motorbike : IVehicleType
    {
        public Bitmap Display(IVehicleTypeVisitor vehicleTypeVisitor, DrivingDirection direction)
        {
            return vehicleTypeVisitor.Visit(this, direction);
        }
    }
}