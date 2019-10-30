using System;
using System.IO;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sELedit
{
	public partial class FieldCompare : Form
	{
		eListCollection eLC;
		eListCollection eLCOther;
		eListConversation conversationList;
		eListConversation conversationListOther;
        ColorProgressBar.ColorProgressBar cpb2_prog;
        private static CacheSave database = new CacheSave();

        public FieldCompare(eListCollection ListCollection, eListConversation ListConversation, ref ColorProgressBar.ColorProgressBar progressBar_prog)
		{
			eLC = ListCollection;
			conversationList = ListConversation;
            cpb2_prog = progressBar_prog;
            InitializeComponent();
			for (int l = 0; l < eLC.Lists.Length; l++)
			{
				comboBox_List.Items.Add("[" + l + "]: " + eLC.Lists[l].listName + " (" + eLC.Lists[l].elementValues.Length + ")");
			}
			CheckCompareButton(null, null);
            database = MainWindow.database;
            colorTheme();
        }

        private void colorTheme()
        {
            if (database.arrTheme != null)
            {
                cpb2.Value = 0;

                comboBox_List.DrawMode = DrawMode.OwnerDrawFixed;
                comboBox_List.FlatStyle = FlatStyle.Flat;

                BackColor = Color.FromName(database.arrTheme[0]);

                cpb2.BarColor = Color.FromName(database.arrTheme[17]);

                label1.ForeColor = Color.FromName(database.arrTheme[1]);
                label2.ForeColor = Color.FromName(database.arrTheme[1]);
                label3.ForeColor = Color.FromName(database.arrTheme[1]);
                label4.ForeColor = Color.FromName(database.arrTheme[1]);

                textBox_ElementPath.BackColor = Color.FromName(database.arrTheme[6]);
                textBox_LogDir.BackColor = Color.FromName(database.arrTheme[6]);
                comboBox_List.BackColor = Color.FromName(database.arrTheme[7]);

                textBox_ElementPath.ForeColor = Color.FromName(database.arrTheme[1]);
                textBox_LogDir.ForeColor = Color.FromName(database.arrTheme[1]);

                dataGridView_fields.BackgroundColor = Color.FromName(database.arrTheme[12]);
                dataGridView_fields.ColumnHeadersDefaultCellStyle.BackColor = Color.FromName(database.arrTheme[13]);
                dataGridView_fields.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromName(database.arrTheme[1]);
                dataGridView_fields.RowHeadersDefaultCellStyle.BackColor = Color.FromName(database.arrTheme[13]);
                dataGridView_fields.DefaultCellStyle.BackColor = Color.FromName(database.arrTheme[13]);
                dataGridView_fields.DefaultCellStyle.SelectionBackColor = Color.FromName(database.arrTheme[14]);
                dataGridView_fields.RowHeadersDefaultCellStyle.SelectionBackColor = Color.FromName(database.arrTheme[14]);
                dataGridView_fields.RowHeadersDefaultCellStyle.ForeColor = Color.FromName(database.arrTheme[1]);

                button_browseElement.BackColor = Color.FromName(database.arrTheme[11]);
                button_browseLogDit.BackColor = Color.FromName(database.arrTheme[11]);
                button_cancel.BackColor = Color.FromName(database.arrTheme[11]);
                button_compare.BackColor = Color.FromName(database.arrTheme[11]);
                button_LoadElement.BackColor = Color.FromName(database.arrTheme[11]);

                button_browseElement.ForeColor = Color.FromName(database.arrTheme[1]);
                button_browseLogDit.ForeColor = Color.FromName(database.arrTheme[1]);
                button_cancel.ForeColor = Color.FromName(database.arrTheme[1]);
                button_compare.ForeColor = Color.FromName(database.arrTheme[1]);
                button_LoadElement.ForeColor = Color.FromName(database.arrTheme[1]);
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

        private void click_browseElement(object sender, EventArgs e)
		{
			OpenFileDialog eLoad = new OpenFileDialog();
			eLoad.Filter = "Elements File (*.data)|*.data|All Files (*.*)|*.*";
			if (eLoad.ShowDialog() == DialogResult.OK && File.Exists(eLoad.FileName))
			{
				textBox_ElementPath.Text = eLoad.FileName;
                if (database.arrTheme == null)
				    textBox_ElementPath.BackColor = Color.FromName("Window");
                else
                    textBox_ElementPath.BackColor = Color.FromName(database.arrTheme[6]);
            }
		}

		private void click_browseLogDir(object sender, EventArgs e)
		{
			FolderBrowserDialog lLoad = new FolderBrowserDialog();
			if (lLoad.ShowDialog() == DialogResult.OK && Directory.Exists(lLoad.SelectedPath))
				textBox_LogDir.Text = lLoad.SelectedPath;
		}

		private void click_LoadElement(object sender, EventArgs e)
		{
			if (textBox_ElementPath.Text != "")
			{
				Cursor = Cursors.AppStarting;
				//progressBar_progress.Style = ProgressBarStyle.Continuous;
				try
				{
					eLCOther = new eListCollection(textBox_ElementPath.Text, ref cpb2_prog);
					conversationListOther = new eListConversation((byte[])eLCOther.Lists[eLCOther.ConversationListIndex].elementValues[0][0]);
					textBox_ElementPath.BackColor = Color.LightGreen;
				}
				catch
				{
					textBox_ElementPath.BackColor = Color.Salmon;
					MessageBox.Show("LOADING ERROR!\nThis error mostly occurs of configuration and elements.data mismatch");
				}
				cpb2_prog.Value = 0;
				//progressBar_progress.Style = ProgressBarStyle.Continuous;
				Cursor = Cursors.Default;
			}
			CheckCompareButton(null, null);
		}

		private void change_list(object sender, EventArgs e)
		{
			dataGridView_fields.Rows.Clear();
			int l = comboBox_List.SelectedIndex;
			for (int i = 0; i < eLC.Lists[l].elementFields.Length; i++)
			{
				dataGridView_fields.Rows.Add(new string[] { eLC.Lists[l].elementFields[i],  "False" });
				dataGridView_fields.Rows[dataGridView_fields.Rows.Count - 1].HeaderCell.Value = i.ToString();
			}
			CheckCompareButton(null, null);
		}

		private void click_compare(object sender, EventArgs e)
		{
			if (eLCOther != null && comboBox_List.SelectedIndex > -1)
			{
				//progressBar_progress.Style = ProgressBarStyle.Continuous;
				int l = comboBox_List.SelectedIndex;
				int lo = l;
				ArrayList Fields = new ArrayList();
				ArrayList Excludes = new ArrayList();
				if (l != eLC.ConversationListIndex)
				{
					for (int i = 0; i < eLC.Lists[l].elementFields.Length; i++)
					{
						if (dataGridView_fields.Rows[i].Cells[1].Value.ToString() == "True")
							Excludes.Add("\t#" + i + "\t- " + eLC.Lists[l].elementFields[i]);
						else
							Fields.Add(eLC.Lists[l].elementFields[i]);
					}
					StreamWriter sw = new StreamWriter(textBox_LogDir.Text + "\\Field_Compare.txt", false, Encoding.Unicode);
					sw.Close();
					File.AppendAllText(textBox_LogDir.Text + "\\Field_Compare.txt", "List: " + eLC.Lists[l].listName + "\r\n", Encoding.Unicode);
					if (Excludes.Count > 0)
					{
						File.AppendAllText(textBox_LogDir.Text + "\\Field_Compare.txt", "Fields Excluded:\r\n", Encoding.Unicode);
						for (int i = 0; i < Excludes.Count; i++)
						{
							File.AppendAllText(textBox_LogDir.Text + "\\Field_Compare.txt", Excludes[i] + "\r\n", Encoding.Unicode);
						}
					}
					if (eLC.Version < 191 && eLCOther.Version >= 191 && l >= eLCOther.ConversationListIndex)
						lo--;
					if (eLC.Version >= 191 && eLCOther.Version < 191 && l >= eLCOther.ConversationListIndex)
						lo++;
					cpb2.Maximum = eLC.Lists[l].elementValues.Length + 1;
					for (int i = 0; i < eLC.Lists[l].elementValues.Length && i < eLCOther.Lists[lo].elementValues.Length; i++)
					{
						for (int eo = 0; eo < eLCOther.Lists[lo].elementValues.Length; eo++)
						{
							if (eLC.GetValue(l, i, 0) == eLCOther.GetValue(lo, eo, 0))
							{
								string log = "";
								for (int fl = 0; fl < Fields.Count; fl++)
								{
									for (int fl1 = 0; fl1 < eLC.Lists[l].elementFields.Length; fl1++)
									{
										if (eLC.Lists[l].elementFields[fl1] == Fields[fl].ToString())
										{
											for (int flo = 0; flo < eLCOther.Lists[lo].elementFields.Length; flo++)
											{
												if (eLCOther.Lists[lo].elementFields[flo] == Fields[fl].ToString())
												{
													if (eLC.GetValue(l, i, fl1) != eLCOther.GetValue(lo, eo, flo))
													{
														log += "Item ID: " + eLC.GetValue(l, i, 0) + "\tField: " + Fields[fl] + "\tOld Value: " + eLC.GetValue(l, i, fl1) + "\tNew Value: " + eLCOther.GetValue(lo, eo, flo) + "\r\n";
													}
													break;
												}
											}
											break;
										}
									}
								}
								if (log != "")
									File.AppendAllText(textBox_LogDir.Text + "\\Field_Compare.txt", "\r\n-------------------------------------------------------------------------\r\n" + log, Encoding.Unicode);
								break;
							}
						}
						cpb2.Value++;
                        Application.DoEvents();
					}
				}
				else
				{
					/*StreamWriter sw = new StreamWriter(textBox_LogDir.Text + "\\Field_Compare.txt", false, Encoding.Unicode);
					sw.Close();
					File.AppendAllText(textBox_LogDir.Text + "\\Field_Compare.txt", "List: " + eLC.Lists[l].listName + "\r\n", Encoding.Unicode);
					if (eLC.Lists[eLC.ConversationListIndex].elementValues == eLCOther.Lists[eLCOther.ConversationListIndex].elementValues)
						File.AppendAllText(textBox_LogDir.Text + "\\Field_Compare.txt", "\r\nMatched", Encoding.Unicode);
					else
						File.AppendAllText(textBox_LogDir.Text + "\\Field_Compare.txt", "\r\nNot Matched", Encoding.Unicode);*/

				}
				cpb2.Value = 0;
				//progressBar_progress.Style = ProgressBarStyle.Continuous;
			}
		}

		private void CheckCompareButton(object sender, EventArgs e)
		{
			if (eLCOther != null && comboBox_List.SelectedIndex > -1 && dataGridView_fields.RowCount > 0 && textBox_ElementPath.Text != "")
				button_compare.Enabled = true;
			else
				button_compare.Enabled = false;
		}

		private void click_close(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
