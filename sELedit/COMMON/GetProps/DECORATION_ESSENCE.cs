﻿
using System;
using System.Globalization;

namespace sELedit
{
    class DECORATION_ESSENCE
    {
        public static string GetProps(int pos_item)
        {
            string line = "";
            try
            {
                for (int k = 0; k < MainWindow.eLC.Lists[9].elementFields.Length; k++)
                {
                    if (MainWindow.eLC.Lists[9].elementFields[k] == "id_sub_type")
                    {
                        string id_sub_type = MainWindow.eLC.GetValue(9, pos_item, k);
                        for (int t = 0; t < MainWindow.eLC.Lists[8].elementValues.Length; t++)
                        {
                            if (MainWindow.eLC.GetValue(8, t, 0) == id_sub_type)
                            {
                                for (int a = 0; a < MainWindow.eLC.Lists[8].elementFields.Length; a++)
                                {
                                    if (MainWindow.eLC.Lists[8].elementFields[a] == "Name")
                                    {
                                        line += "\n" + MainWindow.eLC.GetValue(8, t, a);
                                        break;
                                    }
                                }
                                break;
                            }
                        }
                        break;
                    }
                }
                for (int k = 0; k < MainWindow.eLC.Lists[9].elementFields.Length; k++)
                {
                    if (MainWindow.eLC.Lists[9].elementFields[k] == "level")
                    {
                        line += "\n" + String.Format(Extensions.GetLocalization(7000), MainWindow.eLC.GetValue(9, pos_item, k));
                        break;
                    }
                }
                for (int k = 0; k < MainWindow.eLC.Lists[9].elementFields.Length; k++)
                {
                    if (MainWindow.eLC.Lists[9].elementFields[k] == "armor_enhance_low")
                    {
                        string armor_enhance_low = MainWindow.eLC.GetValue(9, pos_item, k);
                        if (armor_enhance_low != "0")
                        {
                            line += "\n" + Extensions.GetLocalization(7008) + " +" + armor_enhance_low;
                        }
                        break;
                    }
                }
                for (int k = 0; k < MainWindow.eLC.Lists[9].elementFields.Length; k++)
                {
                    if (MainWindow.eLC.Lists[9].elementFields[k] == "damage_low")
                    {
                        string damage_low = MainWindow.eLC.GetValue(9, pos_item, k);
                        if (damage_low != "0")
                        {
                            line += "\n" + Extensions.GetLocalization(7004) + " +" + damage_low;
                        }
                        break;
                    }
                }
                for (int k = 0; k < MainWindow.eLC.Lists[9].elementFields.Length; k++)
                {
                    if (MainWindow.eLC.Lists[9].elementFields[k] == "magic_damage_low")
                    {
                        string magic_damage_low = MainWindow.eLC.GetValue(9, pos_item, k);
                        if (magic_damage_low != "0")
                        {
                            line += "\n" + Extensions.GetLocalization(7005) + " +" + magic_damage_low;
                        }
                        break;
                    }
                }
                for (int k = 0; k < MainWindow.eLC.Lists[9].elementFields.Length; k++)
                {
                    if (MainWindow.eLC.Lists[9].elementFields[k] == "defence_low")
                    {
                        string defence_low = MainWindow.eLC.GetValue(9, pos_item, k);
                        if (defence_low != "0")
                        {
                            line += "\n" + Extensions.GetLocalization(7009) + " +" + defence_low;
                        }
                        string magic_defences_1_low = MainWindow.eLC.GetValue(9, pos_item, k + 2);
                        if (magic_defences_1_low != "0")
                        {
                            line += "\n" + Extensions.GetLocalization(7010) + " +" + magic_defences_1_low;
                        }
                        string magic_defences_2_low = MainWindow.eLC.GetValue(9, pos_item, k + 4);
                        if (magic_defences_2_low != "0")
                        {
                            line += "\n" + Extensions.GetLocalization(7011) + " +" + magic_defences_2_low;
                        }
                        string magic_defences_3_low = MainWindow.eLC.GetValue(9, pos_item, k + 6);
                        if (magic_defences_3_low != "0")
                        {
                            line += "\n" + Extensions.GetLocalization(7012) + " +" + magic_defences_3_low;
                        }
                        string magic_defences_4_low = MainWindow.eLC.GetValue(9, pos_item, k + 8);
                        if (magic_defences_4_low != "0")
                        {
                            line += "\n" + Extensions.GetLocalization(7013) + " +" + magic_defences_4_low;
                        }
                        string magic_defences_5_low = MainWindow.eLC.GetValue(9, pos_item, k + 10);
                        if (magic_defences_5_low != "0")
                        {
                            line += "\n" + Extensions.GetLocalization(7014) + " +" + magic_defences_5_low;
                        }
                        break;
                    }
                }
                for (int k = 0; k < MainWindow.eLC.Lists[9].elementFields.Length; k++)
                {
                    if (MainWindow.eLC.Lists[9].elementFields[k] == "durability_min")
                    {
                        line += "\n" + Extensions.GetLocalization(7015) + " " + MainWindow.eLC.GetValue(9, pos_item, k) + "/" + MainWindow.eLC.GetValue(9, pos_item, k + 1);
                        break;
                    }
                }
                for (int k = 0; k < MainWindow.eLC.Lists[9].elementFields.Length; k++)
                {
                    if (MainWindow.eLC.Lists[9].elementFields[k] == "character_combo_id")
                    {
                        line += Extensions.DecodingCharacterComboId(MainWindow.eLC.GetValue(9, pos_item, k));
                        break;
                    }
                }
                for (int k = 0; k < MainWindow.eLC.Lists[9].elementFields.Length; k++)
                {
                    if (MainWindow.eLC.Lists[9].elementFields[k] == "require_level")
                    {
                        string require_level = MainWindow.eLC.GetValue(9, pos_item, k);
                        if (require_level != "0")
                        {
                            line += "\n" + String.Format(Extensions.GetLocalization(7018), require_level);
                        }
                        break;
                    }
                }
                for (int k = 0; k < MainWindow.eLC.Lists[9].elementFields.Length; k++)
                {
                    if (MainWindow.eLC.Lists[9].elementFields[k] == "require_strength")
                    {
                        string require_strength = MainWindow.eLC.GetValue(9, pos_item, k);
                        if (require_strength != "0")
                        {
                            line += "\n" + String.Format(Extensions.GetLocalization(7019), require_strength);
                        }
                        string require_agility = MainWindow.eLC.GetValue(9, pos_item, k + 1);
                        if (require_agility != "0")
                        {
                            line += "\n" + String.Format(Extensions.GetLocalization(7020), require_agility);
                        }
                        string require_energy = MainWindow.eLC.GetValue(9, pos_item, k + 2);
                        if (require_energy != "0")
                        {
                            line += "\n" + String.Format(Extensions.GetLocalization(7021), require_energy);
                        }
                        string require_tili = MainWindow.eLC.GetValue(9, pos_item, k + 3);
                        if (require_tili != "0")
                        {
                            line += "\n" + String.Format(Extensions.GetLocalization(7022), require_tili);
                        }
                        break;
                    }
                }
                for (int k = 0; k < MainWindow.eLC.Lists[9].elementFields.Length; k++)
                {
                    if (MainWindow.eLC.Lists[9].elementFields[k] == "require_reputation")
                    {
                        string require_reputation = MainWindow.eLC.GetValue(9, pos_item, k);
                        if (require_reputation != "0")
                        {
                            line += "\n" + String.Format(Extensions.GetLocalization(7023), require_reputation);
                        }
                        break;
                    }
                }
                for (int k = 0; k < MainWindow.eLC.Lists[9].elementFields.Length; k++)
                {
                    if (MainWindow.eLC.Lists[9].elementFields[k] == "fixed_props")
                    {
                        if ("0" != MainWindow.eLC.GetValue(9, pos_item, k))
                        {
                            string probability_addon_num0 = "0";
                            for (int t = 0; t < MainWindow.eLC.Lists[9].elementFields.Length; t++)
                            {
                                if (MainWindow.eLC.Lists[9].elementFields[t] == "probability_addon_num0")
                                {
                                    probability_addon_num0 = MainWindow.eLC.GetValue(9, pos_item, t);
                                    break;
                                }
                            }
                            if (probability_addon_num0 != "1")
                            {
                                for (int t = 1; t < 33; t++)
                                {
                                    for (int a = 0; a < MainWindow.eLC.Lists[9].elementFields.Length; a++)
                                    {
                                        if (MainWindow.eLC.Lists[9].elementFields[a] == "addons_" + t + "_id_addon")
                                        {
                                            string id_addon = MainWindow.eLC.GetValue(9, pos_item, a);
                                            if (id_addon != "0")
                                            {
                                                line += "\n" + "^4286f4" + EQUIPMENT_ADDON.GetAddon(id_addon) + "^FFFFFF";
                                            }
                                            break;
                                        }
                                    }
                                }
                            }
                        }
                        break;
                    }
                }
                for (int k = 0; k < MainWindow.eLC.Lists[9].elementFields.Length; k++)
                {
                    if (MainWindow.eLC.Lists[9].elementFields[k] == "price")
                    {
                        string price = MainWindow.eLC.GetValue(9, pos_item, k);
                        if (price != "0")
                        {
                            line += "\n" + Extensions.GetLocalization(7024) + " " + Convert.ToInt32(price).ToString("N0", CultureInfo.CreateSpecificCulture("zh-CN"));
                        }
                        break;
                    }
                }
                bool Suc = false;
                for (int k = 0; k < MainWindow.eLC.Lists[90].elementValues.Length; k++)
                {
                    for (int a = 1; a < 13; a++)
                    {
                        for (int t = 0; t < MainWindow.eLC.Lists[90].elementFields.Length; t++)
                        {
                            if (MainWindow.eLC.Lists[90].elementFields[t] == "equipments_" + a + "_id")
                            {
                                if (Convert.ToInt32(MainWindow.eLC.GetValue(90, k, t)) == Convert.ToInt32(MainWindow.eLC.GetValue(9, pos_item, 0)))
                                {
                                    Suc = true;
                                    string name = "";
                                    string max_equips = "0";
                                    for (int n = 0; n < MainWindow.eLC.Lists[90].elementFields.Length; n++)
                                    {
                                        if (MainWindow.eLC.Lists[90].elementFields[n] == "Name")
                                        {
                                            name = MainWindow.eLC.GetValue(90, k, n);
                                            break;
                                        }
                                    }
                                    for (int n = 0; n < MainWindow.eLC.Lists[90].elementFields.Length; n++)
                                    {
                                        if (MainWindow.eLC.Lists[90].elementFields[n] == "max_equips")
                                        {
                                            max_equips = MainWindow.eLC.GetValue(90, k, n);
                                            break;
                                        }
                                    }
                                    line += "\n\n" + name + " (" + max_equips + ")";
                                    break;
                                }
                                break;
                            }
                        }
                    }
                    if (Suc == true) break;
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

