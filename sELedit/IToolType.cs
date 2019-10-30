using sELedit.DDSReader.Utils;
using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace sELedit
{
    public partial class IToolType : Form
    {
        private static CacheSave database = new CacheSave();

        public IToolType(InfoTool data)
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.None;
            BackColor = Color.FromArgb(32, 32, 32);
            Opacity = 0;
            fadeTimer = new Timer { Interval = 15, Enabled = true };
            fadeTimer.Tick += new EventHandler(fadeTimer_Tick);
            mCurrentPoint = Cursor.Position;
            Left = mCurrentPoint.X + 20;
            Top = mCurrentPoint.Y;
           
            int itemID = 0;
            if (MainWindow.database.item_color.ContainsKey(data.itemId))
            {
                itemID = MainWindow.database.item_color[data.itemId];
            }
            Color color = Helper.getByID(itemID);
            titleText.Text = data.name + " ["+ data.itemId + "]";
            titleText.ForeColor = color;
            iconBox.Image = data.img;
            string line = data.basicAdons;
            line += data.time;
            line += data.addons;
            line += data.protect;
            line += data.description;
            change_preview(line);

            Height = 50 + richTextBox_PreviewText.Height;

            Size Size = Screen.PrimaryScreen.WorkingArea.Size;
            int yx = Size.Height;
            if (Bottom > yx)
            {
                 Top = Top - Height;
            }
            database = MainWindow.database;
            colorTheme();
        }

        private void colorTheme()
        {
            if (database.arrTheme != null)
            {
                BackColor = Color.FromName(database.arrTheme[16]);
                richTextBox_PreviewText.BackColor = Color.FromName(database.arrTheme[16]);
                titleText.BackColor = Color.FromName(database.arrTheme[16]);
            }
        }

        private void rtb_ContentsResized(object sender, ContentsResizedEventArgs e)
        {
            ((RichTextBox)sender).Height = e.NewRectangle.Height + 5;
        }

        private void change_preview(String description)
        {
            String line = description.Replace("\\r", Environment.NewLine).Replace("\\n", Environment.NewLine);
            string defaultcolor = "^FFFFFF";
            Color tmp = Color.FromArgb(int.Parse(defaultcolor.Substring(1, 6), NumberStyles.HexNumber));
            string[] blocks = line.Split(new char[] { '^' });
            if (blocks.Length > 1)
            {
                int le1 = 0;
                richTextBox_PreviewText.Text = "";
                le1 = (line.IndexOf('^', 0));
                richTextBox_PreviewText.AppendText(string.Format(line.Substring(0, le1)));
                richTextBox_PreviewText.Select(0, le1);
                richTextBox_PreviewText.SelectionColor = tmp;
                string result = "";

                if (blocks[0] != "")
                {
                    result += blocks[0];
                }

                int le = 0;
                int st = 0;
                Color color = tmp;
                for (int i = 1; i < blocks.Length; i++)
                {
                    if (blocks[i] != "")
                    {
                        st = richTextBox_PreviewText.Text.Length;
                        try
                        {
                            if (blocks[i].Substring(0, 6).ToUpper() == "FFFFFF")
                            {
                                color = tmp;
                            }
                            else
                            {
                                color = Color.FromArgb(int.Parse(blocks[i].Substring(0, 6), NumberStyles.HexNumber));
                            }
                            richTextBox_PreviewText.AppendText(string.Format(blocks[i].Substring(6)));
                        }
                        catch
                        {
                            richTextBox_PreviewText.AppendText(string.Format("^" + blocks[i]));
                        }
                        le = richTextBox_PreviewText.Text.Length - st;
                        richTextBox_PreviewText.Select(st, le);
                        richTextBox_PreviewText.SelectionColor = color;
                    }
                }
            }
            else
            {
                richTextBox_PreviewText.Text = line;
                richTextBox_PreviewText.Select(0, richTextBox_PreviewText.Text.Length);
                richTextBox_PreviewText.SelectionColor = tmp;
            }
            richTextBox_PreviewText.Multiline = true;
            richTextBox_PreviewText.DeselectAll();
            titleText.Focus();
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x204) return; // WM_RBUTTONDOWN
            if (m.Msg == 0x205) return; // WM_RBUTTONUP
            base.WndProc(ref m);
        }

        private void fadeTimer_Tick(object sender, EventArgs e)
        {
            if (IsDisposed)
                return;
            Opacity += 0.04;
            if (Opacity >= 0.99)
            {
                fadeTimer.Enabled = false;
            }
        }

        Timer fadeTimer;
        private Point mCurrentPoint;
    }
}
