using System;
using System.Runtime.InteropServices;

namespace Gpg.NET.Interop
{
	[StructLayout(LayoutKind.Explicit, CharSet = CharSet.Ansi)]
	struct GpgMeSigNotation
	{
		[FieldOffset(0)]
		public IntPtr Next;
		[FieldOffset(4)]
		public string Name;
		[FieldOffset(8)]
		public string Value;

        // два поля длины расположены со смещением 12 и 16,
        // которые можно игнорировать, поскольку длина является внутренним параметром
        // свойство строк C#.
        [FieldOffset(20)]
		public GpgMeSigNotationFlags NotationFlags;
		[FieldOffset(40)]
        // Несколько флагов упакованы в одно 32-разрядное целое число,
        // поэтому здесь мы явно определяем его размер.
        public UInt32 Flags;
	}
}