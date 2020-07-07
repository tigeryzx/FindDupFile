using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindDupFile
{
    public class ScanFileInfo
    {
        public string Path { get; set; }

        public string MD5 { get; set; }

        public string Size
        {
            get
            {
                return FileHelper.HumanReadableFilesize(this.Path);
            }
        }

        public override string ToString()
        {
            return this.Path;
        }
    }
}
