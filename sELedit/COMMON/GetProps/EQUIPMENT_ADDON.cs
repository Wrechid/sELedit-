using System;
using System.Globalization;

namespace sELedit
{
    class EQUIPMENT_ADDON
    {
        public static string GetAddon(string id)
        {
            string line = "";
            try
            {
                string name = "";
                string num_params = "0";
                string param1 = "0";
                string param2 = "0";
                string param3 = "0";
                //for (int k = 0; k < MainWindow.eLC.Lists[0].elementValues.Count; k++)
                //{
                int key = int.Parse(id);
                if (!MainWindow.eLC.addonIndex.ContainsKey(key))
                {
                    return "";
                }
                int k = MainWindow.eLC.addonIndex[key];
                    if (MainWindow.eLC.GetValue(0, k, 0) == id)
                    {
                        for (int t = 0; t < MainWindow.eLC.Lists[0].elementFields.Length; t++)
                        {
                            if (MainWindow.eLC.Lists[0].elementFields[t] == "Name")
                            {
                                name = MainWindow.eLC.GetValue(0, k, t);
                                break;
                            }
                        }
                        for (int t = 0; t < MainWindow.eLC.Lists[0].elementFields.Length; t++)
                        {
                            if (MainWindow.eLC.Lists[0].elementFields[t] == "num_params")
                            {
                                num_params = MainWindow.eLC.GetValue(0, k, t);
                                break;
                            }
                        }
                        for (int t = 0; t < MainWindow.eLC.Lists[0].elementFields.Length; t++)
                        {
                            if (MainWindow.eLC.Lists[0].elementFields[t] == "param1")
                            {
                                param1 = MainWindow.eLC.GetValue(0, k, t);
                                param2 = MainWindow.eLC.GetValue(0, k, t + 1);
                                param3 = MainWindow.eLC.GetValue(0, k, t + 2);
                                break;
                            }
                        }
                        try
                        {
                            int addon_type = Convert.ToInt32(MainWindow.database.addonslist[id].ToString());
                            switch (addon_type)
                            {
                                case 0:
                                    line = Extensions.GetLocalization(7202) + " +" + param1;
                                    if (Convert.ToInt32(num_params) > 1 && param1 != param2) line += "~" + param2;
                                    break;
                                case 1:
                                    line = Extensions.GetLocalization(7203) + " +" + param1;
                                    if (Convert.ToInt32(num_params) > 1 && param1 != param2) line += "~" + param2;
                                    break;
                                case 2:
                                    line = Extensions.GetLocalization(7202) + " +" + BitConverter.ToSingle(BitConverter.GetBytes(Convert.ToInt32(param1)), 0).ToString("P0");
                                    if (Convert.ToInt32(num_params) > 1 && param1 != param2) line += "~" + BitConverter.ToSingle(BitConverter.GetBytes(Convert.ToInt32(param2)), 0).ToString("P0");
                                    break;
                                case 3:
                                    line = Extensions.GetLocalization(7204) + " +" + param1;
                                    if (Convert.ToInt32(num_params) > 1 && param1 != param2) line += "~" + param2;
                                    break;
                                case 4:
                                    line = Extensions.GetLocalization(7205) + " +" + param1;
                                    if (Convert.ToInt32(num_params) > 1 && param1 != param2) line += "~" + param2;
                                    break;
                                case 5:
                                    line = Extensions.GetLocalization(7204) + " +" + BitConverter.ToSingle(BitConverter.GetBytes(Convert.ToInt32(param1)), 0).ToString("P0");
                                    if (Convert.ToInt32(num_params) > 1 && param1 != param2) line += "~" + BitConverter.ToSingle(BitConverter.GetBytes(Convert.ToInt32(param2)), 0).ToString("P0");
                                    break;
                                case 6:
                                    line = Extensions.GetLocalization(7206) + " +" + param1 + "\n" + Extensions.GetLocalization(7202) + " -" + param2;
                                    break;
                                case 7:
                                    line = Extensions.GetLocalization(7202) + " +" + param1 + "\n" + Extensions.GetLocalization(7206) + " -" + param2;
                                    break;
                                case 8:
                                    line = Extensions.GetLocalization(7204) + " +" + param1 + "\n" + Extensions.GetLocalization(7207) + " -" + param2;;
                                    break;
                                case 9:
                                    line = String.Format(Extensions.GetLocalization(7214), "-" + BitConverter.ToSingle(BitConverter.GetBytes(Convert.ToInt32(param1)), 0).ToString("F2", CultureInfo.CreateSpecificCulture("en-US")));
                                    break;
                                case 10:
                                    line = Extensions.GetLocalization(7213) + " +" + BitConverter.ToSingle(BitConverter.GetBytes(Convert.ToInt32(param1)), 0).ToString("F2", CultureInfo.CreateSpecificCulture("en-US"));
                                    break;
                                case 11:
                                    line = Extensions.GetLocalization(7215) + " -" + BitConverter.ToSingle(BitConverter.GetBytes(Convert.ToInt32(param1)), 0).ToString("P0");
                                    break;
                                case 12:
                                    line = Extensions.GetLocalization(7206) + " +" + param1;
                                    if (Convert.ToInt32(num_params) > 1 && param1 != param2) line += "~" + param2;
                                    break;
                                case 13:
                                    line = Extensions.GetLocalization(7237) + " +" + BitConverter.ToSingle(BitConverter.GetBytes(Convert.ToInt32(param1)), 0).ToString("P0");
                                    if (Convert.ToInt32(num_params) > 1 && param1 != param2) line += "~" + BitConverter.ToSingle(BitConverter.GetBytes(Convert.ToInt32(param2)), 0).ToString("P0");
                                    break;
                                case 14:
                                    line = Extensions.GetLocalization(7207) + " +" + param1;
                                    if (Convert.ToInt32(num_params) > 1 && param1 != param2) line += "~" + param2;
                                    break;
                                case 15:
                                    line = Extensions.GetLocalization(7208) + " +" + param1;
                                    if (Convert.ToInt32(num_params) > 1 && param1 != param2) line += "~" + param2;
                                    break;
                                case 16:
                                    line = Extensions.GetLocalization(7208) + " +" + BitConverter.ToSingle(BitConverter.GetBytes(Convert.ToInt32(param1)), 0).ToString("P0");
                                    if (Convert.ToInt32(num_params) > 1 && param1 != param2) line += "~" + BitConverter.ToSingle(BitConverter.GetBytes(Convert.ToInt32(param2)), 0).ToString("P0");
                                    break;
                                case 17:
                                    line = Extensions.GetLocalization(7209) + " +" + param1;
                                    if (Convert.ToInt32(num_params) > 1 && param1 != param2) line += "~" + param2;
                                    break;
                                case 18:
                                    line = Extensions.GetLocalization(7209) + " +" + BitConverter.ToSingle(BitConverter.GetBytes(Convert.ToInt32(param1)), 0).ToString("P0");
                                    if (Convert.ToInt32(num_params) > 1 && param1 != param2) line += "~" + BitConverter.ToSingle(BitConverter.GetBytes(Convert.ToInt32(param2)), 0).ToString("P0");
                                    break;
                                case 19:
                                    line = Extensions.GetLocalization(7210) + " +" + param1;
                                    if (Convert.ToInt32(num_params) > 1 && param1 != param2) line += "~" + param2;
                                    break;
                                case 20:
                                    line = Extensions.GetLocalization(7210) + " +" + BitConverter.ToSingle(BitConverter.GetBytes(Convert.ToInt32(param1)), 0).ToString("P0");
                                    if (Convert.ToInt32(num_params) > 1 && param1 != param2) line += "~" + BitConverter.ToSingle(BitConverter.GetBytes(Convert.ToInt32(param2)), 0).ToString("P0");
                                    break;
                                case 21:
                                    line = Extensions.GetLocalization(7211) + " +" + param1;
                                    if (Convert.ToInt32(num_params) > 1 && param1 != param2) line += "~" + param2;
                                    break;
                                case 22:
                                    line = Extensions.GetLocalization(7211) + " +" + BitConverter.ToSingle(BitConverter.GetBytes(Convert.ToInt32(param1)), 0).ToString("P0");
                                    if (Convert.ToInt32(num_params) > 1 && param1 != param2) line += "~" + BitConverter.ToSingle(BitConverter.GetBytes(Convert.ToInt32(param2)), 0).ToString("P0");
                                    break;
                                case 23:
                                    line = Extensions.GetLocalization(7212) + " +" + param1;
                                    if (Convert.ToInt32(num_params) > 1 && param1 != param2) line += "~" + param2;
                                    break;
                                case 24:
                                    line = Extensions.GetLocalization(7212) + " +" + BitConverter.ToSingle(BitConverter.GetBytes(Convert.ToInt32(param1)), 0).ToString("P0");
                                    if (Convert.ToInt32(num_params) > 1 && param1 != param2) line += "~" + BitConverter.ToSingle(BitConverter.GetBytes(Convert.ToInt32(param2)), 0).ToString("P0");
                                    break;
                                case 25:
                                    line = Extensions.GetLocalization(7208) + " +" + BitConverter.ToSingle(BitConverter.GetBytes(Convert.ToInt32(param1)), 0).ToString("P0") + "\n" + Extensions.GetLocalization(7211) + " -" + BitConverter.ToSingle(BitConverter.GetBytes(Convert.ToInt32(param2)), 0).ToString("P0");
                                    break;
                                case 26:
                                    line = Extensions.GetLocalization(7209) + " +" + BitConverter.ToSingle(BitConverter.GetBytes(Convert.ToInt32(param1)), 0).ToString("P0") + "\n" + Extensions.GetLocalization(7208) + " -" + BitConverter.ToSingle(BitConverter.GetBytes(Convert.ToInt32(param2)), 0).ToString("P0");
                                    break;
                                case 27:
                                    line = Extensions.GetLocalization(7210) + " +" + BitConverter.ToSingle(BitConverter.GetBytes(Convert.ToInt32(param1)), 0).ToString("P0") + "\n" + Extensions.GetLocalization(7212) + " -" + BitConverter.ToSingle(BitConverter.GetBytes(Convert.ToInt32(param2)), 0).ToString("P0");
                                    break;
                                case 28:
                                    line = Extensions.GetLocalization(7211) + " +" + BitConverter.ToSingle(BitConverter.GetBytes(Convert.ToInt32(param1)), 0).ToString("P0") + "\n" + Extensions.GetLocalization(7210) + " -" + BitConverter.ToSingle(BitConverter.GetBytes(Convert.ToInt32(param2)), 0).ToString("P0");
                                    break;
                                case 29:
                                    line = Extensions.GetLocalization(7212) + " +" + BitConverter.ToSingle(BitConverter.GetBytes(Convert.ToInt32(param1)), 0).ToString("P0") + "\n" + Extensions.GetLocalization(7209) + " -" + BitConverter.ToSingle(BitConverter.GetBytes(Convert.ToInt32(param2)), 0).ToString("P0");
                                    break;
                                case 30:
                                    line = Extensions.GetLocalization(7208) + " +" + param1 + "\n" + Extensions.GetLocalization(7211) + " -" + param2;
                                    break;
                                case 31:
                                    line = Extensions.GetLocalization(7209) + " +" + param1 + "\n" + Extensions.GetLocalization(7208) + " -" + param2;
                                    break;
                                case 32:
                                    line = Extensions.GetLocalization(7210) + " +" + param1 + "\n" + Extensions.GetLocalization(7212) + " -" + param2;
                                    break;
                                case 33:
                                    line = Extensions.GetLocalization(7211) + " +" + param1 + "\n" + Extensions.GetLocalization(7210) + " -" + param2;
                                    break;
                                case 34:
                                    line = Extensions.GetLocalization(7212) + " +" + param1 + "\n" + Extensions.GetLocalization(7209) + " -" + param2;
                                    break;
                                case 35:
                                    line = Extensions.GetLocalization(7217) + " +" + param1;
                                    if (Convert.ToInt32(num_params) > 1 && param1 != param2) line += "~" + param2;
                                    break;
                                case 36:
                                    line = Extensions.GetLocalization(7218) + " +" + param1;
                                    if (Convert.ToInt32(num_params) > 1 && param1 != param2) line += "~" + param2;
                                    break;
                                case 37:
                                    line = Extensions.GetLocalization(7219) + " +" + BitConverter.ToSingle(BitConverter.GetBytes(Convert.ToInt32(param1)), 0).ToString("P0");
                                    break;
                                case 38:
                                    line = Extensions.GetLocalization(7220) + " +" + BitConverter.ToSingle(BitConverter.GetBytes(Convert.ToInt32(param1)), 0).ToString("P0");
                                    break;
                                case 39:
                                    line = Extensions.GetLocalization(7221) + " +" + Convert.ToInt32(param1) / 2;
                                    break;
                                case 40:
                                    line = Extensions.GetLocalization(7222) + " +" + Convert.ToInt32(param1) / 2;
                                    break;
                                case 41:
                                    line = Extensions.GetLocalization(7223) + " +" + param1;
                                    if (Convert.ToInt32(num_params) > 1 && param1 != param2) line += "~" + param2;
                                    break;
                                case 42:
                                    line = Extensions.GetLocalization(7224) + " +" + param1;
                                    if (Convert.ToInt32(num_params) > 1 && param1 != param2) line += "~" + param2;
                                    break;
                                case 43:
                                    line = Extensions.GetLocalization(7225) + " +" + param1;
                                    if (Convert.ToInt32(num_params) > 1 && param1 != param2) line += "~" + param2;
                                    break;
                                case 44:
                                    line = Extensions.GetLocalization(7226) + " +" + param1;
                                    if (Convert.ToInt32(num_params) > 1 && param1 != param2) line += "~" + param2;
                                    break;
                                case 45:
                                    line = Extensions.GetLocalization(7229) + " +" + BitConverter.ToSingle(BitConverter.GetBytes(Convert.ToInt32(param1)), 0).ToString("P0");
                                    break;
                                case 46:
                                    line = Extensions.GetLocalization(7227) + " +" + param1;
                                    break;
                                case 47:
                                    line = Extensions.GetLocalization(7227) + " +" + BitConverter.ToSingle(BitConverter.GetBytes(Convert.ToInt32(param1)), 0).ToString("P0");
                                    break;
                                case 48:
                                    line = String.Format(Extensions.GetLocalization(7230), "+" + BitConverter.ToSingle(BitConverter.GetBytes(Convert.ToInt32(param1)), 0).ToString("F2", CultureInfo.CreateSpecificCulture("en-US")));
                                    break;
                                case 49:
                                    line = Extensions.GetLocalization(7231) + " +" + BitConverter.ToSingle(BitConverter.GetBytes(Convert.ToInt32(param1)), 0).ToString("P0");
                                    break;
                                case 50:
                                    line = Extensions.GetLocalization(7228) + " +" + param1;
                                    break;
                                case 51:
                                    line = Extensions.GetLocalization(7228) + " +" + BitConverter.ToSingle(BitConverter.GetBytes(Convert.ToInt32(param1)), 0).ToString("P0");//param1%~param2%
                                    break;
                                case 52:
                                    line = Extensions.GetLocalization(7232) + " +" + param1;
                                    break;
                                case 53:
                                    line = Extensions.GetLocalization(7232) + " +" + BitConverter.ToSingle(BitConverter.GetBytes(Convert.ToInt32(param1)), 0).ToString("P0");
                                    break;
                                case 54:
                                    line = Extensions.GetLocalization(7233) + " +" + BitConverter.ToSingle(BitConverter.GetBytes(Convert.ToInt32(param1)), 0).ToString("P0");
                                    break;
                                case 55:
                                    line = Extensions.SkillDesc(Convert.ToInt32(param1));
                                    break;
                                case 56:
                                    line = Extensions.GetLocalization(7235) + " -" + BitConverter.ToSingle(BitConverter.GetBytes(Convert.ToInt32(param1)), 0).ToString("P0");
                                    break;
                                case 57:
                                    line = Extensions.GetLocalization(7236);
                                    break;
                                case 58:
                                    line = Extensions.GetLocalization(7216) + " +" + BitConverter.ToSingle(BitConverter.GetBytes(Convert.ToInt32(param1)), 0).ToString("P0");
                                    break;
                                case 59:
                                    line = Extensions.GetLocalization(7239) + " +" + param1;
                                    break;
                                case 60:
                                    line = Extensions.GetLocalization(7240) + " +" + param1;
                                    break;
                                case 61:
                                    line = Extensions.GetLocalization(7238) + " +" + BitConverter.ToSingle(BitConverter.GetBytes(Convert.ToInt32(param1)), 0).ToString("P0");
                                    break;
                                case 62:
                                    line = Extensions.GetLocalization(7241);
                                    break;
                                case 63:
                                    line = Extensions.GetLocalization(7242) + " +" + param1;
                                    break;
                                case 64:
                                    line = Extensions.GetLocalization(7243) + " +" + BitConverter.ToSingle(BitConverter.GetBytes(Convert.ToInt32(param1)), 0).ToString("P0");
                                    break;
                                case 65:
                                    line = Extensions.GetLocalization(7244) + " +" + BitConverter.ToSingle(BitConverter.GetBytes(Convert.ToInt32(param1)), 0).ToString("P0");
                                    break;
                                case 66:
                                    line = Extensions.GetLocalization(7245) + " +" + BitConverter.ToSingle(BitConverter.GetBytes(Convert.ToInt32(param1)), 0).ToString("P0");
                                    break;
                                case 67:
                                    line = Extensions.GetLocalization(7246) + " +" + BitConverter.ToSingle(BitConverter.GetBytes(Convert.ToInt32(param1)), 0).ToString("P0");
                                    break;
                                case 68:
                                    line = Extensions.GetLocalization(7247) + " +" + BitConverter.ToSingle(BitConverter.GetBytes(Convert.ToInt32(param1)), 0).ToString("P0");
                                    break;
                                case 69:
                                    line = Extensions.GetLocalization(7234) + " +" + BitConverter.ToSingle(BitConverter.GetBytes(Convert.ToInt32(param1)), 0).ToString("P0");
                                    break;
                                case 70:
                                    line = Extensions.GetLocalization(7239) + " +" + param1;
                                    if (Convert.ToInt32(num_params) > 1 && param1 != param2) line += "~" + param2;
                                    break;
                                case 71:
                                    line = Extensions.GetLocalization(7240) + " +" + param1;
                                    if (Convert.ToInt32(num_params) > 1 && param1 != param2) line += "~" + param2;
                                    break;
                                case 72:
                                    line = Extensions.GetLocalization(7229) + " +" + BitConverter.ToSingle(BitConverter.GetBytes(Convert.ToInt32(param1)), 0).ToString("P0");
                                    if (Convert.ToInt32(num_params) > 1 && param1 != param2) line += "~" + BitConverter.ToSingle(BitConverter.GetBytes(Convert.ToInt32(param2)), 0).ToString("P0");
                                    break;
                                case 73:
                                    line = Extensions.GetLocalization(7217) + " +" + param1;
                                    if (Convert.ToInt32(num_params) > 1 && param1 != param2) line += "~" + param2;
                                    break;
                                case 74:
                                    line = Extensions.GetLocalization(7218) + " +" + param1;
                                    if (Convert.ToInt32(num_params) > 1 && param1 != param2) line += "~" + param2;
                                    break;
                                case 75:
                                    line = Extensions.GetLocalization(7227) + " +" + BitConverter.ToSingle(BitConverter.GetBytes(Convert.ToInt32(param1)), 0).ToString("P0");
                                    if (Convert.ToInt32(num_params) > 1 && param1 != param2) line += "~" + BitConverter.ToSingle(BitConverter.GetBytes(Convert.ToInt32(param2)), 0).ToString("P0");
                                    break;
                                case 76:
                                    line = Extensions.GetLocalization(7206) + " +" + param1;
                                    if (Convert.ToInt32(num_params) > 1 && param1 != param2) line += "~" + param2;
                                    break;
                                case 77:
                                    line = Extensions.GetLocalization(7207) + " +" + param1;
                                    if (Convert.ToInt32(num_params) > 1 && param1 != param2) line += "~" + param2;
                                    break;
                                case 78:
                                    line = Extensions.GetLocalization(7233) + " +" + BitConverter.ToSingle(BitConverter.GetBytes(Convert.ToInt32(param1)), 0).ToString("P0");
                                    if (Convert.ToInt32(num_params) > 1 && param1 != param2) line += "~" + BitConverter.ToSingle(BitConverter.GetBytes(Convert.ToInt32(param2)), 0).ToString("P0");
                                    break;
                                case 79:
                                    line = Extensions.GetLocalization(7234) + " +" + BitConverter.ToSingle(BitConverter.GetBytes(Convert.ToInt32(param1)), 0).ToString("P0");
                                    if (Convert.ToInt32(num_params) > 1 && param1 != param2) line += "~" + BitConverter.ToSingle(BitConverter.GetBytes(Convert.ToInt32(param2)), 0).ToString("P0");
                                    break;
                                case 80:
                                    line = Extensions.GetLocalization(7215) + " -" + BitConverter.ToSingle(BitConverter.GetBytes(Convert.ToInt32(param1)), 0).ToString("P0");
                                    if (Convert.ToInt32(num_params) > 1 && param1 != param2) line += "~" + BitConverter.ToSingle(BitConverter.GetBytes(Convert.ToInt32(param2)), 0).ToString("P0");
                                    break;
                                case 81:
                                    line = Extensions.GetLocalization(7213) + " +" + BitConverter.ToSingle(BitConverter.GetBytes(Convert.ToInt32(param1)), 0).ToString("F2", CultureInfo.CreateSpecificCulture("en-US"));
                                    if (Convert.ToInt32(num_params) > 1 && param1 != param2) line += "~" + BitConverter.ToSingle(BitConverter.GetBytes(Convert.ToInt32(param2)), 0).ToString("F2", CultureInfo.CreateSpecificCulture("en-US"));
                                    break;
                                case 82:
                                    line = Extensions.GetLocalization(7222) + " +" + Convert.ToInt32(param1) / 2;
                                    if (Convert.ToInt32(num_params) > 1 && param1 != param2) line += "~" + Convert.ToInt32(param2) / 2;
                                    break;
                                case 83:
                                    line = Extensions.GetLocalization(7237) + " +" + BitConverter.ToSingle(BitConverter.GetBytes(Convert.ToInt32(param1)), 0).ToString("P0");
                                    if (Convert.ToInt32(num_params) > 1 && param1 != param2) line += "~" + BitConverter.ToSingle(BitConverter.GetBytes(Convert.ToInt32(param2)), 0).ToString("P0");
                                    break;
                                case 84:
                                    line = Extensions.GetLocalization(7238) + " +" + BitConverter.ToSingle(BitConverter.GetBytes(Convert.ToInt32(param1)), 0).ToString("P0");
                                    if (Convert.ToInt32(num_params) > 1 && param1 != param2) line += "~" + BitConverter.ToSingle(BitConverter.GetBytes(Convert.ToInt32(param2)), 0).ToString("P0");
                                    break;
                                case 85:
                                    line = Extensions.GetLocalization(7221) + " +" + Convert.ToInt32(param1) / 2;
                                    if (Convert.ToInt32(num_params) > 1 && param1 != param2) line += "~" + Convert.ToInt32(param2) / 2;
                                    break;
                                case 86:
                                    line = Extensions.GetLocalization(7228) + " +" + param1;
                                    if (Convert.ToInt32(num_params) > 1 && param1 != param2) line += "~" + param2;
                                    break;
                                case 87:
                                    line = Extensions.GetLocalization(7203) + " +" + param1;
                                    if (Convert.ToInt32(num_params) > 1 && param1 != param2) line += "~" + param2;
                                    break;
                                case 88:
                                    line = Extensions.GetLocalization(7205) + " +" + param1;
                                    if (Convert.ToInt32(num_params) > 1 && param1 != param2) line += "~" + param2;
                                    break;
                                case 89:
                                    line = Extensions.GetLocalization(7200) + " " + id + " " + Extensions.GetLocalization(7201) + " " + addon_type + " " + param1 + "-" + param2 + "-" + param3;
                                    break;
                                case 90:
                                    line = Extensions.GetLocalization(7248) + " +" + param1;
                                    break;
                                case 91:
                                    line = Extensions.GetLocalization(7249) + " +" + param1;
                                    break;
                                case 92:
                                    line = Extensions.GetLocalization(7200) + " " + id + " " + Extensions.GetLocalization(7201) + " " + addon_type + " " + param1 + "-" + param2 + "-" + param3;
                                    //if (Convert.ToInt32(num_params) > 1 && param1 != param2) line += "~" + param2;
                                    break;
                                case 93:
                                    line = Extensions.GetLocalization(7217) + " +" + param1;
                                    break;
                                case 94:
                                    line = Extensions.GetLocalization(7217) + " +" + param1;
                                    if (Convert.ToInt32(num_params) > 1 && param1 != param2) line += "~" + param2;
                                    break;
                                case 95:
                                    line = Extensions.GetLocalization(7223) + " +" + param1;
                                    break;
                                case 96:
                                    line = Extensions.GetLocalization(7224) + " +" + param1;
                                    break;
                                case 97:
                                    line = Extensions.GetLocalization(7225) + " +" + param1;
                                    break;
                                case 98:
                                    line = Extensions.GetLocalization(7226) + " +" + param1;
                                    break;
                                case 99:
                                    line = Extensions.GetLocalization(7218) + " +" + param1;
                                    break;
                                case 100:
                                    line = Extensions.GetLocalization(7202) + " +" + param1;
                                    break;
                                case 101:
                                    line = Extensions.GetLocalization(7203) + " +" + param1;
                                    break;
                                case 102:
                                    line = Extensions.GetLocalization(7204) + " +" + param1;
                                    break;
                                case 103:
                                    line = Extensions.GetLocalization(7205) + " +" + param1;
                                    break;
                                case 104:
                                    line = Extensions.GetLocalization(7206) + " +" + param1;
                                    if (Convert.ToInt32(num_params) > 1 && param1 != param2) line += "~" + param2;
                                    break;
                                case 105:
                                    line = Extensions.GetLocalization(7217) + " +" + param1;
                                    if (Convert.ToInt32(num_params) > 1 && param1 != param2) line += "~" + param2;
                                    break;
                                case 106:
                                    line = Extensions.GetLocalization(7223) + " +" + param1;
                                    if (Convert.ToInt32(num_params) > 1 && param1 != param2) line += "~" + param2;
                                    break;
                                case 107:
                                    line = Extensions.GetLocalization(7224) + " +" + param1;
                                    if (Convert.ToInt32(num_params) > 1 && param1 != param2) line += "~" + param2;
                                    break;
                                case 108:
                                    line = Extensions.GetLocalization(7225) + " +" + param1;
                                    if (Convert.ToInt32(num_params) > 1 && param1 != param2) line += "~" + param2;
                                    break;
                                case 109:
                                    line = Extensions.GetLocalization(7227) + " +" + param1;
                                    if (Convert.ToInt32(num_params) > 1 && param1 != param2) line += "~" + param2;
                                    break;
                                case 110:
                                    line = Extensions.GetLocalization(7229) + " +" + BitConverter.ToSingle(BitConverter.GetBytes(Convert.ToInt32(param1)), 0).ToString("P0");
                                    break;
                                case 111:
                                    line = Extensions.GetLocalization(7239) + " +" + param1;
                                    break;
                                case 112:
                                    line = Extensions.GetLocalization(7240) + " +" + param1;
                                    break;
                                case 113:
                                    line = Extensions.GetLocalization(7215) + " -" + BitConverter.ToSingle(BitConverter.GetBytes(Convert.ToInt32(param1)), 0).ToString("P0");
                                    break;
                                case 114:
                                    line = Extensions.GetLocalization(7207) + " +" + param1;
                                    break;
                                case 115:
                                    line = String.Format(Extensions.GetLocalization(7050), "+" + BitConverter.ToSingle(BitConverter.GetBytes(Convert.ToInt32(param1)), 0).ToString("F1", CultureInfo.CreateSpecificCulture("en-US")));
                                    break;
                                //case 120-146: Engrave
                                case 150:
                                    line = Extensions.GetLocalization(7200) + " " + id + " " + Extensions.GetLocalization(7201) + " " + addon_type + " " + param1 + "-" + param2 + "-" + param3;
                                    break;
                                case 151:
                                    line = Extensions.GetLocalization(7200) + " " + id + " " + Extensions.GetLocalization(7201) + " " + addon_type + " " + param1 + "-" + param2 + "-" + param3;
                                    break;
                                case 152:
                                    line = Extensions.GetLocalization(7200) + " " + id + " " + Extensions.GetLocalization(7201) + " " + addon_type + " " + param1 + "-" + param2 + "-" + param3;
                                    break;
                                case 153:
                                    line = Extensions.GetLocalization(7200) + " " + id + " " + Extensions.GetLocalization(7201) + " " + addon_type + " " + param1 + "-" + param2 + "-" + param3;
                                    break;
                                case 154:
                                    line = Extensions.GetLocalization(7200) + " " + id + " " + Extensions.GetLocalization(7201) + " " + addon_type + " " + param1 + "-" + param2 + "-" + param3;
                                    break;
                                case 155:
                                    line = Extensions.GetLocalization(7200) + " " + id + " " + Extensions.GetLocalization(7201) + " " + addon_type + " " + param1 + "-" + param2 + "-" + param3;
                                    break;
                                case 156:
                                    line = Extensions.GetLocalization(7200) + " " + id + " " + Extensions.GetLocalization(7201) + " " + addon_type + " " + param1 + "-" + param2 + "-" + param3;
                                    break;
                                case 160:
                                    line = Extensions.GetLocalization(7251) + " +" + param1;
                                    break;
                                case 161:
                                    line = Extensions.GetLocalization(7200) + " " + id + " " + Extensions.GetLocalization(7201) + " " + addon_type + " " + param1 + "-" + param2 + "-" + param3;
                                    break;
                                case 162:
                                    line = Extensions.GetLocalization(7200) + " " + id + " " + Extensions.GetLocalization(7201) + " " + addon_type + " " + param1 + "-" + param2 + "-" + param3;
                                    break;
                                case 163:
                                    line = Extensions.GetLocalization(7200) + " " + id + " " + Extensions.GetLocalization(7201) + " " + addon_type + " " + param1 + "-" + param2 + "-" + param3;
                                    break;
                                case 164:
                                    line = Extensions.GetLocalization(7200) + " " + id + " " + Extensions.GetLocalization(7201) + " " + addon_type + " " + param1 + "-" + param2 + "-" + param3;
                                    break;
                                case 165:
                                    line = Extensions.GetLocalization(7200) + " " + id + " " + Extensions.GetLocalization(7201) + " " + addon_type + " " + param1 + "-" + param2 + "-" + param3;
                                    break;
                                case 166:
                                    line = Extensions.GetLocalization(7200) + " " + id + " " + Extensions.GetLocalization(7201) + " " + addon_type + " " + param1 + "-" + param2 + "-" + param3;
                                    break;
                                case 167:
                                    line = Extensions.GetLocalization(7200) + " " + id + " " + Extensions.GetLocalization(7201) + " " + addon_type + " " + param1 + "-" + param2 + "-" + param3;
                                    break;
                                case 168:
                                    line = Extensions.GetLocalization(7200) + " " + id + " " + Extensions.GetLocalization(7201) + " " + addon_type + " " + param1 + "-" + param2 + "-" + param3;
                                    break;
                                case 169:
                                    line = Extensions.GetLocalization(7200) + " " + id + " " + Extensions.GetLocalization(7201) + " " + addon_type + " " + param1 + "-" + param2 + "-" + param3;
                                    break;
                                case 170:
                                    line = Extensions.GetLocalization(7200) + " " + id + " " + Extensions.GetLocalization(7201) + " " + addon_type + " " + param1 + "-" + param2 + "-" + param3;
                                    break;
                                case 171:
                                    line = Extensions.GetLocalization(7200) + " " + id + " " + Extensions.GetLocalization(7201) + " " + addon_type + " " + param1 + "-" + param2 + "-" + param3;
                                    break;
                                case 172:
                                    line = Extensions.GetLocalization(7200) + " " + id + " " + Extensions.GetLocalization(7201) + " " + addon_type + " " + param1 + "-" + param2 + "-" + param3;
                                    break;
                                case 173:
                                    line = Extensions.GetLocalization(7200) + " " + id + " " + Extensions.GetLocalization(7201) + " " + addon_type + " " + param1 + "-" + param2 + "-" + param3;
                                    break;
                                case 174:
                                    line = Extensions.GetLocalization(7200) + " " + id + " " + Extensions.GetLocalization(7201) + " " + addon_type + " " + param1 + "-" + param2 + "-" + param3;
                                    break;
                                case 175:
                                    line = Extensions.GetLocalization(7252) + " +" + param1;
                                    break;
                                case 176:
                                    line = Extensions.GetLocalization(7253) + " +" + param1;
                                    break;
                                case 200:
                                    line = Extensions.GetLocalization(7200) + " " + id + " " + Extensions.GetLocalization(7201) + " " + addon_type + " " + param1 + "-" + param2 + "-" + param3;
                                    break;
                                case 201:
                                    line = Extensions.GetLocalization(7200) + " " + id + " " + Extensions.GetLocalization(7201) + " " + addon_type + " " + param1 + "-" + param2 + "-" + param3;
                                    break;
                                case 202:
                                    line = Extensions.GetLocalization(7200) + " " + id + " " + Extensions.GetLocalization(7201) + " " + addon_type + " " + param1 + "-" + param2 + "-" + param3;
                                    break;
                                case 203:
                                    line = Extensions.GetLocalization(7200) + " " + id + " " + Extensions.GetLocalization(7201) + " " + addon_type + " " + param1 + "-" + param2 + "-" + param3;
                                    break;
                                case 204:
                                    line = Extensions.GetLocalization(7200) + " " + id + " " + Extensions.GetLocalization(7201) + " " + addon_type + " " + param1 + "-" + param2 + "-" + param3;
                                    break;
                                case 205:
                                    line = Extensions.GetLocalization(7200) + " " + id + " " + Extensions.GetLocalization(7201) + " " + addon_type + " " + param1 + "-" + param2 + "-" + param3;
                                    break;
                                case 206:
                                    line = Extensions.GetLocalization(7200) + " " + id + " " + Extensions.GetLocalization(7201) + " " + addon_type + " " + param1 + "-" + param2 + "-" + param3;
                                    break;
                                case 207:
                                    line = Extensions.GetLocalization(7200) + " " + id + " " + Extensions.GetLocalization(7201) + " " + addon_type + " " + param1 + "-" + param2 + "-" + param3;
                                    break;
                                case 208:
                                    line = Extensions.GetLocalization(7200) + " " + id + " " + Extensions.GetLocalization(7201) + " " + addon_type + " " + param1 + "-" + param2 + "-" + param3;
                                    break;
                                case 209:
                                    line = Extensions.GetLocalization(7200) + " " + id + " " + Extensions.GetLocalization(7201) + " " + addon_type + " " + param1 + "-" + param2 + "-" + param3;
                                    break;
                                case 210:
                                    line = Extensions.GetLocalization(7200) + " " + id + " " + Extensions.GetLocalization(7201) + " " + addon_type + " " + param1 + "-" + param2 + "-" + param3;
                                    break;
                                case 211:
                                    line = Extensions.GetLocalization(7200) + " " + id + " " + Extensions.GetLocalization(7201) + " " + addon_type + " " + param1 + "-" + param2 + "-" + param3;
                                    break;
                                case 212:
                                    line = Extensions.GetLocalization(7200) + " " + id + " " + Extensions.GetLocalization(7201) + " " + addon_type + " " + param1 + "-" + param2 + "-" + param3;
                                    break;
                                default:
                                    {
                                        return line = Extensions.GetLocalization(7200) + " " + id + " " + Extensions.GetLocalization(7201) + " " + addon_type + " " + param1 + "-" + param2 + "-" + param3;
                                    }
                            }
                        }
                        catch
                        {
                            line = Extensions.GetLocalization(7200) + " " + id + " " + param1 + "-" + param2 + "-" + param3;
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

