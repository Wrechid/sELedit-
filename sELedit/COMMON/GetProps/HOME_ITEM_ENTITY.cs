
using System;
using System.Collections.Generic;

namespace sELedit
{
    class HOME_ITEM_ENTITY
    {
        public static string GetProps(int pos)
        {
            string line = "";
            string name = "";
            string level = "";
            string flourish_min = "";
            string flourish_max = "";
            string unique_flourish_min = "";
            string unique_flourish_max = "";
            string clean = "";
            string put_area = "";
            string desc = "";
            try
            {
                for (int t = 0; t < MainWindow.eLC.Lists[223].elementFields.Length; t++)
                {
                    if (MainWindow.eLC.Lists[223].elementFields[t] == "Name")
                    {
                        name = MainWindow.eLC.GetValue(223, pos, t);
                        break;
                    }
                }
                for (int t = 0; t < MainWindow.eLC.Lists[223].elementFields.Length; t++)
                {
                    if (MainWindow.eLC.Lists[223].elementFields[t] == "level")
                    {
                        level = MainWindow.eLC.GetValue(223, pos, t);
                        break;
                    }
                }
                for (int t = 0; t < MainWindow.eLC.Lists[223].elementFields.Length; t++)
                {
                    if (MainWindow.eLC.Lists[223].elementFields[t] == "flourish_min")
                    {
                        flourish_min = MainWindow.eLC.GetValue(223, pos, t);
                        flourish_max = MainWindow.eLC.GetValue(223, pos, t + 1);
                    }
                }
                for (int t = 0; t < MainWindow.eLC.Lists[223].elementFields.Length; t++)
                {
                    if (MainWindow.eLC.Lists[223].elementFields[t] == "unique_flourish_min")
                    {
                        unique_flourish_min = MainWindow.eLC.GetValue(223, pos, t);
                        unique_flourish_max = MainWindow.eLC.GetValue(223, pos, t + 1);
                        break;
                    }
                }
                for (int t = 0; t < MainWindow.eLC.Lists[223].elementFields.Length; t++)
                {
                    if (MainWindow.eLC.Lists[223].elementFields[t] == "clean")
                    {
                        clean = MainWindow.eLC.GetValue(223, pos, t);
                        break;
                    }
                }
                for (int t = 0; t < MainWindow.eLC.Lists[223].elementFields.Length; t++)
                {
                    if (MainWindow.eLC.Lists[223].elementFields[t] == "put_area1")
                    {
                        string put_area1 = MainWindow.eLC.GetValue(223, pos, t);
                        string put_area2 = MainWindow.eLC.GetValue(223, pos, t + 1);
                        //line += "\n" + Extensions.GetLocalization(7404);
                        if (put_area1 == "0") put_area += Extensions.GetLocalization(3110);
                        if (put_area1 == "1") put_area += Extensions.GetLocalization(3111);
                        uint putarea2;
                        bool result_put_area2 = uint.TryParse(put_area2, out putarea2);
                        List<uint> powers_put_area2 = new List<uint>(Extensions.GetPowers(putarea2));
                        for (int p = 0; p < powers_put_area2.Count; p++)
                        {
                            if (powers_put_area2[p] == 0) continue;

                            switch (p)
                            {
                                case 0:
                                    put_area +=  Extensions.GetLocalization(3120);//put_area2_1
                                    break;
                                case 1:
                                    put_area +=  Extensions.GetLocalization(3121);//put_area2_2
                                    break;
                                case 2:
                                    put_area +=  Extensions.GetLocalization(3122);//put_area2_4
                                    break;
                                case 3:
                                    put_area +=  Extensions.GetLocalization(3123);//put_area2_8
                                    break;
                            }
                        }
                        break;
                    }
                }
                for (int t = 0; t < MainWindow.eLC.Lists[223].elementFields.Length; t++)
                {
                    if (MainWindow.eLC.Lists[223].elementFields[t] == "desc")
                    {
                        desc = MainWindow.eLC.GetValue(223, pos, t);
                        break;
                    }
                }
                line += String.Format(Extensions.GetLocalization(7400), name, level, flourish_min, flourish_max, unique_flourish_min, unique_flourish_max, clean, put_area, desc);
            }
            catch
            {
                line = "";
            }
            return line;
        }
	}
}

