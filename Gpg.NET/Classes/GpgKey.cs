using System;
using System.Globalization;

namespace Gpg.NET
{
    /// <summary>
    /// Представляет собой GPG-ключ, который может быть использован для шифрования и дешифрования данных.
    /// </summary>
    public class GpgKey
	{
		internal IntPtr Handle { get; }
        /// <summary>
        /// Возвращает режим списка ключей, который был активен при извлечении этого ключа.
        /// </summary>
        public GpgKeylistMode KeylistMode { get; internal set; }
        /// <summary>
        /// Возвращает значение, указывающее, был ли ключ отозван его владельцем.
        /// </summary>
        public bool Revoked { get; internal set; }
        /// <summary>
        /// Возвращает значение, указывающее, истек ли срок действия ключа.
        /// </summary>
        public bool Expired { get; internal set; }
        /// <summary>
        /// Возвращает значение, указывающее, был ли ключ отключен.
        /// </summary>
        public bool Disabled { get; internal set; }
        /// <summary>
        /// Возвращает значение, указывающее, является ли ключ недействительным.
        /// У этого может быть несколько причин, например, для серверной части S/MIME,
        /// он будет установлен при перечислении ключей, 
		/// если ключ не удалось проверить из-за отсутствия сертификатов или несоответствующих политик. 
        /// </summary>
        public bool Invalid { get; internal set; }
        /// <summary>
        /// Возвращает значение, указывающее, можно ли использовать ключ в качестве получателя для шифрования.
        /// </summary>
        public bool CanEncrypt { get; internal set; }
        /// <summary>
        /// Возвращает значение, указывающее, можно ли использовать ключ для подписи данных.
        /// </summary>
        public bool CanSign { get; internal set; }
        /// <summary>
        /// Возвращает значение, указывающее, можно ли использовать ключ для сертификации других ключей и манипулирования подразделами.
        /// </summary>
        public bool CanCertify { get; internal set; }
        /// <summary>
        /// Возвращает значение, указывающее, можно ли использовать ключ для аутентификации.
        /// </summary>
        public bool CanAuthenticate { get; internal set; }
        /// <summary>
        /// Возвращает значение, указывающее, можно ли использовать 
		/// ключ для квалифицированных подписей в соответствии с правилами местного самоуправления.
        /// </summary>
        public bool IsQualified { get; internal set; }
        /// <summary>
        /// Возвращает значение, указывающее, является ли ключ секретным ключом.
        /// </summary>
        public bool Secret { get; internal set; }
        /// <summary>
        /// Возвращает протокол, поддерживаемый текущим <см. cref="GpgKey"/>.
        /// </summary>
        public GpgMeProtocol Protocol { get; internal set; }
        /// <summary>
        /// Возвращает серийный номер эмитента для текущего <см. cref="GpgKey"/>.
        /// </summary>
        public string IssuerSerial { get; internal set; }
        /// <summary>
        /// Возвращает имя эмитента для текущего <см. cref="GpgKey"/>.
        /// </summary>
        public string IssuerName { get; internal set; }
        /// <summary>
        /// Если <см. cref="Protocol"/> - это протокол.Cms, 
        /// получает идентификатор цепочки; который может быть использован для построения цепочки сертификатов.
        /// </summary>
        public string ChainId { get; internal set; }
        /// <summary>
        /// Если <см. cref="Protocol"/> - это протокол.OpenPGP, получает доверие владельца к этому ключу.
        /// </summary>
        public GpgValidity OwnerTrust { get; internal set; }
        /// <summary>
        /// Возвращает подразделы, принадлежащие текущему <см. cref="GpgKey"/>.
        /// </summary>
        public GpgSubkey[] Subkeys { get; internal set; }
        /// <summary>
        /// Возвращает идентификаторы пользователей, которые считаются владельцами текущего <см. cref="GpgKey"/>.
        /// </summary>
        public GpgUserId[] Uids { get; internal set; }
        /// <summary>
        /// Получает отпечаток первичного ключа. Это копия отпечатка пальца первого <см. cref="GpgSubkey"/>.
        /// Для неполного ключа (например, из результата проверки) 
        /// подраздел может отсутствовать, но, тем не менее, это поле может быть установлено.
        /// </summary>
        public string Fingerprint { get; internal set; }

		internal GpgKey(IntPtr handle)
		{
			var c = CultureInfo.CurrentCulture.IsNeutralCulture;
			Handle = handle;
		}

        /// <summary>
        /// Возвращает строку, представляющую текущий объект.
        /// </summary>
        public override string ToString() =>
			$"{Fingerprint}" +
			$"{(Revoked ? " !REV" : "")}" +
			$"{(Expired ? " !EXP" : "")}" +
			$" [{(CanEncrypt ? "E" : "")}" +
			$"{(CanSign ? "S" : "")}" +
			$"{(CanCertify ? "C" : "")}" +
			$"{(CanAuthenticate ? "A" : "")}]" +
			$" [{Protocol}] [{OwnerTrust}]";
	}
}
