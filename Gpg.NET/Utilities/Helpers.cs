using System;

namespace Gpg.NET.Utilities
{
	internal static class Helpers
	{
        /// <summary>
        /// Превращает временную метку Unix в объект DateTime.
        /// </summary>
        public static DateTime DateTimeFromEpochTime(long epochTime) => new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddSeconds(epochTime);
	}
}
