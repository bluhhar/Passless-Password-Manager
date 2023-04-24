using System;
using System.IO;
using Gpg.NET.Interop;

namespace Gpg.NET
{
    /// <summary>
    /// Представляет собой буфер данных с файловой поддержкой, используемый для отправки данных в GPG.
    /// </summary>
    public class FileGpgBuffer : GpgBuffer
	{
		private FileStream BackingFile { get; }

		private FileGpgBuffer(IntPtr handle, FileStream backingFile) : base(handle)
		{
			BackingFile = backingFile;
		}

        /// <summary>
        /// Создает новый буфер на основе файла. Еще не реализовано.
        /// </summary>
        /// <param name="path">Путь к файлу, из которого должен быть создан буфер.
        /// Если по заданному пути не существует файла, создается файл.</param>
        /// <returns></returns>
        public static GpgBuffer CreateFileBuffer(string path)
		{
            // Текущая реализация пока не работает
            throw new NotImplementedException();
			/*
			var stream = File.Open(path, FileMode.OpenOrCreate, FileAccess.ReadWrite);
			var fileDescriptor = stream.SafeFileHandle.DangerousGetHandle();
			IntPtr handle;
			ErrorHandler.Check(GpgMeWrapper.gpgme_data_new_from_fd(out handle, fileDescriptor));
			return new FileGpgBuffer(handle, stream);
			*/
		}
	}
}
