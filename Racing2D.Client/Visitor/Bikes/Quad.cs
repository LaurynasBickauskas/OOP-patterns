using Racing2D.Library;
using System.Drawing;

namespace Racing2D.Client.Visitor.Bikes
{
    public class Quad : IVehicleType
    {
        public Bitmap Display(IVehicleTypeVisitor vehicleTypeVisitor, DrivingDirection direction)
        {
            return vehicleTypeVisitor.Visit(this, direction);
        }
    }
}