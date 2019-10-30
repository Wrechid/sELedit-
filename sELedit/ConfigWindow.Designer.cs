namespace sELedit
{
	partial class ConfigWindow
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.menuStrip_mainMenu = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.scanNewGenerationExperimentalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.comboBox_lists = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_listName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridView_item = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip_row = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addRowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addCopiedRowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyRowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteRowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_offset = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_conversationListIndex = new System.Windows.Forms.TextBox();
            this.textBox_SetName = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.textBox_SetType = new System.Windows.Forms.TextBox();
            this.menuStrip_mainMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_item)).BeginInit();
            this.contextMenuStrip_row.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip_mainMenu
            // 
            this.menuStrip_mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.menuStrip_mainMenu.Location = new System.Drawing.Point(0, 0);
            this.menuStrip_mainMenu.Name = "menuStrip_mainMenu";
            this.menuStrip_mainMenu.Padding = new System.Windows.Forms.Padding(0, 2, 2, 2);
            this.menuStrip_mainMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.menuStrip_mainMenu.Size = new System.Drawing.Size(637, 24);
            this.menuStrip_mainMenu.TabIndex = 1;
            this.menuStrip_mainMenu.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.toolStripSeparator1,
            this.scanNewGenerationExperimentalToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Padding = new System.Windows.Forms.Padding(0);
            this.toolStripMenuItem1.Size = new System.Drawing.Size(29, 20);
            this.toolStripMenuItem1.Text = "File";
            this.toolStripMenuItem1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(240, 22);
            this.loadToolStripMenuItem.Text = "Load...";
            this.loadToolStripMenuItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.click_load);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(240, 22);
            this.saveToolStripMenuItem.Text = "Save As...";
            this.saveToolStripMenuItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.click_save);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(237, 6);
            // 
            // scanNewGenerationExperimentalToolStripMenuItem
            // 
            this.scanNewGenerationExperimentalToolStripMenuItem.Name = "scanNewGenerationExperimentalToolStripMenuItem";
            this.scanNewGenerationExperimentalToolStripMenuItem.Size = new System.Drawing.Size(240, 22);
            this.scanNewGenerationExperimentalToolStripMenuItem.Text = "Scan Sequel EL... (Experimental)";
            this.scanNewGenerationExperimentalToolStripMenuItem.Click += new System.EventHandler(this.click_scanSequel);
            // 
            // comboBox_lists
            // 
            this.comboBox_lists.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox_lists.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_lists.FormattingEnabled = true;
            this.comboBox_lists.Location = new System.Drawing.Point(138, 53);
            this.comboBox_lists.Name = "comboBox_lists";
            this.comboBox_lists.Size = new System.Drawing.Size(487, 21);
            this.comboBox_lists.TabIndex = 2;
            this.comboBox_lists.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.comboBoxDb_DrawItem);
            this.comboBox_lists.SelectedIndexChanged += new System.EventHandler(this.change_list);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "List Name:";
            // 
            // textBox_listName
            // 
            this.textBox_listName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_listName.Location = new System.Drawing.Point(138, 80);
            this.textBox_listName.Name = "textBox_listName";
            this.textBox_listName.Size = new System.Drawing.Size(487, 20);
            this.textBox_listName.TabIndex = 4;
            this.textBox_listName.TextChanged += new System.EventHandler(this.change_listName);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Offset Bytes:";
            // 
            // dataGridView_item
            // 
            this.dataGridView_item.AllowUserToAddRows = false;
            this.dataGridView_item.AllowUserToDeleteRows = false;
            this.dataGridView_item.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView_item.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridView_item.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.dataGridView_item.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_item.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            this.dataGridView_item.ContextMenuStrip = this.contextMenuStrip_row;
            this.dataGridView_item.EnableHeadersVisualStyles = false;
            this.dataGridView_item.Location = new System.Drawing.Point(12, 132);
            this.dataGridView_item.Name = "dataGridView_item";
            this.dataGridView_item.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView_item.RowHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView_item.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToFirstHeader;
            this.dataGridView_item.RowTemplate.Height = 18;
            this.dataGridView_item.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView_item.Size = new System.Drawing.Size(613, 346);
            this.dataGridView_item.TabIndex = 6;
            this.dataGridView_item.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.change_row);
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column1.HeaderText = "Name";
            this.Column1.Name = "Column1";
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column1.Width = 40;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column2.HeaderText = "Type";
            this.Column2.Name = "Column2";
            this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // contextMenuStrip_row
            // 
            this.contextMenuStrip_row.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.contextMenuStrip_row.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addRowToolStripMenuItem,
            this.addCopiedRowToolStripMenuItem,
            this.copyRowToolStripMenuItem,
            this.deleteRowToolStripMenuItem});
            this.contextMenuStrip_row.Name = "contextMenuStrip_row";
            this.contextMenuStrip_row.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.contextMenuStrip_row.ShowImageMargin = false;
            this.contextMenuStrip_row.Size = new System.Drawing.Size(144, 92);
            // 
            // addRowToolStripMenuItem
            // 
            this.addRowToolStripMenuItem.Name = "addRowToolStripMenuItem";
            this.addRowToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.addRowToolStripMenuItem.Text = "Add Row";
            this.addRowToolStripMenuItem.Click += new System.EventHandler(this.add_row);
            // 
            // addCopiedRowToolStripMenuItem
            // 
            this.addCopiedRowToolStripMenuItem.Name = "addCopiedRowToolStripMenuItem";
            this.addCopiedRowToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.addCopiedRowToolStripMenuItem.Text = "Add Copied Rows";
            this.addCopiedRowToolStripMenuItem.Click += new System.EventHandler(this.addCopied_row);
            // 
            // copyRowToolStripMenuItem
            // 
            this.copyRowToolStripMenuItem.Name = "copyRowToolStripMenuItem";
            this.copyRowToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.copyRowToolStripMenuItem.Text = "Copy Rows";
            this.copyRowToolStripMenuItem.Click += new System.EventHandler(this.copy_row);
            // 
            // deleteRowToolStripMenuItem
            // 
            this.deleteRowToolStripMenuItem.Name = "deleteRowToolStripMenuItem";
            this.deleteRowToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.deleteRowToolStripMenuItem.Text = "Delete Rows";
            this.deleteRowToolStripMenuItem.Click += new System.EventHandler(this.delete_row);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(325, 484);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(300, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "Delete Current List";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.click_deleteList);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(12, 484);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(300, 23);
            this.button2.TabIndex = 9;
            this.button2.Text = "Add New List";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.click_addList);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "List:";
            // 
            // textBox_offset
            // 
            this.textBox_offset.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_offset.Location = new System.Drawing.Point(138, 106);
            this.textBox_offset.Name = "textBox_offset";
            this.textBox_offset.Size = new System.Drawing.Size(487, 20);
            this.textBox_offset.TabIndex = 11;
            this.textBox_offset.TextChanged += new System.EventHandler(this.change_listOffset);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(120, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Conversation List Index:";
            // 
            // textBox_conversationListIndex
            // 
            this.textBox_conversationListIndex.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_conversationListIndex.Location = new System.Drawing.Point(138, 27);
            this.textBox_conversationListIndex.Name = "textBox_conversationListIndex";
            this.textBox_conversationListIndex.Size = new System.Drawing.Size(487, 20);
            this.textBox_conversationListIndex.TabIndex = 13;
            this.textBox_conversationListIndex.TextChanged += new System.EventHandler(this.change_conversationListIndex);
            // 
            // textBox_SetName
            // 
            this.textBox_SetName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_SetName.Location = new System.Drawing.Point(12, 514);
            this.textBox_SetName.Name = "textBox_SetName";
            this.textBox_SetName.Size = new System.Drawing.Size(462, 20);
            this.textBox_SetName.TabIndex = 14;
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.Location = new System.Drawing.Point(480, 512);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(145, 23);
            this.button3.TabIndex = 15;
            this.button3.Text = "Set Value Selected Names";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.click_SetValueSelectedNames);
            // 
            // button4
            // 
            this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button4.Location = new System.Drawing.Point(480, 540);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(145, 23);
            this.button4.TabIndex = 16;
            this.button4.Text = "Set Value Selected Types";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.click_SetValueSelectedTypes);
            // 
            // textBox_SetType
            // 
            this.textBox_SetType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_SetType.Location = new System.Drawing.Point(12, 542);
            this.textBox_SetType.Name = "textBox_SetType";
            this.textBox_SetType.Size = new System.Drawing.Size(462, 20);
            this.textBox_SetType.TabIndex = 17;
            // 
            // ConfigWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(637, 576);
            this.Controls.Add(this.textBox_SetType);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.textBox_SetName);
            this.Controls.Add(this.textBox_conversationListIndex);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox_offset);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView_item);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox_listName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox_lists);
            this.Controls.Add(this.menuStrip_mainMenu);
            this.MainMenuStrip = this.menuStrip_mainMenu;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(498, 576);
            this.Name = "ConfigWindow";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Configuration Editor";
            this.menuStrip_mainMenu.ResumeLayout(false);
            this.menuStrip_mainMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_item)).EndInit();
            this.contextMenuStrip_row.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip menuStrip_mainMenu;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripMenuItem scanNewGenerationExperimentalToolStripMenuItem;
		private System.Windows.Forms.ComboBox comboBox_lists;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textBox_listName;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.DataGridView dataGridView_item;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
		private System.Windows.Forms.ContextMenuStrip contextMenuStrip_row;
		private System.Windows.Forms.ToolStripMenuItem addRowToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem deleteRowToolStripMenuItem;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox textBox_offset;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox textBox_conversationListIndex;
		private System.Windows.Forms.ToolStripMenuItem copyRowToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem addCopiedRowToolStripMenuItem;
		private System.Windows.Forms.TextBox textBox_SetName;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.TextBox textBox_SetType;
	}
}