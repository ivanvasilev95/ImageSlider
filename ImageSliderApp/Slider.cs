using System.Collections.Generic;
using System.Linq;

namespace ImageSliderApp
{
    class Slider
    {
        private readonly PhotoService photoService = new PhotoService();

        private List<Photo> photos;
        private int index;

        public Slider()
        {
            this.photos = new List<Photo>();
            this.index = 0;
        }

        public void LoadPhotos(string path)
        {
            this.photos = photoService.GetPhotosList(path);
            this.index = 0;
        }

        public void Previous()
        {
            if (index == 0)
                index = this.photos.Count - 1;
            else
                index--;
        }

        public void Next()
        {
            if (index == this.photos.Count - 1)
                index = 0;
            else
                index++;
        }

        public bool ContainsPhotos 
        { 
            get { return this.photos.Count != 0; } 
        }

        public Photo GetPhoto()
        {
            if (ContainsPhotos)
            {
                var photo = photos[index];
                return photo;
            }
            else
            {
                return photoService.GetDefaultPhoto;
            }
        }

        public void AddPhoto(string file)
        {
            var imageLabel = ImageCreator.CreateImageLabel(file);
            if (this.photos.Where(p => p.Label == imageLabel).Count() == 0)
            {
                this.photos.Add(new Photo { Content = ImageCreator.CreateImage(file), Label = imageLabel });
            }
        }
    }
}
