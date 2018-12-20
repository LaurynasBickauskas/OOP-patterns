using System.Drawing;

namespace CosmosInvaders.Client.Proxy
{
    public class RealImage : IImage
    {
        private string _fileName { get; set; }

        public RealImage(string fileName)
        {
            _fileName = fileName;
        }

        public Bitmap GetImage()
        {
            return new Bitmap(_fileName);
        }

        public bool IsNull()
        {
            return false;
        }
    }
}