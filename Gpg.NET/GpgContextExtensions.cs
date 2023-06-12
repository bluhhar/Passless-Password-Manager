using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Security;
using System.Runtime.InteropServices;
using System.Text;

namespace Gpg.NET
{
    /// <summary>
    /// Содержит методы расширения для использования с <see cref="GpgContext"/>
    /// </summary>
    public static class GpgContextExtensions
	{
        /// <summary>
        /// Шифрует строку и записывает зашифрованный текст в файл.
        /// </summary>
        /// <param name="context">Для работы с <see cref="GpgContext"/></param>
        /// <param name="plaintext">ТЕкст который надо зашифровать</param>
        /// <param name="outputFilePath">Файл в который будет сохранен результат</param>
        /// <param name="encryptFlags">Используемые флаги шифрования.</param>
        /// <param name="overwrite">Следует ли перезаписывать существующий файл, если файл уже существует по адресу <paramref name="outputFilePath"/>.</param>
        /// <param name="recipients">Ключи GPG, для которых данные должны быть зашифрованы.</param>
        public static void EncryptString(this GpgContext context, string plaintext, string outputFilePath, IEnumerable<GpgKey> recipients, EncryptFlags encryptFlags = EncryptFlags.None, bool overwrite = false)
		{
			using (var file = File.Open(outputFilePath, overwrite ? FileMode.Create : FileMode.CreateNew))
			using (var plain = MemoryGpgBuffer.CreateFromString(plaintext))
			using (var cipher = context.Encrypt(plain, recipients, encryptFlags))
			{
				cipher.CopyTo(file);
			}
		}

		/// <summary>
		/// Расшифровывает файл и возвращает расшифрованный текст
		/// </summary>
		/// <param name="context">The <see cref="GpgContext"/> to operate on.</param>
		/// <param name="inputFilePath">The path to the encrypted file.</param>
		public static string DecryptFile(this GpgContext context, string inputFilePath)
		{
			using (var cipher = MemoryGpgBuffer.CreateFromFile(inputFilePath))
			using (var reader = new StreamReader(context.Decrypt(cipher)))
			{
				return reader.ReadToEnd();
			}
		}

        /// <summary>
        /// Расшифровать файл с записывает зашифрованный текст в другой файл
        /// </summary>
        /// <param name="context">Для работы с <see cref="GpgContext"/></param>
        /// <param name="inputFilePath">Путь к зашифрованному файлу.</param>
        /// <param name="outputFilePath">Путь куда будет сохранен расшифрованный файл</param>
        /// <param name="overwrite">Следует ли перезаписывать существующий файл, если файл уже существует по адресу <paramref name="outputFilePath"/>.</param>
        public static void DecryptFile(this GpgContext context, string inputFilePath, string outputFilePath, bool overwrite = false)
		{
			using (var file = File.Open(outputFilePath, overwrite ? FileMode.Create : FileMode.CreateNew))
			using (var cipher = MemoryGpgBuffer.CreateFromFile(inputFilePath))
			using (var plain = context.Decrypt(cipher))
			{
				plain.CopyTo(file);
			}
		}

        /// <summary>
        /// Зашифровывает файл с записывает зашифрованный текст в другой файл
        /// </summary>
        /// <param name="context">Для работы с <see cref="GpgContext"/></param>
        /// <param name="inputFilePath">Путь к файлу который надо зашифровать</param>
        /// <param name="outputFilePath">Путь к выходному файл</param>
        /// <param name="encryptFlags">Используемые флаги шифрования</param>
        /// <param name="overwrite">Следует ли перезаписывать существующий файл, если файл уже существует по адресу <paramref name="outputFilePath"/>.</param>
        /// <param name="recipients">Ключи GPG, для которых данные должны быть зашифрованы.</param>
        public static void EncryptFile(this GpgContext context, string inputFilePath, string outputFilePath, IEnumerable<GpgKey> recipients, EncryptFlags encryptFlags = EncryptFlags.None, bool overwrite = false)
		{
			using (var file = File.Open(outputFilePath, overwrite ? FileMode.Create : FileMode.CreateNew))
			using (var plain = MemoryGpgBuffer.CreateFromFile(inputFilePath))
			using (var cipher = context.Encrypt(plain, recipients, encryptFlags))
			{
				cipher.CopyTo(file);
			}
		}
	}
}
