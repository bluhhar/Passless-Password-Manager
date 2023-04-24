using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Passless.Classes.FileHelper
{
    public static class FileCreates
    {
        public static async Task CreateHiddenFile(string path, string data)
        {
            using (FileStream fstream = new FileStream(path + "\\.gpg_owner", FileMode.OpenOrCreate))
            {
                byte[] buffer = Encoding.Default.GetBytes(data);
                await fstream.WriteAsync(buffer, 0, buffer.Length);
                //File.SetAttributes(path, File.GetAttributes(path) | FileAttributes.Hidden); //репозиторий
                File.SetAttributes(fstream.Name, FileAttributes.Hidden); //файл
            }
        }
    }
}
