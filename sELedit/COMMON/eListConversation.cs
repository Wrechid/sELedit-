using System.IO;

namespace sELedit
{
	public class eListConversation
	{
		public int talk_proc_count;
		public talk_proc[] talk_procs;

		public eListConversation(byte[] Bytes)
		{
			MemoryStream ms = new MemoryStream(Bytes);
			BinaryReader br = new BinaryReader(ms);
			talk_proc_count = br.ReadInt32();
			talk_procs = new talk_proc[talk_proc_count];
			for (int d = 0; d < talk_proc_count; d++)
			{
				talk_procs[d] = new talk_proc();
				talk_procs[d].id_talk = br.ReadInt32();
				talk_procs[d].text = br.ReadBytes(128);
				talk_procs[d].num_window = br.ReadInt32();
				talk_procs[d].windows = new window[talk_procs[d].num_window];
				for (int q = 0; q < talk_procs[d].num_window; q++)
				{
					talk_procs[d].windows[q] = new window();
					talk_procs[d].windows[q].id = br.ReadInt32();
					talk_procs[d].windows[q].id_parent = br.ReadInt32();
					talk_procs[d].windows[q].talk_text_len = br.ReadInt32();
					talk_procs[d].windows[q].talk_text = br.ReadBytes(2 * talk_procs[d].windows[q].talk_text_len);
					talk_procs[d].windows[q].num_option = br.ReadInt32();
					talk_procs[d].windows[q].options = new option[talk_procs[d].windows[q].num_option];
					for (int c = 0; c < talk_procs[d].windows[q].num_option; c++)
					{
						talk_procs[d].windows[q].options[c] = new option();
						talk_procs[d].windows[q].options[c].param = br.ReadInt32();
						talk_procs[d].windows[q].options[c].text = br.ReadBytes(128);
						talk_procs[d].windows[q].options[c].id = br.ReadInt32();
					}
				}
			}
			br.Close();
			ms.Close();
		}

		public byte[] GetBytes()
		{
			MemoryStream ms = new MemoryStream(talk_proc_count);
			BinaryWriter bw = new BinaryWriter(ms);

			bw.Write(talk_proc_count);
			for (int d = 0; d < talk_proc_count; d++)
			{
				bw.Write(talk_procs[d].id_talk);
				bw.Write(talk_procs[d].text);
				bw.Write(talk_procs[d].num_window);
				for (int q = 0; q < talk_procs[d].num_window; q++)
				{
					bw.Write(talk_procs[d].windows[q].id);
					bw.Write(talk_procs[d].windows[q].id_parent);
					bw.Write(talk_procs[d].windows[q].talk_text_len);
					bw.Write(talk_procs[d].windows[q].talk_text);
					bw.Write(talk_procs[d].windows[q].num_option);
					for (int c = 0; c < talk_procs[d].windows[q].num_option; c++)
					{
						bw.Write(talk_procs[d].windows[q].options[c].param);
						bw.Write(talk_procs[d].windows[q].options[c].text);
						bw.Write(talk_procs[d].windows[q].options[c].id);
					}
				}
			}

			byte[] result = ms.ToArray();
			bw.Close();
			ms.Close();
			return result;
		}
	}
}
