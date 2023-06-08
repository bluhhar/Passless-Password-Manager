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
        public static void Writer(string path, string data, string filename)
        {
            if (!File.Exists(path + filename))
            {
                using (File.Create(path + filename)) { }
            }
            using (FileStream fstream = new FileStream(path + filename, FileMode.Truncate))
            {
                byte[] input = Encoding.Default.GetBytes(data);
                fstream.Write(input, 0, input.Length);
                File.SetAttributes(fstream.Name, FileAttributes.Hidden);
            }
        }

        public static string Reader(string path, string filename)
        {
            string result = "";
            if(!File.Exists(path + filename))
            {
                return result;
            }
            using (FileStream fstream = File.OpenRead(path + filename))
            {
                byte[] buffer = new byte[fstream.Length];
                fstream.Read(buffer, 0, buffer.Length);
                result = Encoding.Default.GetString(buffer);
            }
            return result;
        }
    }
}
