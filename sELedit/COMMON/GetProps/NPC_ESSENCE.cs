﻿namespace sELedit
{
    class NPC_ESSENCE
    {
        public static string GetProps(int pos)
        {
            string line = "";
            try
            {
                for (int k = 0; k < MainWindow.eLC.Lists[57].elementFields.Length; k++)
                {
                    if (MainWindow.eLC.Lists[57].elementFields[k] == "id_task_out_service")
                    {
                        string id_task_out_service = MainWindow.eLC.GetValue(57, pos, k);
                        if (id_task_out_service != "0")
                        {
                            line += "\n" + Extensions.GetLocalization(7350) + " " + id_task_out_service;
                        }
                        break;
                    }
                }
                for (int k = 0; k < MainWindow.eLC.Lists[57].elementFields.Length; k++)
                {
                    if (MainWindow.eLC.Lists[57].elementFields[k] == "id_task_in_service")
                    {
                        string id_task_in_service = MainWindow.eLC.GetValue(57, pos, k);
                        if (id_task_in_service != "0")
                        {
                            line += "\n" + Extensions.GetLocalization(7351) + " " + id_task_in_service;
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

