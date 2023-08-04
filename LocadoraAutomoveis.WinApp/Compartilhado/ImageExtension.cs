using System.Drawing.Imaging;

namespace LocadoraAutomoveis.WinApp.Compartilhado
{
    public static class ImageExtension
    {
        public static byte[]? ToByte(this Image image)
        {
            if (image == null)
                return null;

            using MemoryStream ms = new();

            image.Save(ms, ImageFormat.Png);
            return ms.ToArray();
        }
    }
}
