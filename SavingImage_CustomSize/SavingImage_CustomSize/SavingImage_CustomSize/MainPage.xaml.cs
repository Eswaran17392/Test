using Syncfusion.SfImageEditor.XForms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace SavingImage_CustomSize
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            ImageEditor.SetToolbarItemVisibility("save",false);
        }

        private void ImageEditor_ImageSaving(object sender, ImageSavingEventArgs args)
        {
            args.Cancel = true;
            var stream = args.Stream;
            var directory = Path.Combine(FileSystem.AppDataDirectory, "ImageEditorSavedImages");
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            var fileFullPath = Path.Combine(directory, "MySavedImage.png");
            SaveStreamToFile(fileFullPath, stream);
        }

        public void SaveStreamToFile(string fileFullPath, Stream stream)
        {
            if (stream.Length == 0) return;

            // Create a FileStream object to write a stream to a file
            using (FileStream fileStream = System.IO.File.Create(fileFullPath, (int)stream.Length))
            {
                // Fill the bytes[] array with the stream data
                byte[] bytesInStream = new byte[stream.Length];
                stream.Read(bytesInStream, 0, (int)bytesInStream.Length);

                // Use FileStream object to write to the specified file
                fileStream.Write(bytesInStream, 0, bytesInStream.Length);
            }
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            ImageEditor.Save(null,new Size(500,500));
        }
    }
}
