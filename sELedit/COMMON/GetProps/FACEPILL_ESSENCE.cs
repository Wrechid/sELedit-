
using System;
using System.Globalization;

namespace sELedit
{
    class FACEPILL_ESSENCE
    {
        public static string GetProps(int pos_item)
        {
            string line = "";
            try
            {
                for (int k = 0; k < MainWindow.eLC.Lists[89].elementFields.Length; k++)
                {
                    if (MainWindow.eLC.Lists[89].elementFields[k] == "duration")
                    {
                        string duration = MainWindow.eLC.GetValue(89, pos_item, k);
                        line += "\n" + String.Format(Extensions.GetLocalization(7047), duration);
                        break;
                    }
                }
                for (int k = 0; k < MainWindow.eLC.Lists[89].elementFields.Length; k++)
                {
                    if (MainWindow.eLC.Lists[89].elementFields[k] == "character_combo_id")
                    {
                        line += Extensions.DecodingCharacterComboId(MainWindow.eLC.GetValue(89, pos_item, k));
                        break;
                    }
                }
                for (int k = 0; k < MainWindow.eLC.Lists[89].elementFields.Length; k++)
                {
                    if (MainWindow.eLC.Lists[89].elementFields[k] == "price")
                    {
                        string price = MainWindow.eLC.GetValue(89, pos_item, k);
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

