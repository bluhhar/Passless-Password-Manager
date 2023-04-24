using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

using Passless;
using Gpg.NET;
using System.IO;
using System.Web.UI.WebControls;

namespace Passless.Konsole
{
    public class Program
    {
        private static void Main(string[] args)
        {
            GpgNet.Initialise(@"C:\Program Files (x86)\GnuPG\bin\libgpgme-11.dll");
            Console.WriteLine($"Started GpgME version {GpgNet.Version}"); //дОБавить логер

            //TestCreateRepo();
            TestAddPassword();
            TestGetPassword();

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }

        public static void TestCreateRepo()
        {
            Console.WriteLine("RepoName:");
            string repoName = Console.ReadLine();
            string path = @"C:\Users\bluhhar\.passless\" + repoName;
            if (!Directory.Exists(path))
            {
                DirectoryInfo di = Directory.CreateDirectory(path);
                di.Attributes = FileAttributes.Directory | FileAttributes.Hidden;
            }
        }

        public static void TestAddPassword()
        {
            //string pathToPasswords = @"C:\Users\bluhhar\.password-store";
            Console.WriteLine("FillName:");
            string fileName = Console.ReadLine();
            Console.WriteLine("Enter Password:");
            string password = Console.ReadLine();

            var context = GpgContext.CreateContext();

            context.KeylistMode = context.KeylistMode | GpgKeylistMode.WithSecret;

            // Print GPG keys
            var key = context.FindKey("bluhhar@btwow.ru"); //СДЕЛАТЬ ЧТОБЫ если нет ключа ошибку
            var result = context.Encrypt(MemoryGpgBuffer.CreateFromString(password), key); //ПОПРОБОВАТЬ РЕАЛИЗОВАТЬ ЧТОБЫ вместо keys бралось email при вводе в файл подписи

            var encPasswordFile = Environment.ExpandEnvironmentVariables(@"%userprofile%\.passless\" + fileName + ".gpg");
            using (var fs = File.OpenWrite(encPasswordFile))
            {
                result.CopyTo(fs);
            }
            Console.WriteLine("File was encrypted successfully.");
        }

        private static void TestGetPassword()
        {
            var context = GpgContext.CreateContext();

            Console.WriteLine("FileName:");            
            string fileName = Console.ReadLine();

            var passwordFile = Environment.ExpandEnvironmentVariables(@"%userprofile%\.passless\" + fileName + ".gpg");
            // Create a GPG data buffer for storing the ciphertext
            var inputBuffer = MemoryGpgBuffer.CreateFromFile(passwordFile);

            var content = new StreamReader(context.Decrypt(inputBuffer)).ReadToEnd();

            Console.WriteLine("Decryption output:");
            Console.WriteLine(content);
        }
    }
}