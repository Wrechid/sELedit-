using System;
using System.Text;

namespace sELedit
{
	public class option
	{
		public int param;
		public byte[] text;
		public string GetText()
		{
			Encoding enc = Encoding.GetEncoding("Unicode");
			return enc.GetString(text);
		}
		public void SetText(string Value)
		{
			Encoding enc = Encoding.GetEncoding("Unicode");
			byte[] target = new byte[128];
			byte[] source = enc.GetBytes(Value);
			if (target.Length > source.Length)
			{
				Array.Copy(source, target, source.Length);
			}
			else
			{
				Array.Copy(source, target, target.Length);
			}
			text = target;
		}
		public int id;
	}
}
