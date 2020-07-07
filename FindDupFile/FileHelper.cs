using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindDupFile
{
    public class FileHelper
    {
        public static string HumanReadableFilesize(string path)
        {
            var size = Convert.ToDouble(new FileInfo(path).Length);
            return HumanReadableFilesize(size);
        }

        public static string HumanReadableFilesize(double size)
        {
            string[] units = new string[] { "B", "KB", "MB", "GB", "TB", "PB" };
            double mod = 1024.0;
            int i = 0;
            while (size >= mod)
            {
                size /= mod;
                i++;
            }
            return Math.Round(size) + units[i];

        }
    }
}
