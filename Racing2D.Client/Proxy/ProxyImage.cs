using System.Drawing;

namespace Racing2D.Client.Proxy
{
    public class ProxyImage : IImage
    {
        private Bitmap _image { get; set; }
        private string _fileName { get; set; }

        public ProxyImage(string fileName)
        {
            _fileName = fileName;
        }

        public Bitmap GetImage()
        {
            if (_image == null)
            {
                _image = new RealImage(_fileName).GetImage();
            }
            return _image;
        }

        public bool IsNull()
        {
            return false;
        }
    }
}