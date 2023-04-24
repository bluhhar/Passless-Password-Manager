namespace Gpg.NET
{
    /// <summary>
    /// Представляет идентификатор пользователя GPG, который является компонентом ключа GPG
    /// У одного ключа может быть много идентификаторов пользователя. 
	/// Первым в списке является основной (или primary) идентификатор пользователя.
    /// </summary>
    public class GpgUserId
	{
        /// <summary>
        /// Возвращает действительность текущего идентификатора пользователя.
        /// </summary>
        public GpgValidity Validity { get; internal set; }
        /// <summary>
        /// Возвращает строку идентификатора пользователя.
        /// </summary>
        public string Uid { get; internal set; }
        /// <summary>
        /// Возвращает компонент name текущего идентификатора пользователя, если таковой имеется.
        /// </summary>
        public string Name { get; internal set; }
        /// <summary>
        /// Возвращает компонент электронной почты текущего идентификатора пользователя, если таковой имеется.
        /// </summary>
        public string Email { get; internal set; }
        /// <summary>
        /// Возвращает компонент комментария текущего идентификатора пользователя, если таковой имеется.
        /// </summary>
        public string Comment { get; internal set; }
        /// <summary>
        /// Получает адрес электронной почты (addr-spec из RFC-5322) строки идентификатора пользователя.
        /// Обычно это то же самое, что и <см. cref="Email"/>, но может немного отличаться.
        /// </summary>
        public string Address { get; internal set; }

        /// <summary>
        /// Возвращает строковое представление текущего объекта.
		/// </summary>
		public override string ToString()
		{
			return $"{Uid} ({Validity})";
		}
	}
}