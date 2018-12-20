using CosmosInvaders.Library;
using System.Drawing;

namespace CosmosInvaders.Client.Visitor
{
    public interface IVehicleType
    {
        Bitmap Display(IVehicleTypeVisitor vehicleTypeVisitor, DrivingDirection direction);
    }
}