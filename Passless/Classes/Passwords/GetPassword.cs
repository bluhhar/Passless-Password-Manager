using Gpg.NET;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Passless.Classes.Passwords
{
    public static class GetPassword
    {
        public static string GetPasswordFromRepository(string fileName)
        {
            var context = GpgContext.CreateContext();

            var inputBuffer = MemoryGpgBuffer.CreateFromFile(fileName);

            var content = new StreamReader(context.Decrypt(inputBuffer)).ReadToEnd();

            return content;
        }
    }
}
