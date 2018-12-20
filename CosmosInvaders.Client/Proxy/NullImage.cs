using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Racing2D.Client.Proxy
{
    public class NullImage : IImage
    {
        private string _fileName { get; set; }

        public NullImage(string fileName)
        {
            _fileName = fileName;
        }

        public Bitmap GetImage()
        {
            MessageBox.Show($"Paveikslėlis nerastas ({_fileName})", "Klaida",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            return null;
        }

        public bool IsNull()
        {
            return true;
        }
    }
}