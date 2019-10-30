using System;
using System.IO;

namespace SharkShield.classes.oops
{
    public static class FileLog
    {
        public static void write(string msg)
        {
            File.AppendAllText("log.txt", msg + Environment.NewLine);
        }

    }
}
