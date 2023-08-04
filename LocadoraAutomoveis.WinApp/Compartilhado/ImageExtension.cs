using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraAutomoveis.WinApp.Compartilhado
{
    public static class ImageExtension
    {
        public static byte[]? ToByte(this Image image)
        {
            if (image == null)
                return null;

            using MemoryStream ms = new();

            image.Save(ms, ImageFormat.Jpeg);

            return ms.ToArray();
        }
    }
}
