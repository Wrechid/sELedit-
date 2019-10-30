using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sELedit
{
	public partial class DebugWindow : Form
	{
		public DebugWindow(string Title, string Message)
		{
			InitializeComponent();
			this.Text = Title;
			this.message.Text = Message;
			this.message.SelectionStart = 0;
			this.message.SelectionLength = 0;
			this.Show();
		}
	}
}
