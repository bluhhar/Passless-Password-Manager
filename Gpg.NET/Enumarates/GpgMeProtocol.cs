namespace Gpg.NET
{
    /// <summary>
    /// Задает набор возможных значений протокола, поддерживаемых GpgME.
    /// </summary>
    public enum GpgMeProtocol
	{
        /// <summary>
        /// Протокол OpenPGP.
        /// </summary>
        OpenPgp,
        /// <summary>
        /// Синтаксис криптографического сообщения.
        /// </summary>
        Cms,
        /// <summary>
        /// Находится в стадии разработки 
        /// </summary>
        GpgConf,
        /// <summary>
        /// Необработанный ассуанский протокол.
        /// </summary>
        Assuan,
        /// <summary>
        /// Находится в стадии разработки  
        /// </summary>
        G13,
        /// <summary>
        /// Находится в стадии разработки 
        /// </summary>
        UiServer,
        /// <summary>
        /// Специальный протокол, используемый для запуска процессов.
        /// </summary>
        Spawn
    }
}
