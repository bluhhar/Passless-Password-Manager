
namespace Gpg.NET
{
    /// <summary>
    /// ����������� ���������������� ����� ��� ������� � ����.
    /// </summary>
    public enum GpgValidity
	{
        /// <summary>
        /// ����������� ����������������.
        /// </summary>
        Unknown,
        /// <summary>
        /// �������������� ����������������.
        /// </summary>
        Undefined,
        /// <summary>
        /// ������������� ������������ ������� �� �������� ��������������.
        /// </summary>
        Never,
        /// <summary>
        /// ���������� �������������.
        /// </summary>
        Marginal,
        /// <summary>
        /// ������������� ������������ ��������� ������������.
        /// </summary>
        Full,
        /// <summary>
        /// ������������� ����������������.
        /// </summary>
        Ultimate
    }
}