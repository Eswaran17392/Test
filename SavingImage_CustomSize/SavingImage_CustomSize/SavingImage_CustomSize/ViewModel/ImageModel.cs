using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace SavingImage_CustomSize
{
    class ImageModel
    {
        public ImageSource Image { get; set; }

        public ImageModel()
        {
            Image = ImageSource.FromResource("SavingImage_CustomSize.Buldingimage.jpeg");
        }
    }
}
