using System;
using System.IO;
using System.Text;
using Gpg.NET.Interop;

namespace Gpg.NET
{
    /// <summary>
    /// Представляет буфер данных с сохранением в памяти, используемый для отправки данных в GPG.
    /// </summary>
    public class MemoryGpgBuffer : GpgBuffer
	{
		private MemoryGpgBuffer(IntPtr handle) : base(handle) { }

        /// <summary>
        /// Создает новый пустой буфер, отображенный в памяти.
        /// </summary>
        /// <returns>Буфер, который был создан.</returns>
        public static MemoryGpgBuffer Create()
		{
			IntPtr handle;
			ErrorHandler.Check(GpgMeWrapper.gpgme_data_new(out handle));
			return new MemoryGpgBuffer(handle);
		}

        /// <summary>
        /// Создает новый буфер, отображенный в памяти, и инициализирует его заданными данными.
        /// </summary>
        /// <param name="content">Байты, которые должны быть записаны в буфер.</param>
        /// <returns>Буфер, который был создан.</returns>
        public static MemoryGpgBuffer Create(byte[] content)
		{
			var buffer = Create();
			buffer.Write(content,0, content.Length);
			buffer.Position = 0;
			return buffer;
		}

        /// <summary>
        /// Создает новый буфер, отображенный в памяти, и инициализирует его текстовыми данными, используя указанную кодировку.
        /// </summary>
        /// <param name="content">Строка текста, которая должна быть закодирована и сохранена в буфере.</param>
        /// <param name="encoding">Кодировка, которая будет использоваться для кодирования текста.</param>
        /// <returns>Буфер, который был создан.</returns>
        public static MemoryGpgBuffer CreateFromString(string content, Encoding encoding)
		{
			return Create(Encoding.UTF8.GetBytes(content));
		}

        /// <summary>
        /// Создает новый буфер, отображенный в памяти, и инициализирует его текстовыми данными в кодировке UTF-8.
        /// </summary>
        /// <param name="content">Строка текста, которая должна быть закодирована как UTF-8 и сохранена в буфере.</param>
        /// <returns>Буфер, который был создан.</returns>
        public static MemoryGpgBuffer CreateFromString(string content)
		{
			return CreateFromString(content, Encoding.UTF8);
		}

        /// <summary>
        /// Создает новый буфер, отображенный в памяти, и инициализирует его содержимым файла.
        /// </summary>
        /// <param name="path">Путь к файлу, содержимое которого должно быть сохранено в буфере.</param>
        /// <returns>Буфер, который был создан.</returns>
        public static MemoryGpgBuffer CreateFromFile(string path)
		{
			var bytes = File.ReadAllBytes(path);
			return Create(bytes);
		}
	}
}
