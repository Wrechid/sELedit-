﻿using System;

namespace sELedit
{
    class MINE_ESSENCE
    {
        public static string GetProps(int pos)
        {
            if(pos == -1)
            {
                return "";
            }
            string line = "";
            try
            {
                for (int k = 0; k < MainWindow.eLC.Lists[79].elementFields.Length; k++)
                {
                    if (MainWindow.eLC.Lists[79].elementFields[k] == "level_required")
                    {
                        line += "\n" + Extensions.GetLocalization(7370) + " " + MainWindow.eLC.GetValue(79, pos, k);
                        break;
                    }
                }
                for (int k = 0; k < MainWindow.eLC.Lists[79].elementFields.Length; k++)
                {
                    if (MainWindow.eLC.Lists[79].elementFields[k] == "id_equipment_required")
                    {
                        string id_equipment_required = MainWindow.eLC.GetValue(79, pos, k);
                        bool Suc = false;
                        if (id_equipment_required != "0")
                        {
                            for (int i = 0; i < MainWindow.database.task_items_list.Length; i += 2)
                            {
                                if (MainWindow.eLC.Version >= Convert.ToInt32(MainWindow.database.task_items_list[i + 1]))
                                {
                                    int l = Convert.ToInt32(MainWindow.database.task_items_list[i]);
                                    for (int t = 0; t < MainWindow.eLC.Lists[l].elementValues.Length; t++)
                                    {
                                        if (MainWindow.eLC.GetValue(l, t, 0) == id_equipment_required)
                                        {
                                            for (int a = 0; a < MainWindow.eLC.Lists[l].elementFields.Length; a++)
                                            {
                                                if (MainWindow.eLC.Lists[l].elementFields[a] == "Name")
                                                {
                                                    line += "\n" + String.Format(Extensions.GetLocalization(7371), MainWindow.eLC.GetValue(l, t, a), id_equipment_required);
                                                    break;
                                                }
                                            }
                                            Suc = true;
                                            break;
                                        }
                                    }
                                    if (Suc == true) break;
                                }
                            }
                            for (int i = 0; i < MainWindow.eLC.Lists[79].elementFields.Length; i++)
                            {
                                if (MainWindow.eLC.Lists[79].elementFields[i] == "eliminate_tool")
                                {

                                    line += "\n" + Extensions.GetLocalization(7372) + " ";
                                    if (MainWindow.eLC.GetValue(79, pos, i) == "0") line += Extensions.GetLocalization(2310);
                                    else line += Extensions.GetLocalization(2311);
                                    break;
                                }
                            }
                        }
                        break;
                    }
                }
                for (int k = 0; k < MainWindow.eLC.Lists[79].elementFields.Length; k++)
                {
                    if (MainWindow.eLC.Lists[79].elementFields[k] == "time_min")
                    {
                        string time_min = MainWindow.eLC.GetValue(79, pos, k);
                        string time_max = MainWindow.eLC.GetValue(79, pos, k + 1);
                        string time = time_min;
                        if (time_min != time_max) time += "~" + time_max;
                        line += "\n" + String.Format(Extensions.GetLocalization(7373), time);
                        break;
                    }
                }
                for (int k = 0; k < MainWindow.eLC.Lists[79].elementFields.Length; k++)
                {
                    if (MainWindow.eLC.Lists[79].elementFields[k] == "exp")
                    {
                        line += "\n" + Extensions.GetLocalization(7374) + " " + MainWindow.eLC.GetValue(79, pos, k);
                        break;
                    }
                }
                for (int k = 0; k < MainWindow.eLC.Lists[79].elementFields.Length; k++)
                {
                    if (MainWindow.eLC.Lists[79].elementFields[k] == "skillpoint")
                    {
                        line += "\n" + Extensions.GetLocalization(7375) + " " + MainWindow.eLC.GetValue(79, pos, k);
                        break;
                    }
                }
                bool tmp = false;
                for (int t = 1; t < 17; t++)
                {
                    for (int a = 0; a < MainWindow.eLC.Lists[79].elementFields.Length; a++)
                    {
                        if (MainWindow.eLC.Lists[79].elementFields[a] == "materials_" + t + "_id")
                        {
                            string id = MainWindow.eLC.GetValue(79, pos, a);
                            if (id != "0") tmp = true;
                            break;
                        }
                    }
                }
                line += "\n" + Extensions.GetLocalization(7376) + " ";
                if (tmp == false) line += Extensions.GetLocalization(2310);
                else line += Extensions.GetLocalization(2311);
                for (int k = 0; k < MainWindow.eLC.Lists[79].elementFields.Length; k++)
                {
                    if (MainWindow.eLC.Lists[79].elementFields[k] == "task_in")
                    {
                        string task_in = MainWindow.eLC.GetValue(79, pos, k);
                        line += "\n" + Extensions.GetLocalization(7377) + " ";
                        if (task_in != "0") line += task_in;
                        else line += Extensions.GetLocalization(2310);
                        break;
                    }
                }
                for (int k = 0; k < MainWindow.eLC.Lists[79].elementFields.Length; k++)
                {
                    if (MainWindow.eLC.Lists[79].elementFields[k] == "permenent")
                    {

                        string permenent = MainWindow.eLC.GetValue(79, pos, k);
                        line += "\n" + Extensions.GetLocalization(7378) + " ";
                        if (permenent == "0") line += Extensions.GetLocalization(2310);
                        else line += Extensions.GetLocalization(2311);
                        break;
                    }
                }
                for (int k = 0; k < MainWindow.eLC.Lists[79].elementFields.Length; k++)
                {
                    if (MainWindow.eLC.Lists[79].elementFields[k] == "max_gatherer")
                    {
                        line += "\n" + Extensions.GetLocalization(7379) + " " + MainWindow.eLC.GetValue(79, pos, k);
                        break;
                    }
                }
                for (int k = 0; k < MainWindow.eLC.Lists[79].elementFields.Length; k++)
                {
                    if (MainWindow.eLC.Lists[79].elementFields[k] == "gather_dist")
                    {
                        line += "\n" + Extensions.GetLocalization(7380) + " " + MainWindow.eLC.GetValue(79, pos, k) + " м.";
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

