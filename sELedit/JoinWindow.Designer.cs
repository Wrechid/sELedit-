namespace sELedit
{
	partial class JoinWindow
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_ElementFile = new System.Windows.Forms.TextBox();
            this.button_BrowseEL = new System.Windows.Forms.Button();
            this.textBox_LogDir = new System.Windows.Forms.TextBox();
            this.button_BrowseLog = new System.Windows.Forms.Button();
            this.checkBox_AddNew = new System.Windows.Forms.CheckBox();
            this.checkBox_BackupNew = new System.Windows.Forms.CheckBox();
            this.checkBox_ReplaceChanged = new System.Windows.Forms.CheckBox();
            this.checkBox_BackupChanged = new System.Windows.Forms.CheckBox();
            this.checkBox_RemoveMissing = new System.Windows.Forms.CheckBox();
            this.checkBox_BackupMissing = new System.Windows.Forms.CheckBox();
            this.button_OK = new System.Windows.Forms.Button();
            this.button_Cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Join Element File:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Log Directory:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "New Items:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 116);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Changed Items:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 139);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Missing Items:";
            // 
            // textBox_ElementFile
            // 
            this.textBox_ElementFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_ElementFile.Location = new System.Drawing.Point(107, 14);
            this.textBox_ElementFile.Name = "textBox_ElementFile";
            this.textBox_ElementFile.Size = new System.Drawing.Size(304, 20);
            this.textBox_ElementFile.TabIndex = 5;
            // 
            // button_BrowseEL
            // 
            this.button_BrowseEL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_BrowseEL.Location = new System.Drawing.Point(417, 12);
            this.button_BrowseEL.Name = "button_BrowseEL";
            this.button_BrowseEL.Size = new System.Drawing.Size(75, 23);
            this.button_BrowseEL.TabIndex = 6;
            this.button_BrowseEL.Text = "Browse...";
            this.button_BrowseEL.UseVisualStyleBackColor = true;
            this.button_BrowseEL.Click += new System.EventHandler(this.click_BrowseEL);
            // 
            // textBox_LogDir
            // 
            this.textBox_LogDir.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_LogDir.Location = new System.Drawing.Point(107, 43);
            this.textBox_LogDir.Name = "textBox_LogDir";
            this.textBox_LogDir.Size = new System.Drawing.Size(304, 20);
            this.textBox_LogDir.TabIndex = 7;
            // 
            // button_BrowseLog
            // 
            this.button_BrowseLog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_BrowseLog.Location = new System.Drawing.Point(417, 41);
            this.button_BrowseLog.Name = "button_BrowseLog";
            this.button_BrowseLog.Size = new System.Drawing.Size(75, 23);
            this.button_BrowseLog.TabIndex = 8;
            this.button_BrowseLog.Text = "Browse...";
            this.button_BrowseLog.UseVisualStyleBackColor = true;
            this.button_BrowseLog.Click += new System.EventHandler(this.click_BrowseLog);
            // 
            // checkBox_AddNew
            // 
            this.checkBox_AddNew.AutoSize = true;
            this.checkBox_AddNew.Checked = true;
            this.checkBox_AddNew.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_AddNew.Location = new System.Drawing.Point(107, 92);
            this.checkBox_AddNew.Name = "checkBox_AddNew";
            this.checkBox_AddNew.Size = new System.Drawing.Size(98, 17);
            this.checkBox_AddNew.TabIndex = 9;
            this.checkBox_AddNew.Text = "Add New Items";
            this.checkBox_AddNew.UseVisualStyleBackColor = true;
            // 
            // checkBox_BackupNew
            // 
            this.checkBox_BackupNew.AutoSize = true;
            this.checkBox_BackupNew.Location = new System.Drawing.Point(253, 92);
            this.checkBox_BackupNew.Name = "checkBox_BackupNew";
            this.checkBox_BackupNew.Size = new System.Drawing.Size(204, 17);
            this.checkBox_BackupNew.TabIndex = 10;
            this.checkBox_BackupNew.Text = "Export Added Items into Log Directory";
            this.checkBox_BackupNew.UseVisualStyleBackColor = true;
            // 
            // checkBox_ReplaceChanged
            // 
            this.checkBox_ReplaceChanged.AutoSize = true;
            this.checkBox_ReplaceChanged.Location = new System.Drawing.Point(107, 115);
            this.checkBox_ReplaceChanged.Name = "checkBox_ReplaceChanged";
            this.checkBox_ReplaceChanged.Size = new System.Drawing.Size(140, 17);
            this.checkBox_ReplaceChanged.TabIndex = 11;
            this.checkBox_ReplaceChanged.Text = "Replace Changed Items";
            this.checkBox_ReplaceChanged.UseVisualStyleBackColor = true;
            // 
            // checkBox_BackupChanged
            // 
            this.checkBox_BackupChanged.AutoSize = true;
            this.checkBox_BackupChanged.Location = new System.Drawing.Point(253, 115);
            this.checkBox_BackupChanged.Name = "checkBox_BackupChanged";
            this.checkBox_BackupChanged.Size = new System.Drawing.Size(219, 17);
            this.checkBox_BackupChanged.TabIndex = 12;
            this.checkBox_BackupChanged.Text = "Export Replaced Items into Log Directory";
            this.checkBox_BackupChanged.UseVisualStyleBackColor = true;
            // 
            // checkBox_RemoveMissing
            // 
            this.checkBox_RemoveMissing.AutoSize = true;
            this.checkBox_RemoveMissing.Location = new System.Drawing.Point(107, 138);
            this.checkBox_RemoveMissing.Name = "checkBox_RemoveMissing";
            this.checkBox_RemoveMissing.Size = new System.Drawing.Size(132, 17);
            this.checkBox_RemoveMissing.TabIndex = 13;
            this.checkBox_RemoveMissing.Text = "Remove Missing Items";
            this.checkBox_RemoveMissing.UseVisualStyleBackColor = true;
            // 
            // checkBox_BackupMissing
            // 
            this.checkBox_BackupMissing.AutoSize = true;
            this.checkBox_BackupMissing.Location = new System.Drawing.Point(253, 138);
            this.checkBox_BackupMissing.Name = "checkBox_BackupMissing";
            this.checkBox_BackupMissing.Size = new System.Drawing.Size(219, 17);
            this.checkBox_BackupMissing.TabIndex = 14;
            this.checkBox_BackupMissing.Text = "Export Removed Items into Log Directory";
            this.checkBox_BackupMissing.UseVisualStyleBackColor = true;
            // 
            // button_OK
            // 
            this.button_OK.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.button_OK.Location = new System.Drawing.Point(328, 166);
            this.button_OK.Name = "button_OK";
            this.button_OK.Size = new System.Drawing.Size(75, 23);
            this.button_OK.TabIndex = 15;
            this.button_OK.Text = "OK";
            this.button_OK.UseVisualStyleBackColor = true;
            this.button_OK.Click += new System.EventHandler(this.click_OK);
            // 
            // button_Cancel
            // 
            this.button_Cancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.button_Cancel.Location = new System.Drawing.Point(409, 166);
            this.button_Cancel.Name = "button_Cancel";
            this.button_Cancel.Size = new System.Drawing.Size(75, 23);
            this.button_Cancel.TabIndex = 16;
            this.button_Cancel.Text = "Cancel";
            this.button_Cancel.UseVisualStyleBackColor = true;
            this.button_Cancel.Click += new System.EventHandler(this.click_Cancel);
            // 
            // JoinWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(496, 201);
            this.ControlBox = false;
            this.Controls.Add(this.button_Cancel);
            this.Controls.Add(this.button_OK);
            this.Controls.Add(this.checkBox_BackupMissing);
            this.Controls.Add(this.checkBox_RemoveMissing);
            this.Controls.Add(this.checkBox_BackupChanged);
            this.Controls.Add(this.checkBox_ReplaceChanged);
            this.Controls.Add(this.checkBox_BackupNew);
            this.Controls.Add(this.checkBox_AddNew);
            this.Controls.Add(this.button_BrowseLog);
            this.Controls.Add(this.textBox_LogDir);
            this.Controls.Add(this.button_BrowseEL);
            this.Controls.Add(this.textBox_ElementFile);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximumSize = new System.Drawing.Size(512, 240);
            this.MinimumSize = new System.Drawing.Size(512, 240);
            this.Name = "JoinWindow";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Join Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox textBox_ElementFile;
		private System.Windows.Forms.Button button_BrowseEL;
		private System.Windows.Forms.TextBox textBox_LogDir;
		private System.Windows.Forms.Button button_BrowseLog;
		private System.Windows.Forms.CheckBox checkBox_AddNew;
		private System.Windows.Forms.CheckBox checkBox_BackupNew;
		private System.Windows.Forms.CheckBox checkBox_ReplaceChanged;
		private System.Windows.Forms.CheckBox checkBox_BackupChanged;
		private System.Windows.Forms.CheckBox checkBox_RemoveMissing;
		private System.Windows.Forms.CheckBox checkBox_BackupMissing;
		private System.Windows.Forms.Button button_OK;
		private System.Windows.Forms.Button button_Cancel;
	}
}