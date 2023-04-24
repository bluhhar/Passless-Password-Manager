using System;

namespace Gpg.NET
{
    /// <summary>
    /// Представляет собой общую ошибку в Gpg.NET .
    /// </summary>
    public class GpgNetException : Exception
	{
        /// <summary>
        /// Инициализирует новый экземпляр класса <см. cref="GpgNetException"/>.
        /// </summary>
        public GpgNetException(string message) : base(message) {}
	}
}