namespace sELedit
{
	partial class ReplaceWindow
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox_field = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_item = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_list = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.radioButton_replace = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBox_newValue = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_oldValue = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.radioButton_recalculate = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.numericUpDown_operand = new System.Windows.Forms.NumericUpDown();
            this.comboBox_operation = new System.Windows.Forms.ComboBox();
            this.button_replace = new System.Windows.Forms.Button();
            this.button_cancel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_operand)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.textBox_field);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textBox_item);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textBox_list);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(268, 98);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Scan Settings";
            // 
            // textBox_field
            // 
            this.textBox_field.Location = new System.Drawing.Point(162, 71);
            this.textBox_field.Name = "textBox_field";
            this.textBox_field.Size = new System.Drawing.Size(100, 20);
            this.textBox_field.TabIndex = 5;
            this.textBox_field.Text = "*";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "in Field ID:";
            // 
            // textBox_item
            // 
            this.textBox_item.Location = new System.Drawing.Point(162, 45);
            this.textBox_item.Name = "textBox_item";
            this.textBox_item.Size = new System.Drawing.Size(100, 20);
            this.textBox_item.TabIndex = 3;
            this.textBox_item.Text = "*";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "in Item ID:";
            // 
            // textBox_list
            // 
            this.textBox_list.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_list.Location = new System.Drawing.Point(162, 19);
            this.textBox_list.Name = "textBox_list";
            this.textBox_list.Size = new System.Drawing.Size(100, 20);
            this.textBox_list.TabIndex = 1;
            this.textBox_list.Text = "*";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "in List ID:";
            // 
            // radioButton_replace
            // 
            this.radioButton_replace.AutoSize = true;
            this.radioButton_replace.Checked = true;
            this.radioButton_replace.Location = new System.Drawing.Point(12, 116);
            this.radioButton_replace.Name = "radioButton_replace";
            this.radioButton_replace.Size = new System.Drawing.Size(65, 17);
            this.radioButton_replace.TabIndex = 13;
            this.radioButton_replace.TabStop = true;
            this.radioButton_replace.Text = "Replace";
            this.radioButton_replace.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBox_newValue);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.textBox_oldValue);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(12, 139);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(268, 71);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Replace Settings";
            // 
            // textBox_newValue
            // 
            this.textBox_newValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_newValue.Location = new System.Drawing.Point(88, 45);
            this.textBox_newValue.Name = "textBox_newValue";
            this.textBox_newValue.Size = new System.Drawing.Size(174, 20);
            this.textBox_newValue.TabIndex = 9;
            this.textBox_newValue.Text = "*";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "New Value:";
            // 
            // textBox_oldValue
            // 
            this.textBox_oldValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_oldValue.Location = new System.Drawing.Point(88, 19);
            this.textBox_oldValue.Name = "textBox_oldValue";
            this.textBox_oldValue.Size = new System.Drawing.Size(174, 20);
            this.textBox_oldValue.TabIndex = 7;
            this.textBox_oldValue.Text = "*";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Old Value:";
            // 
            // radioButton_recalculate
            // 
            this.radioButton_recalculate.AutoSize = true;
            this.radioButton_recalculate.Location = new System.Drawing.Point(12, 216);
            this.radioButton_recalculate.Name = "radioButton_recalculate";
            this.radioButton_recalculate.Size = new System.Drawing.Size(172, 17);
            this.radioButton_recalculate.TabIndex = 14;
            this.radioButton_recalculate.TabStop = true;
            this.radioButton_recalculate.Text = "Re-Calculate (only for numbers)";
            this.radioButton_recalculate.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.numericUpDown_operand);
            this.groupBox3.Controls.Add(this.comboBox_operation);
            this.groupBox3.Location = new System.Drawing.Point(12, 239);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(268, 48);
            this.groupBox3.TabIndex = 15;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Re-Calculate Settings";
            // 
            // numericUpDown_operand
            // 
            this.numericUpDown_operand.DecimalPlaces = 3;
            this.numericUpDown_operand.Location = new System.Drawing.Point(137, 19);
            this.numericUpDown_operand.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numericUpDown_operand.Minimum = new decimal(new int[] {
            1000000,
            0,
            0,
            -2147483648});
            this.numericUpDown_operand.Name = "numericUpDown_operand";
            this.numericUpDown_operand.Size = new System.Drawing.Size(125, 20);
            this.numericUpDown_operand.TabIndex = 1;
            this.numericUpDown_operand.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // comboBox_operation
            // 
            this.comboBox_operation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_operation.FormattingEnabled = true;
            this.comboBox_operation.Items.AddRange(new object[] {
            "*",
            "/",
            "+",
            "-"});
            this.comboBox_operation.Location = new System.Drawing.Point(7, 19);
            this.comboBox_operation.Name = "comboBox_operation";
            this.comboBox_operation.Size = new System.Drawing.Size(122, 21);
            this.comboBox_operation.TabIndex = 0;
            this.comboBox_operation.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.comboBoxDb_DrawItem);
            // 
            // button_replace
            // 
            this.button_replace.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button_replace.Location = new System.Drawing.Point(12, 290);
            this.button_replace.Name = "button_replace";
            this.button_replace.Size = new System.Drawing.Size(131, 23);
            this.button_replace.TabIndex = 10;
            this.button_replace.Text = "Replace";
            this.button_replace.UseVisualStyleBackColor = true;
            this.button_replace.Click += new System.EventHandler(this.click_replace);
            // 
            // button_cancel
            // 
            this.button_cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button_cancel.Location = new System.Drawing.Point(149, 290);
            this.button_cancel.Name = "button_cancel";
            this.button_cancel.Size = new System.Drawing.Size(131, 23);
            this.button_cancel.TabIndex = 11;
            this.button_cancel.Text = "Close";
            this.button_cancel.UseVisualStyleBackColor = true;
            this.button_cancel.Click += new System.EventHandler(this.click_close);
            // 
            // ReplaceWindow
            // 
            this.AcceptButton = this.button_replace;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.button_cancel;
            this.ClientSize = new System.Drawing.Size(292, 325);
            this.ControlBox = false;
            this.Controls.Add(this.button_cancel);
            this.Controls.Add(this.button_replace);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.radioButton_recalculate);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.radioButton_replace);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(308, 364);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(308, 364);
            this.Name = "ReplaceWindow";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " Logic Replace";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_operand)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TextBox textBox_field;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox textBox_item;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox textBox_list;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.RadioButton radioButton_replace;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.TextBox textBox_newValue;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox textBox_oldValue;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.RadioButton radioButton_recalculate;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.NumericUpDown numericUpDown_operand;
		private System.Windows.Forms.ComboBox comboBox_operation;
		private System.Windows.Forms.Button button_replace;
		private System.Windows.Forms.Button button_cancel;
	}
}