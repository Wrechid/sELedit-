﻿
using System;
using System.Globalization;

namespace sELedit
{
    class FIREWORKS2_ESSENCE
    {
        public static string GetProps(int pos_item)
        {
            string line = "";
            try
            {
                for (int k = 0; k < MainWindow.eLC.Lists[212].elementFields.Length; k++)
                {
                    if (MainWindow.eLC.Lists[212].elementFields[k] == "price")
                    {
                        string price = MainWindow.eLC.GetValue(212, pos_item, k);
                        if (price != "0")
                        {
                            line += "\n" + Extensions.GetLocalization(7024) + " " + Convert.ToInt32(price).ToString("N0", CultureInfo.CreateSpecificCulture("zh-CN"));
                        }
                        break;
                    }
                }
                for (int k = 0; k < MainWindow.eLC.Lists[212].elementFields.Length; k++)
                {
                    if (MainWindow.eLC.Lists[212].elementFields[k] == "level")
                    {
                        string level = MainWindow.eLC.GetValue(212, pos_item, k);
                        line += "\n";
                        for (int a = 0; a < Convert.ToInt32(level); a++)
                        {
                            line += Extensions.GetLocalization(7046);
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

