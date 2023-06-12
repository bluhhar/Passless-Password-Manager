using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Gpg.NET.Interop;

namespace Gpg.NET
{
    /// <summary>
    /// Представляет контекст GPG, который может быть настроен для использования определенного протокола
    /// и содержит настройки, связанные с шифрованием и дешифрованием.
    /// </summary>
    public class GpgContext : IDisposable
	{
		internal IntPtr Handle { get; }

        // TODO: ASCII Armor support: https://www.gnupg.org/documentation/manuals/gpgme/ASCII-Armor.html#ASCII-Armor
        // TODO: Protocol selection: https://www.gnupg.org/documentation/manuals/gpgme/Protocol-Selection.html#Protocol-Selection
        // TODO: Sender selection: https://www.gnupg.org/documentation/manuals/gpgme/Setting-the-Sender.html#Setting-the-Sender
        // TODO: Pinentry selection and loopback implementation: https://www.gnupg.org/documentation/manuals/gpgme/Pinentry-Mode.html#Pinentry-Mode
        // TODO: Keylist mode selection: https://www.gnupg.org/documentation/manuals/gpgme/Key-Listing-Mode.html#Key-Listing-Mode
        // TODO: Key creation: https://www.gnupg.org/documentation/manuals/gpgme/Generating-Keys.html#Generating-Keys

        /// <summary>
        /// Возвращает или устанавливает режим отображения ключей, 
		/// используемый в данный момент этим <см. cref="GpgContext"/>.
        /// </summary>
        public GpgKeylistMode KeylistMode
		{
			get
			{
				return GpgMeWrapper.gpgme_get_keylist_mode(Handle);
			}
			set
			{
				ErrorHandler.Check(GpgMeWrapper.gpgme_set_keylist_mode(Handle, value));
			}
		}

        /// <summary>
        /// Возвращает или устанавливает режим ASCII armor, 
		/// используемый в данный момент этим <см. cref="GpgContext"/>.
        /// Преобразует двоичные зашифрованные данные в представление ASCII. По умолчанию выключено.
        /// </summary>
        public GpgArmorMode ArmorMode
		{
			get
			{
				return GpgMeWrapper.gpgme_get_armor(Handle);
			}
			set
			{
				GpgMeWrapper.gpgme_set_armor(Handle, value);
			}
		}

		internal GpgContext(IntPtr handle)
		{
			Handle = handle;
		}

        /// <summary>
        /// Создает новый <см. cref="GpgContext"/> и возвращает его.
        /// </summary>
        /// <returns><см. cref="GpgContext"/>, который был создан.</returns>
        public static GpgContext CreateContext()
		{
			IntPtr handle;
			ErrorHandler.Check(GpgMeWrapper.gpgme_new(out handle));
			return new GpgContext(handle);
		}

        /// <summary>
        /// Расшифровать содержимое буфера данных.
        /// При необходимости пользователю будет предложено ввести пароль с помощью программы pinentry по умолчанию.
        /// </summary>
        /// <param name="cipher">Буфер данных, содержащий данные, подлежащие расшифровке.</param>
        /// <returns>Буфер данных, содержащий данные, подлежащие расшифровке.</returns>
        public GpgBuffer Decrypt(GpgBuffer cipher)
		{
			var output = MemoryGpgBuffer.Create();
			ErrorHandler.Check(GpgMeWrapper.gpgme_op_decrypt(Handle, cipher.Handle, output.Handle));
			output.Position = 0;
			return output;
		}

        /// <summary>
        /// Зашифровать содержимое буфера данных для данного получателя.
        /// </summary>
        /// <param name="plain">Буфер данных, содержащий данные открытого текста, подлежащие шифрованию.</param>
        /// <param name="recipient">Ключ GPG, для которого данные должны быть зашифрованы.</param>
        /// <returns>Буфер данных, содержащий зашифрованные данные.</returns>
        public GpgBuffer Encrypt(GpgBuffer plain, GpgKey recipient)
		{
			return Encrypt(plain, new[] { recipient });
		}

        /// <summary>
        /// Зашифровать содержимое буфера данных для нескольких получателей.
        /// </summary>
        /// <param name="plain">Буфер данных, содержащий данные открытого текста, подлежащие шифрованию.</param>
        /// <param name="recipients">Ключи GPG, для которых данные должны быть зашифрованы.</param>
        /// <param name="encryptFlags">Флаги шифрования, которые будут использоваться.</param>
        /// <returns>Буфер данных, содержащий зашифрованные данные.</returns>
        public GpgBuffer Encrypt(GpgBuffer plain, IEnumerable<GpgKey> recipients, EncryptFlags encryptFlags = EncryptFlags.None)
		{
			// Transform the recipient list into a list of GpgME key handles
			var rcpHandles = recipients.Select(rcp => rcp.Handle).ToArray();
			var output = MemoryGpgBuffer.Create();
			ErrorHandler.Check(GpgMeWrapper.gpgme_op_encrypt(Handle, rcpHandles, encryptFlags, plain.Handle, output.Handle));
			output.Position = 0;
			return output;
		}

        /// <summary>
        /// Получает ключ GPG, связанный с заданным идентификатором ключа.
        /// Этот метод выдаст исключение, если указанный идентификатор ключа соответствует нулю или нескольким ключам.
        /// </summary>
        /// <param name="keyId">Идентификатор ключа запрошенного GPG-ключа.</param>
        /// <exception cref="GpgKeyNotFoundException">
        /// Выдается, когда указанный идентификатор ключа соответствует нулю или нескольким ключам.
        /// </exception>
        public GpgKey GetKey(string keyId)
		{
			var matches = GpgMeHelper.FindKeys(this, keyId, false).ToArray();
			if (matches.Length == 0) throw new GpgKeyNotFoundException("No matches were returned for the given key ID");
			if (matches.Length > 1) throw new GpgKeyNotFoundException("Multiple matches were found for the given key ID");
			return matches[0];
		}
        /// <summary>
        /// Получает ключи GPG, связанные с заданными идентификаторами ключей.
        /// Этот метод выдаст исключение, если какой-либо из заданных 
		/// идентификаторов ключа соответствует нулю или нескольким ключам.
        /// </summary>
        /// <param name="keyIds">Идентификаторы ключей запрошенных GPG-ключей.</param>
        /// <exception cref="GpgKeyNotFoundException">
        /// Выдается, когда один из заданных идентификаторов ключа соответствует нулю или нескольким ключам.
        /// </exception>
        public IEnumerable<GpgKey> GetKeys(IEnumerable<string> keyIds)
		{
			return keyIds.Select(GetKey);
		}

        /// <summary>
        /// Выполняет поиск ключей, соответствующих заданным параметрам поиска.
        /// </summary>
        /// <param name="pattern">Один или несколько идентификаторов ключа GPG для поиска. 
		/// Значение по умолчанию (null) соответствует всем ключам.</param>
        /// <param name="privateOnly">True, если должны быть возвращены только ключи GPG, 
		/// для которых доступен закрытый ключ, в противном случае false.</param>
        /// <returns>Список GPG-ключей, соответствующих заданным параметрам поиска.</returns>
        public IEnumerable<GpgKey> FindKeys(string pattern = null, bool privateOnly = false)
		{
			return GpgMeHelper.FindKeys(this, pattern, privateOnly);
		}

        /// <summary>
        /// Выполняет поиск ключей, соответствующих заданным параметрам поиска, возвращая первый соответствующий ключ.
        /// </summary>
        /// <param name="pattern">Один или несколько идентификаторов ключа GPG для поиска. 
        /// Значение по умолчанию (null) соответствует всем ключам.</param>
        /// <param name="privateOnly">True, если должны быть возвращены только ключи GPG, 
        /// для которых доступен закрытый ключ, в противном случае false.</param>
        /// <returns>Возвращает первый ключ GPG, соответствующий заданным параметрам поиска, или null, если совпадений нет.</returns>
        public GpgKey FindKey(string pattern, bool privateOnly = false)
		{
			return GpgMeHelper.FindKey(this, pattern, privateOnly);
		}

        /// <summary>
        /// Освобождает базовый контекст GPGME.
        /// </summary>
        public void Dispose()
		{
			GpgMeWrapper.gpgme_release(Handle);
		}
	}
}
