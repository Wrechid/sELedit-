
using System;
using System.Globalization;

namespace sELedit
{
    class PET_EGG_ESSENCE
    {
        public static string GetProps(int pos_item)
        {
            string line = "";
            try
            {
                for (int k = 0; k < MainWindow.eLC.Lists[95].elementFields.Length; k++)
                {
                    if (MainWindow.eLC.Lists[95].elementFields[k] == "id_pet")
                    {
                        string id_pet = MainWindow.eLC.GetValue(95, pos_item, k);
                        if (id_pet != "0")
                        {
                            for (int t = 0; t < MainWindow.eLC.Lists[94].elementValues.Length; t++)
                            {
                                if (MainWindow.eLC.GetValue(94, t, 0) == id_pet)
                                {
                                    string id_type = "0";
                                    for (int a = 0; a < MainWindow.eLC.Lists[94].elementFields.Length; a++)
                                    {
                                        if (MainWindow.eLC.Lists[94].elementFields[a] == "id_type")
                                        {
                                            id_type = MainWindow.eLC.GetValue(94, t, a);
                                            break;
                                        }
                                    }
                                    for (int a = 0; a < MainWindow.eLC.Lists[94].elementFields.Length; a++)
                                    {
                                        if (MainWindow.eLC.Lists[94].elementFields[a] == "food_mask")
                                        {
                                            line += Extensions.DecodingFoodMask(MainWindow.eLC.GetValue(94, t, a));
                                            break;
                                        }
                                    }
                                    for (int a = 0; a < MainWindow.eLC.Lists[95].elementFields.Length; a++)
                                    {
                                        if (MainWindow.eLC.Lists[95].elementFields[a] == "level")
                                        {
                                            line += "\n" + String.Format(Extensions.GetLocalization(7048), MainWindow.eLC.GetValue(95, pos_item, a));
                                            break;
                                        }
                                    }
                                    if (id_type == "8781" || id_type == "8783")
                                    {
                                        for (int a = 0; a < MainWindow.eLC.Lists[94].elementFields.Length; a++)
                                        {
                                            if (MainWindow.eLC.Lists[94].elementFields[a] == "speed_a")
                                            {
                                                line += "\n" + String.Format(Extensions.GetLocalization(7049), Convert.ToSingle(MainWindow.eLC.GetValue(94, t, a)).ToString("F2", CultureInfo.CreateSpecificCulture("en-US")));
                                                break;
                                            }
                                        }
                                    }
                                    for (int a = 0; a < MainWindow.eLC.Lists[94].elementFields.Length; a++)
                                    {
                                        if (MainWindow.eLC.Lists[94].elementFields[a] == "level_require")
                                        {
                                            string level_require = MainWindow.eLC.GetValue(94, t, a);
                                            if (level_require != "0")
                                            {
                                                line += "\n" + String.Format(Extensions.GetLocalization(7018), level_require);
                                            }
                                            break;
                                        }
                                    }
                                    break;
                                }
                            }
                        }
                        break;
                    }
                }
                for (int k = 0; k < MainWindow.eLC.Lists[95].elementFields.Length; k++)
                {
                    if (MainWindow.eLC.Lists[95].elementFields[k] == "price")
                    {
                        string price = MainWindow.eLC.GetValue(95, pos_item, k);
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

