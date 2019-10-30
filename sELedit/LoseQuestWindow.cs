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
	public partial class LoseQuestWindow : Form
	{
		public LoseQuestWindow()
		{
			InitializeComponent();
		}

		private void select_quest(object sender, EventArgs e)
		{
			if (((ListBox)sender).SelectedIndex > -1 && !((ListBox)sender).SelectedItem.ToString().StartsWith("+"))
			{
				webBrowser.Url = new Uri("http://www.pwdatabase.com/pwi/quest/" + ((ListBox)sender).SelectedItem.ToString());
			}
		}
	}
}
