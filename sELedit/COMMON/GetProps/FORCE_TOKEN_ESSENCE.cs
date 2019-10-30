
using System;
using System.Globalization;

namespace sELedit
{
    class FORCE_TOKEN_ESSENCE
    {
        public static string GetProps(int pos_item)
        {
            string line = "";
            try
            {
                for (int k = 0; k < MainWindow.eLC.Lists[151].elementFields.Length; k++)
                {
                    if (MainWindow.eLC.Lists[151].elementFields[k] == "require_force")
                    {
                        string id_sub_type = MainWindow.eLC.GetValue(151, pos_item, k);
                        for (int t = 0; t < MainWindow.eLC.Lists[150].elementValues.Length; t++)
                        {
                            if (MainWindow.eLC.GetValue(150, t, 0) == id_sub_type)
                            {
                                for (int a = 0; a < MainWindow.eLC.Lists[150].elementFields.Length; a++)
                                {
                                    if (MainWindow.eLC.Lists[150].elementFields[a] == "Name")
                                    {
                                        line += "\n" + String.Format(Extensions.GetLocalization(7095), MainWindow.eLC.GetValue(150, t, a));
                                        break;
                                    }
                                }
                                break;
                            }
                        }
                        break;
                    }
                }
                for (int k = 0; k < MainWindow.eLC.Lists[151].elementFields.Length; k++)
                {
                    if (MainWindow.eLC.Lists[151].elementFields[k] == "reputation_add")
                    {
                        string reputation_add = MainWindow.eLC.GetValue(151, pos_item, k);
                        line += "\n" + String.Format(Extensions.GetLocalization(7096), reputation_add, reputation_add);
                        break;
                    }
                }
                for (int k = 0; k < MainWindow.eLC.Lists[151].elementFields.Length; k++)
                {
                    if (MainWindow.eLC.Lists[151].elementFields[k] == "reputation_increase_ratio")
                    {
                        line += "\n" + String.Format(Extensions.GetLocalization(7097), MainWindow.eLC.GetValue(151, pos_item, k));
                        break;
                    }
                }
                for (int k = 0; k < MainWindow.eLC.Lists[151].elementFields.Length; k++)
                {
                    if (MainWindow.eLC.Lists[151].elementFields[k] == "price")
                    {
                        string price = MainWindow.eLC.GetValue(151, pos_item, k);
                        if (price != "0")
                        {
                            line += "\n" + Extensions.GetLocalization(7024) + " " + Convert.ToInt32(price).ToString("N0", CultureInfo.CreateSpecificCulture("zh-CN"));
                        }
                        break;
                    }
                }
            }
            catch
            {
                line = "";
            }
            return line;
        }
	}
}

