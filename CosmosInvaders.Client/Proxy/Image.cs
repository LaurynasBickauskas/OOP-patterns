using System.Drawing;

namespace CosmosInvaders.Client.Proxy
{
    public interface IImage
    {
        Bitmap GetImage();

        bool IsNull();
    }
}