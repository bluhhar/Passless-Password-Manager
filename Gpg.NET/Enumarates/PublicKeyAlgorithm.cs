using System;

namespace Gpg.NET
{
    /// <summary>
    /// Перечисляет алгоритмы с открытым ключом, поддерживаемые GpgME.
    /// </summary>
    public enum PublicKeyAlgorithm
	{
        /// <summary>
        /// Неизвестный алгоритм.
        /// </summary>
        Unknown = 0,
        /// <summary>
        /// Алгоритм RSA (Ривест, Шамир, Адлеман).
        /// </summary>
        RSA = 1,
        /// <summary>
        /// Алгоритм RSA предназначен только для шифрования и дешифрования.
        /// </summary>
        [Obsolete]
		RsaE = 2,
        /// <summary>
        /// Алгоритм RSA, только для подписи и верификации.
        /// </summary>
        [Obsolete]
		RsaS = 3,
        /// <summary>
        /// Также указывает на Elgamal и используется специально в GnuPG.
        /// </summary>
        ElgamalE = 16,
        /// <summary>
        /// DSA (алгоритм цифровой подписи).
		/// </summary>
		DSA = 17,
        /// <summary>
        /// Универсальный индикатор для алгоритмов построения эллиптических кривых.
        /// </summary>
        ECC = 18,
        /// <summary>
        /// Эльгамал.
        /// </summary>
        Elgamal = 20,
        /// <summary>
        /// Алгоритм цифровой подписи с эллиптической кривой, определенный FIPS 186-2 и RFC-6637.
        /// </summary>
        ECDSA = 301,
        /// <summary>
        /// Эллиптическая кривая Диффи-Хеллмана, определенная в RFC-6637
        /// </summary>
        ECDH = 302,
        /// <summary>
        /// Алгоритм Edwards DSA.
        /// </summary>
        EdDSA = 303
	}
}