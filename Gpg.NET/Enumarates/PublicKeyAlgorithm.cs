using System;

namespace Gpg.NET
{
    /// <summary>
    /// ����������� ��������� � �������� ������, �������������� GpgME.
    /// </summary>
    public enum PublicKeyAlgorithm
	{
        /// <summary>
        /// ����������� ��������.
        /// </summary>
        Unknown = 0,
        /// <summary>
        /// �������� RSA (������, �����, �������).
        /// </summary>
        RSA = 1,
        /// <summary>
        /// �������� RSA ������������ ������ ��� ���������� � ������������.
        /// </summary>
        [Obsolete]
		RsaE = 2,
        /// <summary>
        /// �������� RSA, ������ ��� ������� � �����������.
        /// </summary>
        [Obsolete]
		RsaS = 3,
        /// <summary>
        /// ����� ��������� �� Elgamal � ������������ ���������� � GnuPG.
        /// </summary>
        ElgamalE = 16,
        /// <summary>
        /// DSA (�������� �������� �������).
		/// </summary>
		DSA = 17,
        /// <summary>
        /// ������������� ��������� ��� ���������� ���������� ������������� ������.
        /// </summary>
        ECC = 18,
        /// <summary>
        /// ��������.
        /// </summary>
        Elgamal = 20,
        /// <summary>
        /// �������� �������� ������� � ������������� ������, ������������ FIPS 186-2 � RFC-6637.
        /// </summary>
        ECDSA = 301,
        /// <summary>
        /// ������������� ������ �����-��������, ������������ � RFC-6637
        /// </summary>
        ECDH = 302,
        /// <summary>
        /// �������� Edwards DSA.
        /// </summary>
        EdDSA = 303
	}
}