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
	public partial class JoinWindow : Form
	{
		private string fileName;
		public string FileName
		{
			get
			{
				return fileName;
			}
			set
			{
				fileName = value;
				//textBox_ElementFile->Text = fileName;
			}
		}
		private string logDirectory;
		public string LogDirectory
		{
			get
			{
				return logDirectory;
			}
			set
			{
				logDirectory = value;
				//textBox_LogDir->Text = logDirectory;
			}
		}
		public bool AddNew;
		public bool BackupNew;
		public bool ReplaceChanged;
		public bool BackupChanged;
		public bool RemoveMissing;
		public bool BackupMissing;
        private static CacheSave database = new CacheSave();

        public JoinWindow()
		{
			InitializeComponent();
            database = MainWindow.database;
            colorTheme();
        }

        private void colorTheme()
        {
            if (database.arrTheme != null)
            {
                BackColor = Color.FromName(database.arrTheme[0]);

                label1.ForeColor = Color.FromName(database.arrTheme[1]);
                label2.ForeColor = Color.FromName(database.arrTheme[1]);
                label3.ForeColor = Color.FromName(database.arrTheme[1]);
                label4.ForeColor = Color.FromName(database.arrTheme[1]);
                label5.ForeColor = Color.FromName(database.arrTheme[1]);

                textBox_ElementFile.BackColor = Color.FromName(database.arrTheme[6]);
                textBox_LogDir.BackColor = Color.FromName(database.arrTheme[6]);

                textBox_ElementFile.ForeColor = Color.FromName(database.arrTheme[1]);
                textBox_LogDir.ForeColor = Color.FromName(database.arrTheme[1]);

                checkBox_AddNew.ForeColor = Color.FromName(database.arrTheme[1]);
                checkBox_BackupChanged.ForeColor = Color.FromName(database.arrTheme[1]);
                checkBox_BackupMissing.ForeColor = Color.FromName(database.arrTheme[1]);
                checkBox_BackupNew.ForeColor = Color.FromName(database.arrTheme[1]);
                checkBox_RemoveMissing.ForeColor = Color.FromName(database.arrTheme[1]);
                checkBox_ReplaceChanged.ForeColor = Color.FromName(database.arrTheme[1]);

                button_BrowseEL.BackColor = Color.FromName(database.arrTheme[11]);
                button_BrowseLog.BackColor = Color.FromName(database.arrTheme[11]);
                button_Cancel.BackColor = Color.FromName(database.arrTheme[11]);
                button_OK.BackColor = Color.FromName(database.arrTheme[11]);

                button_BrowseEL.ForeColor = Color.FromName(database.arrTheme[1]);
                button_BrowseLog.ForeColor = Color.FromName(database.arrTheme[1]);
                button_Cancel.ForeColor = Color.FromName(database.arrTheme[1]);
                button_OK.ForeColor = Color.FromName(database.arrTheme[1]);
            }
        }

        private void click_OK(object sender, EventArgs e)
		{
			fileName = textBox_ElementFile.Text;
			logDirectory = textBox_LogDir.Text;
			AddNew = checkBox_AddNew.Checked;
			BackupNew = checkBox_BackupNew.Checked;
			ReplaceChanged = checkBox_ReplaceChanged.Checked;
			BackupChanged = checkBox_BackupChanged.Checked;
			RemoveMissing = checkBox_RemoveMissing.Checked;
			BackupMissing = checkBox_BackupMissing.Checked;

			this.DialogResult = DialogResult.OK;
			this.Close();
		}

		private void click_BrowseEL(object sender, EventArgs e)
		{
			OpenFileDialog load = new OpenFileDialog();
			load.Filter = "Elements File (*.data)|*.data|All Files (*.*)|*.*";
			if (load.ShowDialog() == DialogResult.OK && File.Exists(load.FileName))
			{
				textBox_ElementFile.Text = load.FileName;
			}
		}
		private void click_BrowseLog(object sender, EventArgs e)
		{
			FolderBrowserDialog load = new FolderBrowserDialog();
			if (load.ShowDialog() == DialogResult.OK && Directory.Exists(load.SelectedPath))
			{
				textBox_LogDir.Text = load.SelectedPath;
			}
		}

		private void click_Cancel(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
			this.Close();
		}
	}
}
