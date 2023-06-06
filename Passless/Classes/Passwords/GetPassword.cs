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
        private static string ParseString(string input, bool isPasswordMode)
        {
            string[] parts = input.Split(':');

            if (parts.Length == 2)
            {
                string login = parts[0].Trim();
                string password = parts[1].Trim();

                if (isPasswordMode)
                {
                    return password;
                }
                else
                {
                    return login;
                }
            }

            // Если формат строки некорректен, вернуть пустое значение или генерировать исключение.
            return string.Empty;
        }

        public static string GetPasswordFromRepository(string fileName, bool mode)
        {
            var context = GpgContext.CreateContext();

            var inputBuffer = MemoryGpgBuffer.CreateFromFile(fileName);

            var content = new StreamReader(context.Decrypt(inputBuffer)).ReadToEnd();

            content = ParseString(content, mode);
            
            return content;
        }

        public static string GetContentFromRepository(string fileName)
        {
            var context = GpgContext.CreateContext();

            var inputBuffer = MemoryGpgBuffer.CreateFromFile(fileName);

            var content = new StreamReader(context.Decrypt(inputBuffer)).ReadToEnd();

            return content;
        }
    }
}
