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
	public partial class ReplaceWindow : Form
	{
		eListCollection eLC;
        private CacheSave database = new CacheSave();
       

        public ReplaceWindow(eListCollection ListCollection)
		{
            database = MainWindow.database;
            eLC = ListCollection;
			InitializeComponent();
            colorTheme();
			comboBox_operation.SelectedIndex = 0;
		}

        private void colorTheme()
        {
            if (database.arrTheme != null)
            {
                comboBox_operation.DrawMode = DrawMode.OwnerDrawFixed;
                comboBox_operation.FlatStyle = FlatStyle.Flat;

                BackColor = Color.FromName(database.arrTheme[0]);

                groupBox1.ForeColor = Color.FromName(database.arrTheme[1]);
                groupBox2.ForeColor = Color.FromName(database.arrTheme[1]);
                groupBox3.ForeColor = Color.FromName(database.arrTheme[1]);

                textBox_field.ForeColor = Color.FromName(database.arrTheme[1]);
                textBox_item.ForeColor = Color.FromName(database.arrTheme[1]);
                textBox_list.ForeColor = Color.FromName(database.arrTheme[1]);
                textBox_newValue.ForeColor = Color.FromName(database.arrTheme[1]);
                textBox_oldValue.ForeColor = Color.FromName(database.arrTheme[1]);

                radioButton_recalculate.ForeColor = Color.FromName(database.arrTheme[1]);
                radioButton_replace.ForeColor = Color.FromName(database.arrTheme[1]);

                textBox_field.BackColor = Color.FromName(database.arrTheme[6]);
                textBox_item.BackColor = Color.FromName(database.arrTheme[6]);
                textBox_list.BackColor = Color.FromName(database.arrTheme[6]);
                textBox_newValue.BackColor = Color.FromName(database.arrTheme[6]);
                textBox_oldValue.BackColor = Color.FromName(database.arrTheme[6]);
                numericUpDown_operand.BackColor = Color.FromName(database.arrTheme[6]);
                numericUpDown_operand.ForeColor = Color.FromName(database.arrTheme[1]);

                comboBox_operation.BackColor = Color.FromName(database.arrTheme[7]);
                
                button_cancel.BackColor = Color.FromName(database.arrTheme[11]);
                button_replace.BackColor = Color.FromName(database.arrTheme[11]);
                button_cancel.ForeColor = Color.FromName(database.arrTheme[1]);
                button_replace.ForeColor = Color.FromName(database.arrTheme[1]);
            }
        }

        private void comboBoxDb_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (database.arrTheme != null)
            {
                try
                {
                    var combo = sender as ComboBox;

                    if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
                    {
                        e.Graphics.FillRectangle(new SolidBrush(Color.FromName(database.arrTheme[8])), e.Bounds);
                        e.Graphics.DrawString(combo.Items[e.Index].ToString(), e.Font, new SolidBrush(Color.FromName(database.arrTheme[10])), new Point(e.Bounds.X, e.Bounds.Y));
                    }
                    else
                    {
                        e.Graphics.FillRectangle(new SolidBrush(Color.FromName(database.arrTheme[7])), e.Bounds);
                        e.Graphics.DrawString(combo.Items[e.Index].ToString(), e.Font, new SolidBrush(Color.FromName(database.arrTheme[9])), new Point(e.Bounds.X, e.Bounds.Y));
                    }
                }
                catch { }
            }
        }

        private void click_replace(object sender, EventArgs ea)
		{
			Cursor = Cursors.AppStarting;

			int replacementCount = 0;
			int l;
			int l_max;
			int e;
			int e_max;
			int v;
			int v_max;
			string oldValue = textBox_oldValue.Text;
			string newValue = textBox_newValue.Text;
			string operation = comboBox_operation.SelectedItem.ToString();
			Decimal operand = numericUpDown_operand.Value;

			if (textBox_list.Text == "*")
			{
				l = 0;
				l_max = eLC.Lists.Length;
			}
			else
			{
				l = Convert.ToInt32(textBox_list.Text);
				l_max = Convert.ToInt32(textBox_list.Text) + 1;
				if (l < 0 || l_max > eLC.Lists.Length)
				{
					MessageBox.Show("List Index Out of Range");
					return;
				}
			}
			for (int lf = l; lf < l_max; lf++)
			{
				if (textBox_item.Text == "*")
				{
					e = 0;
					e_max = eLC.Lists[lf].elementValues.Length;
				}
				else
				{
					e = Convert.ToInt32(textBox_item.Text);
					e_max = Convert.ToInt32(textBox_item.Text) + 1;
					if (e < 0 || e_max > eLC.Lists[lf].elementValues.Length)
					{
						MessageBox.Show("Item Index Out of Range");
						return;
					}
				}
				for (int ef = e; ef < e_max; ef++)
				{
					if (textBox_field.Text == "*")
					{
						v = 0;
						v_max = eLC.Lists[lf].elementValues[ef].Length;
					}
					else
					{
						v = Convert.ToInt32(textBox_field.Text);
						v_max = Convert.ToInt32(textBox_field.Text) + 1;
						if (v < 0 || v_max > eLC.Lists[lf].elementValues[ef].Length)
						{
							MessageBox.Show("Field Index Out of Range");
							return;
						}
					}
					for (int vf = v; vf < v_max; vf++)
					{
						if (radioButton_replace.Checked)
						{
							if (oldValue == "*" || oldValue == eLC.GetValue(lf, ef, vf).Trim(new char[] { Convert.ToChar(0) }))
							{
								eLC.SetValue(lf, ef, vf, newValue);
								replacementCount++;
							}
						}
						if (radioButton_recalculate.Checked)
						{
							string type = eLC.GetType(lf, vf);
							if (type == "int16")
							{
								short op1 = Convert.ToInt16(eLC.GetValue(lf, ef, vf));
								short op2 = Convert.ToInt16(operand);
								string result = "";
								if (operation == "*")
								{
									result = (op1 * op2).ToString();
								}
								if (operation == "/")
								{
									result = (op1 / op2).ToString();
								}
								if (operation == "+")
								{
									result = (op1 + op2).ToString();
								}
								if (operation == "-")
								{
									result = (op1 - op2).ToString();
								}
								eLC.SetValue(lf, ef, vf, result);
								replacementCount++;
							}
							if (type == "int32")
							{
								int op1 = Convert.ToInt32(eLC.GetValue(lf, ef, vf));
								int op2 = Convert.ToInt32(operand);
								string result = "";
								if (operation == "*")
								{
									result = (op1 * op2).ToString();
								}
								if (operation == "/")
								{
									result = (op1 / op2).ToString();
								}
								if (operation == "+")
								{
									result = (op1 + op2).ToString();
								}
								if (operation == "-")
								{
									result = (op1 - op2).ToString();
								}
								eLC.SetValue(lf, ef, vf, result);
								replacementCount++;
							}
							if (type == "int64")
							{
								long op1 = Convert.ToInt64(eLC.GetValue(lf, ef, vf));
								long op2 = Convert.ToInt64(operand);
								string result = "";
								if (operation == "*")
								{
									result = (op1 * op2).ToString();
								}
								if (operation == "/")
								{
									result = (op1 / op2).ToString();
								}
								if (operation == "+")
								{
									result = (op1 + op2).ToString();
								}
								if (operation == "-")
								{
									result = (op1 - op2).ToString();
								}
								eLC.SetValue(lf, ef, vf, result);
								replacementCount++;
							}
							if (type == "float")
							{
								float op1 = Convert.ToSingle(eLC.GetValue(lf, ef, vf));
								float op2 = Convert.ToSingle(operand);
								string result = "";
								if (operation == "*")
								{
									result = (op1 * op2).ToString("F3");
								}
								if (operation == "/")
								{
									result = (op1 / op2).ToString("F3");
								}
								if (operation == "+")
								{
									result = (op1 + op2).ToString("F3");
								}
								if (operation == "-")
								{
									result = (op1 - op2).ToString("F3");
								}
								eLC.SetValue(lf, ef, vf, result);
								replacementCount++;
							}
							if (type == "double")
							{
								double op1 = Convert.ToDouble(eLC.GetValue(lf, ef, vf));
								double op2 = Convert.ToDouble(operand);
								string result = "";
								if (operation == "*")
								{
									result = (op1 * op2).ToString("F3");
								}
								if (operation == "/")
								{
									result = (op1 / op2).ToString("F3");
								}
								if (operation == "+")
								{
									result = (op1 + op2).ToString("F3");
								}
								if (operation == "-")
								{
									result = (op1 - op2).ToString("F3");
								}
								eLC.SetValue(lf, ef, vf, result);
								replacementCount++;
							}
						}
					}
				}
			}

			Cursor = Cursors.Default;

			MessageBox.Show(replacementCount + " Values Replaced");
		}

		private void click_close(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
