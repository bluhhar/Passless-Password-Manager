using System;

namespace Gpg.NET
{
    /// <summary>
    /// Определяет поведение операции перечисления ключей.
    /// </summary>
    [Flags]
	public enum GpgArmorMode
	{
        /// <summary>
        /// Неизвестные или не заданные параметры.
        /// </summary>
        Off = 0,
        /// <summary>
        /// Поищите ключи в местной связке для ключей.
        /// </summary>
        On = 1
	}
}