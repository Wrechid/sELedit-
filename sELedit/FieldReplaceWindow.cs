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
	public partial class FieldReplaceWindow : Form
	{
		eListCollection eLC;
		eListCollection eLCOther;
		eListConversation conversationList;
		eListConversation conversationListOther;
        ColorProgressBar.ColorProgressBar cpb2_prog;
        private CacheSave database = new CacheSave();

        public FieldReplaceWindow(eListCollection ListCollection, eListConversation ListConversation, ref ColorProgressBar.ColorProgressBar progressBar_prog)
		{
            database = MainWindow.database;
            eLC = ListCollection;
			conversationList = ListConversation;
            cpb2_prog = progressBar_prog;
            InitializeComponent();
            cpb2.Value = 0;
            colorTheme();
			for (int l = 0; l < eLC.Lists.Length; l++)
			{
				comboBox_List.Items.Add("[" + l + "]: " + eLC.Lists[l].listName + " (" + eLC.Lists[l].elementValues.Length + ")");
			}
			CheckReplaceButton(null, null);
		}

        private void colorTheme()
        {
            if (database.arrTheme != null)
            {
                BackColor = Color.FromName(database.arrTheme[0]);

                cpb2.BarColor = Color.FromName(database.arrTheme[17]);

                label1.ForeColor = Color.FromName(database.arrTheme[1]);
                label2.ForeColor = Color.FromName(database.arrTheme[1]);
                label3.ForeColor = Color.FromName(database.arrTheme[1]);
                label4.ForeColor = Color.FromName(database.arrTheme[1]);

                comboBox_Field.DrawMode = DrawMode.OwnerDrawFixed;
                comboBox_Field.FlatStyle = FlatStyle.Flat;
                comboBox_Field.BackColor = Color.FromName(database.arrTheme[7]);
                comboBox_List.DrawMode = DrawMode.OwnerDrawFixed;
                comboBox_List.FlatStyle = FlatStyle.Flat;
                comboBox_List.BackColor = Color.FromName(database.arrTheme[7]);
                
                textBox_ElementPath.BackColor = Color.FromName(database.arrTheme[6]);
                textBox_LogDir.BackColor = Color.FromName(database.arrTheme[6]);

                textBox_ElementPath.ForeColor = Color.FromName(database.arrTheme[1]);
                textBox_LogDir.ForeColor = Color.FromName(database.arrTheme[1]);

                button_browseElement.BackColor = Color.FromName(database.arrTheme[11]);
                button_browseLogDit.BackColor = Color.FromName(database.arrTheme[11]);
                button_LoadElement.BackColor = Color.FromName(database.arrTheme[11]);
                button_cancel.BackColor = Color.FromName(database.arrTheme[11]);
                button_replace.BackColor = Color.FromName(database.arrTheme[11]);

                button_browseElement.ForeColor = Color.FromName(database.arrTheme[1]);
                button_browseLogDit.ForeColor = Color.FromName(database.arrTheme[1]);
                button_cancel.ForeColor = Color.FromName(database.arrTheme[1]);
                button_LoadElement.ForeColor = Color.FromName(database.arrTheme[1]);
                button_replace.ForeColor = Color.FromName(database.arrTheme[1]);
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
                if (database.arrTheme != null)
                    textBox_ElementPath.BackColor = Color.FromName(database.arrTheme[6]);
                else
                    textBox_ElementPath.BackColor = Color.FromName("Window");
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
				Cursor = Cursors.Default;
			}
			CheckReplaceButton(null, null);
		}

		private void change_list(object sender, EventArgs e)
		{
			comboBox_Field.Items.Clear();
			comboBox_Field.SelectedIndex = -1;
			int l = comboBox_List.SelectedIndex;
			for (int i = 0; i < eLC.Lists[l].elementFields.Length; i++)
			{
				comboBox_Field.Items.Add("[" + i + "] - " + eLC.Lists[l].elementFields[i]);
			}
			CheckReplaceButton(null, null);
		}

		private void click_replace(object sender, EventArgs e)
		{
			if (eLCOther != null && comboBox_List.SelectedIndex > -1 && comboBox_Field.SelectedIndex > -1)
			{
				if (textBox_LogDir.Text != "")
				{
					StreamWriter sw = new StreamWriter(textBox_LogDir.Text + "\\Field_Replace.txt", false, Encoding.Unicode);
					sw.Close();
					int l = comboBox_List.SelectedIndex;
					int lo = comboBox_List.SelectedIndex;
					int FieldIndex = comboBox_Field.SelectedIndex;
					int FieldIndexOther = -1;
					int ReplacedCount = 0;
					if (l != eLC.ConversationListIndex)
					{
						if (eLC.Version < 191 && eLCOther.Version >= 191 && comboBox_List.SelectedIndex >= eLC.ConversationListIndex)
							l++;
						if (eLC.Version >= 191 && eLCOther.Version < 191 && comboBox_List.SelectedIndex >= eLCOther.ConversationListIndex)
							lo++;
						if (l < eLC.Lists.Length && lo < eLCOther.Lists.Length)
						{
							cpb2.Maximum = eLCOther.Lists[lo].elementValues.Length;
							for (int i = 0; i < eLCOther.Lists[lo].elementFields.Length; i++)
							{
								if (eLC.Lists[l].elementFields[FieldIndex] == eLCOther.Lists[lo].elementFields[i])
								{
									FieldIndexOther = i;
									break;
								}
							}
							if (FieldIndexOther > -1)
							{
								File.AppendAllText(textBox_LogDir.Text + "\\Field_Replace.txt", "List: " + eLC.Lists[l].listName + " | Field: " + FieldIndex + " - " + eLC.Lists[l].elementFields[FieldIndex] + "\r\n\r\n\r\n", Encoding.Unicode);
								for (int i = 0; i < eLC.Lists[l].elementValues.Length && i < eLCOther.Lists[lo].elementValues.Length; i++)
								{
									for (int io = 0; io < eLCOther.Lists[lo].elementValues.Length; io++)
									{
										if (eLC.GetValue(l, i, 0) == eLCOther.GetValue(lo, io, 0))
										{
											if (eLC.GetValue(l, i, FieldIndex) != eLCOther.GetValue(lo, io, FieldIndexOther))
											{
												File.AppendAllText(textBox_LogDir.Text + "\\Field_Replace.txt", "REPLACED\t\tID:" + eLC.GetValue(l, i, 0) + "\t\tValue: " + eLC.GetValue(l, i, FieldIndex) + "(by: " + eLCOther.GetValue(lo, io, FieldIndexOther) + ")\r\n", Encoding.Unicode);
												eLC.Lists[l].elementValues[i][FieldIndex] = eLCOther.Lists[lo].elementValues[io][FieldIndexOther];
												ReplacedCount++;
											}
											else
												File.AppendAllText(textBox_LogDir.Text + "\\Field_Replace.txt", "NO REPLACED\t\tID:" + eLC.GetValue(l, i, 0) + "\t\tValue: " + eLC.GetValue(l, i, FieldIndex) + "\r\n", Encoding.Unicode);
											cpb2.Value++;
                                            Application.DoEvents();
										}
									}
								}
							}
						}
					}
					else
					{
						cpb2.Maximum = conversationList.talk_proc_count;
						for (int t = 0; t < conversationList.talk_proc_count; t++)
						{
							for (int to = 0; to < conversationListOther.talk_proc_count; to++)
							{
								if (conversationList.talk_procs[t].id_talk == conversationListOther.talk_procs[to].id_talk)
								{
									for (int w = 0; w < conversationList.talk_procs[t].num_window; w++)
									{
										for (int wo = 0; wo < conversationListOther.talk_procs[to].num_window; wo++)
										{
											if (conversationList.talk_procs[t].windows[w].id == conversationListOther.talk_procs[to].windows[wo].id)
											{
												conversationList.talk_procs[t].windows[w].talk_text_len = conversationListOther.talk_procs[to].windows[wo].talk_text_len;
												conversationList.talk_procs[t].windows[w].talk_text = conversationListOther.talk_procs[to].windows[wo].talk_text;
												ReplacedCount++;
												for (int o = 0; o < conversationList.talk_procs[t].windows[w].num_option && o < conversationListOther.talk_procs[to].windows[wo].num_option; o++)
												{
													conversationList.talk_procs[t].windows[w].options[o].text = conversationListOther.talk_procs[to].windows[wo].options[o].text;
													ReplacedCount++;
												}
											}
										}
									}
								}
							}
							cpb2.Value++;
                            Application.DoEvents();
						}
					}
					cpb2.Value = 0;
					MessageBox.Show(ReplacedCount + " Values Replaced");
				}
			}
		}

		private void CheckReplaceButton(object sender, EventArgs e)
		{
			if (eLCOther != null && comboBox_List.SelectedIndex > -1 && comboBox_Field.SelectedIndex > -1 && textBox_ElementPath.Text != "")
				button_replace.Enabled = true;
			else
				button_replace.Enabled = false;
		}

		private void click_close(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
