
using System;
using System.Globalization;

namespace sELedit
{
    class INC_SKILL_ABILITY_ESSENCE
    {
        public static string GetProps(int pos_item)
        {
            string line = "";
            try
            {
                for (int k = 0; k < MainWindow.eLC.Lists[130].elementFields.Length; k++)
                {
                    if (MainWindow.eLC.Lists[130].elementFields[k] == "level_required")
                    {
                        line += "\n" + String.Format(Extensions.GetLocalization(7087), MainWindow.eLC.GetValue(130, pos_item, k));
                        break;
                    }
                }
                for (int k = 0; k < MainWindow.eLC.Lists[130].elementFields.Length; k++)
                {
                    if (MainWindow.eLC.Lists[130].elementFields[k] == "inc_ratio")
                    {
                        line += "\n" + String.Format(Extensions.GetLocalization(7088), Convert.ToSingle(MainWindow.eLC.GetValue(130, pos_item, k)).ToString("P0"));
                        break;
                    }
                }
                for (int k = 0; k < MainWindow.eLC.Lists[130].elementFields.Length; k++)
                {
                    if (MainWindow.eLC.Lists[130].elementFields[k] == "price")
                    {
                        string price = MainWindow.eLC.GetValue(130, pos_item, k);
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

