namespace Gpg.NET
{
    /// <summary>
    /// ������������ ������������� ������������ GPG, ������� �������� ����������� ����� GPG
    /// � ������ ����� ����� ���� ����� ��������������� ������������. 
	/// ������ � ������ �������� �������� (��� primary) ������������� ������������.
    /// </summary>
    public class GpgUserId
	{
        /// <summary>
        /// ���������� ���������������� �������� �������������� ������������.
        /// </summary>
        public GpgValidity Validity { get; internal set; }
        /// <summary>
        /// ���������� ������ �������������� ������������.
        /// </summary>
        public string Uid { get; internal set; }
        /// <summary>
        /// ���������� ��������� name �������� �������������� ������������, ���� ������� �������.
        /// </summary>
        public string Name { get; internal set; }
        /// <summary>
        /// ���������� ��������� ����������� ����� �������� �������������� ������������, ���� ������� �������.
        /// </summary>
        public string Email { get; internal set; }
        /// <summary>
        /// ���������� ��������� ����������� �������� �������������� ������������, ���� ������� �������.
        /// </summary>
        public string Comment { get; internal set; }
        /// <summary>
        /// �������� ����� ����������� ����� (addr-spec �� RFC-5322) ������ �������������� ������������.
        /// ������ ��� �� �� �����, ��� � <��. cref="Email"/>, �� ����� ������� ����������.
        /// </summary>
        public string Address { get; internal set; }

        /// <summary>
        /// ���������� ��������� ������������� �������� �������.
		/// </summary>
		public override string ToString()
		{
			return $"{Uid} ({Validity})";
		}
	}
}