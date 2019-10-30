
using System;
using System.Globalization;

namespace sELedit
{
    class FLYSWORD_ESSENCE
    {
        public static string GetProps(int pos_item)
        {
            string line = "";
            try
            {
                string speed_increase_min = "0";
                string speed_rush_increase_min = "0";
                string time_max_min = "0";
                string time_max_max = "0";
                for (int k = 0; k < MainWindow.eLC.Lists[22].elementFields.Length; k++)
                {
                    if (MainWindow.eLC.Lists[22].elementFields[k] == "level")
                    {
                        line += "\n" + String.Format(Extensions.GetLocalization(7000), MainWindow.eLC.GetValue(22, pos_item, k));
                        break;
                    }
                }
                for (int k = 0; k < MainWindow.eLC.Lists[22].elementFields.Length; k++)
                {
                    if (MainWindow.eLC.Lists[22].elementFields[k] == "max_refine_lvl")
                    {
                        string max_refine_lvl = MainWindow.eLC.GetValue(22, pos_item, k);
                        if (max_refine_lvl != "0")
                        {
                            line += "\n" + String.Format(Extensions.GetLocalization(7036), 0, max_refine_lvl);
                        }
                        else
                        {
                            line += "\n" + Extensions.GetLocalization(7037);
                        }
                        break;
                    }
                }
                for (int k = 0; k < MainWindow.eLC.Lists[22].elementFields.Length; k++)
                {
                    if (MainWindow.eLC.Lists[22].elementFields[k] == "speed_increase_min")
                    {
                        speed_increase_min = MainWindow.eLC.GetValue(22, pos_item, k);
                        break;
                    }
                }
                for (int k = 0; k < MainWindow.eLC.Lists[22].elementFields.Length; k++)
                {
                    if (MainWindow.eLC.Lists[22].elementFields[k] == "speed_rush_increase_min")
                    {
                        speed_rush_increase_min = MainWindow.eLC.GetValue(22, pos_item, k);
                        break;
                    }
                }
                for (int k = 0; k < MainWindow.eLC.Lists[22].elementFields.Length; k++)
                {
                    if (MainWindow.eLC.Lists[22].elementFields[k] == "time_max_min")
                    {
                        time_max_min = MainWindow.eLC.GetValue(22, pos_item, k);
                        break;
                    }
                }
                for (int k = 0; k < MainWindow.eLC.Lists[22].elementFields.Length; k++)
                {
                    if (MainWindow.eLC.Lists[22].elementFields[k] == "time_max_max")
                    {
                        time_max_max = MainWindow.eLC.GetValue(22, pos_item, k);
                        break;
                    }
                }
                if (speed_increase_min != "0")
                {
                    line += "\n" + String.Format(Extensions.GetLocalization(7038), "+" + Convert.ToSingle(speed_increase_min).ToString("F2", CultureInfo.CreateSpecificCulture("en-US")));
                }
                if (speed_rush_increase_min != "0")
                {
                    line += "\n" + String.Format(Extensions.GetLocalization(7039), "+" + Convert.ToSingle(speed_rush_increase_min).ToString("F2", CultureInfo.CreateSpecificCulture("en-US")));
                }
                if (time_max_max != "0")
                {
                    line += "\n" + String.Format(Extensions.GetLocalization(7040), Convert.ToSingle(time_max_min) / 2, Convert.ToSingle(time_max_max) / 1);
                }
                for (int k = 0; k < MainWindow.eLC.Lists[22].elementFields.Length; k++)
                {
                    if (MainWindow.eLC.Lists[22].elementFields[k] == "character_combo_id")
                    {
                        line += Extensions.DecodingCharacterComboId(MainWindow.eLC.GetValue(22, pos_item, k));
                        break;
                    }
                }
                for (int k = 0; k < MainWindow.eLC.Lists[22].elementFields.Length; k++)
                {
                    if (MainWindow.eLC.Lists[22].elementFields[k] == "require_player_level_min")
                    {
                        string require_player_level_min = MainWindow.eLC.GetValue(22, pos_item, k);
                        if (require_player_level_min != "0")
                        {
                            line += "\n" + String.Format(Extensions.GetLocalization(7018), require_player_level_min);
                        }
                        break;
                    }
                }
                for (int k = 0; k < MainWindow.eLC.Lists[22].elementFields.Length; k++)
                {
                    if (MainWindow.eLC.Lists[22].elementFields[k] == "price")
                    {
                        string price = MainWindow.eLC.GetValue(22, pos_item, k);
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

