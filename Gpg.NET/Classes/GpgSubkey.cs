using System;

namespace Gpg.NET
{
    /// <summary>
    /// Представляет подраздел GPG, который принадлежит <см. cref="GpgKey"/> и является
    /// ключ, который фактически отвечает за криптографические операции.
    /// </summary>
    public class GpgSubkey
	{
		internal  IntPtr Handle { get; }
        /// <summary>
        /// Возвращает значение, указывающее, был ли подраздел отозван его владельцем.
        /// </summary>
        public bool Revoked { get; internal set; }
        /// <summary>
        /// Возвращает значение, указывающее, истек ли срок действия подраздела.
        /// </summary>
        public bool Expired { get; internal set; }
        /// <summary>
        /// Возвращает значение, указывающее, был ли отключен подраздел.
        /// </summary>
        public bool Disabled { get; internal set; }
        /// <summary>
        /// Возвращает значение, указывающее, является ли подраздел недопустимым.
        /// У этого может быть несколько причин, например, для серверной части S/MIME,
        /// он будет установлен при перечислении ключей, 
		/// если ключ не удалось проверить из-за отсутствия сертификатов или несоответствующих политик.
        /// </summary>
        public bool Invalid { get; internal set; }
        /// <summary>
        /// Возвращает значение, указывающее, может ли подраздел использоваться в качестве получателя для шифрования.
		/// </summary>
		public bool CanEncrypt { get; internal set; }
        /// <summary>
        /// Возвращает значение, указывающее, можно ли использовать подраздел для подписи данных.
        /// </summary>
        public bool CanSign { get; internal set; }
        /// <summary>
        /// Возвращает значение, указывающее, 
		/// можно ли использовать подраздел для сертификации других ключей и манипулирования подразделами.
        /// </summary>
        public bool CanCertify { get; internal set; }
        /// <summary>
        /// Возвращает значение, указывающее, можно ли использовать подраздел для аутентификации.
        /// </summary>
        public bool CanAuthenticate { get; internal set; }
        /// <summary>
        /// Возвращает значение, указывающее, является ли подраздел секретным ключом.
        /// </summary>
        public bool Secret { get; internal set; }
        /// <summary>
        /// Возвращает значение, указывающее, может ли подраздел использоваться 
		/// для квалифицированных подписей в соответствии с правилами местного самоуправления.
        /// </summary>
        public bool IsQualified { get; internal set; }
        /// <summary>
        /// Возвращает значение, указывающее, сохранен ли подраздел на смарт-карте.
        /// </summary>
        public bool IsCardkey { get; internal set; }
        /// <summary>
        /// Возвращает алгоритм, используемый для этого подраздела.
        /// </summary>
        public PublicKeyAlgorithm PublicKeyAlgorithm { get; internal set; }
        /// <summary>
        /// Возвращает длину (в битах) подраздела.
        /// </summary>
        public int Length { get; internal set; }
        /// <summary>
        /// Возвращает идентификатор подраздела в шестнадцатеричных цифрах.
        /// </summary>
        public string KeyId { get; internal set; }
        /// <summary>
        /// Возвращает отпечаток подраздела в шестнадцатеричных цифрах, если таковой имеется.
        /// </summary>
        public string Fingerprint { get; internal set; }
        /// <summary>
        /// Возвращает дату и время, в которые был создан подраздел.
        /// </summary>
        public DateTime Created { get; internal set; }
        /// <summary>
        /// Возвращает дату и время истечения срока действия подраздела.
        /// </summary>
        public DateTime Expires { get; internal set; }
        /// <summary>
        /// Если подраздел сохранен на смарт-карте, получаем серийный номер смарт-карты, содержащей этот ключ.
        /// </summary>
        public string CardNumber { get; internal set; }
        /// <summary>
        /// Если алгоритм подраздела является алгоритмом ECC, получает название кривой.
        /// </summary>
        public string Curve { get; internal set; }
        /// <summary>
        /// Возвращает keygrip текущего подраздела, если таковой имеется.
        /// </summary>
        public string Keygrip { get; internal set; }

		internal GpgSubkey(IntPtr handle)
		{
			Handle = handle;
		}

        /// <summary>
        /// Возвращает строковое представление текущего объекта.
        /// </summary>
        public override string ToString() =>
			$"{KeyId}" +
			$"{(Revoked ? " !REV" : "")}" +
			$"{(Expired ? " !EXP" : "")}" +
			$"{(Disabled ? " !DIS" : "")}" +
			$" ({PublicKeyAlgorithm}{(Curve == null ? "" : $"/{Curve}" )}-{Length})" +
			$" [{(CanEncrypt ? "E" : "")}" +
			$"{(CanSign ? "S" : "")}" +
			$"{(CanCertify ? "C" : "")}" +
			$"{(CanAuthenticate ? "A" : "")}]" +
			$" [Exp: {Expires:d}]";
	}
}
