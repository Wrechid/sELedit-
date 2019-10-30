
using System;
using System.Globalization;

namespace sELedit
{
    class AUTOHP_ESSENCE
    {
        public static string GetProps(int pos_item)
        {
            string line = "";
            try
            {
                for (int k = 0; k < MainWindow.eLC.Lists[114].elementFields.Length; k++)
                {
                    if (MainWindow.eLC.Lists[114].elementFields[k] == "total_hp")
                    {
                        string total_hp = MainWindow.eLC.GetValue(114, pos_item, k);
                        if (total_hp != "0")
                        {
                            line += "\n" + String.Format(Extensions.GetLocalization(7053), total_hp, total_hp);
                        }
                        break;
                    }
                }
                for (int k = 0; k < MainWindow.eLC.Lists[114].elementFields.Length; k++)
                {
                    if (MainWindow.eLC.Lists[114].elementFields[k] == "trigger_amount")
                    {
                        string trigger_amount = MainWindow.eLC.GetValue(114, pos_item, k);
                        if (trigger_amount != "0")
                        {
                            line += "\n" + String.Format(Extensions.GetLocalization(7054), Convert.ToSingle(trigger_amount).ToString("P0"));
                        }
                        break;
                    }
                }
                for (int k = 0; k < MainWindow.eLC.Lists[114].elementFields.Length; k++)
                {
                    if (MainWindow.eLC.Lists[114].elementFields[k] == "cool_time")
                    {
                        string cool_time = MainWindow.eLC.GetValue(114, pos_item, k);
                        if (cool_time != "0")
                        {
                            line += "\n" + String.Format(Extensions.GetLocalization(7057), Convert.ToSingle(cool_time) / 1000);
                        }
                        break;
                    }
                }
                for (int k = 0; k < MainWindow.eLC.Lists[114].elementFields.Length; k++)
                {
                    if (MainWindow.eLC.Lists[114].elementFields[k] == "price")
                    {
                        string price = MainWindow.eLC.GetValue(114, pos_item, k);
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

