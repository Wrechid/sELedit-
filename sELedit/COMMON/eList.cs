using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sELedit
{
	public class eList
	{
		public eList()
		{
		}

		public string listName;// -> from config file
		public byte[] listOffset;// -> length from config file, values from elements.data
		public int listType;
		public int elementSize;
		public string[] elementFields;// -> length & values from config file
		public string[] elementTypes;// -> length & values from config file
		public object[][] elementValues;// list.length from elements.data, elements.length from config file

		// return a field of an element in string representation
		public string GetValue(int ElementIndex, int FieldIndex)
		{
			if (FieldIndex > -1)
			{
				object value = elementValues[ElementIndex][FieldIndex];
				string type = elementTypes[FieldIndex];

				if (type == "int16")
				{
					return Convert.ToString((short)value);
				}
				if (type == "int32")
				{
					return Convert.ToString((int)value);
				}
				if (type == "int64")
				{
					return Convert.ToString((long)value);
				}
				if (type == "float")
				{
					//return Convert.ToString((float)value);
					return ((float)value).ToString("F6");
				}
				if (type == "double")
				{
					return Convert.ToString((double)value);
				}
				if (type.Contains("byte:"))
				{
					// Convert from byte[] to Hex String
					byte[] b = (byte[])value;
					return BitConverter.ToString(b);
				}
				if (type.Contains("wstring:"))
				{
					Encoding enc = Encoding.GetEncoding("Unicode");
					return enc.GetString((byte[])value).Split(new char[] { '\0' })[0];
				}
				if (type.Contains("string:"))
				{
					Encoding enc = Encoding.GetEncoding("GBK");
					return enc.GetString((byte[])value).Split(new char[] { '\0' })[0];
				}
			}
			return "";
		}

		public void SetValue(int ElementIndex, int FieldIndex, string Value)
		{
			string type = elementTypes[FieldIndex];

			if (type == "int16")
			{
				elementValues[ElementIndex][FieldIndex] = Convert.ToInt16(Value);
				return;
			}
			if (type == "int32")
			{
				elementValues[ElementIndex][FieldIndex] = Convert.ToInt32(Value);
				return;
			}
			if (type == "int64")
			{
				elementValues[ElementIndex][FieldIndex] = Convert.ToInt64(Value);
				return;
			}
			if (type == "float")
			{
				elementValues[ElementIndex][FieldIndex] = Convert.ToSingle(Value);
				return;
			}
			if (type == "double")
			{
				elementValues[ElementIndex][FieldIndex] = Convert.ToDouble(Value);
				return;
			}
			if (type.Contains("byte:"))
			{
				// Convert from Hex to byte[]
				string[] hex = Value.Split(new char[] { '-' });
				byte[] b = new byte[Convert.ToInt32(type.Substring(5))];
				for (int i = 0; i < hex.Length; i++)
				{
					b[i] = Convert.ToByte(hex[i], 16);
				}
				elementValues[ElementIndex][FieldIndex] = b;
				return;
			}
			if (type.Contains("wstring:"))
			{
				Encoding enc = Encoding.GetEncoding("Unicode");
				byte[] target = new byte[Convert.ToInt32(type.Substring(8))];
				byte[] source = enc.GetBytes(Value);
				if (target.Length > source.Length)
				{
					Array.Copy(source, target, source.Length);
				}
				else
				{
					Array.Copy(source, target, target.Length);
				}
				elementValues[ElementIndex][FieldIndex] = target;
				return;
			}
			if (type.Contains("string:"))
			{
				Encoding enc = Encoding.GetEncoding("GBK");
				byte[] target = new byte[Convert.ToInt32(type.Substring(7))];
				byte[] source = enc.GetBytes(Value);
				if (target.Length > source.Length)
				{
					Array.Copy(source, target, source.Length);
				}
				else
				{
					Array.Copy(source, target, target.Length);
				}
				elementValues[ElementIndex][FieldIndex] = target;
				return;
			}
			return;
		}

		// return the type of the field in string representation
		public string GetType(int FieldIndex)
		{
			if (FieldIndex > -1)
			{
				return elementTypes[FieldIndex];
			}
			return "";
		}

		// delete Item
		public void RemoveItem(int itemIndex)
		{
			object[][] newValues = new object[elementValues.Length - 1][];
			Array.Copy(elementValues, 0, newValues, 0, itemIndex);
			int length = newValues.Length - itemIndex;
			Array.Copy(elementValues, itemIndex + 1, newValues, itemIndex, newValues.Length - itemIndex);
			elementValues = newValues;
		}

		// add Item
		public void AddItem(object[] itemValues)//Вроде работает
		{
			object[][] newValues = new object[elementValues.Length + 1][];
			Array.Resize(ref elementValues, elementValues.Length + 1);
			elementValues[elementValues.Length - 1] = itemValues;
		}

		// export item to unicode textfile
		public void ExportItem(string file, int index)
		{
			System.IO.StreamWriter sw = new System.IO.StreamWriter(file, false, Encoding.Unicode);
			for (int i = 0; i < elementTypes.Length; i++)
			{
				sw.WriteLine(elementFields[i] + "(" + elementTypes[i] + ")=\"" + GetValue(index, i) + "\"");
			}
			sw.Close();
		}

		// import item from unicode textfile
		public void ImportItem(string file, int index)
		{
			System.IO.StreamReader sr = new System.IO.StreamReader(file, Encoding.Unicode);
			for (int i = 0; i < elementTypes.Length; i++)
			{
				string field = sr.ReadLine();
				if (!field.StartsWith("#") && !field.StartsWith("//") && field != "")
				{
					string value = field.Substring(field.IndexOf("=") + 2);
					if (!value.EndsWith("\""))
					{
						string nextValueLine;
						do
						{
							nextValueLine = sr.ReadLine();
							value += "\r\n" + nextValueLine;
						} while (!nextValueLine.EndsWith("\""));
					}
					value = value.Replace("\"", "");
					SetValue(index, i, value);
				}
			}
			sr.Close();
		}

		// add all new elements into the elementValues
		public ArrayList JoinElements(eList newList, int listID, bool addNew, bool backupNew, bool replaceChanged, bool backupChanged, bool removeMissing, bool backupMissing, string dirBackupNew, string dirBackupChanged, string dirBackupMissing)
		{
			object[][] newElementValues = newList.elementValues;
			string[] newElementTypes = newList.elementTypes;

			ArrayList report = new ArrayList();
			bool exists;

			// check which elements are missing (removed)
			for (int n = 0; n < elementValues.Length; n++)
			{
				Application.DoEvents();
				exists = false;
				for (int e = 0; e < newElementValues.Length; e++)
				{
					if (this.GetValue(n, 0) == newList.GetValue(e, 0))
					{
						exists = true;
					}
				}
				if (!exists)
				{
					if (dirBackupMissing != null && System.IO.Directory.Exists(dirBackupMissing))
					{
						ExportItem(dirBackupMissing + "\\List_" + listID.ToString() + "_Item_" + this.GetValue(n, 0) + ".txt", n);
					}
					if (removeMissing)
					{
						report.Add("- MISSING ITEM (*removed): " + ((int)elementValues[n][0]).ToString());
						RemoveItem(n);
						n--;
					}
					else
					{
						report.Add("- MISSING ITEM (*not removed): " + ((int)elementValues[n][0]).ToString());
					}
				}
			}

			for (int e = 0; e < newElementValues.Length; e++)
			{
				Application.DoEvents();
				// check if the element with this id already exists
				exists = false;
				for (int n = 0; n < elementValues.Length; n++)
				{
					if (this.GetValue(n, 0) == newList.GetValue(e, 0))
					{
						exists = true;
						// check if this item is different
						if (this.elementValues[n].Length != newList.elementValues[e].Length)
						{
							// invalid amount of values !!!
							report.Add("<> DIFFERENT ITEM (*not replaced, invalid amount of values): " + this.GetValue(n, 0));
						}
						else
						{
							// compare all values of current element
							for (int i = 0; i < this.elementValues[n].Length; i++)
							{
								if (this.GetValue(n, i) != newList.GetValue(e, i))
								{
									if (backupChanged && System.IO.Directory.Exists(dirBackupChanged))
									{
										ExportItem(dirBackupChanged + "\\List_" + listID.ToString() + "_Item_" + this.GetValue(n, 0) + ".txt", n);
									}
									if (replaceChanged)
									{
										report.Add("<> DIFFERENT ITEM (*replaced): " + this.GetValue(n, 0));
										elementValues[n] = newList.elementValues[e];
									}
									else
									{
										report.Add("<> DIFFERENT ITEM (*not replaced): " + this.GetValue(n, 0));
									}
									break;
								}
							}
						}
						break;
					}
				}
				if (!exists)
				{
					if (backupNew && System.IO.Directory.Exists(dirBackupNew))
					{
						newList.ExportItem(dirBackupNew + "\\List_" + listID.ToString() + "_Item_" + newList.GetValue(e, 0) + ".txt", e);
					}
					if (addNew)
					{
						AddItem(newElementValues[e]);
						report.Add("+ NEW ITEM (*added): " + this.GetValue(elementValues.Length - 1, 0));
					}
					else
					{
						report.Add("+ NEW ITEM (*not added): " + this.GetValue(elementValues.Length - 1, 0));
					}
				}
			}

			return report;
		}
	}
}
