using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace Gpg.NET.Interop
{
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
	internal struct GpgMeEngineInfo
	{
		public IntPtr Next;
		public GpgMeProtocol Protocol;
		public string Filename;
		public string Version;
		public string ReqVersion;
		public string HomeDir;

		public IEnumerable<EngineInfo> ToEnumerable()
		{
            // Сначала возвращаем текущий движок
            yield return ToEngineInfo();
            // Далее выполняем итерацию по связанному списку и верните все остальные движки в списке
            var currentPtr = Next;
			while (currentPtr != IntPtr.Zero)
			{
				var currentStructure = Marshal.PtrToStructure<GpgMeEngineInfo>(currentPtr);
				currentPtr = currentStructure.Next;
				yield return currentStructure.ToEngineInfo();
			}
		}

		public List<EngineInfo> ToList()
		{
			return ToEnumerable().ToList();
		}

		public EngineInfo ToEngineInfo()
		{
			return new EngineInfo(Protocol, Filename, HomeDir, Version, ReqVersion);
		}
	}
}
