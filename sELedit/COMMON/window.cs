using System.Text;

namespace sELedit
{
	public class window
	{
		public int id;
		public int id_parent;
		public int talk_text_len;
		public byte[] talk_text;
		public string GetText()
		{
			Encoding enc = Encoding.GetEncoding("Unicode");
			return enc.GetString(talk_text);
		}
		public void SetText(string Value)
		{
			Encoding enc = Encoding.GetEncoding("Unicode");
			talk_text = enc.GetBytes(Value + (char)0);
			talk_text_len = talk_text.Length / 2;
		}
		public int num_option;
		public option[] options;
	}
}
