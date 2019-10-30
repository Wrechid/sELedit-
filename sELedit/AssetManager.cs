using sELedit.DDSReader;
using sELedit.Properties;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace sELedit
{
    public class AssetManager
    {
        public int DDSFORMAT = 6;
        internal delegate void UpdateProgressDelegate(string value, int min, int max);
        private SortedList<int, int> item_color;
        private int rows;
        private Bitmap sourceBitmap;
        private CacheSave database = new CacheSave();
        private bool firstLoad = true;
        private int cols;
        private SortedList<int, string> imagesx;
        private SortedList<string, Point> imageposition;
        private SortedList<int, string> item_desc;
        private List<string> arrTheme;

        public static object anydata;
        public bool load()
        {
            
            firstLoad = true;

            if (sourceBitmap == null)
            {

                imageposition = loadSurfaces();
                loadItem_color();
            }

            if (firstLoad)
            {
                LoadTheme();
                Application.DoEvents();
                LoadLocalizationText();
                Application.DoEvents();
                //this.LoadInstanceList();
                //Application.DoEvents();
                LoadBuffList();
                Application.DoEvents();
                LoadItemExtDescList();
                Application.DoEvents();
                LoadSkillList();
                Application.DoEvents();
                LoadAddonList();
                Application.DoEvents();
                firstLoad = false;
            }
            MainWindow.database = database;

            return true;
        }

        public void LoadTheme()
        {
            try
            {
                string line;
                arrTheme = new List<string>();
                string theme_list = Path.GetDirectoryName(Application.ExecutablePath) + "\\resources\\theme.txt";
                Encoding enc = Encoding.GetEncoding("GBK");
                int lines = File.ReadAllLines(theme_list).Length;
                StreamReader file = new StreamReader(theme_list, enc);
                Application.DoEvents();
                int count = 0;

                while ((line = file.ReadLine()) != null)
                {
                    if (line != null && line.Length > 0 && !line.StartsWith("#") && !line.StartsWith("/"))
                    {
                        arrTheme.Add(line);
                    }
                    count++;
                }
                file.Close();
                database.arrTheme = arrTheme;
            }
            catch
            {
                database.arrTheme = null;
            }
        }

        static public Bitmap getSkillIcon(int skillid)
        {
            Bitmap img = Properties.Resources.ResourceManager.GetObject("_" + skillid) as Bitmap;
            return img != null ? img : new Bitmap(new Bitmap(Resources.blank));
        }

        public void loadItem_color()
        {
            string line;
            item_color = new SortedList<int, int>();
            string iconlist_ivtrm = Path.GetDirectoryName(Application.ExecutablePath) + "\\resources\\configs\\item_color.txt";

            string extension = Path.GetExtension(iconlist_ivtrm);
            if (extension == ".txt")
            {
                Encoding enc = Encoding.GetEncoding("GBK");
                int lines = File.ReadAllLines(iconlist_ivtrm).Length;
                StreamReader file = new StreamReader(iconlist_ivtrm, enc);
                int count = 0;
                while ((line = file.ReadLine()) != null)
                {
                    Application.DoEvents();
                    string[] data = line.Split(null);
                    try
                    {
                        string v1 = data[0].ToString();
                        string v2 = data[1].ToString();
                        if (v1.Length > 0 && v2.Length > 0)
                        {
                            item_color.Add(int.Parse(v1), int.Parse(v2));
                        }
                        else
                        {
                            if (v1.Length > 0)
                            {
                                item_color.Add(int.Parse(v1), 0);
                            }
                            if (v2.Length > 0)
                            {
                                item_color.Add(0, int.Parse(v2));
                            }
                        }
                    }
                    catch (Exception) { }
                    count++;
                }
                file.Close();
            }
            database.item_color = item_color;

            //loaditem_desc();
        }

        //public void loaditem_desc()
        //{
        //    string line;
        //    item_desc = new SortedList<int, string>();
        //    string iconlist_ivtrm = Path.GetDirectoryName(Application.ExecutablePath) + "\\resources\\data\\item_ext_desc.txt";
        //    Encoding enc = Encoding.GetEncoding("GBK");
        //    int lines = File.ReadAllLines(iconlist_ivtrm).Length;
        //    StreamReader file = new StreamReader(iconlist_ivtrm, enc);
        //    Application.DoEvents();
        //    int count = 0;

        //    while ((line = file.ReadLine()) != null)
        //    {
        //        if (line != null && line.Length > 0 && !line.StartsWith("#") && !line.StartsWith("/"))
        //        {
        //            string[] data = line.Split('"');
        //            try
        //            {
        //                Application.DoEvents();
        //                item_desc.Add(int.Parse(data[0]), data[1].ToString().Replace('"', ' '));
        //            }
        //            catch (Exception) { }
        //        }
        //        count++;
        //    }
        //    file.Close();
        //    database.item_desc = item_desc;
        //}

        public void LoadItemExtDescList()
        {
            if (database.item_ext_desc != null)
            {
                MainWindow.item_ext_desc = database.item_ext_desc;
                return;
            }
            try
            {
                string path = Path.GetDirectoryName(Application.ExecutablePath) + "\\resources\\data\\item_ext_desc.txt";
                string extension = Path.GetExtension(path);
                if (File.Exists(path))
                {
                    try
                    {
                        StreamReader sr = new StreamReader(path, Encoding.Unicode);
                        MainWindow.item_ext_desc = sr.ReadToEnd().Split(new char[] { '\"' });
                        string[] temp = MainWindow.item_ext_desc[0].Split(new char[] { '\n' });
                        MainWindow.item_ext_desc[0] = temp[temp.Length - 1];
                        sr.Dispose();
                        sr.Close();
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show("ERROR LOADING ITEM DESCRIPTION LIST\n" + e.Message);
                    }
                }
                else
                {
                    MessageBox.Show("NOT FOUND item_ext_desc.txt!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR LOADING ITEM DESCRIPTION LIST\n" + ex.Message);
            }
            GC.Collect();
            database.item_ext_desc = MainWindow.item_ext_desc;
        }

        private SortedList<string, Point> loadSurfaces()
        {
            string sourceFilename = Path.GetDirectoryName(Application.ExecutablePath) + "\\resources\\surfaces\\iconset\\iconlist_ivtrm.png";

            string extension = Path.GetExtension(sourceFilename);
            if (extension == ".dds")
            {
                DDSReader.Utils.PixelFormat st = (DDSReader.Utils.PixelFormat)DDSFORMAT;
                Bitmap bmp = DDS.LoadImage(sourceFilename, true, st);
                if (bmp != null)
                {
                    sourceBitmap = bmp;
                }
                else
                {
                    MessageBox.Show("Unable to load thumbnails...");
                    //sourceBitmap = (Bitmap)Image.FromFile(Path.GetDirectoryName(Application.ExecutablePath) + "\\resources\\surfaces\\iconset\\iconlist_ivtrm.png");
                }
            }
            else
            {
                sourceBitmap = (Bitmap)Image.FromFile(sourceFilename);
            }
            if(sourceBitmap == null)
            {
                MessageBox.Show("Unable to load dds image...");
                sourceBitmap = (Bitmap)Image.FromFile(Path.GetDirectoryName(Application.ExecutablePath) + "\\resources\\surfaces\\iconset\\iconlist_ivtrm.png");
            }
            database.sourceBitmap = sourceBitmap;
            SortedList<string, Bitmap> results = new SortedList<string, Bitmap>();
            List<Bitmap> zxczxc = new List<Bitmap>();
            List<string> fileNames = new List<string>();

            imagesx = new SortedList<int, string>();
            int w = 0;
            int h = 0;

            int counter = 0;
            string line;
            string iconlist_ivtrm = Path.GetDirectoryName(Application.ExecutablePath) + "\\resources\\surfaces\\iconset\\iconlist_ivtrm.txt";
            Encoding enc = Encoding.GetEncoding("GBK");
            StreamReader file = null;
            string extension2 = Path.GetExtension(iconlist_ivtrm);
            file = new StreamReader(iconlist_ivtrm, enc);

            while ((line = file.ReadLine()) != null)
            {
                switch (counter)
                {
                    case 0:
                        w = int.Parse(line);
                        break;
                    case 1:
                        h = int.Parse(line);
                        break;
                    case 2:
                        rows = int.Parse(line);
                        database.rows = rows;
                        break;
                    case 3:
                        cols = int.Parse(line);
                        database.cols = cols;
                        break;
                    default:
                        fileNames.Add(line);
                        break;
                }
                counter++;
            }
            file.Close();
            imageposition = new SortedList<string, Point>();
            int x, y = 0;
            for (int a = 0; a < fileNames.Count; a++)
            {
                Application.DoEvents();
                y = a / cols;
                x = a - y * cols;
                x = x * w;
                y = y * h;
                try
                {
                    imagesx.Add(a, fileNames[a]);
                    imageposition.Add(fileNames[a], new Point(x, y));
                }
                catch (Exception) { }

            }
            database.imagesx = imagesx;
            database.imageposition = imageposition;
            return imageposition;
        }

        public void LoadSkillList()
        {
            if (database.skillstr != null)
            {
                MainWindow.skillstr = database.skillstr;
                return;
            }
            String path = Path.GetDirectoryName(Application.ExecutablePath) + "\\resources\\data\\skillstr.txt";
            if (File.Exists(path))
            {
                try
                {
                    StreamReader sr = new StreamReader(path, Encoding.Unicode);
                    MainWindow.skillstr = sr.ReadToEnd().Split(new char[] { '\"' });
                    string[] temp = MainWindow.skillstr[0].Split(new char[] { '\n' });
                    MainWindow.skillstr[0] = temp[temp.Length - 1];
                    sr.Close();
                }
                catch (Exception e)
                {
                    MessageBox.Show("ERROR LOADING SKILL LIST\n" + e.Message);
                }
            }
            else
            {
                MessageBox.Show("NOT FOUND localization\\skillstr.txt!");
            }
            database.skillstr = MainWindow.skillstr;
        }

        private void LoadAddonList()
        {
            if (database.addonslist != null)
            {
                MainWindow.addonslist = database.addonslist;
                return;
            }
            String path = Path.GetDirectoryName(Application.ExecutablePath) + "\\resources\\data\\addon_table.txt";
            MainWindow.addonslist = new SortedList();
            if (File.Exists(path))
            {
                try
                {
                    StreamReader sr = new StreamReader(path, Encoding.Unicode);

                    char[] seperator = new char[] { '\t' };
                    string line;
                    string[] split;
                    while (!sr.EndOfStream)
                    {
                        line = sr.ReadLine();
                        if (line.Contains("\t") && line != "" && !line.StartsWith("/") && !line.StartsWith("#"))
                        {
                            split = line.Split(seperator);
                            MainWindow.addonslist.Add(split[0], split[1]);
                        }
                    }

                    sr.Close();
                }
                catch (Exception e)
                {
                    MessageBox.Show("ERROR LOADING ADDON LIST\n" + e.Message);
                }
            }
            else
            {
                MessageBox.Show("NOT FOUND! " + path);
            }
            database.addonslist = MainWindow.addonslist;
        }

        public void LoadLocalizationText()
        {
            MainWindow.LocalizationText = new SortedList();
            string path = Path.GetDirectoryName(Application.ExecutablePath) + "\\resources\\data\\language_en.txt";
            if (File.Exists(path))
            {
                try
                {
                    StreamReader sr = new StreamReader(path, Encoding.Unicode);

                    char[] seperator = new char[] { '"' };
                    string line;
                    string[] split;
                    while (!sr.EndOfStream)
                    {
                        line = sr.ReadLine();
                        if (line != "" && !line.StartsWith("/") && !line.StartsWith("#"))
                        {
                            split = line.Split(seperator);
                            MainWindow.LocalizationText.Add(split[0].Trim(), split[1]);
                        }
                    }

                    sr.Close();
                }
                catch (Exception e)
                {
                    MessageBox.Show("ERROR LOADING LOCALIZATION\n" + e.Message);
                }
            }
            else
            {
                MessageBox.Show("NOT FOUND localization:" + path + "!");
            }
            database.LocalizationText = MainWindow.LocalizationText;
        }

        //public void LoadInstanceList()
        //{
        //    if (database.InstanceList != null)
        //    {
        //        MainWindow.InstanceList = database.InstanceList;
        //        return;
        //    }

        //    database.defaultMapsTemplate = new SortedList<int, Map>();
        //    MainWindow.InstanceList = new SortedList();
        //    String path = Path.GetDirectoryName(Application.ExecutablePath) + "\\configs\\instance_en.txt";
        //    if (File.Exists(path))
        //    {
        //        try
        //        {
        //            StreamReader sr = new StreamReader(path, Encoding.Unicode);

        //            char[] seperator = new char[] { '\t' };
        //            string line;
        //            string[] split;
        //            while (!sr.EndOfStream)
        //            {
        //                line = sr.ReadLine();
        //                if (line.Contains("\t") && line != "" && !line.StartsWith("/") && !line.StartsWith("#"))
        //                {
        //                    split = line.Split(seperator);
        //                    if (split.Length > 2)
        //                    {
        //                        MainWindow.InstanceList.Add(split[0], " [" + split[1] + "] [" + split[2] + "] " + split[3] + "");
        //                        Map map = new Map();
        //                        map.name = split[3];
        //                        map.realName = split[2];
        //                        database.defaultMapsTemplate.Add(Int32.Parse(split[0]), map);
        //                    }
        //                    else
        //                    {
        //                        MainWindow.InstanceList.Add(split[0], split[1]);
        //                    }
        //                }
        //            }

        //            sr.Close();
        //        }
        //        catch (Exception e)
        //        {
        //            MessageBox.Show("ERROR LOADING INSTANCE LIST\n" + e.Message);
        //        }
        //    }
        //    else
        //    {
        //        MessageBox.Show("NOT FOUND localization:" + path + "!");
        //    }
        //    database.InstanceList = MainWindow.InstanceList;
        //}

        public void LoadBuffList()
        {
            if (database.buff_str != null)
            {
                MainWindow.buff_str = database.buff_str;
                return;
            }
            string path = Path.GetDirectoryName(Application.ExecutablePath) + "\\resources\\data\\buff_str.txt";
            if (File.Exists(path))
            {
                try
                {
                    StreamReader sr = new StreamReader(path, Encoding.Unicode);
                    MainWindow.buff_str = sr.ReadToEnd().Split(new char[] { '\"' });
                    string[] temp = MainWindow.buff_str[0].Split(new char[] { '\n' });
                    MainWindow.buff_str[0] = temp[temp.Length - 1];

                    sr.Close();
                }
                catch (Exception e)
                {
                    MessageBox.Show("ERROR LOADING BUFF LIST\n" + e.Message);
                }
            }
            else
            {
                MessageBox.Show("NOT FOUND localization\\buff_str.txt!");
            }
            database.buff_str = MainWindow.buff_str;
        }
    }
}
