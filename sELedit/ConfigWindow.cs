using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sELedit
{

    public struct ScanInfo
	{
		public int ElementCount;
		public int FirstElementID;
		public int SecondElementID;
		public int EntrySizePrior;
		public int EntrySizeEstimated;
	}

	public partial class ConfigWindow : Form
	{
		int conversationListIndex;
		string loadedConfFileName;
		string[] listNames;
		string[] listOffsets;
		string[][] fieldNames;
		string[][] fieldTypes;
		string[] CopyfieldNames;
		string[] CopyfieldTypes;
        private static CacheSave database = new CacheSave();

        public ConfigWindow()
		{
			InitializeComponent();
            database = MainWindow.database;
            colorTheme();
		}

        private void colorTheme()
        {
            if (database.arrTheme != null)
            {
                comboBox_lists.DrawMode = DrawMode.OwnerDrawFixed;
                comboBox_lists.FlatStyle = FlatStyle.Flat;

                menuStrip_mainMenu.RenderMode = ToolStripRenderMode.Professional;

                BackColor = Color.FromName(database.arrTheme[0]);

                label1.ForeColor = Color.FromName(database.arrTheme[1]);
                label2.ForeColor = Color.FromName(database.arrTheme[1]);
                label3.ForeColor = Color.FromName(database.arrTheme[1]);
                label4.ForeColor = Color.FromName(database.arrTheme[1]);

                menuStrip_mainMenu.BackColor = Color.FromName(database.arrTheme[2]);
                textBox_conversationListIndex.BackColor = Color.FromName(database.arrTheme[6]);
                textBox_listName.BackColor = Color.FromName(database.arrTheme[6]);
                textBox_offset.BackColor = Color.FromName(database.arrTheme[6]);
                textBox_SetName.BackColor = Color.FromName(database.arrTheme[6]);
                textBox_SetType.BackColor = Color.FromName(database.arrTheme[6]);
                comboBox_lists.BackColor = Color.FromName(database.arrTheme[7]);

                textBox_conversationListIndex.ForeColor = Color.FromName(database.arrTheme[1]);
                textBox_listName.ForeColor = Color.FromName(database.arrTheme[1]);
                textBox_offset.ForeColor = Color.FromName(database.arrTheme[1]);
                textBox_SetName.ForeColor = Color.FromName(database.arrTheme[1]);
                textBox_SetType.ForeColor = Color.FromName(database.arrTheme[1]);

                dataGridView_item.BackgroundColor = Color.FromName(database.arrTheme[12]);
                dataGridView_item.ColumnHeadersDefaultCellStyle.BackColor = Color.FromName(database.arrTheme[13]);
                dataGridView_item.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromName(database.arrTheme[1]);
                dataGridView_item.RowHeadersDefaultCellStyle.BackColor = Color.FromName(database.arrTheme[13]);
                dataGridView_item.DefaultCellStyle.BackColor = Color.FromName(database.arrTheme[13]);
                dataGridView_item.DefaultCellStyle.SelectionBackColor = Color.FromName(database.arrTheme[14]);
                dataGridView_item.RowHeadersDefaultCellStyle.SelectionBackColor = Color.FromName(database.arrTheme[14]);
                dataGridView_item.RowHeadersDefaultCellStyle.ForeColor = Color.FromName(database.arrTheme[1]);

                button1.BackColor = Color.FromName(database.arrTheme[11]);
                button2.BackColor = Color.FromName(database.arrTheme[11]);
                button3.BackColor = Color.FromName(database.arrTheme[11]);
                button4.BackColor = Color.FromName(database.arrTheme[11]);

                button1.ForeColor = Color.FromName(database.arrTheme[1]);
                button2.ForeColor = Color.FromName(database.arrTheme[1]);
                button3.ForeColor = Color.FromName(database.arrTheme[1]);
                button4.ForeColor = Color.FromName(database.arrTheme[1]);

                menuStrip_mainMenu.Renderer = new MyRenderer();
            }
        }

        public class MyRenderer : ToolStripProfessionalRenderer
        {
            protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
            {
                if (database.arrTheme != null)
                {
                    if (!e.Item.Selected)
                    {
                        base.OnRenderMenuItemBackground(e);
                        e.Item.BackColor = Color.FromName(database.arrTheme[7]);
                    }
                    else
                    {
                        Rectangle rc = new Rectangle(Point.Empty, e.Item.Size);
                        Brush myBrush = new SolidBrush(Color.FromName(database.arrTheme[3]));
                        e.Graphics.FillRectangle(myBrush, rc);
                        Pen myPen = new Pen(Color.FromName(database.arrTheme[2]));
                        e.Graphics.DrawRectangle(myPen, 1, 0, rc.Width - 2, rc.Height - 1);
                        e.Item.BackColor = Color.FromName(database.arrTheme[3]);
                    }
                }
            }
            protected override void OnRenderSeparator(ToolStripSeparatorRenderEventArgs e)
            {
                if (database.arrTheme != null)
                {
                    Rectangle rc = new Rectangle(Point.Empty, e.Item.Size);
                    Brush myBrush = new SolidBrush(Color.FromName(database.arrTheme[3]));
                    e.Graphics.FillRectangle(myBrush, rc);
                    Pen myPen = new Pen(Color.FromName(database.arrTheme[2]));
                    e.Graphics.DrawRectangle(myPen, 1, 0, rc.Width - 2, rc.Height - 1);
                    e.Item.BackColor = Color.FromName(database.arrTheme[3]);
                }
            }
            protected override void OnRenderItemText(ToolStripItemTextRenderEventArgs e)
            {
                if (database.arrTheme != null)
                {
                    base.OnRenderItemText(e);
                    if (!e.Item.Selected)
                    {
                        e.Item.ForeColor = Color.FromName(database.arrTheme[4]);
                    }
                    else
                    {
                        e.Item.ForeColor = Color.FromName(database.arrTheme[5]);
                    }
                }
            }
        }

        private void comboBoxDb_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (database.arrTheme != null)
            {
                try
                {
                    var combo = sender as ComboBox;

                    if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
                    {
                        e.Graphics.FillRectangle(new SolidBrush(Color.FromName(database.arrTheme[8])), e.Bounds);
                        e.Graphics.DrawString(combo.Items[e.Index].ToString(), e.Font, new SolidBrush(Color.FromName(database.arrTheme[10])), new Point(e.Bounds.X, e.Bounds.Y));
                    }
                    else
                    {
                        e.Graphics.FillRectangle(new SolidBrush(Color.FromName(database.arrTheme[7])), e.Bounds);
                        e.Graphics.DrawString(combo.Items[e.Index].ToString(), e.Font, new SolidBrush(Color.FromName(database.arrTheme[9])), new Point(e.Bounds.X, e.Bounds.Y));
                    }
                }
                catch { }
            }
        }

        private void click_load(object sender, EventArgs e)
		{
			OpenFileDialog cLoad = new OpenFileDialog();
			cLoad.InitialDirectory = Application.StartupPath + "\\configs";
			cLoad.Filter = "EL Configuration File (*.cfg)|*.cfg|All Files (*.*)|*.*";
			if (cLoad.ShowDialog() == DialogResult.OK && File.Exists(cLoad.FileName))
			{
				loadedConfFileName = cLoad.SafeFileName;
				StreamReader sr = new StreamReader(cLoad.FileName);

				comboBox_lists.Items.Clear();

				int listCount = Convert.ToInt32(sr.ReadLine());

				listNames = new string[listCount];
				listOffsets = new string[listCount];
				fieldNames = new string[listCount][];
				fieldTypes = new string[listCount][];

				try
				{
					conversationListIndex = Convert.ToInt32(sr.ReadLine());
				}
				catch
				{
					conversationListIndex = 58;
				}
				textBox_conversationListIndex.Text = conversationListIndex.ToString();

				string line;
				for (int i = 0; i < listCount; i++)
				{
					while ((line = sr.ReadLine()) == "")
					{
					}
					comboBox_lists.Items.Add("[" + i + "]: " + line);
					listNames[i] = line;
					listOffsets[i] = sr.ReadLine();
					fieldNames[i] = sr.ReadLine().Split(new char[] { ';' });
					fieldTypes[i] = sr.ReadLine().Split(new char[] { ';' });
				}
				sr.Close();
			}
		}

		private void click_save(object sender, EventArgs e)
		{
			SaveFileDialog cSave = new SaveFileDialog();
			cSave.InitialDirectory = Application.StartupPath + "\\configs";
			cSave.Filter = "EL Configuration File (*.cfg)|*.cfg|All Files (*.*)|*.*";
			if (cSave.ShowDialog() == DialogResult.OK && cSave.FileName != "")
			{
				StreamWriter sw = new StreamWriter(cSave.FileName);

				int listCount = listNames.Length;

				sw.WriteLine(listCount);
				sw.WriteLine(conversationListIndex);

				for (int i = 0; i < listCount; i++)
				{
					sw.WriteLine();
					sw.WriteLine(listNames[i]);
					sw.WriteLine(listOffsets[i]);
					sw.WriteLine(string.Join(";", fieldNames[i]));
					sw.WriteLine(string.Join(";", fieldTypes[i]));
				}

				sw.Close();
			}
		}

		private void change_list(object sender, EventArgs e)
		{
			if (comboBox_lists.SelectedIndex > -1)
			{
				textBox_listName.Text = listNames[comboBox_lists.SelectedIndex];
				textBox_offset.Text = listOffsets[comboBox_lists.SelectedIndex];
				dataGridView_item.Rows.Clear();
				for (int i = 0; i < fieldNames[comboBox_lists.SelectedIndex].Length; i++)
				{
					dataGridView_item.Rows.Add(new string[] { fieldNames[comboBox_lists.SelectedIndex][i], fieldTypes[comboBox_lists.SelectedIndex][i] });
					dataGridView_item.Rows[i].HeaderCell.Value = i.ToString();
				}
			}
		}

		private void change_row(object sender, DataGridViewCellEventArgs e)
		{
			try
			{
				if (fieldNames != null && e.ColumnIndex == 0)
				{
					fieldNames[comboBox_lists.SelectedIndex][e.RowIndex] = dataGridView_item[e.ColumnIndex, e.RowIndex].Value.ToString();
				}
				if (fieldTypes != null && e.ColumnIndex == 1)
				{
					fieldTypes[comboBox_lists.SelectedIndex][e.RowIndex] = dataGridView_item[e.ColumnIndex, e.RowIndex].Value.ToString();
				}
			}
			catch
			{
				MessageBox.Show("CHANGING ERROR!\nFailed changing value, this value seems to be invalid.");
			}
		}

		private void add_row(object sender, EventArgs e)
		{
			if (comboBox_lists.SelectedIndex > -1)
			{
				int CurrentRowIndex = -1;
				if (dataGridView_item.CurrentCell != null)
					CurrentRowIndex = dataGridView_item.CurrentCell.RowIndex + 1;
				if (fieldNames[comboBox_lists.SelectedIndex].Length > 0)
				{
					string[] temp = new string[fieldNames[comboBox_lists.SelectedIndex].Length + 1];
					Array.Copy(fieldNames[comboBox_lists.SelectedIndex], 0, temp, 0, dataGridView_item.CurrentCell.RowIndex + 1);
					temp[dataGridView_item.CurrentCell.RowIndex + 1] = "< NAME >";
					Array.Copy(fieldNames[comboBox_lists.SelectedIndex], dataGridView_item.CurrentCell.RowIndex + 1, temp, dataGridView_item.CurrentCell.RowIndex + 2, fieldNames[comboBox_lists.SelectedIndex].Length - dataGridView_item.CurrentCell.RowIndex - 1);
					fieldNames[comboBox_lists.SelectedIndex] = temp;

					temp = new string[fieldTypes[comboBox_lists.SelectedIndex].Length + 1];
					Array.Copy(fieldTypes[comboBox_lists.SelectedIndex], 0, temp, 0, dataGridView_item.CurrentCell.RowIndex + 1);
					temp[dataGridView_item.CurrentCell.RowIndex + 1] = "< TYPE >";
					Array.Copy(fieldTypes[comboBox_lists.SelectedIndex], dataGridView_item.CurrentCell.RowIndex + 1, temp, dataGridView_item.CurrentCell.RowIndex + 2, fieldTypes[comboBox_lists.SelectedIndex].Length - dataGridView_item.CurrentCell.RowIndex - 1);
					fieldTypes[comboBox_lists.SelectedIndex] = temp;
				}
				else
				{
					string[] temp = new string[1] { "< NAME >" };
					fieldNames[comboBox_lists.SelectedIndex] = temp;

					temp = new string[1] { "< TYPE >" };
					fieldTypes[comboBox_lists.SelectedIndex] = temp;
				}

				change_list(null, null);
				if (CurrentRowIndex > -1)
					dataGridView_item.CurrentCell = dataGridView_item.Rows[CurrentRowIndex].Cells[0];
			}
		}
		private void copy_row(object sender, EventArgs e)
		{
			if (comboBox_lists.SelectedIndex > -1)
			{
				CopyfieldNames = new string[0];
				CopyfieldTypes = new string[0];
				System.Collections.ArrayList SelectedCellsIndexes = new System.Collections.ArrayList();
				for (int i = 0; i < dataGridView_item.SelectedCells.Count; i++)
				{
					bool check = true;
					for (int k = 0; k < SelectedCellsIndexes.Count; k++)
					{
						if ((int)SelectedCellsIndexes[k] == dataGridView_item.SelectedCells[i].RowIndex)
						{
							check = false;
							break;
						}
					}
					if (check)
						SelectedCellsIndexes.Add(dataGridView_item.SelectedCells[i].RowIndex);
				}
				SelectedCellsIndexes.Sort();
				for (int i = 0; i < SelectedCellsIndexes.Count; i++)
				{
					string[] temp = new string[CopyfieldNames.Length + 1];
					if (CopyfieldNames.Length > 0)
						Array.Copy(CopyfieldNames, 0, temp, 0, CopyfieldNames.Length);
					temp[CopyfieldNames.Length] = fieldNames[comboBox_lists.SelectedIndex][(int)SelectedCellsIndexes[i]];
					CopyfieldNames = temp;

					temp = new string[CopyfieldTypes.Length + 1];
					if (CopyfieldTypes.Length > 0)
						Array.Copy(CopyfieldTypes, 0, temp, 0, CopyfieldTypes.Length);
					temp[CopyfieldTypes.Length] = fieldTypes[comboBox_lists.SelectedIndex][(int)SelectedCellsIndexes[i]];
					CopyfieldTypes = temp;

				}
			}
		}

		private void addCopied_row(object sender, EventArgs e)
		{
			if (comboBox_lists.SelectedIndex > -1)
			{
				System.Collections.ArrayList SelectedCellsIndexes = new System.Collections.ArrayList();
				System.Collections.ArrayList LocSelectedCellsIndexes = new System.Collections.ArrayList();
				for (int i = 0; i < dataGridView_item.SelectedCells.Count; i++)
				{
					bool check = true;
					for (int k = 0; k < SelectedCellsIndexes.Count; k++)
					{
						if ((int)SelectedCellsIndexes[k] == dataGridView_item.SelectedCells[i].RowIndex)
						{
							check = false;
							break;
						}
					}
					if (check)
						SelectedCellsIndexes.Add(dataGridView_item.SelectedCells[i].RowIndex);
				}
				SelectedCellsIndexes.Sort();
				int CurrentRowIndex = -1;
				if (dataGridView_item.CurrentCell != null)
					CurrentRowIndex = dataGridView_item.CurrentCell.RowIndex;
				for (int i = 0; i < dataGridView_item.SelectedCells.Count; i++)
				{
					for (int ic = 0; ic < CopyfieldNames.Length; ic++)
					{
						for (int p = 0; p < SelectedCellsIndexes.Count; p++)
						{
							LocSelectedCellsIndexes.Add(SelectedCellsIndexes[p]);
						}
						if (fieldNames[comboBox_lists.SelectedIndex].Length > 0)
						{
							string[] temp = new string[fieldNames[comboBox_lists.SelectedIndex].Length + 1];
							Array.Copy(fieldNames[comboBox_lists.SelectedIndex], 0, temp, 0, (int)LocSelectedCellsIndexes[i] + 1);
							temp[(int)LocSelectedCellsIndexes[i] + 1] = CopyfieldNames[ic];
							Array.Copy(fieldNames[comboBox_lists.SelectedIndex], (int)LocSelectedCellsIndexes[i] + 1, temp, (int)LocSelectedCellsIndexes[i] + 2, fieldNames[comboBox_lists.SelectedIndex].Length - (int)LocSelectedCellsIndexes[i] - 1);
							fieldNames[comboBox_lists.SelectedIndex] = temp;

							temp = new string[fieldTypes[comboBox_lists.SelectedIndex].Length + 1];
							Array.Copy(fieldTypes[comboBox_lists.SelectedIndex], 0, temp, 0, (int)LocSelectedCellsIndexes[i] + 1);
							temp[(int)LocSelectedCellsIndexes[i] + 1] = CopyfieldTypes[ic];
							Array.Copy(fieldTypes[comboBox_lists.SelectedIndex], (int)LocSelectedCellsIndexes[i] + 1, temp, (int)LocSelectedCellsIndexes[i] + 2, fieldTypes[comboBox_lists.SelectedIndex].Length - (int)LocSelectedCellsIndexes[i] - 1);
							fieldTypes[comboBox_lists.SelectedIndex] = temp;
						}
						else
						{
							string[] temp = new string[1] { CopyfieldNames[ic] };
							fieldNames[comboBox_lists.SelectedIndex] = temp;

							temp = new string[1] { CopyfieldTypes[ic] };
							fieldTypes[comboBox_lists.SelectedIndex] = temp;
						}
						for (int ii = 0; ii < dataGridView_item.SelectedCells.Count; ii++)
						{
							LocSelectedCellsIndexes[ii] = (int)LocSelectedCellsIndexes[ii] + 1;
						}
						for (int ii = i; ii < dataGridView_item.SelectedCells.Count; ii++)
						{
							if (ic < CopyfieldNames.Length - 1)
								SelectedCellsIndexes[ii] = (int)SelectedCellsIndexes[ii] + 1 + ic;
							else
								SelectedCellsIndexes[ii] = (int)SelectedCellsIndexes[ii] + ic;
						}
						CurrentRowIndex = (int)LocSelectedCellsIndexes[0];
					}
				}

				change_list(null, null);
				if (CurrentRowIndex > -1)
					dataGridView_item.CurrentCell = dataGridView_item.Rows[CurrentRowIndex].Cells[0];
			}
		}

		private void delete_row(object sender, EventArgs e)
		{
			if (comboBox_lists.SelectedIndex > -1 && dataGridView_item.SelectedCells != null)
			{
				int CurrentRowIndex = -1;
				System.Collections.ArrayList SelectedCellsIndexes = new System.Collections.ArrayList();
				for (int i = 0; i < dataGridView_item.SelectedCells.Count; i++)
				{
					bool check = true;
					for (int k = 0; k < SelectedCellsIndexes.Count; k++)
					{
						if ((int)SelectedCellsIndexes[k] == dataGridView_item.SelectedCells[i].RowIndex)
						{
							check = false;
							break;
						}
					}
					if (check)
						SelectedCellsIndexes.Add(dataGridView_item.SelectedCells[i].RowIndex);
				}
				SelectedCellsIndexes.Sort();
				for (int i = SelectedCellsIndexes.Count - 1; i > -1; i--)
				{
					string[] temp = new string[fieldNames[comboBox_lists.SelectedIndex].Length - 1];
					Array.Copy(fieldNames[comboBox_lists.SelectedIndex], 0, temp, 0, (int)SelectedCellsIndexes[i]);
					Array.Copy(fieldNames[comboBox_lists.SelectedIndex], (int)SelectedCellsIndexes[i] + 1, temp, (int)SelectedCellsIndexes[i], fieldNames[comboBox_lists.SelectedIndex].Length - 1 - (int)SelectedCellsIndexes[i]);
					fieldNames[comboBox_lists.SelectedIndex] = temp;

					temp = new string[fieldTypes[comboBox_lists.SelectedIndex].Length - 1];
					Array.Copy(fieldTypes[comboBox_lists.SelectedIndex], 0, temp, 0, (int)SelectedCellsIndexes[i]);
					Array.Copy(fieldTypes[comboBox_lists.SelectedIndex], (int)SelectedCellsIndexes[i] + 1, temp, (int)SelectedCellsIndexes[i], fieldTypes[comboBox_lists.SelectedIndex].Length - 1 - (int)SelectedCellsIndexes[i]);
					fieldTypes[comboBox_lists.SelectedIndex] = temp;
				}

				change_list(null, null);
				if (dataGridView_item.Rows != null)
					CurrentRowIndex = (int)SelectedCellsIndexes[0] - 1;
				if (CurrentRowIndex > -1)
					dataGridView_item.CurrentCell = dataGridView_item.Rows[CurrentRowIndex].Cells[0];
			}
		}

		private void click_addList(object sender, EventArgs e)
		{
			string[] templistNames = new string[listNames.Length + 1];
			Array.Copy(listNames, 0, templistNames, 0, comboBox_lists.SelectedIndex + 1);
			templistNames[comboBox_lists.SelectedIndex + 1] = "< LIST >";
			Array.Copy(listNames, comboBox_lists.SelectedIndex + 1, templistNames, comboBox_lists.SelectedIndex + 2, listNames.Length - comboBox_lists.SelectedIndex - 1);
			listNames = templistNames;
			string[] templistOffsets = new string[listOffsets.Length + 1];
			Array.Copy(listOffsets, 0, templistOffsets, 0, comboBox_lists.SelectedIndex + 1);
			templistOffsets[comboBox_lists.SelectedIndex + 1] = "0";
			Array.Copy(listOffsets, comboBox_lists.SelectedIndex + 1, templistOffsets, comboBox_lists.SelectedIndex + 2, listOffsets.Length - comboBox_lists.SelectedIndex - 1);
			listOffsets = templistOffsets;
			string[][] tempfieldNames = new string[fieldNames.Length + 1][];
			Array.Copy(fieldNames, 0, tempfieldNames, 0, comboBox_lists.SelectedIndex + 1);
			tempfieldNames[comboBox_lists.SelectedIndex + 1] = new string[] { "< NAME >" };
			Array.Copy(fieldNames, comboBox_lists.SelectedIndex + 1, tempfieldNames, comboBox_lists.SelectedIndex + 2, fieldNames.Length - comboBox_lists.SelectedIndex - 1);
			fieldNames = tempfieldNames;
			string[][] tempfieldTypes = new string[fieldTypes.Length + 1][];
			Array.Copy(fieldTypes, 0, tempfieldTypes, 0, comboBox_lists.SelectedIndex + 1);
			tempfieldTypes[comboBox_lists.SelectedIndex + 1] = new string[] { "< TYPE >" };
			Array.Copy(fieldTypes, comboBox_lists.SelectedIndex + 1, tempfieldTypes, comboBox_lists.SelectedIndex + 2, fieldTypes.Length - comboBox_lists.SelectedIndex - 1);
			fieldTypes = tempfieldTypes;

			comboBox_lists.Items.Add("[" + (listNames.Length - 1) + "]: " + listNames[listNames.Length - 1]);
			for (int i = 0; i < listNames.Length; i++)
			{
				comboBox_lists.Items[i] = "[" + i + "]: " + listNames[i];
			}
			comboBox_lists.SelectedIndex = comboBox_lists.SelectedIndex + 1;
		}

		private void click_deleteList(object sender, EventArgs e)
		{
			if (comboBox_lists.SelectedIndex > -1)
			{
				int index = comboBox_lists.SelectedIndex;

				string[] itemp = new string[listOffsets.Length - 1];

				Array.Copy(listOffsets, 0, itemp, 0, index);
				Array.Copy(listOffsets, index + 1, itemp, index, listOffsets.Length - 1 - index);
				listOffsets = itemp;

				string[] stemp = new string[listNames.Length - 1];

				Array.Copy(listNames, 0, stemp, 0, index);
				Array.Copy(listNames, index + 1, stemp, index, listNames.Length - 1 - index);
				listNames = stemp;

				string[][] astemp = new string[fieldNames.Length - 1][];

				Array.Copy(fieldNames, 0, astemp, 0, index);
				Array.Copy(fieldNames, index + 1, astemp, index, fieldNames.Length - 1 - index);
				fieldNames = astemp;

				astemp = new string[fieldTypes.Length - 1][];

				Array.Copy(fieldTypes, 0, astemp, 0, index);
				Array.Copy(fieldTypes, index + 1, astemp, index, fieldTypes.Length - 1 - index);
				fieldTypes = astemp;

				dataGridView_item.Rows.Clear();
				comboBox_lists.Items.Clear();

				for (int i = 0; i < listNames.Length; i++)
				{
					comboBox_lists.Items.Add("[" + i + "]: " + listNames[i]);
				}

				index--;

				if (index < 0 && comboBox_lists.Items.Count > 0)
				{
					index++;
				}
				comboBox_lists.SelectedIndex = index;
			}
		}

		private void click_SetValueSelectedNames(object sender, EventArgs e)
		{
			System.Collections.ArrayList SelectedCellsIndexes = new System.Collections.ArrayList();
			for (int i = 0; i < dataGridView_item.SelectedCells.Count; i++)
			{
				bool check = true;
				for (int k = 0; k < SelectedCellsIndexes.Count; k++)
				{
					if ((int)SelectedCellsIndexes[k] == dataGridView_item.SelectedCells[i].RowIndex)
					{
						check = false;
						break;
					}
				}
				if (check)
					SelectedCellsIndexes.Add(dataGridView_item.SelectedCells[i].RowIndex);
			}
			for (int i = 0; i < SelectedCellsIndexes.Count; i++)
			{
				dataGridView_item.Rows[(int)SelectedCellsIndexes[i]].Cells[0].Value = textBox_SetName.Text;
			}
		}

		private void click_SetValueSelectedTypes(object sender, EventArgs e)
		{
			System.Collections.ArrayList SelectedCellsIndexes = new System.Collections.ArrayList();
			for (int i = 0; i < dataGridView_item.SelectedCells.Count; i++)
			{
				bool check = true;
				for (int k = 0; k < SelectedCellsIndexes.Count; k++)
				{
					if ((int)SelectedCellsIndexes[k] == dataGridView_item.SelectedCells[i].RowIndex)
					{
						check = false;
						break;
					}
				}
				if (check)
					SelectedCellsIndexes.Add(dataGridView_item.SelectedCells[i].RowIndex);
			}
			for (int i = 0; i < SelectedCellsIndexes.Count; i++)
			{
				dataGridView_item.Rows[(int)SelectedCellsIndexes[i]].Cells[1].Value = textBox_SetType.Text;
			}
		}

		private void change_conversationListIndex(object sender, EventArgs e)
		{
			conversationListIndex = Convert.ToInt32(textBox_conversationListIndex.Text);
		}

		private void change_listName(object sender, EventArgs e)
		{
			if (comboBox_lists.SelectedIndex > -1)
			{
				listNames[comboBox_lists.SelectedIndex] = textBox_listName.Text;
				comboBox_lists.Items[comboBox_lists.SelectedIndex] = "[" + comboBox_lists.SelectedIndex + "]: " + textBox_listName.Text;
			}
		}

		private void change_listOffset(object sender, EventArgs e)
		{
			if (comboBox_lists.SelectedIndex > -1)
			{
				listOffsets[comboBox_lists.SelectedIndex] = textBox_offset.Text;
			}
		}

		private int GetTypeSize(string type)
		{
			if (type == "int16")
			{
				return 2;
			}
			if (type == "int32")
			{
				return 4;
			}
			if (type == "int64")
			{
				return 8;
			}
			if (type == "float")
			{
				return 4;
			}
			if (type == "double")
			{
				return 8;
			}
			if (type.Contains("byte:"))
			{
				return Convert.ToInt32(type.Split(new char[] { ':' })[1]);
			}
			if (type.Contains("wstring:"))
			{
				return Convert.ToInt32(type.Split(new char[] { ':' })[1]);
			}
			if (type.Contains("string:"))
			{
				return Convert.ToInt32(type.Split(new char[] { ':' })[1]);
			}

			return 0;
		}

		private int GetElTypeSize(int listIndex)
		{
			int size = 0;
			for (int i = 0; i < fieldTypes[listIndex].Length; i++)
			{
				size += GetTypeSize(fieldTypes[listIndex][i]);
			}
			return size;
		}

		private ScanInfo[] LoadSequelScannerConfiguration(string file)
		{
			if (listNames != null && File.Exists(file))
			{
				StreamReader sr = new StreamReader(file);

				ScanInfo[] siList = new ScanInfo[listNames.Length];
				ScanInfo si;
				String line;
				int i = 0;

				while (i < siList.Length)
				{
					try
					{
						line = sr.ReadLine();
						if (!line.StartsWith("#"))
						{
							si = new ScanInfo();

							si.EntrySizePrior = -1;
							si.EntrySizeEstimated = -1;

							if (i != conversationListIndex)
							{
								si.EntrySizePrior = GetElTypeSize(i);
							}
							if (line == "NULL")
							{
								si.FirstElementID = -1;
							}
							else
							{
								si.FirstElementID = Convert.ToInt32(line);
							}

							line = sr.ReadLine();

							if (line == "NULL")
							{
								si.SecondElementID = -1;
							}
							else
							{
								si.SecondElementID = Convert.ToInt32(line);
							}

							siList[i] = si;
							i++;
						}
					}
					catch
					{ }
				}

				sr.Close();

				// fill the missing if necessary
				for (int ifo = i; ifo < siList.Length; ifo++)
				{
					si = new ScanInfo();
					si.EntrySizePrior = GetElTypeSize(ifo);
					si.FirstElementID = -1;
					si.SecondElementID = -1;
					siList[ifo] = si;
				}

				return siList;
			}

			return null;
		}

		private void SkipOffset(int version, int listIndex, BinaryReader br)
		{
			string offset = listOffsets[listIndex];

			// support for 1.2.6 config scan (assuming)
			if (loadedConfFileName.EndsWith("_v7.cfg") && version > 8)
			{
				if (listIndex == 0)
				{
					// force offset = 4
					offset = "4";
				}
				if (listIndex == 20 || listIndex == 100)
				{
					// force offset = AUTO
					offset = "AUTO";
				}
			}

			if (offset != "" && offset != "0")
			{
				if (offset == "AUTO")
				{
					if (listIndex == 0)
					{
						br.ReadBytes(4); // head
						int count = br.ReadInt32(); // count
						br.ReadBytes(count); // body
					}
					if (listIndex == 20)
					{
						br.ReadBytes(4); // head
						int count = br.ReadInt32(); // count
						br.ReadBytes(count); // body
						br.ReadBytes(4); // tail
					}
					int NPC_WAR_TOWERBUILD_SERVICE_index = 100;
					if (version >= 191)
						NPC_WAR_TOWERBUILD_SERVICE_index = 99;
					if (listIndex == NPC_WAR_TOWERBUILD_SERVICE_index)
					{
						br.ReadBytes(4); // head
						int count = br.ReadInt32(); // count
						br.ReadBytes(count); // body
					}
				}
				else
				{
					br.ReadBytes(Convert.ToInt32(offset));
				}
			}
		}

		private void SkipConversationList(short version, int listIndex, BinaryReader br)
		{
			if (version >= 191)
			{
				long sourcePosition = br.BaseStream.Position;

				bool run = true;
				while (run)
				{
					run = false;
					try
					{
						br.ReadByte();
						run = true;
					}
					catch
					{ }
				}
			}
			else
			{
				// scan directly to next list count (automatically skip next list offset)
				if (fieldTypes[listIndex][0].Contains("AUTO"))
				{
					byte[] pattern = (Encoding.GetEncoding("GBK")).GetBytes("facedata\\");
					long sourcePosition = br.BaseStream.Position;

					bool run = true;
					while (run)
					{
						run = false;
						for (int i = 0; i < pattern.Length; i++)
						{
							if (br.ReadByte() != pattern[i])
							{
								run = true;
								break;
							}
						}
					}
					// decrement base stream position (ElementCount, ID, Name, PatternLength)
					br.BaseStream.Position -= (4 + 4 + 64 + pattern.Length);
				}
				else
				{
					br.BaseStream.Position += Convert.ToInt32(fieldTypes[listIndex][0].Split(new char[] { ':' })[0]) + Convert.ToInt32(listOffsets[listIndex]);
					//br->ReadBytes( Convert::ToInt32(fieldTypes[listIndex][0]->Split(gcnew array<wchar_t>{':'})[0]) );
				}
			}
		}

		private void click_scanSequel(object sender, EventArgs e)
		{
			ScanInfo[] siList = LoadSequelScannerConfiguration(Application.StartupPath + "\\configs\\sequel_scanner.txt");

			// open the new element.data file
			OpenFileDialog eLoad = new OpenFileDialog();
			eLoad.Filter = "EL (*.data)|*.data|All Files (*.*)|*.*";
			if (eLoad.ShowDialog() == DialogResult.OK && File.Exists(eLoad.FileName))
			{
				StreamReader sr = new StreamReader(eLoad.FileName);
				BinaryReader br = new BinaryReader(sr.BaseStream);

				long streamPos;
				int currentListIndex = 0;
				short version = br.ReadInt16();
				short signature = br.ReadInt16();

				string log = "";
				log += "Configuration File: " + loadedConfFileName + "\r\n";
				log += "Element File Version: " + version.ToString() + "\r\n\r\n";

				for (int i = 0; i < listNames.Length; i++)
				{
					// skip offset
					SkipOffset(version, i, br);
					// skip conversation list
					if (i == conversationListIndex)
					{
						// offset from next list automatically skipped
						SkipConversationList(version, i, br);
						log += i.ToString("D3") + ": SKIPPED (Conversation List)\r\n";
						i++;
					}

					log += i.ToString("D3") + ":";

					// read the number of elements in this list
					siList[i].ElementCount = br.ReadInt32();
					// store the current stream position (list begin)
					streamPos = br.BaseStream.Position;

					// only process non-empty lists
					if (siList[i].ElementCount > 0)
					{
						// FirstElementID = VALID
						if (siList[i].FirstElementID > -1)
						{
							// SecondElementID = VALID
							if (siList[i].SecondElementID > -1)
							{
								// CurrentList: ElementCount = >1 (assumption, because elements will never removed in newer lists)
								// CurrentList: FirstElementID = VALID
								// CurrentList: SecondElementID = VALID
								// CurrentList: ElementCountConfig = >1
								//
								// NextList: ElementCount = ?
								// NextList: FirstElementID = ?
								// NextList: SecondElementID = ?
								// NextList: ElementCountConfig = ?

								// skip byte size from (prior)configuration file
								br.ReadBytes(siList[i].EntrySizePrior);
								siList[i].EntrySizeEstimated = siList[i].EntrySizePrior;
								// read byte by byte until value matches SecondElementID
								while (br.ReadInt32() != siList[i].SecondElementID)
								{
									// TODO: condition to prevent infinite loop
									siList[i].EntrySizeEstimated++;
									br.BaseStream.Position -= 3;
								}
								br.BaseStream.Position = streamPos + (siList[i].ElementCount * siList[i].EntrySizeEstimated);

								if (siList[i].EntrySizePrior != siList[i].EntrySizeEstimated)
								{
									log += " CHANGED: Entry Size Increased (" + siList[i].EntrySizePrior.ToString() + " -> " + siList[i].EntrySizeEstimated.ToString() + ", +" + (siList[i].EntrySizeEstimated - siList[i].EntrySizePrior).ToString() + ")";
								}
								else
								{
									log += " -";
								}
							}
							// SecondElementID = NULL
							else
							{
								if (i < siList.Length - 1)
								{
									// NextList: FirstElementID = VALID
									if (siList[i + 1].FirstElementID > -1)
									{
										// CurrentList: ElementCount = >0
										// CurrentList: FirstElementID = VALID
										// CurrentList: SecondElementID = NULL
										// CurrentList: ElementCountConfig = >0
										//
										// NextList: ElementCount = ?
										// NextList: FirstElementID = VALID
										// NextList: SecondElementID = ?
										// NextList: ElementCountConfig = >0

										// we have to rely on the offset from the configuration file (hopefully it doesn't changed)
										// if the offset is AUTO mode then we can give up here
										if (listOffsets[i + 1] == "AUTO" || ((i + 1 == 20 || i + 1 == 100) && version > 8 && loadedConfFileName.EndsWith("_v7.cfg")))
										{
											if (MessageBox.Show("List Index: " + i.ToString() + "\r\n\r\nDeep scan through Offset:AUTO in next list not possible.\r\nTry to use EntrySize from configuration file?\r\n*Application may crash when EntrySize has been increased!", listNames[i], MessageBoxButtons.YesNo) == DialogResult.Yes)
											{
												siList[i].EntrySizeEstimated = siList[i].EntrySizePrior;
												br.BaseStream.Position = streamPos + (siList[i].ElementCount * siList[i].EntrySizeEstimated);
												log += " INHERITED: Using Entry Size from Configuration File (" + siList[i].EntrySizeEstimated + ")";
											}
											else
											{
												log += " ABORT (Can't deep scan through OFFSET:AUTO)\r\n";
												goto ABORT;
											}
										}
										else
										{
											// scan for the FirstElementID in next list
											br.BaseStream.Position += (siList[i].ElementCount * siList[i].EntrySizePrior);
											// read byte by byte until value matches FirstElementID in next list
											while (br.ReadInt32() != siList[i + 1].FirstElementID)
											{
												// TODO: condition to prevent infinite loop
												br.BaseStream.Position -= 3;
											}
											// decrement stream position by NextList: Offset + ElementCount + FirstItemID
											br.BaseStream.Position -= (Convert.ToInt32(listOffsets[i + 1]) + 4 + 4);
											// divide list length by entrycount to acquire the EntrySizeExtimated
											siList[i].EntrySizeEstimated = (int)((br.BaseStream.Position - streamPos) / siList[i].ElementCount);

											if (siList[i].EntrySizePrior != siList[i].EntrySizeEstimated)
											{
												log += " CHANGED: Entry Size Increased (" + siList[i].EntrySizePrior.ToString() + " -> " + siList[i].EntrySizeEstimated.ToString() + ", +" + (siList[i].EntrySizeEstimated - siList[i].EntrySizePrior).ToString() + ")";
											}
											else
											{
												log += " -";
											}
										}
									}
									// NextList: FirstElementID = NULL
									else
									{
										// CurrentList: ElementCount = >0
										// CurrentList: FirstElementID = VALID
										// CurrentList: SecondElementID = NULL
										// CurrentList: ElementCountConfig = >0
										//
										// NextList: ElementCount = ?
										// NextList: FirstElementID = NULL
										// NextList: SecondElementID = ?
										// NextList: ElementCountConfig = 0
										log += " ABORT (Can't deep scan through multiple unknown lists)\r\n";
										goto ABORT;
									}
								}
								else
								{
									// use EntrySizePrior and check if end of file reached
									br.BaseStream.Position += (siList[i].ElementCount * siList[i].EntrySizePrior);
									if (br.BaseStream.Length != br.BaseStream.Position)
									{
										log += " ABORT (Can't deep scan through next [non-existing] list)\r\n";
										goto ABORT;
									}
									else
									{
										siList[i].EntrySizeEstimated = siList[i].EntrySizePrior;
										log += " INHERITED: Using Entry Size from Configuration File (" + siList[i].EntrySizeEstimated + ")";
									}
								}
							}
						}
						// FirstElementID = NULL
						else
						{
							// SecondElementID = VALID
							if (false)
							{
								// SecondElementID can't be valid when FirstElementID is NULL
								// otherwise: wrong sequel_scanner configuration
								log += " ABORT (Error in sequel_scanner.txt)\r\n";
								goto ABORT;
							}
							// SecondElementID = NULL
							else
							{
								if (i < siList.Length - 1)
								{
									// NextList: FirstElementID = VALID
									if (siList[i + 1].FirstElementID > -1)
									{
										// CurrentList: ElementCount = >0
										// CurrentList: FirstElementID = NULL
										// CurrentList: SecondElementID = NULL
										// CurrentList: ElementCountConfig = 0
										//
										// NextList: ElementCount = ?
										// NextList: FirstElementID = VALID
										// NextList: SecondElementID = ?
										// NextList: ElementCountConfig = >0
										log += " ABORT (mot implemented yet)\r\n";
										goto ABORT;
									}
									// NextList: FirstElementID = NULL
									else
									{
										// CurrentList: ElementCount = >0
										// CurrentList: FirstElementID = NULL
										// CurrentList: SecondElementID = NULL
										// CurrentList: ElementCountConfig = 0
										//
										// NextList: ElementCount = ?
										// NextList: FirstElementID = NULL
										// NextList: SecondElementID = ?
										// NextList: ElementCountConfig = 0
										log += " ABORT (Can't deep scan through multiple unknown lists)\r\n";
										goto ABORT;
									}
								}
								else
								{
									// use EntrySizePrior and check if end of file reached
									br.BaseStream.Position += (siList[i].ElementCount * siList[i].EntrySizePrior);
									if (br.BaseStream.Length != br.BaseStream.Position)
									{
										log += " ABORT (Can't deep scan through next [non-existing] list)\r\n";
										goto ABORT;
									}
									else
									{
										siList[i].EntrySizeEstimated = siList[i].EntrySizePrior;
										log += " INHERITED: Using Entry Size from Configuration File (" + siList[i].EntrySizeEstimated + ")";
									}
								}
							}
						}
					}
					else
					{
						log += " SKIPPED (Empty List)";
					}

					log += "\r\n";
					//MessageBox::Show("List Name: " + listNames[i] + "\n\nList Index: " + i.ToString() + "\nElement Count: " + siList[i]->ElementCount.ToString() + "\nEntry Size (Prior Config): " + siList[i]->EntrySizePrior.ToString() + "\nEntry Size (Estimated): " + siList[i]->EntrySizeEstimated.ToString());
				}

				ABORT:

				log += "\r\nBYTES LEFT: " + (br.BaseStream.Length - br.BaseStream.Position).ToString();

				br.Close();
				sr.Close();

				new DebugWindow("Scan Results", log);
			}

		}
	}
}
