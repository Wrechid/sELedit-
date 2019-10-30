﻿
using System;
using System.Globalization;

namespace sELedit
{
    class DAMAGERUNE_ESSENCE
    {
        public static string GetProps(int pos_item)
        {
            string line = "";
            try
            {
                string damage_type = "-1";
                string require_weapon_level_min = "0";
                string require_weapon_level_max = "0";
                string damage_increased = "0";
                for (int k = 0; k < MainWindow.eLC.Lists[17].elementFields.Length; k++)
                {
                    if (MainWindow.eLC.Lists[17].elementFields[k] == "damage_type")
                    {
                        damage_type = MainWindow.eLC.GetValue(17, pos_item, k);
                        break;
                    }
                }
                for (int k = 0; k < MainWindow.eLC.Lists[17].elementFields.Length; k++)
                {
                    if (MainWindow.eLC.Lists[17].elementFields[k] == "require_weapon_level_min")
                    {
                        require_weapon_level_min = MainWindow.eLC.GetValue(17, pos_item, k);
                        break;
                    }
                }
                for (int k = 0; k < MainWindow.eLC.Lists[17].elementFields.Length; k++)
                {
                    if (MainWindow.eLC.Lists[17].elementFields[k] == "require_weapon_level_max")
                    {
                        require_weapon_level_max = MainWindow.eLC.GetValue(17, pos_item, k);
                        break;
                    }
                }
                for (int k = 0; k < MainWindow.eLC.Lists[17].elementFields.Length; k++)
                {
                    if (MainWindow.eLC.Lists[17].elementFields[k] == "damage_increased")
                    {
                        damage_increased = MainWindow.eLC.GetValue(17, pos_item, k);
                        break;
                    }
                }
                if (require_weapon_level_min != "0" || require_weapon_level_max != "0")
                {
                    line += "\n" + Extensions.GetLocalization(7031) + String.Format(Extensions.GetLocalization(7032), require_weapon_level_min, require_weapon_level_max);
                }
                if (damage_increased != "0" && damage_type == "0")
                {
                    line += "\n" + Extensions.GetLocalization(7025) + Extensions.GetLocalization(7004) + " +" + damage_increased;
                }
                if (damage_increased != "0" && damage_type == "1")
                {
                    line += "\n" + Extensions.GetLocalization(7025) + Extensions.GetLocalization(7005) + " +" + damage_increased;
                }
                for (int k = 0; k < MainWindow.eLC.Lists[17].elementFields.Length; k++)
                {
                    if (MainWindow.eLC.Lists[17].elementFields[k] == "price")
                    {
                        string price = MainWindow.eLC.GetValue(17, pos_item, k);
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

