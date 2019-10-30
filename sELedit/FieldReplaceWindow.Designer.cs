namespace sELedit
{
	partial class FieldReplaceWindow
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
            this.textBox_ElementPath = new System.Windows.Forms.TextBox();
            this.button_browseElement = new System.Windows.Forms.Button();
            this.button_LoadElement = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_LogDir = new System.Windows.Forms.TextBox();
            this.button_browseLogDit = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox_List = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBox_Field = new System.Windows.Forms.ComboBox();
            this.button_replace = new System.Windows.Forms.Button();
            this.button_cancel = new System.Windows.Forms.Button();
            this.cpb2 = new ColorProgressBar.ColorProgressBar();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Select Element File:";
            // 
            // textBox_ElementPath
            // 
            this.textBox_ElementPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_ElementPath.Location = new System.Drawing.Point(112, 12);
            this.textBox_ElementPath.Name = "textBox_ElementPath";
            this.textBox_ElementPath.Size = new System.Drawing.Size(365, 20);
            this.textBox_ElementPath.TabIndex = 1;
            // 
            // button_browseElement
            // 
            this.button_browseElement.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_browseElement.Location = new System.Drawing.Point(484, 10);
            this.button_browseElement.Name = "button_browseElement";
            this.button_browseElement.Size = new System.Drawing.Size(75, 23);
            this.button_browseElement.TabIndex = 2;
            this.button_browseElement.Text = "Browse";
            this.button_browseElement.UseVisualStyleBackColor = true;
            this.button_browseElement.Click += new System.EventHandler(this.click_browseElement);
            // 
            // button_LoadElement
            // 
            this.button_LoadElement.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button_LoadElement.Location = new System.Drawing.Point(111, 39);
            this.button_LoadElement.Name = "button_LoadElement";
            this.button_LoadElement.Size = new System.Drawing.Size(367, 23);
            this.button_LoadElement.TabIndex = 3;
            this.button_LoadElement.Text = "Load elements.data";
            this.button_LoadElement.UseVisualStyleBackColor = true;
            this.button_LoadElement.Click += new System.EventHandler(this.click_LoadElement);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Select Log Dir:";
            // 
            // textBox_LogDir
            // 
            this.textBox_LogDir.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_LogDir.Location = new System.Drawing.Point(112, 69);
            this.textBox_LogDir.Name = "textBox_LogDir";
            this.textBox_LogDir.Size = new System.Drawing.Size(365, 20);
            this.textBox_LogDir.TabIndex = 5;
            // 
            // button_browseLogDit
            // 
            this.button_browseLogDit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_browseLogDit.Location = new System.Drawing.Point(484, 67);
            this.button_browseLogDit.Name = "button_browseLogDit";
            this.button_browseLogDit.Size = new System.Drawing.Size(75, 23);
            this.button_browseLogDit.TabIndex = 6;
            this.button_browseLogDit.Text = "Browse";
            this.button_browseLogDit.UseVisualStyleBackColor = true;
            this.button_browseLogDit.Click += new System.EventHandler(this.click_browseLogDir);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(83, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "List:";
            // 
            // comboBox_List
            // 
            this.comboBox_List.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox_List.FormattingEnabled = true;
            this.comboBox_List.Location = new System.Drawing.Point(112, 96);
            this.comboBox_List.Name = "comboBox_List";
            this.comboBox_List.Size = new System.Drawing.Size(365, 21);
            this.comboBox_List.TabIndex = 8;
            this.comboBox_List.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.comboBoxDb_DrawItem);
            this.comboBox_List.SelectedIndexChanged += new System.EventHandler(this.change_list);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(77, 127);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Field:";
            // 
            // comboBox_Field
            // 
            this.comboBox_Field.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox_Field.FormattingEnabled = true;
            this.comboBox_Field.Location = new System.Drawing.Point(112, 124);
            this.comboBox_Field.Name = "comboBox_Field";
            this.comboBox_Field.Size = new System.Drawing.Size(365, 21);
            this.comboBox_Field.TabIndex = 10;
            this.comboBox_Field.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.comboBoxDb_DrawItem);
            this.comboBox_Field.SelectedIndexChanged += new System.EventHandler(this.CheckReplaceButton);
            // 
            // button_replace
            // 
            this.button_replace.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button_replace.Location = new System.Drawing.Point(162, 172);
            this.button_replace.Name = "button_replace";
            this.button_replace.Size = new System.Drawing.Size(75, 23);
            this.button_replace.TabIndex = 11;
            this.button_replace.Text = "Replace";
            this.button_replace.UseVisualStyleBackColor = true;
            this.button_replace.Click += new System.EventHandler(this.click_replace);
            // 
            // button_cancel
            // 
            this.button_cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_cancel.Location = new System.Drawing.Point(352, 172);
            this.button_cancel.Name = "button_cancel";
            this.button_cancel.Size = new System.Drawing.Size(75, 23);
            this.button_cancel.TabIndex = 12;
            this.button_cancel.Text = "Close";
            this.button_cancel.UseVisualStyleBackColor = true;
            this.button_cancel.Click += new System.EventHandler(this.click_close);
            // 
            // cpb2
            // 
            this.cpb2.BarColor = System.Drawing.Color.DarkGray;
            this.cpb2.BorderColor = System.Drawing.Color.Transparent;
            this.cpb2.FillStyle = ColorProgressBar.ColorProgressBar.FillStyles.Solid;
            this.cpb2.Location = new System.Drawing.Point(4, 210);
            this.cpb2.Maximum = 100;
            this.cpb2.Minimum = 0;
            this.cpb2.Name = "cpb2";
            this.cpb2.Size = new System.Drawing.Size(564, 16);
            this.cpb2.Step = 10;
            this.cpb2.TabIndex = 331;
            this.cpb2.Value = 100;
            // 
            // FieldReplaceWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(572, 228);
            this.Controls.Add(this.cpb2);
            this.Controls.Add(this.button_cancel);
            this.Controls.Add(this.button_replace);
            this.Controls.Add(this.comboBox_Field);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comboBox_List);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button_browseLogDit);
            this.Controls.Add(this.textBox_LogDir);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button_LoadElement);
            this.Controls.Add(this.button_browseElement);
            this.Controls.Add(this.textBox_ElementPath);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(588, 267);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(588, 267);
            this.Name = "FieldReplaceWindow";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Field Replace";
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textBox_ElementPath;
		private System.Windows.Forms.Button button_browseElement;
		private System.Windows.Forms.Button button_LoadElement;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox textBox_LogDir;
		private System.Windows.Forms.Button button_browseLogDit;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox comboBox_List;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ComboBox comboBox_Field;
		private System.Windows.Forms.Button button_replace;
		private System.Windows.Forms.Button button_cancel;
        private ColorProgressBar.ColorProgressBar cpb2;
    }
}