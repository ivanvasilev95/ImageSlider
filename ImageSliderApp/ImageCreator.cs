using System.Drawing;

namespace ImageSliderApp
{
    class ImageCreator
    {
        public static Image CreateImage(string file)
        {
            var image = Image.FromFile(file);

            return image;
        }

        public static string CreateImageLabel(string file)
        {
            // extract image name (with extension) from the full image path
            var fileLength = file.Length;
            var startIndex = file.LastIndexOf(@"\") + 1;
            var length = fileLength - startIndex;
            var label = file.Substring(startIndex, length);

            return label;
        }
    }
}
