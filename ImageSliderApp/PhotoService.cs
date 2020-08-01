using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;

namespace ImageSliderApp
{
    class PhotoService
    {
        private readonly string searchPattern = "*.*";

        public Photo GetDefaultPhoto
        { 
            get
            { 
                return new Photo { Content = new Bitmap(300, 150), Label = "No photo available" };
            }
        }

        public List<Photo> GetPhotosList(string path)
        {
            var photos = GetPhotosFromDirectory(path)
                .Select(file => new Photo { Content = ImageCreator.CreateImage(file), Label = ImageCreator.CreateImageLabel(file) })
                .ToList();
            
            return photos;
        }

        private string[] GetPhotosFromDirectory(string path)
        {
            try
            {
                var files = Directory.GetFiles(path, searchPattern)
                    .Where(file => file.EndsWith(".jpg") || file.EndsWith(".jpeg") || file.EndsWith(".png"))
                    .ToArray();

                return files;
            }
            catch
            {
                return Array.Empty<string>();
            }
        }
    }
}
