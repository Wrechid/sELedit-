namespace sELedit
{
	partial class LoseQuestWindow
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
			this.listBox_Receive = new System.Windows.Forms.ListBox();
			this.listBox_Activate = new System.Windows.Forms.ListBox();
			this.webBrowser = new System.Windows.Forms.WebBrowser();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
			this.label1.Location = new System.Drawing.Point(-3, 3);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(58, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Receive:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
			this.label2.Location = new System.Drawing.Point(-3, 318);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(58, 13);
			this.label2.TabIndex = 1;
			this.label2.Text = "Activate:";
			// 
			// listBox_Receive
			// 
			this.listBox_Receive.FormattingEnabled = true;
			this.listBox_Receive.Location = new System.Drawing.Point(0, 19);
			this.listBox_Receive.Name = "listBox_Receive";
			this.listBox_Receive.Size = new System.Drawing.Size(200, 277);
			this.listBox_Receive.TabIndex = 2;
			this.listBox_Receive.SelectedIndexChanged += new System.EventHandler(this.select_quest);
			// 
			// listBox_Activate
			// 
			this.listBox_Activate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.listBox_Activate.FormattingEnabled = true;
			this.listBox_Activate.Location = new System.Drawing.Point(0, 334);
			this.listBox_Activate.Name = "listBox_Activate";
			this.listBox_Activate.Size = new System.Drawing.Size(200, 277);
			this.listBox_Activate.TabIndex = 3;
			this.listBox_Activate.SelectedIndexChanged += new System.EventHandler(this.select_quest);
			// 
			// webBrowser
			// 
			this.webBrowser.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.webBrowser.Location = new System.Drawing.Point(206, 3);
			this.webBrowser.MinimumSize = new System.Drawing.Size(20, 20);
			this.webBrowser.Name = "webBrowser";
			this.webBrowser.Size = new System.Drawing.Size(785, 608);
			this.webBrowser.TabIndex = 4;
			this.webBrowser.Url = new System.Uri("http://www.pwdatabase.com/pwi/quests", System.UriKind.Absolute);
			// 
			// LoseQuestWindow
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(992, 613);
			this.Controls.Add(this.webBrowser);
			this.Controls.Add(this.listBox_Activate);
			this.Controls.Add(this.listBox_Receive);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(1000, 640);
			this.Name = "LoseQuestWindow";
			this.ShowIcon = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Lost Quests (1.4.3 -> 1.3.6)";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		public System.Windows.Forms.ListBox listBox_Receive;
		public System.Windows.Forms.ListBox listBox_Activate;
		private System.Windows.Forms.WebBrowser webBrowser;
	}
}