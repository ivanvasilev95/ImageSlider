using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            var fileLength = file.Length;
            var startIndex = file.LastIndexOf(@"\") + 1;
            var length = fileLength - startIndex;
            var label = file.Substring(startIndex, length);

            return label;
        }
    }
}
