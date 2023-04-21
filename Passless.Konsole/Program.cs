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
            Console.WriteLine($"Started GpgME version {GpgNet.Version}");
            //Test0();
            //Test1();
            //Test2();

            TestAddPassword();
            //TestGetPassword();

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
        public static void TestAddPassword()
        {
            //string pathToPasswords = @"C:\Users\bluhhar\.password-store";
            Console.WriteLine("FileName:");
            string fileName = Console.ReadLine();
            Console.WriteLine("Enter Password:");
            string password = Console.ReadLine();

            var context = GpgContext.CreateContext();

            context.KeylistMode = context.KeylistMode | GpgKeylistMode.WithSecret;

            // Print GPG keys
            var keys = context.FindKeys().ToArray();
            var result = context.Encrypt(MemoryGpgBuffer.CreateFromString(password), keys[0]); //ПОПРОБОВАТЬ РЕАЛИЗОВАТЬ ЧТОБЫ вместо keys бралось email при вводе в файл подписи

            var encPasswordFile = Environment.ExpandEnvironmentVariables(@"%userprofile%\.password-store\" + fileName + ".gpg");
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

            var passwordFile = Environment.ExpandEnvironmentVariables(@"%userprofile%\.password-store\" + fileName + ".gpg");
            // Create a GPG data buffer for storing the ciphertext
            var inputBuffer = MemoryGpgBuffer.CreateFromFile(passwordFile);

            var content = new StreamReader(context.Decrypt(inputBuffer)).ReadToEnd();

            Console.WriteLine("Decryption output:");
            Console.WriteLine(content);
        }

        private static void Test2()
        {

            var helloWorld = "Hello World!";
            Console.WriteLine(helloWorld);

            var context = GpgContext.CreateContext();

            context.KeylistMode = context.KeylistMode | GpgKeylistMode.WithSecret;
            context.ArmorMode = GpgArmorMode.On;

            // Print GPG keys
            var keys = context.FindKeys().ToArray();
            foreach (var key in keys)
            {
                Console.WriteLine(key.ToString());
                Console.WriteLine($"\t{key.Uids.First()}");
                foreach (var subkey in key.Subkeys)
                {
                    Console.WriteLine($"\t{subkey}");
                }
            }


            MemoryGpgBuffer helloBuffer = MemoryGpgBuffer.CreateFromString(helloWorld);
            var encryptedBuffer = context.Encrypt(helloBuffer, keys[1]); //ПОПРОБОВАТЬ РЕАЛИЗОВАТЬ ЧТОБЫ вместо keys бралось email при вводе в файл подписи
            var encryptedByteBuffer = new byte[(int)encryptedBuffer.Length];
            encryptedBuffer.Read(encryptedByteBuffer, 0, (int)encryptedBuffer.Length);
            Console.WriteLine("========");
            Console.WriteLine(Encoding.UTF8.GetString(encryptedByteBuffer));
            Console.WriteLine("========");
            encryptedBuffer.Position = 0;
            var prop = new byte[2];

            using (var decrypted = context.Decrypt(encryptedBuffer))
            {
                var decryptedByteBuffer = new byte[decrypted.Length];
                encryptedBuffer.Position = 0;
                var decryptedBuffer = context.Decrypt(encryptedBuffer);
                decryptedBuffer.Read(decryptedByteBuffer, 0, decryptedByteBuffer.Length);
                Console.WriteLine(Encoding.UTF8.GetString(decryptedByteBuffer));
            }
        }

        private static void Test1()
        {
            var context = GpgContext.CreateContext();
            var recipient = context.FindKey("dev");

            var reencFile = Environment.ExpandEnvironmentVariables(@"%userprofile%\.password-store\testpw-reenc.gpg");
            var file = MemoryGpgBuffer.CreateFromFile(reencFile);
            var plaintext = new StreamReader(context.Decrypt(file)).ReadToEnd();
            Console.WriteLine(plaintext);
        }

        private static void Test0()
        {
            // Create a new GPG context
            var context = GpgContext.CreateContext();

            context.KeylistMode = context.KeylistMode | GpgKeylistMode.WithSecret;

            // Print GPG keys
            var keys = context.FindKeys().ToArray();
            foreach (var key in keys)
            {
                Console.WriteLine(key.ToString());
                Console.WriteLine($"\t{key.Uids.First()}");
                foreach (var subkey in key.Subkeys)
                {
                    Console.WriteLine($"\t{subkey}");
                }
            }

            var passwordFile = Environment.ExpandEnvironmentVariables(@"%userprofile%\.password-store\testpw-reenc.gpg");
            // Create a GPG data buffer for storing the ciphertext
            var inputBuffer = MemoryGpgBuffer.CreateFromFile(passwordFile);

            var content = new StreamReader(context.Decrypt(inputBuffer)).ReadToEnd();

            Console.WriteLine("Decryption output:");
            Console.WriteLine(content);

            var result = context.Encrypt(MemoryGpgBuffer.CreateFromString(content + "Re-Encrypted: True\n"), keys.Take(1));

            var reEncPasswordFile = Environment.ExpandEnvironmentVariables(@"%userprofile%\.password-store\testpw-reenc.gpg");
            using (var fs = File.OpenWrite(reEncPasswordFile))
            {
                result.CopyTo(fs);
            }
            Console.WriteLine("File was re-encrypted successfully.");
        }
    }
}