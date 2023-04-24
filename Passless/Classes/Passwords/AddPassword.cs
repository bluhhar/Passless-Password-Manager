using Gpg.NET;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Passless.Classes.Passwords
{
    public static class AddPassword
    {
        public static void AddPasswordToRepository(string path, string keyOwner, string fileName, string password)
        {
            var context = GpgContext.CreateContext();

            context.KeylistMode = context.KeylistMode | GpgKeylistMode.WithSecret;

            var key = context.FindKey(keyOwner); //СДЕЛАТЬ ЧТОБЫ если нет ключа ошибку
            var result = context.Encrypt(MemoryGpgBuffer.CreateFromString(password), key);

            var encPasswordFile = path + fileName + ".gpg";
            using (var fs = File.OpenWrite(encPasswordFile))
            {
                result.CopyTo(fs);
            }
        }
    }
}
