using System;

namespace Gpg.NET
{
    /// <summary>
    /// ���������� ��������� �������� ������������ ������.
    /// </summary>
    [Flags]
	public enum GpgArmorMode
	{
        /// <summary>
        /// ����������� ��� �� �������� ���������.
        /// </summary>
        Off = 0,
        /// <summary>
        /// ������� ����� � ������� ������ ��� ������.
        /// </summary>
        On = 1
	}
}