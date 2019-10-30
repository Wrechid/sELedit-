namespace sELedit
{
	partial class DebugWindow
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
			this.message = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// message
			// 
			this.message.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.message.Font = new System.Drawing.Font("Lucida Console", 8.25F);
			this.message.Location = new System.Drawing.Point(0, 0);
			this.message.Multiline = true;
			this.message.Name = "message";
			this.message.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.message.Size = new System.Drawing.Size(320, 478);
			this.message.TabIndex = 0;
			this.message.WordWrap = false;
			// 
			// DebugWindow
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(320, 478);
			this.Controls.Add(this.message);
			this.Name = "DebugWindow";
			this.ShowIcon = false;
			this.Text = "DebugWindow";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox message;
	}
}