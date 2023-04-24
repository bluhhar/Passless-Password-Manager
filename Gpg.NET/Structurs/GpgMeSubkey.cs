using System;
using System.Runtime.InteropServices;
using Gpg.NET.Utilities;

namespace Gpg.NET.Interop
{
	[StructLayout(LayoutKind.Explicit, CharSet = CharSet.Ansi, Size = 72)]
	internal struct GpgMeSubkey
	{
		[FieldOffset(0)]
		public IntPtr Next;
		[FieldOffset(4)]
		// Несколько флагов упакованы в одно 32-разрядное целое число,
		// поэтому здесь мы явно определяем его размер.
		public UInt32 Flags;
		[FieldOffset(8)]
		public PublicKeyAlgorithm PublicKeyAlgorithm;
		[FieldOffset(12)]
		public int Length;
		[FieldOffset(16)]
		public string KeyId;

        // Скрытое поле расположено со смещением 20 и занимает 17 байт.
        // Это приводит к следующему возможному смещению на 37, но поскольку для этого необходимо
        // чтобы быть кратным 4, мы пропускаем 3 байта и продолжаем с 40.
        [FieldOffset(40)]
		public string Fingerprint;
		[FieldOffset(44)]
        // GpgME определяет их как 32-разрядные целые числа со знаком,
        // однако на самом деле они без знака.
        public uint Timestamp;
		[FieldOffset(48)]
		public uint Expires;
		[FieldOffset(52)]
		public string CardNumber;
		[FieldOffset(56)]
		public string Curve;
		[FieldOffset(60)]
		public string Keygrip;

		public GpgSubkey ToGpgSubkey(IntPtr handle)
		{
			return new GpgSubkey(handle)
			{
                // Считайте логические флаги из поля Flags.
                // Это может не сработать в системах порядкового байта.
                Revoked = ((Flags >> 0) & 1) == 1,
				Expired = ((Flags >> 1) & 1) == 1,
				Disabled = ((Flags >> 2) & 1) == 1,
				Invalid = ((Flags >> 3) & 1) == 1,
				CanEncrypt = ((Flags >> 4) & 1) == 1,
				CanSign = ((Flags >> 5) & 1) == 1,
				CanCertify = ((Flags >> 6) & 1) == 1,
				Secret = ((Flags >> 7) & 1) == 1,
				CanAuthenticate = ((Flags >> 8) & 1) == 1,
				IsQualified = ((Flags >> 9) & 1) == 1,
				IsCardkey = ((Flags >> 10) & 1) == 1,
				PublicKeyAlgorithm = PublicKeyAlgorithm,
				Length = Length,
				KeyId = KeyId,
				Fingerprint = Fingerprint,
				Created = Helpers.DateTimeFromEpochTime(Timestamp),
				Expires = Helpers.DateTimeFromEpochTime(Expires),
				CardNumber = CardNumber,
				Curve = Curve,
				Keygrip = Keygrip
			};
		}
	}
}
