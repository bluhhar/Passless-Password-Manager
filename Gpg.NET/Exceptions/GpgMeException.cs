using System;

namespace Gpg.NET
{
    /// <summary>
    /// Переносит код ошибки GpgME.
    /// </summary>
    public class GpgMeException : GpgNetException
	{
        /// <summary>
        /// Возвращено имя ошибки GpgME.
        /// </summary>
        public GpgMeError GpgMeError { get; }
        /// <summary>
        /// Ошибка GpgME в виде целого числа.
        /// </summary>
        public int GpgErrorCode => (int)GpgMeError;

        /// <summary>
        /// Создает новое исключение GpgMeException.
        /// </summary>
        /// <param name="error">Возвращенный GpgMeError</param>
        /// <param name="message">Сообщение об ошибке, связанное с кодом ошибки</param>
        public GpgMeException(GpgMeError error, string message) : base(message)
		{
			GpgMeError = error;
		}
	}
}