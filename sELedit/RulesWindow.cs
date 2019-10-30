using System;
using System.IO;
using System.Drawing;
using System.Windows.Forms;

namespace sELedit
{
	public partial class RulesWindow : Form
	{
		eListCollection eLC_base;
		eListCollection eLC_recent;
		RuleConfig[] eRules;
        ColorProgressBar.ColorProgressBar cpb2_prog;
        private static CacheSave database = new CacheSave();
        //ProgressBar progressBar_progress;

        public RulesWindow(ref ColorProgressBar.ColorProgressBar progressBar_prog)
		{
            cpb2_prog = progressBar_prog;
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

                BackColor = Color.FromName(database.arrTheme[0]);

                groupBox1.ForeColor = Color.FromName(database.arrTheme[1]);
                groupBox2.ForeColor = Color.FromName(database.arrTheme[1]);

                label1.ForeColor = Color.FromName(database.arrTheme[1]);
                label2.ForeColor = Color.FromName(database.arrTheme[1]);
                label3.ForeColor = Color.FromName(database.arrTheme[1]);
                label4.ForeColor = Color.FromName(database.arrTheme[1]);

                radioButton_baseOffset.ForeColor = Color.FromName(database.arrTheme[1]);
                radioButton_recentOffset.ForeColor = Color.FromName(database.arrTheme[1]);
                checkBox_removeList.ForeColor = Color.FromName(database.arrTheme[1]);

                textBox_baseFile.BackColor = Color.FromName(database.arrTheme[6]);
                textBox_baseOffset.BackColor = Color.FromName(database.arrTheme[6]);
                textBox_baseVersion.BackColor = Color.FromName(database.arrTheme[6]);
                textBox_recentFile.BackColor = Color.FromName(database.arrTheme[6]);
                textBox_recentOffset.BackColor = Color.FromName(database.arrTheme[6]);
                textBox_recentVersion.BackColor = Color.FromName(database.arrTheme[6]);
                comboBox_lists.BackColor = Color.FromName(database.arrTheme[7]);

                textBox_baseFile.ForeColor = Color.FromName(database.arrTheme[1]);
                textBox_baseOffset.ForeColor = Color.FromName(database.arrTheme[1]);
                textBox_baseVersion.ForeColor = Color.FromName(database.arrTheme[1]);
                textBox_recentFile.ForeColor = Color.FromName(database.arrTheme[1]);
                textBox_recentOffset.ForeColor = Color.FromName(database.arrTheme[1]);
                textBox_recentVersion.ForeColor = Color.FromName(database.arrTheme[1]);

                dataGridView_fields.BackgroundColor = Color.FromName(database.arrTheme[12]);
                dataGridView_fields.ColumnHeadersDefaultCellStyle.BackColor = Color.FromName(database.arrTheme[13]);
                dataGridView_fields.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromName(database.arrTheme[1]);
                dataGridView_fields.RowHeadersDefaultCellStyle.BackColor = Color.FromName(database.arrTheme[13]);
                dataGridView_fields.DefaultCellStyle.BackColor = Color.FromName(database.arrTheme[13]);
                dataGridView_fields.DefaultCellStyle.SelectionBackColor = Color.FromName(database.arrTheme[14]);
                dataGridView_fields.RowHeadersDefaultCellStyle.SelectionBackColor = Color.FromName(database.arrTheme[14]);
                dataGridView_fields.RowHeadersDefaultCellStyle.ForeColor = Color.FromName(database.arrTheme[1]);
                Column6.DefaultCellStyle.BackColor = Color.FromName(database.arrTheme[13]);
                dataGridView_values.BackgroundColor = Color.FromName(database.arrTheme[12]);
                dataGridView_values.ColumnHeadersDefaultCellStyle.BackColor = Color.FromName(database.arrTheme[13]);
                dataGridView_values.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromName(database.arrTheme[1]);
                dataGridView_values.RowHeadersDefaultCellStyle.BackColor = Color.FromName(database.arrTheme[13]);
                dataGridView_values.RowHeadersDefaultCellStyle.ForeColor = Color.FromName(database.arrTheme[1]);
                dataGridView_values.DefaultCellStyle.BackColor = Color.FromName(database.arrTheme[13]);
                dataGridView_values.DefaultCellStyle.SelectionBackColor = Color.FromName(database.arrTheme[14]);
                dataGridView_values.RowHeadersDefaultCellStyle.SelectionBackColor = Color.FromName(database.arrTheme[14]);

                button_browseBase.BackColor = Color.FromName(database.arrTheme[11]);
                button_browseRecent.BackColor = Color.FromName(database.arrTheme[11]);
                button_export.BackColor = Color.FromName(database.arrTheme[11]);
                button_import.BackColor = Color.FromName(database.arrTheme[11]);
                button_view.BackColor = Color.FromName(database.arrTheme[11]);

                button_browseBase.ForeColor = Color.FromName(database.arrTheme[1]);
                button_browseRecent.ForeColor = Color.FromName(database.arrTheme[1]);
                button_export.ForeColor = Color.FromName(database.arrTheme[1]);
                button_import.ForeColor = Color.FromName(database.arrTheme[1]);
                button_view.ForeColor = Color.FromName(database.arrTheme[1]);
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


        private int count_mismatches(int listIndexB, int listIndexR, int baseFieldIndex, int recentFieldIndex)
		{
			int mismatches = 0;

			if (eRules[listIndexR].RemoveValues[recentFieldIndex])
			{
				return -1;
			}

			if (baseFieldIndex >= eLC_base.Lists[listIndexB].elementFields.Length)
			{
				return -1; //eLC_recent->Lists[listIndex]->elementValues->Length;
			}

			if (recentFieldIndex >= eLC_recent.Lists[listIndexR].elementFields.Length)
			{
				return -1; //eLC_base->Lists[listIndex]->elementValues->Length;
			}

			for (int e = 0; e < eLC_recent.Lists[listIndexR].elementValues.Length; e++)
			{
				if (e >= eLC_base.Lists[listIndexB].elementValues.Length || e >= eLC_recent.Lists[listIndexR].elementValues.Length)
				{
					break;
				}

				if (eLC_base.GetValue(listIndexB, e, baseFieldIndex) != eLC_recent.GetValue(listIndexR, e, recentFieldIndex))
				{
					mismatches++;
				}
			}

			return mismatches;
		}

		private void click_browse(object sender, EventArgs e)
		{
			OpenFileDialog eLoad = new OpenFileDialog();
			eLoad.Filter = "Elements File (*.data)|*.data|All Files (*.*)|*.*";
			if (eLoad.ShowDialog() == DialogResult.OK && File.Exists(eLoad.FileName))
			{
				Cursor = Cursors.AppStarting;

				dataGridView_fields.Rows.Clear();
				dataGridView_values.Rows.Clear();
				this.Column1.HeaderText = "Base Fields";
				this.Column2.HeaderText = "Recent Fields";
				this.Column7.HeaderText = "Base Values";
				this.Column8.HeaderText = "Recent Values";
				comboBox_lists.Items.Clear();

				//progressBar_progress.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
				if (sender == (object)button_browseBase)
				{
					eLC_base = new eListCollection(eLoad.FileName, ref cpb2_prog);
					textBox_baseFile.Text = eLoad.FileName;
					textBox_baseVersion.Text = eLC_base.Version.ToString();
				}

				if (sender == (object)button_browseRecent)
				{
					eLC_recent = new eListCollection(eLoad.FileName, ref cpb2_prog);
					textBox_recentFile.Text = eLoad.FileName;
					textBox_recentVersion.Text = eLC_recent.Version.ToString();
				}

				if (eLC_base != null && eLC_recent != null && eLC_base.Lists.Length > 0 && eLC_recent.Lists.Length > 0)
				{
					// add list names from recent file
					eRules = new RuleConfig[eLC_recent.Lists.Length];
					for (int l = 0; l < eLC_recent.Lists.Length; l++)
					{
						comboBox_lists.Items.Add("[" + l + "]: " + eLC_recent.Lists[l].listName + " (" + eLC_recent.Lists[l].elementValues.Length + ")");
						eRules[l] = new RuleConfig();
						eRules[l].RemoveList = false;
						eRules[l].ReplaceOffset = false;
						eRules[l].Offset = "";
						eRules[l].RemoveValues = new bool[eLC_recent.Lists[l].elementFields.Length];
						for (int f = 0; f < eRules[l].RemoveValues.Length; f++)
						{
							eRules[l].RemoveValues[f] = false;
						}
					}
				}
                cpb2_prog.Value = 0;
				//progressBar_progress.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
				Cursor = Cursors.Default;
			}
		}

		private void change_list(object sender, EventArgs e)
		{
			Cursor = Cursors.AppStarting;

			dataGridView_fields.Rows.Clear();
			dataGridView_values.Rows.Clear();
			this.Column1.HeaderText = "Base Fields";
			this.Column2.HeaderText = "Recent Fields";
			this.Column7.HeaderText = "Base Values";
			this.Column8.HeaderText = "Recent Values";

			int lb = comboBox_lists.SelectedIndex;
			int lr = comboBox_lists.SelectedIndex;
			if (eLC_base.Version < 191 && eLC_recent.Version >= 191 && eLC_base.ConversationListIndex <= lb)
			{
				lb = lb + 1;
			}

			if (lr > -1)
			{
				checkBox_removeList.Checked = eRules[lr].RemoveList;

				if (eLC_base.Lists.Length > lb && eLC_recent.ConversationListIndex != lr)
				{
					this.Column1.HeaderText = "Base Fields (" + eLC_base.Lists[lb].elementFields.Length.ToString() + ")";
					this.Column2.HeaderText = "Recent Fields (" + eLC_recent.Lists[lr].elementFields.Length.ToString() + ")";

					int baseFieldIndex = 0;
					int recentFieldIndex = 0;

					if (eRules[lr].ReplaceOffset)
					{
						radioButton_baseOffset.Checked = true;
						radioButton_recentOffset.Checked = false;
					}
					else
					{
						radioButton_baseOffset.Checked = false;
						radioButton_recentOffset.Checked = true;
					}
					textBox_baseOffset.Text = eLC_base.GetOffset(lb);
					textBox_recentOffset.Text = eLC_recent.GetOffset(lr);

                    for (int f = 0; f < eLC_recent.Lists[lr].elementFields.Length; f++)
					{
						if (eRules[lr].RemoveValues[f])
						{
							baseFieldIndex--;
						}

						if (eRules[lr].RemoveValues[f] || baseFieldIndex >= eLC_base.Lists[lb].elementFields.Length)
						{
							dataGridView_fields.Rows.Add(new string[] { "", eLC_recent.Lists[lr].elementTypes[recentFieldIndex], count_mismatches(lb, lr, baseFieldIndex, recentFieldIndex).ToString(), eRules[lr].RemoveValues[f].ToString(), "Details" });
						}
						else
						{
							dataGridView_fields.Rows.Add(new string[] { eLC_base.Lists[lb].elementTypes[baseFieldIndex], eLC_recent.Lists[lr].elementTypes[recentFieldIndex], count_mismatches(lb, lr, baseFieldIndex, recentFieldIndex).ToString(), eRules[lr].RemoveValues[f].ToString(), "Details" });
                        }
						dataGridView_fields.Rows[dataGridView_fields.Rows.Count - 1].HeaderCell.Value = f.ToString();
						baseFieldIndex++;
						recentFieldIndex++;
					}
				}
				else
				{
					//
				}
			}

			Cursor = Cursors.Default;
		}

		private void check_removeList(object sender, EventArgs e)
		{
			int l = comboBox_lists.SelectedIndex;
			if (l > -1)
			{
				eRules[l].RemoveList = checkBox_removeList.Checked;
			}
		}

		private void check_offset(object sender, EventArgs e)
		{
			int l = comboBox_lists.SelectedIndex;
			if (l > -1)
			{
				if (radioButton_baseOffset.Checked)
				{
					eRules[l].ReplaceOffset = true;
					eRules[l].Offset = eLC_base.GetOffset(l);
				}
				else
				{
					eRules[l].ReplaceOffset = false;
					eRules[l].Offset = "";
				}
			}
		}

		private void change_field(object sender, DataGridViewCellEventArgs e)
		{
		}

		private void click_field(object sender, DataGridViewCellEventArgs e)
		{
			int l = comboBox_lists.SelectedIndex;
			int lb = comboBox_lists.SelectedIndex;
			if (eLC_base.Version < 191 && eLC_recent.Version >= 191 && eLC_base.ConversationListIndex <= lb)
			{
				lb = lb + 1;
			}
			if (l > -1 && e.ColumnIndex == 3 && e.RowIndex > -1)
			{
				int displayRow = dataGridView_fields.FirstDisplayedCell.RowIndex;
				int displayCol = dataGridView_fields.FirstDisplayedCell.ColumnIndex;
				// click event don't has new state, we need to access next state property: EditedFormattedValue
				eRules[l].RemoveValues[e.RowIndex] = Convert.ToBoolean(dataGridView_fields.Rows[e.RowIndex].Cells[e.ColumnIndex].EditedFormattedValue);
				change_list(null, null);
				dataGridView_fields.FirstDisplayedCell = dataGridView_fields.Rows[displayRow].Cells[displayCol];
			}

			if (l > -1 && e.ColumnIndex == 4 && e.RowIndex > -1/* && !eRules[l]->RemoveValues[e->RowIndex]*/)
			{
				Cursor = Cursors.AppStarting;

				dataGridView_values.Rows.Clear();
				this.Column7.HeaderText = "Base Values";
				this.Column8.HeaderText = "Recent Values";

				int baseFieldIndex = 0;
				int recentFieldIndex = 0;

				for (int f = 0; f < e.RowIndex; f++)
				{
					if (eRules[l].RemoveValues[f])
					{
						baseFieldIndex--;
					}
					baseFieldIndex++;
					recentFieldIndex++;
				}

				if (recentFieldIndex < eLC_recent.Lists[l].elementFields.Length)
				{
					this.Column7.HeaderText = "Base Values (" + eLC_base.Lists[lb].elementValues.Length.ToString() + ")";
					this.Column8.HeaderText = "Recent Values (" + eLC_recent.Lists[l].elementValues.Length.ToString() + ")";

					for (int i = 0; i < eLC_recent.Lists[l].elementValues.Length; i++)
					{
						if (i < eLC_base.Lists[lb].elementValues.Length && baseFieldIndex < eLC_base.Lists[lb].elementFields.Length && !eRules[l].RemoveValues[recentFieldIndex])
						{
							dataGridView_values.Rows.Add(new string[] { eLC_base.GetValue(lb, i, baseFieldIndex), eLC_recent.GetValue(l, i, recentFieldIndex) });
							if (eLC_base.GetValue(lb, i, baseFieldIndex) != eLC_recent.GetValue(l, i, recentFieldIndex))
								dataGridView_values.Rows[i].DefaultCellStyle.BackColor = Color.Salmon;
						}
						else
						{
							dataGridView_values.Rows.Add(new string[] { "", eLC_recent.GetValue(l, i, recentFieldIndex) });
						}
						dataGridView_values.Rows[dataGridView_values.Rows.Count - 1].HeaderCell.Value = i.ToString();
					}
				}

				Cursor = Cursors.Default;
			}
		}

		private void click_viewRules(object sender, EventArgs e)
		{
			if (eRules != null)
			{
				string message = "";
				message += "##############################\r\n";
				message += "#### RULES FOR v" + eLC_recent.Version.ToString() + " -> v" + eLC_base.Version.ToString() + " ####\r\n";
				message += "##############################\r\n";

				message += "\r\nSETVERSION|" + eLC_base.Version.ToString();
				message += "\r\nSETSIGNATURE|" + eLC_base.Signature.ToString();
				message += "\r\nSETCONVERSATIONLISTINDEX|" + eLC_base.ConversationListIndex.ToString() + "\r\n";

				// find all remove lists
				for (int l = 0; l < eRules.Length; l++)
				{
					if (eRules[l].RemoveList)
					{
						message += "\r\nREMOVELIST:" + l.ToString();
					}
				}

				message += "\r\n";

				// find all replace offsets
				for (int l = 0; l < eRules.Length; l++)
				{
					if (eRules[l].ReplaceOffset)
					{
						message += "\r\nREPLACEOFFSET:" + l.ToString() + "|" + eRules[l].Offset;
					}
				}

				// find all remove values
				bool breakLine = true;
				for (int l = 0; l < eRules.Length; l++)
				{
					if (breakLine)
					{
						message += "\r\n";
						breakLine = false;
					}

					for (int f = 0; f < eRules[l].RemoveValues.Length; f++)
					{
						if (eRules[l].RemoveValues[f])
						{
							message += "\r\nREMOVEVALUE:" + l.ToString() + ":" + f.ToString();
							breakLine = true;
						}
					}
				}

				new DebugWindow("Rules v" + eLC_recent.Version.ToString() + " -> v" + eLC_base.Version.ToString(), message);
			}
		}

		private void click_importRules(object sender, EventArgs e)
		{
			if (eRules != null)
			{
				OpenFileDialog rLoad = new OpenFileDialog();
				rLoad.Filter = "Rules File (*.rules)|*.rules|All Files (*.*)|*.*";
				if (rLoad.ShowDialog() == DialogResult.OK && File.Exists(rLoad.FileName))
				{
					Cursor = Cursors.AppStarting;

					StreamReader sr = new StreamReader(rLoad.FileName);

					string[] values;
					string line;
					while ((line = sr.ReadLine()) != null)
					{
						System.Windows.Forms.Application.DoEvents();

						if (line != "" && !line.StartsWith("#"))
						{
							// use SETVERSION & SETSIGNATURE from eLC_base instead from rules
							/*
							if(line->StartsWith("SETVERSION|"))
							{
							}
							if(line->StartsWith("SETSIGNATURE|"))
							{
							}
							*/
							if (line.StartsWith("REMOVELIST:"))
							{
								values = line.Split(new char[] { ':' });
								eRules[Convert.ToInt32(values[1])].RemoveList = true;
							}
							if (line.StartsWith("REPLACEOFFSET:"))
							{
								values = line.Split(new char[] { ':', '|' });
								int l = Convert.ToInt32(values[1]);
								eRules[l].ReplaceOffset = true;
								// use offset from eLC_base instead the one from rules
								eRules[l].Offset = eLC_base.GetOffset(l); // eRules[l]->Offset = values[2];
							}
							if (line.StartsWith("REMOVEVALUE:"))
							{
								values = line.Split(new char[] { ':' });
								eRules[Convert.ToInt32(values[1])].RemoveValues[Convert.ToInt32(values[2])] = true;
							}
						}
					}

					sr.Close();

					change_list(null, null);

					Cursor = Cursors.Default;
				}
			}
		}

		private void click_exportRules(object sender, EventArgs e)
		{
			if (eRules != null)
			{
				SaveFileDialog rSave = new SaveFileDialog();
				rSave.Filter = "Rules File (*.rules)|*.rules|All Files (*.*)|*.*";
				rSave.FileName = "PW_v" + eLC_recent.Version.ToString() + " = PW_v" + eLC_base.Version.ToString() + ".rules";
				if (rSave.ShowDialog() == DialogResult.OK)
				{
					Cursor = Cursors.AppStarting;

					StreamWriter sw = new StreamWriter(rSave.FileName);

					sw.WriteLine("##############################");
					sw.WriteLine("#### RULES FOR v" + eLC_recent.Version.ToString() + " -> v" + eLC_base.Version.ToString() + " ####");
					sw.WriteLine("##############################");

					sw.WriteLine();

					sw.WriteLine("SETVERSION|" + eLC_base.Version.ToString());
					sw.WriteLine("SETSIGNATURE|" + eLC_base.Signature.ToString());
					sw.WriteLine("SETCONVERSATIONLISTINDEX|" + eLC_base.ConversationListIndex.ToString());

					sw.WriteLine();

					// find all remove lists
					for (int l = 0; l < eRules.Length; l++)
					{
						if (eRules[l].RemoveList)
						{
							sw.WriteLine("REMOVELIST:" + l.ToString());
						}
					}

					sw.WriteLine();

					// find all replace offsets
					for (int l = 0; l < eRules.Length; l++)
					{
						if (eRules[l].ReplaceOffset)
						{
							sw.WriteLine("REPLACEOFFSET:" + l.ToString() + "|" + eRules[l].Offset);
						}
					}

					// find all remove values
					bool breakLine = true;
					for (int l = 0; l < eRules.Length; l++)
					{
						if (breakLine)
						{
							sw.WriteLine();
							breakLine = false;
						}

						for (int f = 0; f < eRules[l].RemoveValues.Length; f++)
						{
							if (eRules[l].RemoveValues[f])
							{
								sw.WriteLine("REMOVEVALUE:" + l.ToString() + ":" + f.ToString());
								breakLine = true;
							}
						}
					}

					sw.Close();

					Cursor = Cursors.Default;
				}
			}
		}
	}
}
