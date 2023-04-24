namespace Gpg.NET
{
    /// <summary>
    /// Выдается, когда поиск ключа GPG завершается неудачей.
    /// </summary>
    public class GpgKeyNotFoundException : GpgNetException
	{
        /// <summary>
        /// Инициализирует новый экземпляр класса <см. cref="GpgKeyNotFoundException"/>.
        /// </summary>
        public GpgKeyNotFoundException(string message) :base(message){}
	}
}