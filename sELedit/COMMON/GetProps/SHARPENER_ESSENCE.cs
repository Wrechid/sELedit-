﻿
using System;
using System.Globalization;

namespace sELedit
{
    class SHARPENER_ESSENCE
    {
        public static string GetProps(int pos_item)
        {
            string line = "";
            try
            {
                for (int k = 0; k < MainWindow.eLC.Lists[135].elementFields.Length; k++)
                {
                    if (MainWindow.eLC.Lists[135].elementFields[k] == "level")
                    {
                        line += "\n" + String.Format(Extensions.GetLocalization(7000), MainWindow.eLC.GetValue(135, pos_item, k));
                        break;
                    }
                }
                for (int k = 0; k < MainWindow.eLC.Lists[135].elementFields.Length; k++)
                {
                    if (MainWindow.eLC.Lists[135].elementFields[k] == "price")
                    {
                        string price = MainWindow.eLC.GetValue(135, pos_item, k);
                        if (price != "0")
                        {
                            line += "\n" + Extensions.GetLocalization(7024) + " " + Convert.ToInt32(price).ToString("N0", CultureInfo.CreateSpecificCulture("zh-CN"));
                        }
                        break;
                    }
                }
                line += "\n";
                for (int k = 1; k < 4; k++)
                {
                    for (int t = 0; t < MainWindow.eLC.Lists[135].elementFields.Length; t++)
                    {
                        if (MainWindow.eLC.Lists[135].elementFields[t] == "addon_" + k)
                        {
                            string addon = MainWindow.eLC.GetValue(135, pos_item, t);
                            if (addon != "0")
                            {
                                line += "\n" + "^4286f4" + EQUIPMENT_ADDON.GetAddon(addon) + "^FFFFFF";
                            }
                            break;
                        }
                    }
                }
                for (int k = 0; k < MainWindow.eLC.Lists[135].elementFields.Length; k++)
                {
                    if (MainWindow.eLC.Lists[135].elementFields[k] == "addon_time")
                    {
                        string price = MainWindow.eLC.GetValue(135, pos_item, k);
                        line += "\n" + Extensions.GetLocalization(7090) + Extensions.ItemPropsSecondsToString(Convert.ToUInt32(MainWindow.eLC.GetValue(135, pos_item, k)));
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

