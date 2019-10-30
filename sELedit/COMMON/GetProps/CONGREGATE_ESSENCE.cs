
using System;
using System.Globalization;

namespace sELedit
{
    class CONGREGATE_ESSENCE
    {
        public static string GetProps(int pos_item)
        {
            string line = "";
            try
            {
                for (int k = 0; k < MainWindow.eLC.Lists[141].elementFields.Length; k++)
                {
                    if (MainWindow.eLC.Lists[141].elementFields[k] == "price")
                    {
                        string price = MainWindow.eLC.GetValue(141, pos_item, k);
                        if (price != "0")
                        {
                            line += "\n" + Extensions.GetLocalization(7024) + " " + Convert.ToInt32(price).ToString("N0", CultureInfo.CreateSpecificCulture("zh-CN"));
                        }
                        break;
                    }
                }
                for (int a = 1; a < 9; a++)
                {
                    for (int k = 0; k < MainWindow.eLC.Lists[141].elementFields.Length; k++)
                    {
                        if (MainWindow.eLC.Lists[141].elementFields[k] == "area_" + a + "_id")
                        {
                            string area_id = MainWindow.eLC.GetValue(141, pos_item, k);
                            if (area_id != "0")
                            {
                                if (a == 1)
                                {
                                    line += "\n" + Extensions.GetLocalization(7083);
                                }
                                //line += " " + Extensions.InstanceName(Convert.ToInt32(area_id)).Replace("\r\n", " ");
                            }
                            break;
                        }
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

