using System.Drawing;

namespace Racing2D.Client.Proxy
{
    public interface IImage
    {
        Bitmap GetImage();

        bool IsNull();
    }
}