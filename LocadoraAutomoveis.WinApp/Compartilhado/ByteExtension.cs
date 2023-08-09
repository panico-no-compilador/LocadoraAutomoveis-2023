namespace LocadoraAutomoveis.WinApp.Compartilhado
{
    public static class ByteExtension
    {
        public static Image? ToImage(this byte[] imageBytes)
        {
            if (imageBytes == null || imageBytes.Length == 0)
                return null;

            using MemoryStream ms = new(imageBytes);

            Image imagem = Image.FromStream(ms);

            return imagem;
        }
    }
}
