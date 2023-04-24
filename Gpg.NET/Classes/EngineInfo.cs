namespace Gpg.NET
{
    /// <summary>
    /// Содержит информацию о движке GPG.
    /// </summary>
    public class EngineInfo
	{
        /// <summary>
        /// Получает протокол, для которого используется движок.
        /// </summary>
        public GpgMeProtocol Protocol { get; }
        /// <summary>
        /// Получает имя файла исполняемого файла
        /// </summary>
        public string Filename { get; }
        /// <summary>
        /// Возвращает имя каталога конфигурации движка. Если оно равно null, то используется каталог по умолчанию.
        /// </summary>
        public string HomeDir { get; }
        /// <summary>
        /// Получает номер версии движка.
        /// </summary>
        public string Version { get; }
        /// <summary>
        /// Возвращает минимально необходимый номер версии движка для корректной работы GpgME.
        /// </summary>
        public string ReqVersion { get; }

		internal EngineInfo(GpgMeProtocol protocol, string filename, string homeDir, string version, string reqVersion)
		{
			Protocol = protocol;
			Filename = filename;
			HomeDir = homeDir;
			Version = version;
			ReqVersion = reqVersion;
		}

        /// <summary>
        /// Возвращает строку, представляющую текущий объект.
        /// </summary>
        public override string ToString()
		{
			return $"{Protocol} ver: \"{Version}\" req: \"{ReqVersion}\" home: \"{HomeDir}\" filename: \"{Filename}\"";
		}
	}
}
