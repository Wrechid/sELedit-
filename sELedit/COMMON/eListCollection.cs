using System;
using System.IO;
using System.Collections;
using System.Text;
using System.Windows.Forms;
using System.Collections.Generic;

namespace sELedit
{
	public class eListCollection
	{
		public eListCollection(string elFile, ref ColorProgressBar.ColorProgressBar cpb2)
		{
			Lists = Load(elFile, ref cpb2);
		}

		public short Version;
		public short Signature;
		public int ConversationListIndex;
		public string ConfigFile;
		public eList[] Lists;
        public IDictionary<int, int> addonIndex = new Dictionary<int, int>(); //itemID list

        public void RemoveItem(int ListIndex, int ElementIndex)
		{
			Lists[ListIndex].RemoveItem(ElementIndex);
		}
		public void AddItem(int ListIndex, object[] ItemValues)
		{
			Lists[ListIndex].AddItem(ItemValues);
		}
		public string GetOffset(int ListIndex)
		{
			return BitConverter.ToString(Lists[ListIndex].listOffset);
		}

		public void SetOffset(int ListIndex, string Offset)
		{
			if (Offset != "")
			{
				// Convert from Hex to byte[]
				string[] hex = Offset.Split(new char[] { '-' });
				Lists[ListIndex].listOffset = new byte[hex.Length];
				for (int i = 0; i < hex.Length; i++)
				{
					Lists[ListIndex].listOffset[i] = Convert.ToByte(hex[i], 16);
				}
			}
			else
			{
				Lists[ListIndex].listOffset = new byte[0];
			}
		}

		public string GetValue(int ListIndex, int ElementIndex, int FieldIndex)
		{
			return Lists[ListIndex].GetValue(ElementIndex, FieldIndex);
		}

		public void SetValue(int ListIndex, int ElementIndex, int FieldIndex, string Value)
		{
			Lists[ListIndex].SetValue(ElementIndex, FieldIndex, Value);
		}

		public string GetType(int ListIndex, int FieldIndex)
		{
			return Lists[ListIndex].GetType(FieldIndex);
		}

		private object readValue(BinaryReader br, string type)
		{
			if (type == "int16")
			{
				return br.ReadInt16();
			}
			if (type == "int32")
			{
				return br.ReadInt32();
			}
			if (type == "int64")
			{
				return br.ReadInt64();
			}
			if (type == "float")
			{
				return br.ReadSingle();
			}
			if (type == "double")
			{
				return br.ReadDouble();
			}
			if (type.Contains("byte:"))
			{
				return br.ReadBytes(Convert.ToInt32(type.Substring(5)));
			}
			if (type.Contains("wstring:"))
			{
				return br.ReadBytes(Convert.ToInt32(type.Substring(8)));
			}
			if (type.Contains("string:"))
			{
				return br.ReadBytes(Convert.ToInt32(type.Substring(7)));
			}
			return null;
		}

		private void writeValue(BinaryWriter bw, object value, string type)
		{
			if (type == "int16")
			{
				bw.Write((short)value);
				return;
			}
			if (type == "int32")
			{
				bw.Write((int)value);
				return;
			}
			if (type == "int64")
			{
				bw.Write((long)value);
				return;
			}
			if (type == "float")
			{
				bw.Write((float)value);
				return;
			}
			if (type == "double")
			{
				bw.Write((double)value);
				return;
			}
			if (type.Contains("byte:"))
			{
				bw.Write((byte[])value);
				return;
			}
			if (type.Contains("wstring:"))
			{
				bw.Write((byte[])value);
				return;
			}
			if (type.Contains("string:"))
			{
				bw.Write((byte[])value);
				return;
			}
		}

		// returns an eList array with preconfigured fields from configuration file
		private eList[] loadConfiguration(string file)
		{
			StreamReader sr = new StreamReader(file);
			eList[] Li = new eList[Convert.ToInt32(sr.ReadLine())];
			try
			{
				ConversationListIndex = Convert.ToInt32(sr.ReadLine());
			}
			catch
			{
				ConversationListIndex = 58;
			}
			string line;
			for (int i = 0; i < Li.Length; i++)
			{
				System.Windows.Forms.Application.DoEvents();

				while ((line = sr.ReadLine()) == "")
				{
				}
				Li[i] = new eList();
				Li[i].listName = line;
				Li[i].listOffset = null;
				string offset = sr.ReadLine();
				if (offset != "AUTO")
				{
					Li[i].listOffset = new byte[Convert.ToInt32(offset)];
				}
				Li[i].elementFields = sr.ReadLine().Split(new char[] { ';' });
				Li[i].elementTypes = sr.ReadLine().Split(new char[] { ';' });
			}
			sr.Close();

			return Li;
		}
		private Hashtable loadRules(string file)
		{
			StreamReader sr = new StreamReader(file);
			Hashtable result = new Hashtable();
			string key = "";
			string value = "";
			string line;
			while (!sr.EndOfStream)
			{
				line = sr.ReadLine();
				System.Windows.Forms.Application.DoEvents();

				if (line != "" && !line.StartsWith("#"))
				{
					if (line.Contains("|"))
					{
						key = line.Split(new char[] { '|' })[0];
						value = line.Split(new char[] { '|' })[1];
					}
					else
					{
						key = line;
						value = "";
					}
					result.Add(key, value);
				}
			}
			sr.Close();

			if (!result.ContainsKey("SETCONVERSATIONLISTINDEX"))
				result.Add("SETCONVERSATIONLISTINDEX", 58);

			return result;
		}

        public static SortedList Listcnts;
        public static SortedList ListOsets;
        public static short Listver;
        public static int[] SStat;

        // only works for PW !!!
        public eList[] Load(string elFile, ref ColorProgressBar.ColorProgressBar cpb2)
		{
			eList[] Li = new eList[0];
            addonIndex = new Dictionary<int, int>();

            Listcnts = null;
            ListOsets = null;
            Listver = -1;
            SStat = new int[5] { 0, 0, 0, 0, 0 };

            string fileStream = Path.GetDirectoryName(elFile) + "\\elements.list.count";
            if (File.Exists(fileStream))
            {
                Listcnts = new SortedList();
                ListOsets = new SortedList();
                using (StreamReader reader = new StreamReader(fileStream))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] val = line.Split('=');
                        if (val[0] == "ver") { Listver = Convert.ToInt16(val[1]); }
                        else if (val[0] == "offset") { ListOsets.Add(val[1], val[2]); }
                        else { Listcnts.Add(val[0], val[1]); }
                    }
                }
            }

            // open the element file
            FileStream fs = File.OpenRead(elFile);
			BinaryReader br = new BinaryReader(fs);

			Version = br.ReadInt16();
            if (Listver > -1) { Version = Listver; }
			Signature = br.ReadInt16();

			// check if a corresponding configuration file exists
			string[] configFiles = Directory.GetFiles(Application.StartupPath + "\\configs", "PW_*_v" + Version + ".cfg");
			if (configFiles.Length > 0)
			{
				// configure an eList array with the configuration file
				ConfigFile = configFiles[0];
				Li = loadConfiguration(ConfigFile);
				cpb2.Maximum = Li.Length;
                cpb2.Value = 0;

				// read the element file
				for (int l = 0; l < Li.Length; l++)
				{
                    SStat[0] = l;
                    Application.DoEvents();

					// read offset
					if (Li[l].listOffset != null)
					{
						// offset > 0
						if (Li[l].listOffset.Length > 0)
						{
							Li[l].listOffset = br.ReadBytes(Li[l].listOffset.Length);
						}
					}
					// autodetect offset (for list 20 & 100)
					else
					{
						if (l == 0)
						{
							byte[] t = br.ReadBytes(4);
							byte[] len = br.ReadBytes(4);
							byte[] buffer = br.ReadBytes(BitConverter.ToInt32(len, 0));
							Li[l].listOffset = new byte[t.Length + len.Length + buffer.Length];
							Array.Copy(t, 0, Li[l].listOffset, 0, t.Length);
							Array.Copy(len, 0, Li[l].listOffset, 4, len.Length);
							Array.Copy(buffer, 0, Li[l].listOffset, 8, buffer.Length);
						}
						if (l == 20)
						{
							byte[] tag = br.ReadBytes(4);
							byte[] len = br.ReadBytes(4);
							byte[] buffer = br.ReadBytes(BitConverter.ToInt32(len, 0));
							byte[] t = br.ReadBytes(4);
							Li[l].listOffset = new byte[tag.Length + len.Length + buffer.Length + t.Length];
							Array.Copy(tag, 0, Li[l].listOffset, 0, tag.Length);
							Array.Copy(len, 0, Li[l].listOffset, 4, len.Length);
							Array.Copy(buffer, 0, Li[l].listOffset, 8, buffer.Length);
							Array.Copy(t, 0, Li[l].listOffset, 8 + buffer.Length, t.Length);
						}
						int NPC_WAR_TOWERBUILD_SERVICE_index = 100;
						if (Version >= 191)
							NPC_WAR_TOWERBUILD_SERVICE_index = 99;
						if (l == NPC_WAR_TOWERBUILD_SERVICE_index)
						{
							byte[] tag = br.ReadBytes(4);
							byte[] len = br.ReadBytes(4);
							byte[] buffer = br.ReadBytes(BitConverter.ToInt32(len, 0));
							Li[l].listOffset = new byte[tag.Length + len.Length + buffer.Length];
							Array.Copy(tag, 0, Li[l].listOffset, 0, tag.Length);
							Array.Copy(len, 0, Li[l].listOffset, 4, len.Length);
							Array.Copy(buffer, 0, Li[l].listOffset, 8, buffer.Length);
						}
					}

					// read conversation list
					if (l == ConversationListIndex)
					{
						if (Version >= 191)
						{
							long sourcePosition = br.BaseStream.Position;
							int listLength = 0;
							bool run = true;
							while (run)
							{
								run = false;
								try
								{
									br.ReadByte();
									listLength++;
									run = true;
								}
								catch
								{ }
							}
							br.BaseStream.Position = sourcePosition;
							Li[l].elementTypes[0] = "byte:" + listLength;
						}
						else
						{
							// Auto detect only works for Perfect World elements.data !!!
							if (Li[l].elementTypes[0].Contains("AUTO"))
							{
								byte[] pattern = (Encoding.GetEncoding("GBK")).GetBytes("facedata\\");
								long sourcePosition = br.BaseStream.Position;
								int listLength = -72 - pattern.Length;
								bool run = true;
								while (run)
								{
									run = false;
									for (int i = 0; i < pattern.Length; i++)
									{
										listLength++;
										if (br.ReadByte() != pattern[i])
										{
											run = true;
											break;
										}
									}
								}
								br.BaseStream.Position = sourcePosition;
								Li[l].elementTypes[0] = "byte:" + listLength;
							}
						}

						Li[l].elementValues = new object[1][];
						Li[l].elementValues[0] = new object[Li[l].elementTypes.Length];
						Li[l].elementValues[0][0] = readValue(br, Li[l].elementTypes[0]);
					}
					// read lists
					else
					{
						if (Version >= 191)
						{
							Li[l].listType = br.ReadInt32();
						}
                        if (Listver > -1 && Listcnts[l.ToString()] != null)
                        {
                            int num = Convert.ToInt32(Listcnts[l.ToString()]);
                            Li[l].elementValues = new object[num][];
                            br.ReadBytes(4);
                        }
                        else
                        {
                            Li[l].elementValues = new object[br.ReadInt32()][];
                        }

                        SStat[1] = Li[l].elementValues.Length;

                        if (Version >= 191)
						{
							Li[l].elementSize = br.ReadInt32();
						}

						// go through all elements of a list
						for (int e = 0; e < Li[l].elementValues.Length; e++)
						{
							Li[l].elementValues[e] = new object[Li[l].elementTypes.Length];

                            // go through all fields of an element
                            int idtest = -1;
                            for (int f = 0; f < Li[l].elementValues[e].Length; f++)
							{
								Li[l].elementValues[e][f] = readValue(br, Li[l].elementTypes[f]);
                                if (Li[l].elementFields[f] == "ID")
                                {
                                    idtest = Int32.Parse(Li[l].GetValue(e, f));
                                    SStat[2] = idtest;
                                    if (l == 0)
                                    {
                                        if (!addonIndex.ContainsKey(idtest))
                                        {
                                            addonIndex.Add(idtest, e);
                                        }
                                        else
                                        {
                                            MessageBox.Show("Error: Found duplicate Addon id:" + idtest);
                                            addonIndex[idtest] = e;
                                        }
                                    }
                                }
                            }
						}
					}
                    cpb2.Value++;
				}
			}
			else
			{
				MessageBox.Show("No corressponding configuration file found!\nVersion: " + Version + "\nPattern: " + "configs\\PW_*_v" + Version + ".cfg");
			}

			br.Close();
			fs.Close();

			return Li;
		}

		public void Save(string elFile)
		{
			if (File.Exists(elFile))
			{
				File.Delete(elFile);
			}

			FileStream fs = new FileStream(elFile, FileMode.Create, FileAccess.Write);
			BinaryWriter bw = new BinaryWriter(fs);

			bw.Write(Version);
			bw.Write(Signature);

			// go through all lists
			for (int l = 0; l < Lists.Length; l++)
			{
				System.Windows.Forms.Application.DoEvents();

				if (Lists[l].listOffset.Length > 0)
				{
					bw.Write(Lists[l].listOffset);
				}

				if (l != ConversationListIndex)
				{
					if (Version >= 191)
					{
						bw.Write(Lists[l].listType);
					}

					bw.Write(Lists[l].elementValues.Length);

					if (Version >= 191)
					{
						bw.Write(Lists[l].elementSize);
					}
				}

				// go through all elements of a list
				for (int e = 0; e < Lists[l].elementValues.Length; e++)
				{
					// go through all fields of an element
					for (int f = 0; f < Lists[l].elementValues[e].Length; f++)
					{
						writeValue(bw, Lists[l].elementValues[e][f], Lists[l].elementTypes[f]);
					}
				}
			}
			bw.Close();
			fs.Close();
		}

		public void Export(string RulesFile, string TargetFile)
		{
			// Load the rules
			Hashtable rules = loadRules(RulesFile);


			if (File.Exists(TargetFile))
			{
				File.Delete(TargetFile);
			}

			FileStream fs = new FileStream(TargetFile, FileMode.Create, FileAccess.Write);
			BinaryWriter bw = new BinaryWriter(fs);

			if (rules.ContainsKey("SETVERSION"))
			{
				bw.Write(Convert.ToInt16((string)rules["SETVERSION"]));
			}
			else
			{
				MessageBox.Show("Rules file is missing parameter\n\nSETVERSION:", "Export Failed");
				bw.Close();
				fs.Close();
				return;
			}

			if (rules.ContainsKey("SETSIGNATURE"))
			{
				bw.Write(Convert.ToInt16((string)rules["SETSIGNATURE"]));
			}
			else
			{
				MessageBox.Show("Rules file is missing parameter\n\nSETSIGNATURE:", "Export Failed");
				bw.Close();
				fs.Close();
				return;
			}
			// go through all lists
			for (int l = 0; l < Lists.Length; l++)
			{
				if (Convert.ToInt16((string)rules["SETCONVERSATIONLISTINDEX"]) == l)
				{
					for (int e = 0; e < Lists[ConversationListIndex].elementValues.Length; e++)
					{
						// go through all fields of an element
						for (int f = 0; f < Lists[ConversationListIndex].elementValues[e].Length; f++)
						{
							System.Windows.Forms.Application.DoEvents();

							writeValue(bw, Lists[ConversationListIndex].elementValues[e][f], Lists[ConversationListIndex].elementTypes[f]);
						}
					}
				}
				if (l != ConversationListIndex)
				{
					if (!rules.ContainsKey("REMOVELIST:" + l))
					{

						if (rules.ContainsKey("REPLACEOFFSET:" + l))
						{
							// Convert from Hex to byte[]
							string[] hex = ((string)rules["REPLACEOFFSET:" + l]).Split(new char[] { '-', ' ' });
							if (hex.Length > 1)
							{
								byte[] b = new byte[hex.Length];
								for (int i = 0; i < hex.Length; i++)
								{
									b[i] = Convert.ToByte(hex[i], 16);
								}
								if (b.Length > 0)
								{
									bw.Write(b);
								}
							}
						}
						else
						{
							if (Lists[l].listOffset.Length > 0)
							{
								bw.Write(Lists[l].listOffset);
							}
						}

						if (Convert.ToInt16((string)rules["SETVERSION"]) >= 191)
						{
							bw.Write(Lists[l].listType);
						}

						bw.Write(Lists[l].elementValues.Length);

						if (Convert.ToInt16((string)rules["SETVERSION"]) >= 191)
						{
							bw.Write(Lists[l].elementSize);
						}

						// go through all elements of a list
						for (int e = 0; e < Lists[l].elementValues.Length; e++)
						{
							// go through all fields of an element
							for (int f = 0; f < Lists[l].elementValues[e].Length; f++)
							{
								System.Windows.Forms.Application.DoEvents();

								if (!rules.ContainsKey("REMOVEVALUE:" + l + ":" + f))
								{
									writeValue(bw, Lists[l].elementValues[e][f], Lists[l].elementTypes[f]);
								}
							}
						}
					}
				}
			}
			bw.Close();
			fs.Close();
		}
	}
}
