
using System;
using System.Globalization;

namespace sELedit
{
    class SELL_CERTIFICATE_ESSENCE
    {
        public static string GetProps(int pos_item)
        {
            string line = "";
            try
            {
                for (int k = 0; k < MainWindow.eLC.Lists[123].elementFields.Length; k++)
                {
                    if (MainWindow.eLC.Lists[123].elementFields[k] == "num_sell_item")
                    {
                        line += "\n" + String.Format(Extensions.GetLocalization(7080), MainWindow.eLC.GetValue(123, pos_item, k));
                        break;
                    }
                }
                for (int k = 0; k < MainWindow.eLC.Lists[123].elementFields.Length; k++)
                {
                    if (MainWindow.eLC.Lists[123].elementFields[k] == "num_buy_item")
                    {
                        line += "\n" + String.Format(Extensions.GetLocalization(7081), MainWindow.eLC.GetValue(123, pos_item, k));
                        break;
                    }
                }
                for (int k = 0; k < MainWindow.eLC.Lists[123].elementFields.Length; k++)
                {
                    if (MainWindow.eLC.Lists[123].elementFields[k] == "max_name_length")
                    {
                        line += "\n" + String.Format(Extensions.GetLocalization(7082), MainWindow.eLC.GetValue(123, pos_item, k));
                        break;
                    }
                }
                for (int k = 0; k < MainWindow.eLC.Lists[123].elementFields.Length; k++)
                {
                    if (MainWindow.eLC.Lists[123].elementFields[k] == "price")
                    {
                        string price = MainWindow.eLC.GetValue(123, pos_item, k);
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

