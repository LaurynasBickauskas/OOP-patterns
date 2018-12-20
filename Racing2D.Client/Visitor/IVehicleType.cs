using Racing2D.Library;
using System.Drawing;

namespace Racing2D.Client.Visitor
{
    public interface IVehicleType
    {
        Bitmap Display(IVehicleTypeVisitor vehicleTypeVisitor, DrivingDirection direction);
    }
}