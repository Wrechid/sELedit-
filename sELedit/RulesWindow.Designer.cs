namespace sELedit
{
	partial class RulesWindow
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RulesWindow));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button_browseRecent = new System.Windows.Forms.Button();
            this.button_browseBase = new System.Windows.Forms.Button();
            this.textBox_recentVersion = new System.Windows.Forms.TextBox();
            this.textBox_baseVersion = new System.Windows.Forms.TextBox();
            this.textBox_recentFile = new System.Windows.Forms.TextBox();
            this.textBox_baseFile = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataGridView_values = new System.Windows.Forms.DataGridView();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridView_fields = new System.Windows.Forms.DataGridView();
            this.textBox_recentOffset = new System.Windows.Forms.TextBox();
            this.textBox_baseOffset = new System.Windows.Forms.TextBox();
            this.radioButton_recentOffset = new System.Windows.Forms.RadioButton();
            this.radioButton_baseOffset = new System.Windows.Forms.RadioButton();
            this.checkBox_removeList = new System.Windows.Forms.CheckBox();
            this.comboBox_lists = new System.Windows.Forms.ComboBox();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.button_import = new System.Windows.Forms.Button();
            this.button_view = new System.Windows.Forms.Button();
            this.button_export = new System.Windows.Forms.Button();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_values)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_fields)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.button_browseRecent);
            this.groupBox1.Controls.Add(this.button_browseBase);
            this.groupBox1.Controls.Add(this.textBox_recentVersion);
            this.groupBox1.Controls.Add(this.textBox_baseVersion);
            this.groupBox1.Controls.Add(this.textBox_recentFile);
            this.groupBox1.Controls.Add(this.textBox_baseFile);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(8, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(828, 75);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Files";
            // 
            // button_browseRecent
            // 
            this.button_browseRecent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_browseRecent.Location = new System.Drawing.Point(747, 46);
            this.button_browseRecent.Name = "button_browseRecent";
            this.button_browseRecent.Size = new System.Drawing.Size(75, 23);
            this.button_browseRecent.TabIndex = 9;
            this.button_browseRecent.Text = "Browse...";
            this.button_browseRecent.UseVisualStyleBackColor = true;
            this.button_browseRecent.Click += new System.EventHandler(this.click_browse);
            // 
            // button_browseBase
            // 
            this.button_browseBase.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_browseBase.Location = new System.Drawing.Point(747, 17);
            this.button_browseBase.Name = "button_browseBase";
            this.button_browseBase.Size = new System.Drawing.Size(75, 23);
            this.button_browseBase.TabIndex = 8;
            this.button_browseBase.Text = "Browse...";
            this.button_browseBase.UseVisualStyleBackColor = true;
            this.button_browseBase.Click += new System.EventHandler(this.click_browse);
            // 
            // textBox_recentVersion
            // 
            this.textBox_recentVersion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_recentVersion.Enabled = false;
            this.textBox_recentVersion.Location = new System.Drawing.Point(705, 48);
            this.textBox_recentVersion.Name = "textBox_recentVersion";
            this.textBox_recentVersion.Size = new System.Drawing.Size(36, 20);
            this.textBox_recentVersion.TabIndex = 7;
            // 
            // textBox_baseVersion
            // 
            this.textBox_baseVersion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_baseVersion.Enabled = false;
            this.textBox_baseVersion.Location = new System.Drawing.Point(705, 19);
            this.textBox_baseVersion.Name = "textBox_baseVersion";
            this.textBox_baseVersion.Size = new System.Drawing.Size(36, 20);
            this.textBox_baseVersion.TabIndex = 6;
            // 
            // textBox_recentFile
            // 
            this.textBox_recentFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_recentFile.Enabled = false;
            this.textBox_recentFile.Location = new System.Drawing.Point(75, 48);
            this.textBox_recentFile.Name = "textBox_recentFile";
            this.textBox_recentFile.Size = new System.Drawing.Size(573, 20);
            this.textBox_recentFile.TabIndex = 5;
            // 
            // textBox_baseFile
            // 
            this.textBox_baseFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_baseFile.Enabled = false;
            this.textBox_baseFile.Location = new System.Drawing.Point(75, 19);
            this.textBox_baseFile.Name = "textBox_baseFile";
            this.textBox_baseFile.Size = new System.Drawing.Size(573, 20);
            this.textBox_baseFile.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(654, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Version:";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(654, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Version:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Recent File:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Base File:";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.dataGridView_values);
            this.groupBox2.Controls.Add(this.dataGridView_fields);
            this.groupBox2.Controls.Add(this.textBox_recentOffset);
            this.groupBox2.Controls.Add(this.textBox_baseOffset);
            this.groupBox2.Controls.Add(this.radioButton_recentOffset);
            this.groupBox2.Controls.Add(this.radioButton_baseOffset);
            this.groupBox2.Controls.Add(this.checkBox_removeList);
            this.groupBox2.Controls.Add(this.comboBox_lists);
            this.groupBox2.Location = new System.Drawing.Point(8, 83);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(828, 457);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Lists";
            // 
            // dataGridView_values
            // 
            this.dataGridView_values.AllowUserToAddRows = false;
            this.dataGridView_values.AllowUserToDeleteRows = false;
            this.dataGridView_values.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView_values.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.dataGridView_values.ColumnHeadersHeight = 20;
            this.dataGridView_values.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column7,
            this.Column8});
            this.dataGridView_values.EnableHeadersVisualStyles = false;
            this.dataGridView_values.Location = new System.Drawing.Point(488, 98);
            this.dataGridView_values.Name = "dataGridView_values";
            this.dataGridView_values.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dataGridView_values.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.dataGridView_values.Size = new System.Drawing.Size(334, 353);
            this.dataGridView_values.TabIndex = 7;
            // 
            // Column7
            // 
            this.Column7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Column7.HeaderText = "Base Values";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.Width = 91;
            // 
            // Column8
            // 
            this.Column8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Column8.HeaderText = "Recent Values";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            this.Column8.Width = 102;
            // 
            // dataGridView_fields
            // 
            this.dataGridView_fields.AllowUserToAddRows = false;
            this.dataGridView_fields.AllowUserToDeleteRows = false;
            this.dataGridView_fields.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView_fields.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.dataGridView_fields.ColumnHeadersHeight = 20;
            this.dataGridView_fields.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column6});
            this.dataGridView_fields.EnableHeadersVisualStyles = false;
            this.dataGridView_fields.Location = new System.Drawing.Point(6, 98);
            this.dataGridView_fields.Name = "dataGridView_fields";
            this.dataGridView_fields.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dataGridView_fields.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.dataGridView_fields.Size = new System.Drawing.Size(476, 353);
            this.dataGridView_fields.TabIndex = 6;
            this.toolTip.SetToolTip(this.dataGridView_fields, resources.GetString("dataGridView_fields.ToolTip"));
            this.dataGridView_fields.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.click_field);
            this.dataGridView_fields.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.change_field);
            // 
            // textBox_recentOffset
            // 
            this.textBox_recentOffset.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_recentOffset.Location = new System.Drawing.Point(131, 72);
            this.textBox_recentOffset.Name = "textBox_recentOffset";
            this.textBox_recentOffset.Size = new System.Drawing.Size(691, 20);
            this.textBox_recentOffset.TabIndex = 5;
            // 
            // textBox_baseOffset
            // 
            this.textBox_baseOffset.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_baseOffset.Location = new System.Drawing.Point(131, 46);
            this.textBox_baseOffset.Name = "textBox_baseOffset";
            this.textBox_baseOffset.Size = new System.Drawing.Size(691, 20);
            this.textBox_baseOffset.TabIndex = 4;
            // 
            // radioButton_recentOffset
            // 
            this.radioButton_recentOffset.AutoSize = true;
            this.radioButton_recentOffset.Location = new System.Drawing.Point(6, 73);
            this.radioButton_recentOffset.Name = "radioButton_recentOffset";
            this.radioButton_recentOffset.Size = new System.Drawing.Size(119, 17);
            this.radioButton_recentOffset.TabIndex = 3;
            this.radioButton_recentOffset.TabStop = true;
            this.radioButton_recentOffset.Text = "Keep Recent Offset";
            this.toolTip.SetToolTip(this.radioButton_recentOffset, "Keep the list offsets from the recent file.\r\nSuspicious offsets are in lists: 0, " +
        "20, 100\r\n\r\nFor version 7 base file (1.2.6 server) you have to use base offsets f" +
        "rom list 0, 20, 100 !!!");
            this.radioButton_recentOffset.UseVisualStyleBackColor = true;
            // 
            // radioButton_baseOffset
            // 
            this.radioButton_baseOffset.AutoSize = true;
            this.radioButton_baseOffset.Location = new System.Drawing.Point(6, 47);
            this.radioButton_baseOffset.Name = "radioButton_baseOffset";
            this.radioButton_baseOffset.Size = new System.Drawing.Size(102, 17);
            this.radioButton_baseOffset.TabIndex = 2;
            this.radioButton_baseOffset.TabStop = true;
            this.radioButton_baseOffset.Text = "Use Base Offset";
            this.toolTip.SetToolTip(this.radioButton_baseOffset, resources.GetString("radioButton_baseOffset.ToolTip"));
            this.radioButton_baseOffset.UseVisualStyleBackColor = true;
            this.radioButton_baseOffset.CheckedChanged += new System.EventHandler(this.check_offset);
            // 
            // checkBox_removeList
            // 
            this.checkBox_removeList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBox_removeList.AutoSize = true;
            this.checkBox_removeList.Location = new System.Drawing.Point(737, 21);
            this.checkBox_removeList.Name = "checkBox_removeList";
            this.checkBox_removeList.Size = new System.Drawing.Size(85, 17);
            this.checkBox_removeList.TabIndex = 1;
            this.checkBox_removeList.Text = "Remove List";
            this.toolTip.SetToolTip(this.checkBox_removeList, "Remove the selected list.");
            this.checkBox_removeList.UseVisualStyleBackColor = true;
            this.checkBox_removeList.CheckedChanged += new System.EventHandler(this.check_removeList);
            // 
            // comboBox_lists
            // 
            this.comboBox_lists.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox_lists.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_lists.FormattingEnabled = true;
            this.comboBox_lists.Location = new System.Drawing.Point(6, 19);
            this.comboBox_lists.Name = "comboBox_lists";
            this.comboBox_lists.Size = new System.Drawing.Size(725, 21);
            this.comboBox_lists.TabIndex = 0;
            this.comboBox_lists.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.comboBoxDb_DrawItem);
            this.comboBox_lists.SelectedIndexChanged += new System.EventHandler(this.change_list);
            // 
            // toolTip
            // 
            this.toolTip.AutomaticDelay = 0;
            this.toolTip.AutoPopDelay = 25000;
            this.toolTip.InitialDelay = 0;
            this.toolTip.ReshowDelay = 0;
            // 
            // button_import
            // 
            this.button_import.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.button_import.Location = new System.Drawing.Point(241, 546);
            this.button_import.Name = "button_import";
            this.button_import.Size = new System.Drawing.Size(100, 23);
            this.button_import.TabIndex = 2;
            this.button_import.Text = "Import Rules...";
            this.button_import.UseVisualStyleBackColor = true;
            this.button_import.Click += new System.EventHandler(this.click_importRules);
            // 
            // button_view
            // 
            this.button_view.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.button_view.Location = new System.Drawing.Point(347, 546);
            this.button_view.Name = "button_view";
            this.button_view.Size = new System.Drawing.Size(100, 23);
            this.button_view.TabIndex = 2;
            this.button_view.Text = "View Rules...";
            this.button_view.UseVisualStyleBackColor = true;
            this.button_view.Click += new System.EventHandler(this.click_viewRules);
            // 
            // button_export
            // 
            this.button_export.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.button_export.Location = new System.Drawing.Point(453, 546);
            this.button_export.Name = "button_export";
            this.button_export.Size = new System.Drawing.Size(100, 23);
            this.button_export.TabIndex = 2;
            this.button_export.Text = "Export Rules...";
            this.button_export.UseVisualStyleBackColor = true;
            this.button_export.Click += new System.EventHandler(this.click_exportRules);
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Column1.HeaderText = "Base Fields";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 86;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Column2.HeaderText = "Recent Fields";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 97;
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column3.HeaderText = "Value Mismatches";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Column4.HeaderText = "DEL";
            this.Column4.Name = "Column4";
            this.Column4.Width = 34;
            // 
            // Column6
            // 
            this.Column6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            this.Column6.DefaultCellStyle = dataGridViewCellStyle1;
            this.Column6.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Column6.HeaderText = "Analize";
            this.Column6.Name = "Column6";
            this.Column6.Width = 47;
            // 
            // RulesWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(844, 573);
            this.Controls.Add(this.button_export);
            this.Controls.Add(this.button_view);
            this.Controls.Add(this.button_import);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(860, 600);
            this.Name = "RulesWindow";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Element Structure Diff (Rules GUI)";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_values)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_fields)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button button_browseRecent;
		private System.Windows.Forms.Button button_browseBase;
		private System.Windows.Forms.TextBox textBox_recentVersion;
		private System.Windows.Forms.TextBox textBox_baseVersion;
		private System.Windows.Forms.TextBox textBox_recentFile;
		private System.Windows.Forms.TextBox textBox_baseFile;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.DataGridView dataGridView_values;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
		private System.Windows.Forms.DataGridView dataGridView_fields;
		private System.Windows.Forms.ToolTip toolTip;
		private System.Windows.Forms.TextBox textBox_recentOffset;
		private System.Windows.Forms.TextBox textBox_baseOffset;
		private System.Windows.Forms.RadioButton radioButton_recentOffset;
		private System.Windows.Forms.RadioButton radioButton_baseOffset;
		private System.Windows.Forms.CheckBox checkBox_removeList;
		private System.Windows.Forms.ComboBox comboBox_lists;
		private System.Windows.Forms.Button button_import;
		private System.Windows.Forms.Button button_view;
		private System.Windows.Forms.Button button_export;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column4;
        private System.Windows.Forms.DataGridViewButtonColumn Column6;
    }
}