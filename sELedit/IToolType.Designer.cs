namespace sELedit
{
    partial class IToolType
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
            this.iconBox = new System.Windows.Forms.PictureBox();
            this.titleText = new System.Windows.Forms.Label();
            this.richTextBox_PreviewText = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.iconBox)).BeginInit();
            this.SuspendLayout();
            // 
            // iconBox
            // 
            this.iconBox.Location = new System.Drawing.Point(6, 8);
            this.iconBox.Name = "iconBox";
            this.iconBox.Size = new System.Drawing.Size(32, 32);
            this.iconBox.TabIndex = 6;
            this.iconBox.TabStop = false;
            // 
            // titleText
            // 
            this.titleText.AutoSize = true;
            this.titleText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.titleText.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleText.ForeColor = System.Drawing.Color.White;
            this.titleText.Location = new System.Drawing.Point(40, 16);
            this.titleText.Name = "titleText";
            this.titleText.Size = new System.Drawing.Size(179, 16);
            this.titleText.TabIndex = 7;
            this.titleText.Text = "AAAAASDASDASDASDASD";
            // 
            // richTextBox_PreviewText
            // 
            this.richTextBox_PreviewText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.richTextBox_PreviewText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox_PreviewText.CausesValidation = false;
            this.richTextBox_PreviewText.Cursor = System.Windows.Forms.Cursors.No;
            this.richTextBox_PreviewText.Location = new System.Drawing.Point(3, 46);
            this.richTextBox_PreviewText.Name = "richTextBox_PreviewText";
            this.richTextBox_PreviewText.ReadOnly = true;
            this.richTextBox_PreviewText.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.richTextBox_PreviewText.Size = new System.Drawing.Size(244, 311);
            this.richTextBox_PreviewText.TabIndex = 42;
            this.richTextBox_PreviewText.TabStop = false;
            this.richTextBox_PreviewText.Text = "";
            this.richTextBox_PreviewText.ContentsResized += new System.Windows.Forms.ContentsResizedEventHandler(this.rtb_ContentsResized);
            // 
            // IToolType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.ClientSize = new System.Drawing.Size(251, 368);
            this.Controls.Add(this.richTextBox_PreviewText);
            this.Controls.Add(this.titleText);
            this.Controls.Add(this.iconBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "IToolType";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "IToolType";
            ((System.ComponentModel.ISupportInitialize)(this.iconBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox iconBox;
        private System.Windows.Forms.Label titleText;
        private System.Windows.Forms.RichTextBox richTextBox_PreviewText;
    }
}