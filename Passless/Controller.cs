using Passless.Modules;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Passless.Modules.GnuPGHelper;

namespace Passless
{
    public class Controller
    {
        private enum Options
        {
            init
        }
        private static void CreateRepo(string repoName)
        {
            string repoPath = Path.Combine(Environment.CurrentDirectory, repoName); // Полный путь к репозиторию
            Directory.CreateDirectory(repoPath); // Создание директории
            File.SetAttributes(repoPath, File.GetAttributes(repoPath) | FileAttributes.Hidden); // Скрытие директории
        }
        public static void Activation()
        {
            GnuPGHelper.EncryptFile("output.txt", "input.txt", "bluhhar_0xF0B87C99_public.asc", true, true);

            GnuPGHelper.DecryptFile("output.txt", "bluhhar_0xF0B87C99_SECRET.asc", "daf123456".ToCharArray(), "default.txt");
        }
    }
}
