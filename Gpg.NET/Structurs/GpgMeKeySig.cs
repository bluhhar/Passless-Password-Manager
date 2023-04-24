using System;
using System.Runtime.InteropServices;

namespace Gpg.NET.Interop
{
	[StructLayout(LayoutKind.Explicit, CharSet = CharSet.Ansi, Size = 76)]
	struct GpgMeKeySig
	{
		[FieldOffset(0)]
		public IntPtr Next;
		[FieldOffset(4)]
		public UInt32 Flags;
		[FieldOffset(8)]
		public PublicKeyAlgorithm PublicKeyAlgorithm;
		[FieldOffset(12)]
		public string KeyId;

        // Скрытое поле расположено со смещением 16 и занимает 17 байт.
        // Это приводит к следующему возможному смещению на 33, но поскольку для этого необходимо
        // чтобы быть кратным 4, мы пропускаем 3 байта и продолжаем с 36.
        [FieldOffset(36)]
		public int Timestamp;
		[FieldOffset(40)]
		public int Expires;
		[FieldOffset(44)]
		public GpgMeError Status;

        // Другое скрытое поле расположено со смещением 48
        [FieldOffset(52)]
		public string Uid;
		[FieldOffset(56)]
		public string Name;
		[FieldOffset(60)]
		public string Comment;
		[FieldOffset(64)]
		public uint SigClass;
		[FieldOffset(68)]
		public GpgMeSigNotation Notations;
        // Другое скрытое поле расположено со смещением 72
    }
}
