using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Passless.Modules
{
    public static class FileHelper
    {
        public static void Writer(string path, string data)
        {
            if (!File.Exists(path + "\\.gpg_owner"))
            {
                using (File.Create(path + "\\.gpg_owner")) { }
            }
            using (FileStream fstream = new FileStream(path + "\\.gpg_owner", FileMode.Truncate))
            {
                byte[] input = Encoding.Default.GetBytes(data);
                fstream.Write(input, 0, input.Length);
                File.SetAttributes(fstream.Name, FileAttributes.Hidden);
            }
        }

        public static string Reader(string path)
        {
            string result = "";
            if(!File.Exists(path + "\\.gpg_owner"))
            {
                return result;
            }
            using (FileStream fstream = File.OpenRead(path + "\\.gpg_owner"))
            {
                byte[] buffer = new byte[fstream.Length];
                fstream.Read(buffer, 0, buffer.Length);
                result = Encoding.Default.GetString(buffer);
            }
            return result;
        }
    }
}
