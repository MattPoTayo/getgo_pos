using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GetGoPOS.Helpers
{
    class Helper
    {
        public static string ProgramDataDirectory
        {
            get
            {
                var dir = $@"{Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData)}\{Application.ProductName}";
                if (!Directory.Exists(dir))
                    Directory.CreateDirectory(dir);
                return dir;
            }
        }

        public static string ImagesDirectory
        {
            get
            {
                var dir = $@"{Environment.GetFolderPath(Environment.SpecialFolder.CommonDocuments)}\{Application.ProductName}\Images";
                if (!Directory.Exists(dir))
                    Directory.CreateDirectory(dir);
                return dir;
            }
        }
        public static string DbFile => CreateFileIfNotExists("AppDb.sqlite");

        private static string CreateFileIfNotExists(string fileName, byte[] writeBytes = null)
        {
            var fileFullName = $@"{ProgramDataDirectory}\{fileName}";

            if (fileName != "userbg.jpg")
                if (fileName.Substring(fileName.Length - 4) == ".jpg" || fileName.Substring(fileName.Length - 5) == ".jpeg" ||
                    fileName.Substring(fileName.Length - 4) == ".bmp" || fileName.Substring(fileName.Length - 4) == ".png")
                    fileFullName = $@"{ImagesDirectory}\{fileName}";

            if (!File.Exists(fileFullName))
            {
                var file = null as FileStream;
                file = File.Create(fileFullName);

                if (file != null)
                    file.Close();

                if (writeBytes != null)
                    File.WriteAllBytes(fileFullName, writeBytes);
            }

            return fileFullName;
        }
    }
}
