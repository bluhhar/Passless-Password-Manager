
namespace Gpg.NET
{
    /// <summary>
    /// Перечисляет действительность ключа или доверие к нему.
    /// </summary>
    public enum GpgValidity
	{
        /// <summary>
        /// Неизвестная действительность.
        /// </summary>
        Unknown,
        /// <summary>
        /// Неопределенная действительность.
        /// </summary>
        Undefined,
        /// <summary>
        /// Идентификатор пользователя никогда не является действительным.
        /// </summary>
        Never,
        /// <summary>
        /// Предельная достоверность.
        /// </summary>
        Marginal,
        /// <summary>
        /// Идентификатор пользователя полностью действителен.
        /// </summary>
        Full,
        /// <summary>
        /// Окончательная действительность.
        /// </summary>
        Ultimate
    }
}