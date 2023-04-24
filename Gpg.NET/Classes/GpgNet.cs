using System;
using System.Collections.Generic;
using System.IO;
using Gpg.NET;
using Gpg.NET.Interop;

namespace Gpg.NET
{
    /// <summary>
    /// Используется для настройки и инициализации базовой библиотеки GPGME.
    /// </summary>
    public static class GpgNet
	{
        /// <summary>
        /// Возвращает версию библиотеки GpgME, используемую в данный момент.
        /// </summary>
        public static string Version { get; private set; }
        /// <summary>
        /// Возвращает значение, указывающее, была ли инициализирована базовая библиотека GpgME.
        /// </summary>
        public static bool Initialised { get; private set; }
        /// <summary>
        /// Возвращает список движков GpgME, доступных для использования.
        /// </summary>
        public static IReadOnlyList<EngineInfo> AvailableEngines { get; private set; }

        /// <summary>
        /// Возвращает домашний каталог по умолчанию для GPG.
        /// </summary>
        public static string Homedir { get; private set; }
        /// <summary>
        /// Возвращает каталог конфигурации системы GPG.
        /// </summary>
        public static string Sysconfdir { get; private set; }
        /// <summary>
        /// Возвращает каталог, содержащий двоичные файлы GPG.
        /// </summary>
        public static string Bindir { get; private set; }
        /// <summary>
        /// Возвращает каталог, содержащий библиотеки GPG.
        /// </summary>
        public static string Libdir { get; private set; }
        /// <summary>
        /// Возвращает каталог, содержащий файлы вспомогательной программы GPG.
        /// </summary>
        public static string Libexecdir { get; private set; }
        /// <summary>
        /// Возвращает каталог, содержащий общие данные, используемые GPG.
        /// </summary>
        public static string Datadir { get; private set; }
        /// <summary>
        /// Возвращает каталог, содержащий данные локали, используемые GPG.
        /// </summary>
        public static string Localedir { get; private set; }
        /// <summary>
        /// Возвращает путь к файлу сокета, используемому для подключения к агенту GPG.
        /// </summary>
        public static string AgentSocket { get; private set; }

        /// <summary>
        /// Инициализирует базовую библиотеку GpgME.
        /// </summary>
        /// <param name="dllPath">Если задано, переопределяет расположение библиотеки DLL GpgME по умолчанию.</param>
        /// <param name="installDir">Если задано, переопределяет каталог установки GpgME по умолчанию.
        /// Это должно указывать на каталог bin каталога установки GPG.</param>
        /// <param name="minLibraryVersion">
        /// Минимально необходимая версия GpgME. Установите значение null, чтобы отключить эту проверку версии.
        /// </param>
        /// <param name="minGpgVersion">
        /// Минимально необходимая версия Gpg. Установите значение null, чтобы отключить эту проверку версии.
        /// </param>
        public static void Initialise(string dllPath = null, string installDir = null, string minLibraryVersion = "1.8.0", string minGpgVersion = "2.0.0")
		{
			if (Initialised)
			{
				throw new InvalidOperationException("GpgME has already been initialised.");
			}
			if (dllPath != null)
			{
                // Вручную загрузить GpgME DLL из пользовательского пути
                // вместо того, чтобы позволять Windows искать его.
                Kernel32.Load(dllPath);
			}

			// Глобальные флаги должны быть установлены перед инициализацией
			if (minGpgVersion != null)
			{
				if (GpgMeWrapper.gpgme_set_global_flag("require-gnupg", minGpgVersion) != 0)
				{
					throw new GpgNetException("Failed to set minimum required GnuPG version.");
				}
			}
			if (installDir != null)
			{
				var result = GpgMeWrapper.gpgme_set_global_flag("w32-inst-dir", installDir);
				if (result != 0)
				{
					throw new GpgNetException("Failed to set Win32 install dir.");
				}
			}
            // Проверка версии обязательна, поскольку она инициализирует GpgME
            Version = GpgMeWrapper.gpgme_check_version(minLibraryVersion);
			if (Version == null)
			{
				throw new GpgNetException("Minimum required GpgME version is not met.");
			}

            // Получить информацию о доступных движках GPG
            AvailableEngines = GpgMeHelper.GetEngines();
			// Получить информацию о текущей конфигурации GPG
			Homedir = GpgMeWrapper.gpgme_get_dirinfo("homedir");
			Sysconfdir = GpgMeWrapper.gpgme_get_dirinfo("sysconfdir");
			Bindir = GpgMeWrapper.gpgme_get_dirinfo("bindir");
			Libdir = GpgMeWrapper.gpgme_get_dirinfo("libdir");
			Libexecdir = GpgMeWrapper.gpgme_get_dirinfo("libexecdir");
			Datadir = GpgMeWrapper.gpgme_get_dirinfo("datadir");
			Localedir = GpgMeWrapper.gpgme_get_dirinfo("localedir");
			AgentSocket = GpgMeWrapper.gpgme_get_dirinfo("agent-socket");
			Initialised = true;
		}

        /// <summary>
        /// Гарантирует, что данный протокол доступен. Если это не так, то генерируется исключение.
        /// </summary>
        /// <param name="protocol"><См. cref="GpgMeProtocol"/> для проверки.</param>
        /// <exception cref="GpgMeException">Выбрасывается, если данный протокол недоступен, 
        /// неправильно настроен или иным образом непригоден для использования.</exception>
        public static void EnsureProtocol(GpgMeProtocol protocol)
		{
			ErrorHandler.Check(GpgMeWrapper.gpgme_engine_check_version(protocol));
		}

        /// <summary>
        /// Включите отладку GpgME. Это должно быть сделано до инициализации GpgME.
        /// </summary>
        /// <param name="debugPath">
        /// Путь к файлу debug output должен быть сохранен по адресу. Если для этого параметра по умолчанию установлено значение null,
        /// выходные данные отладки сохраняются в файле с именем <code>gpgme-debug.txt </code> в текущем рабочем каталоге.
        /// </param>
        /// <param name="debugLevel">Уровень детализации GpgME. Большее число увеличивает детализацию.</param>
        public static void EnableDebugging(string debugPath = null, int debugLevel = 9)
		{
			if (Initialised)
			{
				throw new InvalidOperationException("Debugging needs to be enabled before GpgME is initialised.");
			}
			if (debugPath == null)
			{
				debugPath = Path.Combine(Environment.CurrentDirectory, "gpgme-debug.txt");
			}
			if (GpgMeWrapper.gpgme_set_global_flag("debug", $"{debugLevel};{debugPath}") != 0)
			{
				throw new GpgNetException("Failed to enable debugging.");
			}
		}
	}
}
