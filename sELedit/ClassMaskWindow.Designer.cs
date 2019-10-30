namespace sELedit
{
	partial class ClassMaskWindow
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
			this.checkBox_BM = new System.Windows.Forms.CheckBox();
			this.checkBox_WIZ = new System.Windows.Forms.CheckBox();
			this.checkBox_PSY = new System.Windows.Forms.CheckBox();
			this.checkBox_VEN = new System.Windows.Forms.CheckBox();
			this.checkBox_BAR = new System.Windows.Forms.CheckBox();
			this.checkBox_AS = new System.Windows.Forms.CheckBox();
			this.checkBox_AR = new System.Windows.Forms.CheckBox();
			this.checkBox_CLE = new System.Windows.Forms.CheckBox();
			this.checkBox_SE = new System.Windows.Forms.CheckBox();
			this.checkBox_MY = new System.Windows.Forms.CheckBox();
			this.checkBox_DU = new System.Windows.Forms.CheckBox();
			this.checkBox_ST = new System.Windows.Forms.CheckBox();
			this.numericUpDown_mask = new System.Windows.Forms.NumericUpDown();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown_mask)).BeginInit();
			this.SuspendLayout();
			// 
			// checkBox_BM
			// 
			this.checkBox_BM.AutoSize = true;
			this.checkBox_BM.Location = new System.Drawing.Point(12, 11);
			this.checkBox_BM.Name = "checkBox_BM";
			this.checkBox_BM.Size = new System.Drawing.Size(84, 17);
			this.checkBox_BM.TabIndex = 0;
			this.checkBox_BM.Text = "Blademaster";
			this.checkBox_BM.UseVisualStyleBackColor = true;
			this.checkBox_BM.CheckedChanged += new System.EventHandler(this.change_Bin);
			// 
			// checkBox_WIZ
			// 
			this.checkBox_WIZ.AutoSize = true;
			this.checkBox_WIZ.Location = new System.Drawing.Point(12, 34);
			this.checkBox_WIZ.Name = "checkBox_WIZ";
			this.checkBox_WIZ.Size = new System.Drawing.Size(59, 17);
			this.checkBox_WIZ.TabIndex = 1;
			this.checkBox_WIZ.Text = "Wizard";
			this.checkBox_WIZ.UseVisualStyleBackColor = true;
			this.checkBox_WIZ.CheckedChanged += new System.EventHandler(this.change_Bin);
			// 
			// checkBox_PSY
			// 
			this.checkBox_PSY.AutoSize = true;
			this.checkBox_PSY.Location = new System.Drawing.Point(12, 57);
			this.checkBox_PSY.Name = "checkBox_PSY";
			this.checkBox_PSY.Size = new System.Drawing.Size(63, 17);
			this.checkBox_PSY.TabIndex = 2;
			this.checkBox_PSY.Text = "Psychic";
			this.checkBox_PSY.UseVisualStyleBackColor = true;
			this.checkBox_PSY.CheckedChanged += new System.EventHandler(this.change_Bin);
			// 
			// checkBox_VEN
			// 
			this.checkBox_VEN.AutoSize = true;
			this.checkBox_VEN.Location = new System.Drawing.Point(12, 80);
			this.checkBox_VEN.Name = "checkBox_VEN";
			this.checkBox_VEN.Size = new System.Drawing.Size(86, 17);
			this.checkBox_VEN.TabIndex = 3;
			this.checkBox_VEN.Text = "Venomancer";
			this.checkBox_VEN.UseVisualStyleBackColor = true;
			this.checkBox_VEN.CheckedChanged += new System.EventHandler(this.change_Bin);
			// 
			// checkBox_BAR
			// 
			this.checkBox_BAR.AutoSize = true;
			this.checkBox_BAR.Location = new System.Drawing.Point(12, 103);
			this.checkBox_BAR.Name = "checkBox_BAR";
			this.checkBox_BAR.Size = new System.Drawing.Size(71, 17);
			this.checkBox_BAR.TabIndex = 4;
			this.checkBox_BAR.Text = "Barbarian";
			this.checkBox_BAR.UseVisualStyleBackColor = true;
			this.checkBox_BAR.CheckedChanged += new System.EventHandler(this.change_Bin);
			// 
			// checkBox_AS
			// 
			this.checkBox_AS.AutoSize = true;
			this.checkBox_AS.Location = new System.Drawing.Point(12, 126);
			this.checkBox_AS.Name = "checkBox_AS";
			this.checkBox_AS.Size = new System.Drawing.Size(67, 17);
			this.checkBox_AS.TabIndex = 5;
			this.checkBox_AS.Text = "Assassin";
			this.checkBox_AS.UseVisualStyleBackColor = true;
			this.checkBox_AS.CheckedChanged += new System.EventHandler(this.change_Bin);
			// 
			// checkBox_AR
			// 
			this.checkBox_AR.AutoSize = true;
			this.checkBox_AR.Location = new System.Drawing.Point(12, 149);
			this.checkBox_AR.Name = "checkBox_AR";
			this.checkBox_AR.Size = new System.Drawing.Size(57, 17);
			this.checkBox_AR.TabIndex = 6;
			this.checkBox_AR.Text = "Archer";
			this.checkBox_AR.UseVisualStyleBackColor = true;
			this.checkBox_AR.CheckedChanged += new System.EventHandler(this.change_Bin);
			// 
			// checkBox_CLE
			// 
			this.checkBox_CLE.AutoSize = true;
			this.checkBox_CLE.Location = new System.Drawing.Point(12, 172);
			this.checkBox_CLE.Name = "checkBox_CLE";
			this.checkBox_CLE.Size = new System.Drawing.Size(52, 17);
			this.checkBox_CLE.TabIndex = 7;
			this.checkBox_CLE.Text = "Cleric";
			this.checkBox_CLE.UseVisualStyleBackColor = true;
			this.checkBox_CLE.CheckedChanged += new System.EventHandler(this.change_Bin);
			// 
			// checkBox_SE
			// 
			this.checkBox_SE.AutoSize = true;
			this.checkBox_SE.Location = new System.Drawing.Point(12, 195);
			this.checkBox_SE.Name = "checkBox_SE";
			this.checkBox_SE.Size = new System.Drawing.Size(60, 17);
			this.checkBox_SE.TabIndex = 8;
			this.checkBox_SE.Text = "Seeker";
			this.checkBox_SE.UseVisualStyleBackColor = true;
			this.checkBox_SE.CheckedChanged += new System.EventHandler(this.change_Bin);
			// 
			// checkBox_MY
			// 
			this.checkBox_MY.AutoSize = true;
			this.checkBox_MY.Location = new System.Drawing.Point(12, 218);
			this.checkBox_MY.Name = "checkBox_MY";
			this.checkBox_MY.Size = new System.Drawing.Size(56, 17);
			this.checkBox_MY.TabIndex = 9;
			this.checkBox_MY.Text = "Mystic";
			this.checkBox_MY.UseVisualStyleBackColor = true;
			this.checkBox_MY.CheckedChanged += new System.EventHandler(this.change_Bin);
			// 
			// checkBox_DU
			// 
			this.checkBox_DU.AutoSize = true;
			this.checkBox_DU.Location = new System.Drawing.Point(12, 241);
			this.checkBox_DU.Name = "checkBox_DU";
			this.checkBox_DU.Size = new System.Drawing.Size(77, 17);
			this.checkBox_DU.TabIndex = 10;
			this.checkBox_DU.Text = "Duskblade";
			this.checkBox_DU.UseVisualStyleBackColor = true;
			this.checkBox_DU.CheckedChanged += new System.EventHandler(this.change_Bin);
			// 
			// checkBox_ST
			// 
			this.checkBox_ST.AutoSize = true;
			this.checkBox_ST.Location = new System.Drawing.Point(12, 264);
			this.checkBox_ST.Name = "checkBox_ST";
			this.checkBox_ST.Size = new System.Drawing.Size(85, 17);
			this.checkBox_ST.TabIndex = 11;
			this.checkBox_ST.Text = "Stormbringer";
			this.checkBox_ST.UseVisualStyleBackColor = true;
			this.checkBox_ST.CheckedChanged += new System.EventHandler(this.change_Bin);
			// 
			// numericUpDown_mask
			// 
			this.numericUpDown_mask.Location = new System.Drawing.Point(12, 288);
			this.numericUpDown_mask.Maximum = new decimal(new int[] {
            4095,
            0,
            0,
            0});
			this.numericUpDown_mask.Name = "numericUpDown_mask";
			this.numericUpDown_mask.Size = new System.Drawing.Size(84, 20);
			this.numericUpDown_mask.TabIndex = 12;
			this.numericUpDown_mask.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.numericUpDown_mask.ValueChanged += new System.EventHandler(this.change_Dec);
			// 
			// ClassMaskWindow
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(124, 320);
			this.Controls.Add(this.numericUpDown_mask);
			this.Controls.Add(this.checkBox_ST);
			this.Controls.Add(this.checkBox_DU);
			this.Controls.Add(this.checkBox_MY);
			this.Controls.Add(this.checkBox_SE);
			this.Controls.Add(this.checkBox_CLE);
			this.Controls.Add(this.checkBox_AR);
			this.Controls.Add(this.checkBox_AS);
			this.Controls.Add(this.checkBox_BAR);
			this.Controls.Add(this.checkBox_VEN);
			this.Controls.Add(this.checkBox_PSY);
			this.Controls.Add(this.checkBox_WIZ);
			this.Controls.Add(this.checkBox_BM);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(140, 359);
			this.Name = "ClassMaskWindow";
			this.ShowIcon = false;
			this.Text = "Class Mask";
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown_mask)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.CheckBox checkBox_BM;
		private System.Windows.Forms.CheckBox checkBox_WIZ;
		private System.Windows.Forms.CheckBox checkBox_PSY;
		private System.Windows.Forms.CheckBox checkBox_VEN;
		private System.Windows.Forms.CheckBox checkBox_BAR;
		private System.Windows.Forms.CheckBox checkBox_AS;
		private System.Windows.Forms.CheckBox checkBox_AR;
		private System.Windows.Forms.CheckBox checkBox_CLE;
		private System.Windows.Forms.CheckBox checkBox_SE;
		private System.Windows.Forms.CheckBox checkBox_MY;
		private System.Windows.Forms.CheckBox checkBox_DU;
		private System.Windows.Forms.CheckBox checkBox_ST;
		private System.Windows.Forms.NumericUpDown numericUpDown_mask;
	}
}