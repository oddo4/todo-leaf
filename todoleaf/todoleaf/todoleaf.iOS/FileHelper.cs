using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using todoleaf.iOS;
using Xamarin.Forms;

[assembly: Dependency(typeof(FileHelper))]
namespace todoleaf.iOS
{
    public class FileHelper : IFileHelper
    {
        public string GetLocalFilePath(string filename)
        {
            string docFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string libFolder = Path.Combine(docFolder, "..", "Library", "Databases");

            if (!Directory.Exists(libFolder))
            {
                Directory.CreateDirectory(libFolder);
            }

            return Path.Combine(libFolder, filename);
        }
    }
}
