using System;
using System.Collections;
using System.IO;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using System.Diagnostics;
using System.Threading;
using System.Collections.Generic;

namespace sELedit
{
	public partial class MainWindow : Form
	{
        public static eListCollection eLC;
		public eListConversation conversationList;
		string[][] xrefs;
		private Point mouseMoveCheck;
		public bool EnableSelectionList = true;
		public bool EnableSelectionItem = true;
		string ElementsPath = "";
        public Bitmap raw_img;
        public static string[] buff_str;
        public static string[] item_ext_desc;
        public static string[] skillstr;
        public static SortedList addonslist;
        public static SortedList InstanceList;
        public static CacheSave database = null;
        private int proctypeLocation = 0;
        private int proctypeLocationvak = 0;
        private IToolType customTooltype;
        public static SortedList LocalizationText;

        public AssetManager asm;

        public MainWindow()
		{
			InitializeComponent();

            Assembly assembly = Assembly.GetExecutingAssembly();
            FileVersionInfo fileVersionInfo = FileVersionInfo.GetVersionInfo(assembly.Location);
            label_Version.Text = "Wrechid Was Here... v" + fileVersionInfo.ProductVersion;

            asm = new AssetManager();
            asm.load();
            cpb2.Value = 0;
            colorTheme();

            mouseMoveCheck = new Point(0, 0);
        }

        private void colorTheme()
        {
            if (database.arrTheme != null)
            {
                comboBox_lists.DrawMode = DrawMode.OwnerDrawFixed;
                comboBox_lists.FlatStyle = FlatStyle.Flat;

                menuStrip_mainMenu.RenderMode = ToolStripRenderMode.Professional;

                BackColor = Color.FromName(database.arrTheme[0]);
                cpb2.BarColor = Color.FromName(database.arrTheme[17]);

                label1.ForeColor = Color.FromName(database.arrTheme[1]);

                checkBox_SearchAll.ForeColor = Color.FromName(database.arrTheme[1]);
                checkBox_SearchExactMatching.ForeColor = Color.FromName(database.arrTheme[1]);
                checkBox_SearchMatchCase.ForeColor = Color.FromName(database.arrTheme[1]);

                textBox_offset.ForeColor = Color.FromName(database.arrTheme[1]);
                textBox_search.ForeColor = Color.FromName(database.arrTheme[1]);
                textBox_SetValue.ForeColor = Color.FromName(database.arrTheme[1]);

                menuStrip_mainMenu.BackColor = Color.FromName(database.arrTheme[2]);
                textBox_offset.BackColor = Color.FromName(database.arrTheme[6]);
                textBox_search.BackColor = Color.FromName(database.arrTheme[6]);
                textBox_SetValue.BackColor = Color.FromName(database.arrTheme[6]);
                comboBox_lists.BackColor = Color.FromName(database.arrTheme[7]);

                dataGridView_elems.BackgroundColor = Color.FromName(database.arrTheme[12]);
                dataGridView_elems.ColumnHeadersDefaultCellStyle.BackColor = Color.FromName(database.arrTheme[13]);
                dataGridView_elems.RowHeadersDefaultCellStyle.BackColor = Color.FromName(database.arrTheme[13]);
                dataGridView_elems.DefaultCellStyle.BackColor = Color.FromName(database.arrTheme[13]);
                dataGridView_elems.DefaultCellStyle.SelectionBackColor = Color.FromName(database.arrTheme[14]);
                dataGridView_elems.DefaultCellStyle.ForeColor = Color.FromName(database.arrTheme[15]);
                dataGridView_elems.DefaultCellStyle.SelectionForeColor = Color.FromName(database.arrTheme[15]);
                dataGridView_elems.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromName(database.arrTheme[15]);
                dataGridView_elems.RowHeadersDefaultCellStyle.ForeColor = Color.FromName(database.arrTheme[15]);
                dataGridView_item.BackgroundColor = Color.FromName(database.arrTheme[12]);
                dataGridView_item.ColumnHeadersDefaultCellStyle.BackColor = Color.FromName(database.arrTheme[13]);
                dataGridView_item.RowHeadersDefaultCellStyle.BackColor = Color.FromName(database.arrTheme[13]);
                dataGridView_item.DefaultCellStyle.BackColor = Color.FromName(database.arrTheme[13]);
                dataGridView_item.DefaultCellStyle.SelectionBackColor = Color.FromName(database.arrTheme[14]);
                dataGridView_item.RowHeadersDefaultCellStyle.SelectionBackColor = Color.FromName(database.arrTheme[14]);
                dataGridView_item.DefaultCellStyle.ForeColor = Color.FromName(database.arrTheme[15]);
                dataGridView_item.DefaultCellStyle.SelectionForeColor = Color.FromName(database.arrTheme[15]);
                dataGridView_item.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromName(database.arrTheme[15]);
                dataGridView_item.RowHeadersDefaultCellStyle.ForeColor = Color.FromName(database.arrTheme[15]);

                button_search.BackColor = Color.FromName(database.arrTheme[11]);
                button_SetValue.BackColor = Color.FromName(database.arrTheme[11]);
                button_search.ForeColor = Color.FromName(database.arrTheme[1]);
                button_SetValue.ForeColor = Color.FromName(database.arrTheme[1]);

                menuStrip_mainMenu.Renderer = new MyRenderer();
                contextMenuStrip_items.Renderer = new MyRenderer();
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
			OpenFileDialog eLoad = new OpenFileDialog();
			eLoad.Filter = "Elements File (*.data)|*.data|All Files (*.*)|*.*";
			if (eLoad.ShowDialog() == DialogResult.OK && File.Exists(eLoad.FileName))
			{
				try
				{
					Cursor = Cursors.AppStarting;
					//progressBar_progress.Style = ProgressBarStyle.Continuous;

					eLC = new eListCollection(eLoad.FileName, ref cpb2);

					this.exportContainerToolStripMenuItem.DropDownItems.Clear();

					// search for available export rules
					if (eLC.ConfigFile != null)
					{
						this.exportContainerToolStripMenuItem.DropDownItems.Add(new ToolStripLabel("Select a valid Conversation Rules Set"));
						this.exportContainerToolStripMenuItem.DropDownItems[0].Font = new Font("Tahoma", 8.25F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
						this.exportContainerToolStripMenuItem.DropDownItems.Add(new ToolStripSeparator());
						string[] files = Directory.GetFiles(Application.StartupPath + "\\rules", "PW_v" + eLC.Version.ToString() + "*.rules");
						for (int i = 0; i < files.Length; i++)
						{
							files[i] = files[i].Replace("=", "=>");
							files[i] = files[i].Replace(".rules", "");
							files[i] = files[i].Replace(Application.StartupPath + "\\rules\\", "");
							this.exportContainerToolStripMenuItem.DropDownItems.Add(files[i], null, new EventHandler(this.click_export));
						}
					}
					// load cross references list
					if (eLC.ConfigFile != null)//Вроде работает
					{
						string[] referencefiles = Directory.GetFiles(Application.StartupPath + "\\configs", "references.txt");
						if (referencefiles.Length > 0)
						{
							StreamReader sr = new StreamReader(referencefiles[0]);
							char[] chars = { ';', ',' };
							string[] x;
							xrefs = new string[eLC.Lists.Length][];
							string line;
							while (!sr.EndOfStream)
							{
								line = sr.ReadLine();
								if (!line.StartsWith("#"))
								{
									x = line.Split(chars);
									if (int.Parse(x[0]) < eLC.Lists.Length)
									{
										xrefs[int.Parse(x[0])] = x;
									}
								}
							}
							this.toolStripSeparator6.Visible = true;
							this.xrefItemToolStripMenuItem.Visible = true;
						}
					}

					if (eLC.ConversationListIndex > -1 && eLC.Lists.Length > eLC.ConversationListIndex)
					{
						conversationList = new eListConversation((byte[])eLC.Lists[eLC.ConversationListIndex].elementValues[0][0]);
					}

					dataGridView_item.Rows.Clear();
					comboBox_lists.Items.Clear();
					for (int l = 0; l < eLC.Lists.Length; l++)
					{
						comboBox_lists.Items.Add("[" + l + "] " + eLC.Lists[l].listName.Split(new string[] { " - " }, StringSplitOptions.None)[1] + " (" + eLC.Lists[l].elementValues.Length + ")");
					}
					string timestamp = "";
					if (eLC.Lists[0].listOffset.Length > 0)
						timestamp = ", Timestamp: " + timestamp_to_string(BitConverter.ToUInt32(eLC.Lists[0].listOffset, 0));
					this.Text = " sELedit++ (" + eLoad.FileName + " [Version: " + eLC.Version.ToString() + timestamp + "])";
					ElementsPath = eLoad.FileName;

					cpb2.Value = 0;
					//progressBar_progress.Style = ProgressBarStyle.Continuous;

                    comboBox_lists.SelectedIndex = 0;

                    Cursor = Cursors.Default;
				}
				catch
				{
                    //MessageBox.Show(eListCollection.SStat[0].ToString() + "\n" + eListCollection.SStat[1].ToString() + "\n" + eListCollection.SStat[2].ToString());
                    MessageBox.Show("LOADING ERROR!\n\nThis error usually occurs if incorrect configuration, structure, or encrypted elements.data file...\nIf you are using elements.list.count trying to decrypt, its likely the last list item count is incorrect... \nUse details below to assist... \n\nRead Failed at this point :\n" + eListCollection.SStat[0].ToString() + " - List #\n" + eListCollection.SStat[1].ToString() + " - # Items This List\n" + eListCollection.SStat[2].ToString() + " - Item ID");
					//progressBar_progress.Style = ProgressBarStyle.Continuous;
					Cursor = Cursors.Default;
				}
			}
		}

		private void click_save(object sender, EventArgs e)
		{

			SaveFileDialog eSave = new SaveFileDialog();
			eSave.InitialDirectory = Environment.CurrentDirectory;
			eSave.Filter = "Elements File (*.data)|*.data|All Files (*.*)|*.*";
			if (eSave.ShowDialog() == DialogResult.OK && eSave.FileName != "")
			{
				try
				{
					Cursor = Cursors.AppStarting;
					//progressBar_progress.Style = ProgressBarStyle.Marquee;
					//File.Copy(eSave.FileName, eSave.FileName + ".bak", true);
					if (eLC.ConversationListIndex > -1 && eLC.Lists.Length > eLC.ConversationListIndex)
					{
						eLC.Lists[eLC.ConversationListIndex].elementValues[0][0] = conversationList.GetBytes();
					}
					eLC.Save(eSave.FileName);
					//progressBar_progress.Style = ProgressBarStyle.Continuous;
					Cursor = Cursors.Default;
                }
                catch
                {
                    MessageBox.Show("SAVING ERROR!\nThis error mostly occurs of configuration and elements.data mismatch");
                    //progressBar_progress.Style = ProgressBarStyle.Continuous;
                    Cursor = Cursors.Default;
                }
            }
		}

		private void click_save2(object sender, EventArgs e)
		{
			if (ElementsPath != "" && File.Exists(ElementsPath))
			{
				try
				{
					Cursor = Cursors.AppStarting;
					//progressBar_progress.Style = ProgressBarStyle.Marquee;
					File.Copy(ElementsPath, ElementsPath + ".bak", true);
					if (eLC.ConversationListIndex > -1 && eLC.Lists.Length > eLC.ConversationListIndex)
					{
						eLC.Lists[eLC.ConversationListIndex].elementValues[0][0] = conversationList.GetBytes();
					}
					eLC.Save(ElementsPath);
					//progressBar_progress.Style = ProgressBarStyle.Continuous;
					Cursor = Cursors.Default;
				}
				catch
				{
					MessageBox.Show("SAVING ERROR!\nThis error mostly occurs of configuration and elements.data mismatch");
					//progressBar_progress.Style = ProgressBarStyle.Continuous;
					Cursor = Cursors.Default;
				}
			}
		}

		private void click_export(object sender, EventArgs e)
		{
			SaveFileDialog eSave = new SaveFileDialog();
			eSave.Filter = "Elements File (*.data)|*.data|All Files (*.*)|*.*";
			if (eSave.ShowDialog() == DialogResult.OK && eSave.FileName != "")
			{
				try
				{
					int start = ((ToolStripMenuItem)sender).Text.IndexOf(" ==> ") + 5;

					Cursor = Cursors.WaitCursor;
					//progressBar_progress.Style = ProgressBarStyle.Marquee;
					string rulesFile = Application.StartupPath + "\\rules\\" + ((ToolStripMenuItem)sender).Text.Replace("=>", "=") + ".rules";
					eLC.Export(rulesFile, eSave.FileName);
					//progressBar_progress.Style = ProgressBarStyle.Continuous;
					Cursor = Cursors.Default;
				}
				catch
				{
					MessageBox.Show("EXPORTING ERROR!\nThis error mostly occurs if selected rules fileset is invalid");
					//progressBar_progress.Style = ProgressBarStyle.Continuous;
					Cursor = Cursors.Default;
				}
			}
		}

		private void change_list(object sender, EventArgs ea)
		{
		if (comboBox_lists.SelectedIndex > -1 && EnableSelectionList)
			{
				int l = comboBox_lists.SelectedIndex;
                dataGridView_elems.Rows.Clear();
				textBox_offset.Text = eLC.GetOffset(l);
				dataGridView_item.Rows.Clear();
				this.xrefItemToolStripMenuItem.Enabled = true;
				try
				{
					int ajk = xrefs[l].Length;
				}
				catch
				{
					this.xrefItemToolStripMenuItem.Enabled = false;
				}

				if (l != eLC.ConversationListIndex)
				{
					// Find Position for Name
					int pos = -1;
                    int pos2 = -1;
                    for (int i = 0; i < eLC.Lists[l].elementFields.Length; i++)
					{
						if (eLC.Lists[l].elementFields[i] == "Name")
						{
							pos = i;
						}
                        if (eLC.Lists[l].elementFields[i] == "file_icon" || eLC.Lists[l].elementFields[i] == "file_icon1")
                        {
                            pos2 = i;
                        }
                        if (pos != -1 && pos2 != -1) { break; }
                    }
					for (int e = 0; e < eLC.Lists[l].elementValues.Length; e++)
					{
						if (eLC.Lists[l].elementFields[0] == "ID")
						{
                            Bitmap img = Properties.Resources.blank;
                            string path = Path.GetFileName(eLC.GetValue(l, e, pos2));
                            if (database.sourceBitmap != null && database.ContainsKey(path))
                            {
                                if (database.ContainsKey(path))
                                {
                                    img = database.images(path);
                                }
                            }
                            dataGridView_elems.Rows.Add(new object[] { eLC.GetValue(l, e, 0), img, eLC.GetValue(l, e, pos) });
                        }
						else
						{
                            dataGridView_elems.Rows.Add(new object[] { 0, Properties.Resources.blank, eLC.GetValue(l, e, pos) });
                        }
					}
				}
				else
				{
					for (int e = 0; e < conversationList.talk_proc_count; e++)
					{
                        dataGridView_elems.Rows.Add(new object[] { conversationList.talk_procs[e].id_talk, Properties.Resources.blank, conversationList.talk_procs[e].id_talk + " - Dialog" });
                    }
				}
			}
		}

		private void change_item(object sender, EventArgs ea)
		{
			if (EnableSelectionItem)
			{
				int l = comboBox_lists.SelectedIndex;
                if (dataGridView_elems.CurrentCell == null) { return; }
                int e = dataGridView_elems.CurrentCell.RowIndex;
                int scroll = dataGridView_item.FirstDisplayedScrollingRowIndex;
                dataGridView_item.SuspendLayout();
                dataGridView_item.Rows.Clear();
                proctypeLocation = 0;
                proctypeLocationvak = 0;
                try
                {
                    if (l != eLC.ConversationListIndex)
                    {
                        if (e > -1)
                        {
                            dataGridView_item.Enabled = false;
                            for (int f = 0; f < eLC.Lists[l].elementValues[e].Length; f++)
                            {
                                dataGridView_item.Rows.Add(new string[] { eLC.Lists[l].elementFields[f], eLC.Lists[l].elementTypes[f], eLC.GetValue(l, e, f) });
                                dataGridView_item.Rows[f].HeaderCell.Value = f.ToString();
                            }
                            dataGridView_item.Enabled = true;
                            dataGridView_item.PerformLayout();
                            dataGridView_item.ResumeLayout();
                        }
                    }
                    else
                    {
                        if (e > -1)
                        {
                            dataGridView_item.Rows.Add(new string[] { "id_talk", "int32", conversationList.talk_procs[e].id_talk.ToString() });
                            dataGridView_item.Rows.Add(new string[] { "text", "wstring:128", conversationList.talk_procs[e].GetText() });
                            for (int q = 0; q < conversationList.talk_procs[e].num_window; q++)
                            {
                                dataGridView_item.Rows.Add(new string[] { "window_" + q + "_id", "int32", conversationList.talk_procs[e].windows[q].id.ToString() });
                                dataGridView_item.Rows.Add(new string[] { "window_" + q + "_id_parent", "int32", conversationList.talk_procs[e].windows[q].id_parent.ToString() });
                                dataGridView_item.Rows.Add(new string[] { "window_" + q + "_talk_text", "wstring:" + conversationList.talk_procs[e].windows[q].talk_text_len, conversationList.talk_procs[e].windows[q].GetText() });
                                for (int c = 0; c < conversationList.talk_procs[e].windows[q].num_option; c++)
                                {
                                    dataGridView_item.Rows.Add(new string[] { "window_" + q + "_option_" + c + "_param", "int32", conversationList.talk_procs[e].windows[q].options[c].param.ToString() });
                                    dataGridView_item.Rows.Add(new string[] { "window_" + q + "_option_" + c + "_text", "wstring:128", conversationList.talk_procs[e].windows[q].options[c].GetText() });
                                    dataGridView_item.Rows.Add(new string[] { "window_" + q + "_option_" + c + "_id", "int32", conversationList.talk_procs[e].windows[q].options[c].id.ToString() });
                                }
                            }
                        }
                    }
                    if (scroll > -1)
                    {
                        dataGridView_item.FirstDisplayedScrollingRowIndex = scroll;
                    }
                }
                catch { }
			}
		}

		private void change_offset(object sender, EventArgs e)
		{
			eLC.SetOffset(comboBox_lists.SelectedIndex, textBox_offset.Text);
		}

		private void change_value(object sender, DataGridViewCellEventArgs ea)
		{
			try
			{
				if (eLC != null && ea.ColumnIndex > -1)
				{
					int l = comboBox_lists.SelectedIndex;
					int f = ea.RowIndex;
                    int r = dataGridView_elems.CurrentCell.RowIndex;
                    if (l != eLC.ConversationListIndex)
					{
						EnableSelectionItem = false;
                        int[] selIndices = gridSelectedIndices(dataGridView_elems);
						for (int e = 0; e < selIndices.Length; e++)
						{
							eLC.SetValue(l, selIndices[e], f, Convert.ToString(dataGridView_item.CurrentCell.Value));

							if (dataGridView_item.Rows[f].Cells[0].Value.ToString() == "ID" || dataGridView_item.Rows[f].Cells[0].Value.ToString() == "Name" || dataGridView_item.Rows[f].Cells[0].Value.ToString() == "file_icon" || dataGridView_item.Rows[f].Cells[0].Value.ToString() == "file_icon1")
							{
                                // change the values in the listbox depending on new name & id

                                // Find Position for Name
                                int pos = -1;
                                int pos2 = -1;
                                for (int i = 0; i < eLC.Lists[l].elementFields.Length; i++)
                                {
                                    if (eLC.Lists[l].elementFields[i] == "Name")
                                    {
                                        pos = i;
                                    }
                                    if (eLC.Lists[l].elementFields[i] == "file_icon" || eLC.Lists[l].elementFields[i] == "file_icon1")
                                    {
                                        pos2 = i;
                                    }
                                    if (pos != -1 && pos2 != -1)
                                    {
                                        break;
                                    }
                                }
                                Bitmap img = Properties.Resources.blank;
                                string path = Path.GetFileName(eLC.GetValue(l, selIndices[e], pos2));
                                if (database.sourceBitmap != null && database.ContainsKey(path))
                                {
                                    if (database.ContainsKey(path))
                                    {
                                        img = database.images(path);
                                    }
                                }
                                dataGridView_elems.Rows[selIndices[e]].Cells[0].Value = eLC.GetValue(l, selIndices[e], 0);
                                dataGridView_elems.Rows[selIndices[e]].Cells[1].Value = img;
                                dataGridView_elems.Rows[selIndices[e]].Cells[2].Value = eLC.GetValue(l, selIndices[e], pos);
							}
						}
						EnableSelectionItem = true;
					}
					else
					{
						//TALK_PROCs check which item was changed by field name
						string fieldName = dataGridView_item[0, ea.RowIndex].Value.ToString();

						if (fieldName == "id_talk")
						{
							conversationList.talk_procs[r].id_talk = Convert.ToInt32(dataGridView_item.CurrentCell.Value);
							return;
						}
						if (fieldName == "text")
						{
							conversationList.talk_procs[r].SetText(dataGridView_item.CurrentCell.Value.ToString());
							return;
						}
						if (fieldName.StartsWith("window_") && fieldName.EndsWith("_id"))
						{
							int q = Convert.ToInt32(fieldName.Replace("window_", "").Replace("_id", ""));
							conversationList.talk_procs[r].windows[q].id = Convert.ToInt32(dataGridView_item.CurrentCell.Value);
							return;
						}
						if (fieldName.StartsWith("window_") && fieldName.Contains("option_") && fieldName.EndsWith("_param"))
						{
							string[] s = fieldName.Replace("window_", "").Replace("_option_", ";").Replace("_param", "").Split(new char[] { ';' });
							int q = Convert.ToInt32(s[0]);
							int c = Convert.ToInt32(s[1]);
							conversationList.talk_procs[r].windows[q].options[c].param = Convert.ToInt32(dataGridView_item.CurrentCell.Value);
							return;
						}
						if (fieldName.StartsWith("window_") && fieldName.Contains("option_") && fieldName.EndsWith("_text"))
						{
							string[] s = fieldName.Replace("window_", "").Replace("_option_", ";").Replace("_text", "").Split(new char[] { ';' });
							int q = Convert.ToInt32(s[0]);
							int c = Convert.ToInt32(s[1]);
							conversationList.talk_procs[r].windows[q].options[c].SetText(dataGridView_item.CurrentCell.Value.ToString());
							return;
						}
						if (fieldName.StartsWith("window_") && fieldName.Contains("option_") && fieldName.EndsWith("_id"))
						{
							string[] s = fieldName.Replace("window_", "").Replace("_option_", ";").Replace("_id", "").Split(new char[] { ';' });
							int q = Convert.ToInt32(s[0]);
							int c = Convert.ToInt32(s[1]);
							conversationList.talk_procs[r].windows[q].options[c].id = Convert.ToInt32(dataGridView_item.CurrentCell.Value);
							return;
						}
						if (fieldName.StartsWith("window_") && fieldName.EndsWith("_id_parent"))
						{
							int q = Convert.ToInt32(fieldName.Replace("window_", "").Replace("_id_parent", ""));
							conversationList.talk_procs[r].windows[q].id_parent = Convert.ToInt32(dataGridView_item.CurrentCell.Value);
							return;
						}
						if (fieldName.StartsWith("window_") && fieldName.EndsWith("_talk_text"))
						{
							int q = Convert.ToInt32(fieldName.Replace("window_", "").Replace("_talk_text", ""));
							conversationList.talk_procs[r].windows[q].SetText(dataGridView_item.CurrentCell.Value.ToString());
							dataGridView_item[1, ea.RowIndex].Value = "wstring:" + conversationList.talk_procs[r].windows[q].talk_text_len;
							return;
						}
					}
				}
			}
			catch
			{
				MessageBox.Show("CHANGING ERROR!\nFailed changing value, this value seems to be invalid.");
			}
		}

		private void click_search(object sender, EventArgs ea)
		{
			string id = textBox_search.Text;
			if (!checkBox_SearchMatchCase.Checked)
				id = id.ToLower();
			string value = "";
			int l = comboBox_lists.SelectedIndex;
			if (l < 0) { l = 0; }
			int f = 0;
			if (dataGridView_item.CurrentCell != null)
				f = dataGridView_item.CurrentCell.RowIndex + 1;
			if (f < 0) { f = 0; }
			if (eLC != null && eLC.Lists != null)
			{
				EnableSelectionItem = false;
				int ftmp = f;
				if (checkBox_SearchAll.Checked)
				{
                    int e = dataGridView_elems.CurrentCell.RowIndex;
					if (e < 0) { e = 0; }
					int etmp = e;
					for (int lf = l; lf < eLC.Lists.Length; lf++)
					{
						for (int ef = etmp; ef < eLC.Lists[lf].elementValues.Length; ef++)
						{
							for (int ff = ftmp; ff < eLC.Lists[lf].elementFields.Length; ff++)
							{
								if (checkBox_SearchExactMatching.Checked)
								{
									if (eLC.GetValue(lf, ef, ff) == id)
									{
										comboBox_lists.SelectedIndex = lf;
                                        dataGridView_elems.ClearSelection();
										EnableSelectionItem = true;
                                        dataGridView_elems.CurrentCell = dataGridView_elems[0, ef];
                                        dataGridView_elems.Rows[ef].Selected = true;
                                        dataGridView_elems.FirstDisplayedScrollingRowIndex = ef;
										dataGridView_item.CurrentCell = dataGridView_item.Rows[ff].Cells[2];
										return;
									}
								}
								else
								{
									value = eLC.GetValue(lf, ef, ff);
									if (!checkBox_SearchMatchCase.Checked)
										value = value.ToLower();
									if (value.Contains(id))
									{
										comboBox_lists.SelectedIndex = lf;
                                        dataGridView_elems.ClearSelection();
                                        EnableSelectionItem = true;
                                        dataGridView_elems.CurrentCell = dataGridView_elems[0, ef];
                                        dataGridView_elems.Rows[ef].Selected = true;
                                        dataGridView_elems.FirstDisplayedScrollingRowIndex = ef;
                                        dataGridView_item.CurrentCell = dataGridView_item.Rows[ff].Cells[2];
										return;
									}
								}
							}
							ftmp = 0;
						}
						etmp = 0;
					}
					etmp = e;
					ftmp = f;
					for (int lf = 0; lf < eLC.Lists.Length && lf <= l; lf++)
					{
						for (int ef = 0; ef < eLC.Lists[lf].elementValues.Length; ef++)
						{
							for (int ff = 0; ff < eLC.Lists[lf].elementFields.Length; ff++)
							{
								if (checkBox_SearchExactMatching.Checked)
								{
									if (eLC.GetValue(lf, ef, ff) == id)
									{
										comboBox_lists.SelectedIndex = lf;
                                        dataGridView_elems.ClearSelection();
                                        EnableSelectionItem = true;
                                        dataGridView_elems.CurrentCell = dataGridView_elems[0, ef];
                                        dataGridView_elems.Rows[ef].Selected = true;
                                        dataGridView_elems.FirstDisplayedScrollingRowIndex = ef;
                                        dataGridView_item.CurrentCell = dataGridView_item.Rows[ff].Cells[2];
										return;
									}
								}
								else
								{
									value = eLC.GetValue(lf, ef, ff);
									if (!checkBox_SearchMatchCase.Checked)
										value = value.ToLower();
									if (value.Contains(id))
									{
										comboBox_lists.SelectedIndex = lf;
                                        dataGridView_elems.ClearSelection();
                                        EnableSelectionItem = true;
                                        dataGridView_elems.CurrentCell = dataGridView_elems[0, ef];
                                        dataGridView_elems.Rows[ef].Selected = true;
                                        dataGridView_elems.FirstDisplayedScrollingRowIndex = ef;
                                        dataGridView_item.CurrentCell = dataGridView_item.Rows[ff].Cells[2];
										return;
									}
								}
							}
							ftmp = 0;
						}
						etmp = 0;
					}
				}
				else
				{
                    int e = dataGridView_elems.CurrentCell.RowIndex + 1;
                    if (e < 0) { e = 0; }
					int etmp = e;
					for (int lf = l; lf < eLC.Lists.Length; lf++)
					{
						int pos = 0;
						for (int i = 0; i < eLC.Lists[lf].elementFields.Length; i++)
						{
							if (eLC.Lists[lf].elementFields[i] == "Name")
							{
								pos = i;
								break;
							}
						}
						for (int ef = etmp; ef < eLC.Lists[lf].elementValues.Length; ef++)
						{
							if (checkBox_SearchExactMatching.Checked)
							{
								if (id == eLC.GetValue(lf, ef, 0) || eLC.GetValue(lf, ef, pos) == id)
								{
									comboBox_lists.SelectedIndex = lf;
                                    dataGridView_elems.ClearSelection();
                                    EnableSelectionItem = true;
                                    dataGridView_elems.CurrentCell = dataGridView_elems[0, ef];
                                    dataGridView_elems.Rows[ef].Selected = true;
                                    dataGridView_elems.FirstDisplayedScrollingRowIndex = ef;
                                    return;
								}
							}
							else
							{
								value = eLC.GetValue(lf, ef, pos);
								if (!checkBox_SearchMatchCase.Checked)
									value = value.ToLower();
								if (id == eLC.GetValue(lf, ef, 0) || value.Contains(id))
								{
									comboBox_lists.SelectedIndex = lf;
                                    dataGridView_elems.ClearSelection();
                                    EnableSelectionItem = true;
                                    dataGridView_elems.CurrentCell = dataGridView_elems[0,ef];
                                    dataGridView_elems.Rows[ef].Selected = true;
                                    dataGridView_elems.FirstDisplayedScrollingRowIndex = ef;
                                    return;
								}
							}
						}
						etmp = 0;
					}
					etmp = e;
					for (int lf = 0; lf < eLC.Lists.Length && lf <= l; lf++)
					{
						int pos = 0;
						for (int i = 0; i < eLC.Lists[lf].elementFields.Length; i++)
						{
							if (eLC.Lists[lf].elementFields[i] == "Name")
							{
								pos = i;
								break;
							}
						}
						for (int ef = 0; ef < eLC.Lists[lf].elementValues.Length; ef++)
						{
							if (checkBox_SearchExactMatching.Checked)
							{
								if (id == eLC.GetValue(lf, ef, 0) || eLC.GetValue(lf, ef, pos) == id)
								{
									comboBox_lists.SelectedIndex = lf;
                                    dataGridView_elems.ClearSelection();
                                    EnableSelectionItem = true;
                                    dataGridView_elems.CurrentCell = dataGridView_elems[0, ef];
                                    dataGridView_elems.Rows[ef].Selected = true;
                                    dataGridView_elems.FirstDisplayedScrollingRowIndex = ef;
                                    return;
								}
							}
							else
							{
								value = eLC.GetValue(lf, ef, pos);
								if (!checkBox_SearchMatchCase.Checked)
									value = value.ToLower();
								if (id == eLC.GetValue(lf, ef, 0) || value.Contains(id))
								{
									comboBox_lists.SelectedIndex = lf;
                                    dataGridView_elems.ClearSelection();
                                    EnableSelectionItem = true;
                                    dataGridView_elems.CurrentCell = dataGridView_elems[0, ef];
                                    dataGridView_elems.Rows[ef].Selected = true;
                                    dataGridView_elems.FirstDisplayedScrollingRowIndex = ef;
                                    return;
								}
							}
						}
						etmp = 0;
					}
				}
				EnableSelectionItem = true;
				MessageBox.Show("Search reached End without Result!");
			}
		}

		private void click_deleteItem(object sender, EventArgs ea)
		{
			int l = comboBox_lists.SelectedIndex;
            int[] selIndices = gridSelectedIndices(dataGridView_elems);
            if (dataGridView_elems.RowCount > 0 && selIndices.Length > 0)
			{
				if (selIndices.Length < dataGridView_elems.RowCount)
				{
					if (l != eLC.ConversationListIndex)
					{
						EnableSelectionList = false;
						EnableSelectionItem = false;
						for (int i = selIndices.Length - 1; i > -1; i--)
						{
							eLC.Lists[l].RemoveItem(selIndices[i]);
                            dataGridView_elems.Rows.RemoveAt(selIndices[i]);
						}
						comboBox_lists.Items[l] = "[" + l + "]: " + eLC.Lists[l].listName + " (" + eLC.Lists[l].elementValues.Length + ")";
						EnableSelectionList = true;
						EnableSelectionItem = true;
                        change_item(null, null);
					}
					else
					{
						MessageBox.Show("Operation not supported in List " + eLC.ConversationListIndex.ToString());
					}
				}
				else
				{
					MessageBox.Show("Cannot delete all items in list!");
				}
			}
		}

		private void click_cloneItem(object sender, EventArgs ea)
		{
			int l = comboBox_lists.SelectedIndex;
			if (dataGridView_elems.RowCount > 0)
			{
				if (l != eLC.ConversationListIndex)
				{
                    int[] selIndices = gridSelectedIndices(dataGridView_elems);
                    EnableSelectionList = false;
					EnableSelectionItem = false;
					int NewSelectedCount = 0;
					for (int i = 0; i < selIndices.Length; i++)
					{
						object[] o = new object[eLC.Lists[l].elementValues[selIndices[i]].Length];
						eLC.Lists[l].elementValues[selIndices[i]].CopyTo(o, 0);
						eLC.Lists[l].AddItem(o);
                        dataGridView_elems.Rows.Add(new object[]
                        {
                            dataGridView_elems.Rows[selIndices[i]].Cells[0].Value,
                            dataGridView_elems.Rows[selIndices[i]].Cells[1].Value,
                            dataGridView_elems.Rows[selIndices[i]].Cells[2].Value
                        });
                        NewSelectedCount++;
					}
					comboBox_lists.Items[l] = "[" + l + "]: " + eLC.Lists[l].listName + " (" + eLC.Lists[l].elementValues.Length + ")";
                    dataGridView_elems.ClearSelection();
					for (int i = NewSelectedCount; i > 0; i--)
					{
                        dataGridView_elems.Rows[dataGridView_elems.RowCount - i].Selected = true;
                        dataGridView_elems.FirstDisplayedScrollingRowIndex = dataGridView_elems.RowCount - 1;
					}
					EnableSelectionList = true;
					EnableSelectionItem = true;
					change_item(null, null);
				}
				else
				{
					MessageBox.Show("Operation not supported in List " + eLC.ConversationListIndex.ToString());
				}
			}
		}

		private void click_logicReplace(object sender, EventArgs e)
		{
			if (eLC != null)
			{
				(new ReplaceWindow(eLC)).ShowDialog();
				int itemIndex = dataGridView_elems.CurrentCell.RowIndex;
				change_list(null, null);
				dataGridView_elems.Rows[itemIndex].Selected = true;
			}
			else
			{
				MessageBox.Show("No File Loaded!");
			}
		}

		private void click_fieldReplace(object sender, EventArgs e)
		{
			if (eLC != null)
			{
				(new FieldReplaceWindow(eLC, conversationList, ref cpb2)).ShowDialog();
			}
			else
			{
				MessageBox.Show("No File Loaded!");
			}
		}

		private void click_info(object sender, EventArgs e)
		{
			if (eLC != null)
			{
				//(gcnew InfoWindow(eLC))->ShowDialog();
			}
			else
			{
				MessageBox.Show("No File Loaded!");
			}
		}

		private void click_version(object sender, EventArgs e)
		{
			OpenFileDialog eLoad = new OpenFileDialog();
			eLoad.Filter = "Elements File (*.data)|*.data|All Files (*.*)|*.*";
			if (eLoad.ShowDialog() == DialogResult.OK && File.Exists(eLoad.FileName))
			{
				FileStream fs = File.OpenRead(eLoad.FileName);
				BinaryReader br = new BinaryReader(fs);
				short version = br.ReadInt16();
				short signature = br.ReadInt16();
				int timestamp = 0;
				string stimestamp = "";
				if (version >= 10)
					timestamp = br.ReadInt32();
				if (timestamp != 0)
					stimestamp = "\nTimestamp: " + timestamp_to_string((uint)timestamp);
				br.Close();
				fs.Close();

				MessageBox.Show("File: " + eLoad.FileName + "\n\nVersion: " + version.ToString() + "\nSignature: " + signature.ToString() + stimestamp);
			}
			else
			{
				//MessageBox::Show("No File!");
			}
		}

		private void click_config(object sender, EventArgs e)
		{
			(new ConfigWindow()).Show();
		}

		private void click_exportItem(object sender, EventArgs ea)
		{
			if (dataGridView_elems.RowCount > 0)
			{
				int l = comboBox_lists.SelectedIndex;
                int[] selIndices = gridSelectedIndices(dataGridView_elems);
                if (l != eLC.ConversationListIndex)
				{
                    if (dataGridView_elems.RowCount > 0 && selIndices.Length > 0)
                    {
                        FolderBrowserDialog eSave = new FolderBrowserDialog();
                        if (eSave.ShowDialog() == DialogResult.OK && Directory.Exists(eSave.SelectedPath))
                        {
                            try
                            {
                                Cursor = Cursors.AppStarting;
                                //progressBar_progress.Style = ProgressBarStyle.Continuous;
                                cpb2.Maximum = selIndices.Length;
                                for (int i = 0; i < selIndices.Length; i++)
                                {
                                    eLC.Lists[l].ExportItem(eSave.SelectedPath + "\\" + selIndices[i], selIndices[i]);
                                    cpb2.Value++;
                                }
                                Cursor = Cursors.Default;
                                MessageBox.Show("Export complete!");
                            }
                            catch
                            {
                                MessageBox.Show("EXPORT ERROR!\nExporting item to unicode text file failed!");
                                Cursor = Cursors.Default;
                            }
                            cpb2.Value = 0;
                            //progressBar_progress.Style = ProgressBarStyle.Continuous;
                        }
                    }
				}
				else
				{
					MessageBox.Show("Operation not supported in List " + eLC.ConversationListIndex.ToString());
				}
			}
		}

		private void click_importItem(object sender, EventArgs ea)
		{
			int l = comboBox_lists.SelectedIndex;
			int e = dataGridView_elems.CurrentRow.Index;
			if (l != eLC.ConversationListIndex)
			{
				if (l > -1 && e > -1)
				{
					OpenFileDialog eLoad = new OpenFileDialog();
					eLoad.Filter = "All Files (*.*)|*.*";
					if (eLoad.ShowDialog() == DialogResult.OK && File.Exists(eLoad.FileName))
					{
						try
						{
							Cursor = Cursors.AppStarting;
							eLC.Lists[l].ImportItem(eLoad.FileName, e);
							change_list(null, null);
							dataGridView_elems.Rows[e].Selected = true;
							Cursor = Cursors.Default;
						}
						catch
						{
							MessageBox.Show("IMPORT ERROR!\nCheck if the item version matches the elements.data version and is imported to the correct list!");
							Cursor = Cursors.Default;
						}
					}
				}
			}
			else
			{
				MessageBox.Show("Operation not supported in List " + eLC.ConversationListIndex.ToString());
			}
		}

		private void click_addItems(object sender, EventArgs ea)
		{
			int l = comboBox_lists.SelectedIndex;
			if (dataGridView_elems.RowCount >= 1)
			{
				if (l != eLC.ConversationListIndex)
				{
					string[] fileNames = null;
					OpenFileDialog eLoad = new OpenFileDialog();
					eLoad.Filter = "All Files (*.*)|*.*";
					eLoad.Multiselect = true;
					if (eLoad.ShowDialog() == DialogResult.OK && File.Exists(eLoad.FileName))
					{
						EnableSelectionList = false;
						EnableSelectionItem = false;
						fileNames = eLoad.FileNames;
						try
						{
							Cursor = Cursors.AppStarting;
                            //progressBar_progress.Style = ProgressBarStyle.Continuous;
                            cpb2.Maximum = fileNames.Length;
							int pos = -1;
                            int pos2 = -1;
                            for (int i = 0; i < eLC.Lists[l].elementFields.Length; i++)
							{
                                if (eLC.Lists[l].elementFields[i] == "Name")
                                {
                                    pos = i;
                                }
                                if (eLC.Lists[l].elementFields[i] == "file_icon" || eLC.Lists[l].elementFields[i] == "file_icon1")
                                {
                                    pos2 = i;
                                }
                                if (pos != -1 && pos2 != -1)
                                {
                                    break;
                                }
                            }
							for (int i = 0; i < fileNames.Length; i++)
							{
								int e = dataGridView_elems.RowCount - 1;
								object[] o = new object[eLC.Lists[l].elementValues[e].Length];
								eLC.Lists[l].elementValues[e].CopyTo(o, 0);
								eLC.Lists[l].AddItem(o);
								eLC.Lists[l].ImportItem(fileNames[i], e + 1);
								if (eLC.Lists[l].elementFields[0] == "ID")
								{
                                    Bitmap img = Properties.Resources.blank;
                                    string path = Path.GetFileName(eLC.GetValue(l, e, pos2));
                                    if (database.sourceBitmap != null && database.ContainsKey(path))
                                    {
                                        if (database.ContainsKey(path))
                                        {
                                            img = database.images(path);
                                        }
                                    }
                                    dataGridView_elems.Rows.Add(new object[] { eLC.GetValue(l, e, 0), img, eLC.GetValue(l, e, pos) });
                                }
								else
								{
                                    dataGridView_elems.Rows.Add(new object[] { 0, Properties.Resources.blank, eLC.GetValue(l, e, pos) });
                                }
                                cpb2.Value++;
							}
							Cursor = Cursors.Default;
						}
						catch
						{
							MessageBox.Show("IMPORT ERROR!\nCheck if the item version matches the elements.data version and is imported to the correct list!");
							Cursor = Cursors.Default;
						}
						comboBox_lists.Items[l] = "[" + l + "]: " + eLC.Lists[l].listName + " (" + eLC.Lists[l].elementValues.Length + ")";
                        cpb2.Value = 0;
						//progressBar_progress.Style = ProgressBarStyle.Continuous;
                        dataGridView_elems.ClearSelection();
						EnableSelectionList = true;
						EnableSelectionItem = true;
						dataGridView_elems.Rows[dataGridView_elems.RowCount - 1].Selected = true;
                        dataGridView_elems.FirstDisplayedScrollingRowIndex = dataGridView_elems.RowCount - 1;
                        change_item(null, null);
					}
				}
				else
				{
					MessageBox.Show("Operation not supported in List " + eLC.ConversationListIndex.ToString());
				}
			}
		}

		private void click_npcExport(object sender, EventArgs e)
		{
			SaveFileDialog save = new SaveFileDialog();
			save.InitialDirectory = Environment.CurrentDirectory;
			save.Filter = "Text File (*.txt)|*.txt|All Files (*.*)|*.*";
			if (save.ShowDialog() == DialogResult.OK && save.FileName != "")
			{
				try
				{
					Cursor = Cursors.AppStarting;
					//progressBar_progress.Style = ProgressBarStyle.Marquee;

					StreamWriter sw = new StreamWriter(save.FileName, false, Encoding.Unicode);

					for (int i = 0; i < eLC.Lists[38].elementValues.Length; i++)
					{
						sw.WriteLine(eLC.GetValue(38, i, 0) + "\t" + eLC.GetValue(38, i, 2));
					}

					for (int i = 0; i < eLC.Lists[57].elementValues.Length; i++)
					{
						sw.WriteLine(eLC.GetValue(57, i, 0) + "\t" + eLC.GetValue(57, i, 1));
					}

					sw.Close();

					//progressBar_progress.Style = ProgressBarStyle.Continuous;
					Cursor = Cursors.Default;
				}
				catch
				{
					MessageBox.Show("SAVING ERROR!");
					//progressBar_progress.Style = ProgressBarStyle.Continuous;
					Cursor = Cursors.Default;
				}
			}
		}

		private void click_joinEL(object sender, EventArgs e)
		{
			JoinWindow eJoin = new JoinWindow();
			if (eJoin.ShowDialog() == DialogResult.OK)
			{
				if (File.Exists(eJoin.FileName))
				{
					if (eJoin.LogDirectory == "" || !Directory.Exists(eJoin.LogDirectory))
					{
						eJoin.LogDirectory = eJoin.FileName + ".JOIN";
						Directory.CreateDirectory(eJoin.LogDirectory);
					}

					if (eJoin.BackupNew)
					{
						Directory.CreateDirectory(eJoin.LogDirectory + "\\added.backup");
					}
					if (eJoin.BackupChanged)
					{
						Directory.CreateDirectory(eJoin.LogDirectory + "\\replaced.backup");
					}
					if (eJoin.BackupMissing)
					{
						Directory.CreateDirectory(eJoin.LogDirectory + "\\removed.backup");
					}

					try
					{
						Cursor = Cursors.WaitCursor;
						//progressBar_progress.Style = ProgressBarStyle.Continuous;
						eListCollection neLC = new eListCollection(eJoin.FileName, ref cpb2);
						if (eLC.ConfigFile != neLC.ConfigFile)
						{
							MessageBox.Show("You're going to join two different element.data versions. The merged file will become invalid!", " WARNING");
						}
						if (eLC.ConversationListIndex > -1 && neLC.Lists.Length > eLC.ConversationListIndex)
						{
							conversationList = new eListConversation((byte[])neLC.Lists[eLC.ConversationListIndex].elementValues[0][0]);
						}
						StreamWriter sw = new StreamWriter(eJoin.LogDirectory + "\\LOG.TXT", false, Encoding.Unicode);

						ArrayList report;
						for (int l = 0; l < eLC.Lists.Length; l++)
						{
							if (l != eLC.ConversationListIndex)
							{
								report = eLC.Lists[l].JoinElements(neLC.Lists[l], l, eJoin.AddNew, eJoin.BackupNew, eJoin.ReplaceChanged, eJoin.BackupChanged, eJoin.RemoveMissing, eJoin.BackupMissing, eJoin.LogDirectory + "\\added.backup", eJoin.LogDirectory + "\\replaced.backup", eJoin.LogDirectory + "\\removed.backup");
								report.Sort();
								if (report.Count > 0)
								{
									sw.WriteLine("List " + l + ": " + report.Count + " Item(s) Affected");
									sw.WriteLine();

									for (int n = 0; n < report.Count; n++)
									{
										sw.WriteLine((string)report[n]);
									}

									sw.WriteLine();
								}

								comboBox_lists.Items[l] = "[" + l + "]: " + eLC.Lists[l].listName + " (" + eLC.Lists[l].elementValues.Length + ")";
							}
						}
						
						sw.Close();

						if (comboBox_lists.SelectedIndex > -1)
						{
							change_list(null, null);
						}

                        cpb2.Value = 0;
                        //cpb2.Style = ProgressBarStyle.Continuous;
						Cursor = Cursors.Default;
					}
					catch
					{
						MessageBox.Show("LOADING ERROR!\nThis error mostly occurs of configuration and elements.data mismatch");
						//progressBar_progress.Style = ProgressBarStyle.Continuous;
						Cursor = Cursors.Default;
					}
				}
			}
		}

		private void click_npcAIexport(object sender, EventArgs e)
		{
			SaveFileDialog save = new SaveFileDialog();
			save.InitialDirectory = Environment.CurrentDirectory;
			save.Filter = "Text File (*.txt)|*.txt|All Files (*.*)|*.*";
			if (save.ShowDialog() == DialogResult.OK && save.FileName != "")
			{
				try
				{
					Cursor = Cursors.AppStarting;
					//progressBar_progress.Style = ProgressBarStyle.Marquee;

					StreamWriter sw = new StreamWriter(save.FileName, false, Encoding.Unicode);

					for (int i = 0; i < eLC.Lists[38].elementValues.Length; i++)
					{
						sw.WriteLine(eLC.GetValue(38, i, 0) + "\t" + eLC.GetValue(38, i, 2) + "\t" + eLC.GetValue(38, i, 64));
					}

					sw.Close();

					//progressBar_progress.Style = ProgressBarStyle.Continuous;
					Cursor = Cursors.Default;
				}
				catch
				{
					MessageBox.Show("SAVING ERROR!");
					//progressBar_progress.Style = ProgressBarStyle.Continuous;
					Cursor = Cursors.Default;
				}
			}
		}

		private void click_skillValidate(object sender, EventArgs e)
		{
			if (eLC != null)
			{
				ArrayList mobSkills = new ArrayList();

				string skill;

				// check all monster skills (list 38 fields 119, 121, 123, 125, 127, 129)
				for (int n = 0; n < eLC.Lists[38].elementValues.Length; n++)
				{
					for (int f = 119; f < 130; f += 2)
					{
						skill = eLC.GetValue(38, n, f);

						if (Convert.ToInt32(skill) > 846)
						{
							mobSkills.Add("Invalid Skill: " + skill + " (Monster: " + eLC.GetValue(38, n, 0) + ")");
						}
					}
				}

				if (mobSkills.Count == 0)
				{
					MessageBox.Show("OK, no invalid skills found!");
				}
				else
				{
					string message = "";
					for (int i = 0; i < mobSkills.Count; i++)
					{
						message += (string)mobSkills[i] + "\r\n";
					}
					new DebugWindow("Invalid Skills", message);
				}
			}
		}

		private void click_propertyValidate(object sender, EventArgs e)
		{
			if (eLC != null)
			{
				ArrayList properties = new ArrayList();

				string attribute;

				// weapons (list 3, fields 43-201, +=2)
				for (int n = 0; n < eLC.Lists[3].elementValues.Length; n++)
				{
					for (int f = 43; f < 202; f += 2)
					{
						attribute = eLC.GetValue(3, n, f);

						if (Convert.ToInt32(attribute) > 1909)
						{
							properties.Add("Invalid Property: " + attribute + " (Weapon: " + eLC.GetValue(3, n, 0) + ")");
						}
					}
				}

				// armors (list 6, fields 55-179, +=2)
				for (int n = 0; n < eLC.Lists[6].elementValues.Length; n++)
				{
					for (int f = 55; f < 180; f += 2)
					{
						attribute = eLC.GetValue(6, n, f);

						if (Convert.ToInt32(attribute) > 1909)
						{
							properties.Add("Invalid Property: " + attribute + " (Armor: " + eLC.GetValue(6, n, 0) + ")");
						}
					}
				}

				// ornaments (list 9, fields 44-160, +=2)
				for (int n = 0; n < eLC.Lists[9].elementValues.Length; n++)
				{
					for (int f = 44; f < 161; f += 2)
					{
						attribute = eLC.GetValue(9, n, f);

						if (Convert.ToInt32(attribute) > 1909)
						{
							properties.Add("Invalid Property: " + attribute + " (Ornament: " + eLC.GetValue(9, n, 0) + ")");
						}
					}
				}

				// soulgems (list 35, fields 11-12, +=1)
				for (int n = 0; n < eLC.Lists[35].elementValues.Length; n++)
				{
					for (int f = 11; f < 13; f++)
					{
						attribute = eLC.GetValue(35, n, f);

						if (Convert.ToInt32(attribute) > 1909)
						{
							properties.Add("Invalid Property: " + attribute + " (Soulgem: " + eLC.GetValue(35, n, 0) + ")");
						}
					}
				}

				// complect boni (list 90, fields 15-19, +=1)
				for (int n = 0; n < eLC.Lists[90].elementValues.Length; n++)
				{
					for (int f = 15; f < 20; f++)
					{
						attribute = eLC.GetValue(90, n, f);

						if (Convert.ToInt32(attribute) > 1909)
						{
							properties.Add("Invalid Property: " + attribute + " (Complect Bonus: " + eLC.GetValue(90, n, 0) + ")");
						}
					}
				}

				if (properties.Count == 0)
				{
					MessageBox.Show("OK, no invalid properties found!");
				}
				else
				{
					string message = "";
					for (int i = 0; i < properties.Count; i++)
					{
						message += (string)properties[i] + "\r\n";
					}
					new DebugWindow("Invalid Properties", message);
				}
			}
		}

		private void click_tomeValidate(object sender, EventArgs e)
		{
			if (eLC != null)
			{
				ArrayList properties = new ArrayList();

				string attribute;

				for (int n = 0; n < eLC.Lists[112].elementValues.Length; n++)
				{
					for (int f = 4; f < 14; f++)
					{
						attribute = eLC.GetValue(112, n, f);

						if (Convert.ToInt32(attribute) > 1909)
						{
							properties.Add("Invalid Property: " + attribute + " (Tome: " + eLC.GetValue(112, n, 0) + ")");
						}
					}
				}

				if (properties.Count == 0)
				{
					MessageBox.Show("OK, no invalid tome properties found!");
				}
				else
				{
					string message = "";
					for (int i = 0; i < properties.Count; i++)
					{
						message += (string)properties[i] + "\r\n";
					}
					new DebugWindow("Invalid Tome Properties", message);
				}
			}
		}

		private void click_skillReplace(object sender, EventArgs e)
		{
			if (eLC != null)
			{
				OpenFileDialog load = new OpenFileDialog();
				load.InitialDirectory = Application.StartupPath + "\\replace";
				load.Filter = "Skill Replace File (*.txt)|*.txt|All Files (*.*)|*.*";
				if (load.ShowDialog() == DialogResult.OK && File.Exists(load.FileName))
				{
					SortedList skillTable = new SortedList();

					StreamReader sr = new StreamReader(load.FileName);

					string line;
					string[] pair;
					string[] seperator = new string[] { "=" };
					while (!sr.EndOfStream)
					{
						line = sr.ReadLine();
						if (!line.StartsWith("#") && line.Contains("="))
						{
							pair = line.Split(seperator, StringSplitOptions.RemoveEmptyEntries);
							if (pair.Length == 2)
							{
								skillTable.Add(pair[0], pair[1]);
							}
						}
					}

					sr.Close();
					/*
					ArrayList^ mobSkills = gcnew ArrayList();
					*/
					string skill;

					// change all monster skills (list 38 fields 119, 121, 123, 125, 127, 129)
					for (int n = 0; n < eLC.Lists[38].elementValues.Length; n++)
					{
						for (int f = 119; f < 130; f += 2)
						{
							skill = eLC.GetValue(38, n, f);
							/*
							if(!mobSkills->Contains(skill))
							{
								mobSkills->Add(skill);
							}
							*/
							if (skillTable.ContainsKey(skill))
							{
								eLC.SetValue(38, n, f, (string)skillTable[skill]);
							}
						}
					}
					/*
					int debug = 1;
					*/
				}
			}
		}

		private void click_propertyReplace(object sender, EventArgs e)
		{
			if (eLC != null)
			{
				OpenFileDialog load = new OpenFileDialog();
				load.InitialDirectory = Application.StartupPath + "\\replace";
				load.Filter = "Property Replace File (*.txt)|*.txt|All Files (*.*)|*.*";
				if (load.ShowDialog() == DialogResult.OK && File.Exists(load.FileName))
				{
					SortedList propertyTable = new SortedList();

					StreamReader sr = new StreamReader(load.FileName);

					string line;
					string[] pair;
					string[] seperator = new string[] { "=" };
					while (!sr.EndOfStream)
					{
						line = sr.ReadLine();
						if (!line.StartsWith("#") && line.Contains("="))
						{
							pair = line.Split(seperator, StringSplitOptions.RemoveEmptyEntries);
							if (pair.Length == 2)
							{
								propertyTable.Add(pair[0], pair[1]);
							}
						}
					}

					sr.Close();
					/*
					ArrayList^ weaponProps = gcnew ArrayList();
					ArrayList^ armorProps = gcnew ArrayList();
					ArrayList^ ornamentProps = gcnew ArrayList();
					ArrayList^ gemProps = gcnew ArrayList();
					ArrayList^ complectProps = gcnew ArrayList();
					*/

					string attribute;

					// weapons (list 3, fields 43-201, +=2)
					for (int n = 0; n < eLC.Lists[3].elementValues.Length; n++)
					{
						for (int f = 43; f < 202; f += 2)
						{
							attribute = eLC.GetValue(3, n, f);
							/*
							if(!weaponProps->Contains(attribute))
							{
								weaponProps->Add(attribute);
							}
							*/
							if (propertyTable.ContainsKey(attribute))
							{
								eLC.SetValue(3, n, f, (string)propertyTable[attribute]);
							}
						}
					}

					// armors (list 6, fields 55-179, +=2)
					for (int n = 0; n < eLC.Lists[6].elementValues.Length; n++)
					{
						for (int f = 55; f < 180; f += 2)
						{
							attribute = eLC.GetValue(6, n, f);
							/*
							if(!armorProps->Contains(attribute))
							{
								armorProps->Add(attribute);
							}
							*/
							if (propertyTable.ContainsKey(attribute))
							{
								eLC.SetValue(6, n, f, (string)propertyTable[attribute]);
							}
						}
					}

					// ornaments (list 9, fields 44-160, +=2)
					for (int n = 0; n < eLC.Lists[9].elementValues.Length; n++)
					{
						for (int f = 44; f < 161; f += 2)
						{
							attribute = eLC.GetValue(9, n, f);
							/*
							if(!ornamentProps->Contains(attribute))
							{
								ornamentProps->Add(attribute);
							}
							*/
							if (propertyTable.ContainsKey(attribute))
							{
								eLC.SetValue(9, n, f, (string)propertyTable[attribute]);
							}
						}
					}

					// soulgems (list 35, fields 11-12, +=1)
					for (int n = 0; n < eLC.Lists[35].elementValues.Length; n++)
					{
						for (int f = 11; f < 13; f++)
						{
							attribute = eLC.GetValue(35, n, f);
							/*
							if(!gemProps->Contains(attribute))
							{
								gemProps->Add(attribute);
							}
							*/
							if (propertyTable.ContainsKey(attribute))
							{
								eLC.SetValue(35, n, f, (string)propertyTable[attribute]);

								if ((string)propertyTable[attribute] == "1515")
								{
									eLC.SetValue(35, n, f + 2, "Vit. +20");
								}
								if ((string)propertyTable[attribute] == "1517")
								{
									eLC.SetValue(35, n, f + 2, "Critical +2%");
								}
								if ((string)propertyTable[attribute] == "1518")
								{
									eLC.SetValue(35, n, f + 2, "Channel -6%");
								}
							}
						}
					}

					// complect boni (list 90, fields 15-19, +=1)
					for (int n = 0; n < eLC.Lists[90].elementValues.Length; n++)
					{
						for (int f = 15; f < 20; f++)
						{
							attribute = eLC.GetValue(90, n, f);
							/*
							if(!complectProps->Contains(attribute))
							{
								complectProps->Add(attribute);
							}
							*/
							if (propertyTable.ContainsKey(attribute))
							{
								eLC.SetValue(90, n, f, (string)propertyTable[attribute]);
							}
						}
					}
					/*
					int debug = 1;
					*/
				}
			}
		}

		private void click_tomeReplace(object sender, EventArgs e)
		{
			if (eLC != null)
			{
				OpenFileDialog load = new OpenFileDialog();
				load.InitialDirectory = Application.StartupPath + "\\replace";
				load.Filter = "Tome Replace File (*.txt)|*.txt|All Files (*.*)|*.*";
				if (load.ShowDialog() == DialogResult.OK && File.Exists(load.FileName))
				{
					SortedList propertyTable = new SortedList();

					StreamReader sr = new StreamReader(load.FileName);

					string line;
					string[] pair;
					string[] seperator = new string[] { "=" };
					string[] divider = new string[] { "," };
					while (!sr.EndOfStream)
					{
						line = sr.ReadLine();
						if (!line.StartsWith("#") && line.Contains("="))
						{
							pair = line.Split(seperator, StringSplitOptions.RemoveEmptyEntries);
							if (pair.Length == 2)
							{
								propertyTable.Add(pair[0], pair[1].Split(divider, StringSplitOptions.RemoveEmptyEntries));
							}
						}
					}

					sr.Close();
					/*
					ArrayList^ tomeProps = gcnew ArrayList();
					*/
					string attribute;
					string[] attributes;
					ArrayList attributesOrgiginal = new ArrayList();
					ArrayList attributesReplaced = new ArrayList();

					// weapons (list 3, fields 43-201, +=2)
					for (int n = 0; n < eLC.Lists[112].elementValues.Length; n++)
					{
						attributesOrgiginal.Clear();
						attributesReplaced.Clear();

						for (int f = 4; f < 14; f++)
						{
							attribute = eLC.GetValue(112, n, f);
							/*
							if(!tomeProps->Contains(attribute))
							{
								tomeProps->Add(attribute);
							}
							*/
							if (attribute != "0")
							{
								if (propertyTable.ContainsKey(attribute))
								{
									attributes = (string[])propertyTable[attribute];
									for (int a = 0; a < attributes.Length; a++)
									{
										attributesReplaced.Add(attributes[a]);
									}
								}
								else
								{
									// add the attribute without changes
									attributesReplaced.Add(attribute);
								}
							}
						}

						if (attributesReplaced.Count > 10)
						{
							MessageBox.Show("Tome Attribute Overflow: " + n + "\nAttributes Truncated");
						}

						// add the new attribute list to the current tome
						for (int f = 4; f < 14; f++)
						{
							if (f - 4 < attributesReplaced.Count)
							{
								// add the replaced attribute
								attribute = (string)attributesReplaced[f - 4];
								eLC.SetValue(112, n, f, attribute);
							}
							else
							{
								eLC.SetValue(112, n, f, "0");
							}
						}
					}
					/*
					int debug = 1;
					*/
				}
			}
		}

		private void click_probabilityValidate(object sender, EventArgs e)
		{
			if (eLC != null)
			{
				ArrayList probabilities = new ArrayList();
				double attribute;

				// weapons (list 3)
				for (int n = 0; n < eLC.Lists[3].elementValues.Length; n++)
				{
					// weapon drop sockets count(fields 32-34, +=1)

					attribute = 0;

					for (int f = 32; f < 35; f++)
					{
						attribute += Convert.ToDouble(eLC.GetValue(3, n, f));
					}

					if (Math.Round(attribute, 6) != 1)
					{
						probabilities.Add("Suspicious Socket Drop Probability (sum != 1.0): " + attribute.ToString() + " (Weapon: " + eLC.GetValue(3, n, 0) + ")");
					}

					// weapon craft sockets count(fields 35-37, +=1)

					attribute = 0;

					for (int f = 35; f < 38; f++)
					{
						attribute += Convert.ToDouble(eLC.GetValue(3, n, f));
					}

					if (Math.Round(attribute, 6) != 1)
					{
						probabilities.Add("Suspicious Socket Craft Probability (sum != 1.0): " + attribute.ToString() + " (Weapon: " + eLC.GetValue(3, n, 0) + ")");
					}

					// weapon addons count(fields 38-41, +=1)

					attribute = 0;

					for (int f = 38; f < 42; f++)
					{
						attribute += Convert.ToDouble(eLC.GetValue(3, n, f));
					}

					if (Math.Round(attribute, 6) != 1)
					{
						probabilities.Add("Suspicious Addon Count Probability (sum != 1.0): " + attribute.ToString() + " (Weapon: " + eLC.GetValue(3, n, 0) + ")");
					}

					// weapon drop (fields 44-106, +=2)

					attribute = 0;

					for (int f = 44; f < 107; f += 2)
					{
						attribute += Convert.ToDouble(eLC.GetValue(3, n, f));
					}

					if (Math.Round(attribute, 6) != 1)
					{
						probabilities.Add("Suspicious Drop Attriutes Probability (sum != 1.0): " + attribute.ToString() + " (Weapon: " + eLC.GetValue(3, n, 0) + ")");
					}

					// weapon craft (fields 108-170, +=2)

					attribute = 0;

					for (int f = 108; f < 171; f += 2)
					{
						attribute += Convert.ToDouble(eLC.GetValue(3, n, f));
					}

					if (Math.Round(attribute, 6) != 1)
					{
						probabilities.Add("Suspicious Craft Attributes Probability (sum != 1.0): " + attribute.ToString() + " (Weapon: " + eLC.GetValue(3, n, 0) + ")");
					}

					// weapons unique (fields 172-202, +=2)

					attribute = 0;

					for (int f = 172; f < 203; f += 2)
					{
						attribute += Convert.ToDouble(eLC.GetValue(3, n, f));
					}

					if (Math.Round(attribute, 6) != 1)
					{
						probabilities.Add("Suspicious Unique Attributes Probability (sum != 1.0): " + attribute.ToString() + " (Weapon: " + eLC.GetValue(3, n, 0) + ")");
					}
				}

				// armors (list 6)
				for (int n = 0; n < eLC.Lists[6].elementValues.Length; n++)
				{
					// armor drop sockets count(fields 41-45, +=1)

					attribute = 0;

					for (int f = 41; f < 46; f++)
					{
						attribute += Convert.ToDouble(eLC.GetValue(6, n, f));
					}

					if (Math.Round(attribute, 6) != 1)
					{
						probabilities.Add("Suspicious Socket Drop Probability (sum != 1.0): " + attribute.ToString() + " (Armor: " + eLC.GetValue(6, n, 0) + ")");
					}

					// armor craft sockets count(fields 46-50, +=1)

					attribute = 0;

					for (int f = 46; f < 51; f++)
					{
						attribute += Convert.ToDouble(eLC.GetValue(6, n, f));
					}

					if (Math.Round(attribute, 6) != 1)
					{
						probabilities.Add("Suspicious Socket Craft Probability (sum != 1.0): " + attribute.ToString() + " (Armor: " + eLC.GetValue(6, n, 0) + ")");
					}

					// armor addons count(fields 51-54, +=1)

					attribute = 0;

					for (int f = 51; f < 55; f++)
					{
						attribute += Convert.ToDouble(eLC.GetValue(6, n, f));
					}

					if (Math.Round(attribute, 6) != 1)
					{
						probabilities.Add("Suspicious Addon Count Probability (sum != 1.0): " + attribute.ToString() + " (Armor: " + eLC.GetValue(6, n, 0) + ")");
					}

					// armor drop (fields 56-118, +=2)

					attribute = 0;

					for (int f = 56; f < 119; f += 2)
					{
						attribute += Convert.ToDouble(eLC.GetValue(6, n, f));
					}

					if (Math.Round(attribute, 6) != 1)
					{
						probabilities.Add("Suspicious Drop Attriutes Probability (sum != 1.0): " + attribute.ToString() + " (Armor: " + eLC.GetValue(6, n, 0) + ")");
					}

					// armor craft (fields 120-180, +=2)

					attribute = 0;

					for (int f = 120; f < 181; f += 2)
					{
						attribute += Convert.ToDouble(eLC.GetValue(6, n, f));
					}

					if (Math.Round(attribute, 6) != 1)
					{
						probabilities.Add("Suspicious Craft Attributes Probability (sum != 1.0): " + attribute.ToString() + " (Armor: " + eLC.GetValue(6, n, 0) + ")");
					}
				}

				// ornaments (list 9)
				for (int n = 0; n < eLC.Lists[9].elementValues.Length; n++)
				{
					// ornament addons count(fields 40-43, +=1)

					attribute = 0;

					for (int f = 40; f < 44; f++)
					{
						attribute += Convert.ToDouble(eLC.GetValue(9, n, f));
					}

					if (Math.Round(attribute, 6) != 1)
					{
						probabilities.Add("Suspicious Addon Count Probability (sum != 1.0): " + attribute.ToString() + " (Ornament: " + eLC.GetValue(9, n, 0) + ")");
					}

					// ornament drop (fields 45-107, +=2)

					attribute = 0;

					for (int f = 45; f < 108; f += 2)
					{
						attribute += Convert.ToDouble(eLC.GetValue(9, n, f));
					}

					if (Math.Round(attribute, 6) != 1)
					{
						probabilities.Add("Suspicious Drop Attriutes Probability (sum != 1.0): " + attribute.ToString() + " (Ornament: " + eLC.GetValue(9, n, 0) + ")");
					}

					// ornament craft (fields 109-161, +=2)

					attribute = 0;

					for (int f = 109; f < 162; f += 2)
					{
						attribute += Convert.ToDouble(eLC.GetValue(9, n, f));
					}

					if (Math.Round(attribute, 6) != 1)
					{
						probabilities.Add("Suspicious Craft Attributes Probability (sum != 1.0): " + attribute.ToString() + " (Ornament: " + eLC.GetValue(9, n, 0) + ")");
					}
				}

				if (probabilities.Count == 0)
				{
					MessageBox.Show("OK, no invalid probabilities found!");
				}
				else
				{
					string message = "";
					for (int i = 0; i < probabilities.Count; i++)
					{
						message += (string)probabilities[i] + "\r\n";
					}
					new DebugWindow("Invalid Probabilities", message);
				}
			}
		}

		private void click_TaskOverflowCheck(object sender, EventArgs e)
		{
			if (eLC != null)
			{
				string value;
				bool isAddedElement;

				LoseQuestWindow questWindow = new LoseQuestWindow();



				// list 45 recive quests
				for (int n = 0; n < eLC.Lists[45].elementValues.Length; n++)
				{
					isAddedElement = false;
					for (int f = 34; f < eLC.Lists[45].elementFields.Length; f++)
					{
						value = eLC.GetValue(45, n, f);
						if (value != "0")
						{
							if (!isAddedElement)
							{
								questWindow.listBox_Receive.Items.Add("+++++ " + eLC.GetValue(45, n, 0) + " - " + eLC.GetValue(45, n, 1) + " +++++");
								isAddedElement = true;
							}
							questWindow.listBox_Receive.Items.Add(value);
						}
					}
				}

				// list 46 activate quests
				for (int n = 0; n < eLC.Lists[46].elementValues.Length; n++)
				{
					isAddedElement = false;
					for (int f = 34; f < eLC.Lists[46].elementFields.Length; f++)
					{
						value = eLC.GetValue(46, n, f);
						if (value != "0")
						{
							if (!isAddedElement)
							{
								questWindow.listBox_Activate.Items.Add("+++++ " + eLC.GetValue(46, n, 0) + " - " + eLC.GetValue(46, n, 1) + " +++++");
								isAddedElement = true;
							}
							questWindow.listBox_Activate.Items.Add(value);
						}
					}
				}

				questWindow.Show();
			}
		}

		private void click_classMask(object sender, EventArgs e)
		{
			ClassMaskWindow eClassMask = new ClassMaskWindow();
			eClassMask.Show();
		}

		private void cellMouseMove_ToolTip(object sender, DataGridViewCellMouseEventArgs e)
		{
			if (comboBox_lists.SelectedIndex == 0 && dataGridView_elems.CurrentCell.RowIndex != -1 && e.ColumnIndex == 2 && e.RowIndex > 2 && e.RowIndex < 6)
			{
				dataGridView_item.ShowCellToolTips = false;
				string text = "Float: " + (BitConverter.ToSingle(BitConverter.GetBytes((int)(eLC.Lists[0].elementValues[dataGridView_elems.CurrentCell.RowIndex][e.RowIndex])), 0)).ToString("F6");

				// not working on first mouse over (still shows previous value on first mouse over)
				//dataGridView_item->Rows[e->RowIndex]->Cells[e->ColumnIndex]->ToolTipText = text;

				// only draw on real move to prevent flickering in windows 7
				if (mouseMoveCheck.X != e.X || mouseMoveCheck.Y != e.Y)
				{
					toolTip.SetToolTip((Control)sender, text);
					mouseMoveCheck.X = e.X;
					mouseMoveCheck.Y = e.Y;
				}
			}
			else if(e.RowIndex > -1 && dataGridView_item.Rows[e.RowIndex].Cells[0].Value.ToString() == "shop_price" && comboBox_lists.SelectedIndex > -1 && dataGridView_elems.CurrentCell.RowIndex  > -1)
			{
				dataGridView_item.ShowCellToolTips = false;
				int shop_price = Convert.ToInt32(eLC.GetValue(comboBox_lists.SelectedIndex, dataGridView_elems.CurrentCell.RowIndex, e.RowIndex));
				double tmp = 0;
				double tmp1 = 0;
				tmp1 = shop_price * 0.05;
				if (shop_price >= 10)
					tmp1 = Math.Round(tmp1, MidpointRounding.AwayFromZero);
				else
					tmp1 = Math.Round(tmp1);
				tmp = shop_price + tmp1;
				if (tmp >= 100 && tmp < 1000)
				{
					tmp = tmp * 0.1;
					tmp = Math.Ceiling(tmp);
					tmp = tmp * 10;
				}
				if (tmp >= 1000)
				{
					tmp = tmp * 0.01;
					tmp = Math.Ceiling(tmp);
					tmp = tmp * 100;
				}
				string text = "In Game Price: " + tmp;
				if (mouseMoveCheck.X != e.X || mouseMoveCheck.Y != e.Y)
				{
					toolTip.SetToolTip((Control)sender, text);
					mouseMoveCheck.X = e.X;
					mouseMoveCheck.Y = e.Y;
				}
			}
			else
			{
				toolTip.Hide((Control)sender);
				dataGridView_item.ShowCellToolTips = true;
			}
		}

		private void click_diffEL(object sender, EventArgs e)
		{
			RulesWindow eRules = new RulesWindow(ref cpb2);
			eRules.Show();
		}

		private void listBox_items_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			int l = comboBox_lists.SelectedIndex;
			int k = dataGridView_elems.CurrentCell.RowIndex;
			if (l != eLC.ConversationListIndex)
			{
				if (l > -1 && k > -1)
				{
					int pos = -1;
					for (int i = 0; i < eLC.Lists[l].elementFields.Length; i++)
					{
						if (eLC.Lists[l].elementFields[i] == "Name")
						{
							pos = i;
							break;
						}
					}
					if (pos > -1)
					{
						Clipboard.SetDataObject(eLC.GetValue(l, k, 0) + "	" + eLC.GetValue(l, k, pos), true);
					}
					else
					{
						MessageBox.Show("Config Error: cannot find Name field");
					}
				}
				else
				{
					MessageBox.Show("Invalid List");
				}
			}
			else
			{
				MessageBox.Show("Operation not supported in List " + eLC.ConversationListIndex.ToString());
			}
		}

		private void click_xrefItem(object sender, EventArgs ea)
		{
			int l = comboBox_lists.SelectedIndex;
			int e = dataGridView_elems.CurrentCell.RowIndex;
			if (l != eLC.ConversationListIndex)
			{
				if (l > -1 && e > -1)
				{
					ReferencesWindow eXRef = new ReferencesWindow();
					char[] chars = { '-' };
					int results = 0;

					for (int j = 1; j < xrefs[l].Length; j++)
					{
						string[] x = xrefs[l][j].Split(chars);
						for (int m = 1; m < eLC.Lists[int.Parse(x[0])].elementValues.Length; m++)
						{
							for (int k = 1; k < x.Length; k++)
							{
								if (eLC.GetValue(int.Parse(x[0]), m, int.Parse(x[k])) == eLC.GetValue(l, e, 0))
								{
									results++;
									int pos = -1;
									for (int i = 0; i < eLC.Lists[l].elementFields.Length; i++)
									{
										if (eLC.Lists[int.Parse(x[0])].elementFields[i] == "Name")
										{
											pos = i;
											break;
										}
									}
									eXRef.dataGridView.Rows.Add(new string[] { x[0], eLC.Lists[int.Parse(x[0])].listName, eLC.GetValue(int.Parse(x[0]), m, 0), eLC.GetValue(int.Parse(x[0]), m, pos), x[k] + " - " + eLC.Lists[int.Parse(x[0])].elementFields[int.Parse(x[k])] });
								}
							}
						}
					}
					if (results > 0)
					{
						eXRef.Show();
					}
					else
					{
						eXRef.Close();
						MessageBox.Show("No results found");
					}
				}
			}
			else
			{
				MessageBox.Show("Operation not supported in List " + eLC.ConversationListIndex.ToString());
			}
		}

		private void CheckSearchCondition(object sender, EventArgs e)
		{
			if (checkBox_SearchAll.Checked && textBox_search.Text == "ID or NAME")
				textBox_search.Text = "VALUE";
			else if (textBox_search.Text == "VALUE")
				textBox_search.Text = "ID or NAME";
		}

		private void click_SetValue(object sender, EventArgs e)
		{
            int l = comboBox_lists.SelectedIndex;
            if (l > -1 && l != eLC.ConversationListIndex)
			{
				ArrayList SelectedCellsIndexes = new ArrayList();
                int[] selIndices = gridSelectedIndices(dataGridView_elems);
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
					dataGridView_item.Rows[(int)SelectedCellsIndexes[i]].Cells[2].Value = textBox_SetValue.Text;
				}
				for (int i = 0; i < selIndices.Length; i++)
				{
					for (int f = 0; f < SelectedCellsIndexes.Count; f++)
					{
						eLC.SetValue(l, selIndices[i], (int)SelectedCellsIndexes[f], textBox_SetValue.Text);
						if (dataGridView_item.Rows[(int)SelectedCellsIndexes[f]].Cells[0].Value.ToString() == "Name")
						{
                            int pos = -1;
                            int pos2 = -1;
                            for (int p = 0; p < eLC.Lists[l].elementFields.Length; p++)
                            {
                                if (eLC.Lists[l].elementFields[p] == "Name")
                                {
                                    pos = p;
                                }
                                if (eLC.Lists[l].elementFields[p] == "file_icon" || eLC.Lists[l].elementFields[p] == "file_icon1")
                                {
                                    pos2 = p;
                                }
                                if (pos != -1 && pos2 != -1)
                                {
                                    break;
                                }
                            }
                            if (eLC.Lists[l].elementFields[0] == "ID")
							{
                                Bitmap img = Properties.Resources.blank;
                                string path = Path.GetFileName(eLC.GetValue(l, selIndices[i], pos2));
                                if (database.sourceBitmap != null && database.ContainsKey(path))
                                {
                                    if (database.ContainsKey(path))
                                    {
                                        img = database.images(path);
                                    }
                                }
                                dataGridView_elems.Rows[selIndices[i]].Cells[0].Value = eLC.GetValue(l, selIndices[i], 0);
                                dataGridView_elems.Rows[selIndices[i]].Cells[1].Value = img;
                                dataGridView_elems.Rows[selIndices[i]].Cells[2].Value = eLC.GetValue(l, selIndices[i], pos);
							}
							else
							{
                                dataGridView_elems.Rows[selIndices[i]].Cells[0].Value = "";
                                dataGridView_elems.Rows[selIndices[i]].Cells[1].Value = Properties.Resources.blank;
                                dataGridView_elems.Rows[selIndices[i]].Cells[2].Value = eLC.GetValue(l, selIndices[i], pos);
							}
						}
					}
				}
			}
		}

		private void listBox_items_KeyDown(object sender, KeyEventArgs e)
		{
			//if (ModifierKeys == Keys.Control && listBox_items.SelectedIndices.Count > 0 && comboBox_lists.SelectedIndex != eLC.ConversationListIndex)
			//{
			//	if (e.KeyCode == Keys.Up)
			//	{
			//		if (listBox_items.SelectedIndices[0] > 0)
			//		{
			//			EnableSelectionItem = false;
			//			int[] SelectedIndices = new int[listBox_items.SelectedIndices.Count];
			//			for (int i = 0; i < listBox_items.SelectedIndices.Count; i++)
			//			{
			//				SelectedIndices[i] = listBox_items.SelectedIndices[i];
			//			}
			//			int pos = -1;
			//			for (int i = 0; i < eLC.Lists[comboBox_lists.SelectedIndex].elementFields.Length; i++)
			//			{
			//				if (eLC.Lists[comboBox_lists.SelectedIndex].elementFields[i] == "Name")
			//				{
			//					pos = i;
			//					break;
			//				}
			//			}
			//			for (int i = 0; i < listBox_items.SelectedIndices.Count; i++)
			//			{
			//				object[][] temp = new object[eLC.Lists[comboBox_lists.SelectedIndex].elementValues.Length][];
			//				Array.Copy(eLC.Lists[comboBox_lists.SelectedIndex].elementValues, 0, temp, 0, listBox_items.SelectedIndices[i] - 1);
			//				Array.Copy(eLC.Lists[comboBox_lists.SelectedIndex].elementValues, listBox_items.SelectedIndices[i], temp, listBox_items.SelectedIndices[i] - 1, 1);
			//				Array.Copy(eLC.Lists[comboBox_lists.SelectedIndex].elementValues, listBox_items.SelectedIndices[i] - 1, temp, listBox_items.SelectedIndices[i], 1);
			//				if (listBox_items.SelectedIndices[i] < listBox_items.Items.Count - 1)
			//					Array.Copy(eLC.Lists[comboBox_lists.SelectedIndex].elementValues, listBox_items.SelectedIndices[i] + 1, temp, listBox_items.SelectedIndices[i] + 1, listBox_items.Items.Count - listBox_items.SelectedIndices[i] - 1);
			//				eLC.Lists[comboBox_lists.SelectedIndex].elementValues = temp;
			//				int ei = SelectedIndices[i] - 1;
			//				int ei2 = SelectedIndices[i];
			//				if (eLC.Lists[comboBox_lists.SelectedIndex].elementFields[0] == "ID")
			//				{
			//					listBox_items.Items[ei] = "[" + ei + "]: " + eLC.GetValue(comboBox_lists.SelectedIndex, ei, 0) + " - " + eLC.GetValue(comboBox_lists.SelectedIndex, ei, pos);
			//					listBox_items.Items[ei2] = "[" + ei2 + "]: " + eLC.GetValue(comboBox_lists.SelectedIndex, ei2, 0) + " - " + eLC.GetValue(comboBox_lists.SelectedIndex, ei2, pos);
			//				}
			//				else
			//				{
			//					listBox_items.Items[ei] = "[" + ei + "]: " + eLC.GetValue(comboBox_lists.SelectedIndex, ei, pos);
			//					listBox_items.Items[ei2] = "[" + ei2 + "]: " + eLC.GetValue(comboBox_lists.SelectedIndex, ei2, pos);
			//				}
			//			}
			//			listBox_items.SelectedIndex = -1;
			//			listBox_items.SelectionMode = SelectionMode.MultiSimple;
			//			for (int i = 0; i < SelectedIndices.Length; i++)
			//			{
			//				listBox_items.SelectedIndex = SelectedIndices[i] - 1;
			//			}
			//			listBox_items.SelectionMode = SelectionMode.MultiExtended;
			//			EnableSelectionItem = true;
			//			change_item(null, null);
			//		}
			//	}
			//	else if (e.KeyCode == Keys.Down)
			//	{
			//		if (listBox_items.SelectedIndices[listBox_items.SelectedIndices.Count - 1] < listBox_items.Items.Count - 1)
			//		{
			//			EnableSelectionItem = false;
			//			int[] SelectedIndices = new int[listBox_items.SelectedIndices.Count];
			//			for (int i = 0; i < listBox_items.SelectedIndices.Count; i++)
			//			{
			//				SelectedIndices[i] = listBox_items.SelectedIndices[i];
			//			}
			//			int pos = -1;
			//			for (int i = 0; i < eLC.Lists[comboBox_lists.SelectedIndex].elementFields.Length; i++)
			//			{
			//				if (eLC.Lists[comboBox_lists.SelectedIndex].elementFields[i] == "Name")
			//				{
			//					pos = i;
			//					break;
			//				}
			//			}
			//			for (int i = listBox_items.SelectedIndices.Count - 1; i > -1; i--)
			//			{
			//				object[][] temp = new object[eLC.Lists[comboBox_lists.SelectedIndex].elementValues.Length][];
			//				Array.Copy(eLC.Lists[comboBox_lists.SelectedIndex].elementValues, 0, temp, 0, listBox_items.SelectedIndices[i]);
			//				Array.Copy(eLC.Lists[comboBox_lists.SelectedIndex].elementValues, listBox_items.SelectedIndices[i] + 1, temp, listBox_items.SelectedIndices[i], 1);
			//				Array.Copy(eLC.Lists[comboBox_lists.SelectedIndex].elementValues, listBox_items.SelectedIndices[i], temp, listBox_items.SelectedIndices[i] + 1, 1);
			//				if (listBox_items.SelectedIndices[i] < listBox_items.Items.Count - 2)
			//					Array.Copy(eLC.Lists[comboBox_lists.SelectedIndex].elementValues, listBox_items.SelectedIndices[i] + 2, temp, listBox_items.SelectedIndices[i] + 2, listBox_items.Items.Count - listBox_items.SelectedIndices[i] - 2);
			//				eLC.Lists[comboBox_lists.SelectedIndex].elementValues = temp;
			//				int ei = SelectedIndices[i] + 1;
			//				int ei2 = SelectedIndices[i];
			//				if (eLC.Lists[comboBox_lists.SelectedIndex].elementFields[0] == "ID")
			//				{
			//					listBox_items.Items[ei] = "[" + ei + "]: " + eLC.GetValue(comboBox_lists.SelectedIndex, ei, 0) + " - " + eLC.GetValue(comboBox_lists.SelectedIndex, ei, pos);
			//					listBox_items.Items[ei2] = "[" + ei2 + "]: " + eLC.GetValue(comboBox_lists.SelectedIndex, ei2, 0) + " - " + eLC.GetValue(comboBox_lists.SelectedIndex, ei2, pos);
			//				}
			//				else
			//				{
			//					listBox_items.Items[ei] = "[" + ei + "]: " + eLC.GetValue(comboBox_lists.SelectedIndex, ei, pos);
			//					listBox_items.Items[ei2] = "[" + ei2 + "]: " + eLC.GetValue(comboBox_lists.SelectedIndex, ei2, pos);
			//				}
			//			}
			//			listBox_items.SelectedIndex = -1;
			//			listBox_items.SelectionMode = SelectionMode.MultiSimple;
			//			for (int i = 0; i < SelectedIndices.Length; i++)
			//			{
			//				listBox_items.SelectedIndex = SelectedIndices[i] + 1;
			//			}
			//			listBox_items.SelectionMode = SelectionMode.MultiExtended;
			//			EnableSelectionItem = true;
			//			change_item(null, null);
			//		}
			//	}
			//}
		}

        private void click_moveItemsToTop(object sender, EventArgs ea)
        {
            int l = comboBox_lists.SelectedIndex;
            int[] selIndices = gridSelectedIndices(dataGridView_elems);
            if (selIndices[0] > 0 && selIndices.Length > 0 && l != eLC.ConversationListIndex)
            {
                EnableSelectionItem = false;
                object[][] temp = new object[eLC.Lists[l].elementValues.Length][];
                for (int i = 0; i < selIndices.Length; i++)
                {
                    Array.Copy(eLC.Lists[l].elementValues, selIndices[i], temp, i, 1);
                }
                Array.Copy(eLC.Lists[l].elementValues, 0, temp, selIndices.Length, selIndices[0]);
                for (int i = selIndices.Length - 1; i > -1; i--)
                {
                    eLC.Lists[l].RemoveItem(selIndices[i]);
                }
                Array.Copy(eLC.Lists[l].elementValues, 0, temp, selIndices.Length, eLC.Lists[l].elementValues.Length);
                eLC.Lists[l].elementValues = temp;

                change_list(null, null);

                dataGridView_elems.ClearSelection();
                for (int i = 0; i < selIndices.Length; i++)
                {
                    dataGridView_elems.Rows[i].Selected = true;
                    dataGridView_elems.FirstDisplayedScrollingRowIndex = i;
                }
                EnableSelectionItem = true;
            }
        }

        private void click_moveItemsToEnd(object sender, EventArgs ea)
        {
            int l = comboBox_lists.SelectedIndex;
            int[] selIndices = gridSelectedIndices(dataGridView_elems);
            if (selIndices[0] < dataGridView_elems.RowCount-1 && selIndices.Length > 0 && l != eLC.ConversationListIndex)
            {
                EnableSelectionItem = false;
                object[][] temp = new object[eLC.Lists[l].elementValues.Length][];
                for (int i = 0; i < selIndices.Length; i++)
                {
                    Array.Copy(eLC.Lists[l].elementValues, selIndices[i], temp, dataGridView_elems.RowCount - selIndices.Length + i, 1);
                }
                Array.Copy(eLC.Lists[l].elementValues, 0, temp, selIndices.Length, selIndices[0]);
                for (int i = selIndices.Length - 1; i > -1; i--)
                {
                    eLC.Lists[l].RemoveItem(selIndices[i]);
                }
                Array.Copy(eLC.Lists[l].elementValues, 0, temp, 0, eLC.Lists[l].elementValues.Length);
                eLC.Lists[l].elementValues = temp;

                change_list(null, null);

                dataGridView_elems.ClearSelection();
                for (int i = dataGridView_elems.RowCount - selIndices.Length; i < dataGridView_elems.RowCount; i++)
                {
                    dataGridView_elems.Rows[i].Selected = true;
                    dataGridView_elems.FirstDisplayedScrollingRowIndex = i;
                }
                EnableSelectionItem = true;
            }
        }

        private void click_fieldCompare(object sender, EventArgs e)
		{
			if (eLC != null)
			{
				(new FieldCompare(eLC, conversationList, ref cpb2)).Show();
			}
			else
			{
				MessageBox.Show("No File Loaded!");
			}
		}

		string timestamp_to_string(uint timestamp)
		{
			DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0, 0);
			origin = origin.AddSeconds(timestamp);
			return origin.ToString("yyyy-MM-dd HH:mm:ss");
		}

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            About about = new About();
            about.Show();
        }

        //public Bitmap CropBitmap(Bitmap bitmap, int cropX, int cropY, int cropWidth, int cropHeight)
        //{
        //    Rectangle rect = new Rectangle(cropX, cropY, cropWidth, cropHeight);
        //    Bitmap cropped = bitmap.Clone(rect, bitmap.PixelFormat);
        //    return cropped;
        //}

        public Bitmap ddsIcon(Bitmap rawImg, string rawTxt, string icoName)
        {
            try
            { 
                int counter = 0;
                string line;
                int W = 0;
                int H = 0;
                double col = 0;
                double imgNum = -1;
                //X = horizonal
                double X;
                //Y = vertical
                double Y;
                Bitmap cImage = null;

                StreamReader file = new StreamReader(rawTxt, Encoding.GetEncoding("GB2312"));
                while ((line = file.ReadLine()) != null)
                {
                    if (counter == 0) { W = Int32.Parse(line); }
                    if (counter == 1) { H = Int32.Parse(line); }
                    if (counter == 3) { col = Int32.Parse(line); }

                    if (line == icoName)
                    {
                        imgNum = counter - 3;
                        break;
                    }
                    counter++;
                }

                if (imgNum != -1)
                {
                    X = Math.Floor(((imgNum * W) - W) / (col * W)) * W;
                    Y = ((imgNum * W) - W) - (((col * W) * X) / W);

                    Rectangle rect = new Rectangle(Convert.ToInt32(Y), Convert.ToInt32(X), W, H);
                    cImage = rawImg.Clone(rect, rawImg.PixelFormat);
                    //Bitmap cropped = rawImg.Clone(rect, rawImg.PixelFormat);

                    //cImage = CropBitmap(rawImg, Convert.ToInt32(Y), Convert.ToInt32(X), W, H);
                }
                return cImage;
            }
            catch
            {
                return Properties.Resources.QMark;
            }
        }

        public int[] gridSelectedIndices(DataGridView grd)
        {
            List<int> inx = new List<int>();
            Int32 selectedRowCount = grd.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (selectedRowCount > 0)
            {
                for (int i = 0; i < selectedRowCount; i++)
                {
                    inx.Add(grd.SelectedRows[i].Index);
                }
            }
            inx.Sort();
            int[] arr = inx.ToArray();
            return arr;
        }

        private void textBox_search_enter(object sender, EventArgs e)
        {
            if (textBox_search.Text == "ID or NAME")
            {
                textBox_search.Clear();
            }
        }

        private void textBox_search_leave(object sender, EventArgs e)
        {
            if (textBox_search.Text == "")
            {
                textBox_search.Text = "ID or NAME";
            }
        }

        private void textBox_value_enter(object sender, EventArgs e)
        {
            if (textBox_SetValue.Text == "Set Value")
            {
                textBox_SetValue.Clear();
            }
        }

        private void textBox_value_leave(object sender, EventArgs e)
        {
            if (textBox_SetValue.Text == "")
            {
                textBox_SetValue.Text = "Set Value";
            }
        }

        private void listBox_items_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (customTooltype != null)
                    customTooltype.Close();
            }
            catch { }
            if (e.ColumnIndex >= 0 && e.ColumnIndex == 1 && e.RowIndex > -1)
            {
                InfoTool ift = null;
                try
                {
                    int l = comboBox_lists.SelectedIndex;
                    int xe = e.RowIndex;
                    int Id = Convert.ToInt32(this.dataGridView_elems.Rows[e.RowIndex].Cells[0].Value);
                    if (Id > 0)
                    {
                        ift = Extensions.GetItemProps2(Id, 0, l, xe);
                    }
                    if (ift == null)
                    {
                        string text = Extensions.GetItemProps(Id, 0);
                        text += Extensions.ItemDesc(Id);
                        this.dataGridView_elems.Rows[e.RowIndex].Cells[e.ColumnIndex].ToolTipText = text;
                    }
                    else
                    {
                        ift.description = Extensions.ColorClean(Extensions.ItemDesc(Id));
                        customTooltype = new IToolType(ift);
                        customTooltype.Show();
                    }
                }
                catch
                {
                }
            }
        }

        private void createListWithCountsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.FileName = "elements.list.count";
            saveFileDialog1.Title = "Save List Count File";
            saveFileDialog1.ShowDialog();

            // If the file name is not an empty string open it for saving.
            if (saveFileDialog1.FileName != "")
            {
                if (File.Exists(saveFileDialog1.FileName)) { File.Delete(saveFileDialog1.FileName); }
                using (StreamWriter file = new StreamWriter(saveFileDialog1.FileName))
                {
                    file.WriteLine("ver=" + eLC.Version);
                    for (int l = 0; l < eLC.Lists.Length; l++)
                    {
                        file.WriteLine(l + "=" + eLC.Lists[l].elementValues.Length);
                    }
                }
            }
        }
    }
}
