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

        public string _Size;

        public string Size
        {
            get
            {
                if (string.IsNullOrEmpty(this._Size) && File.Exists(this.Path))
                    this._Size = FileHelper.HumanReadableFilesize(this.Path);
                else
                    this._Size = "NE";
                return this._Size;
            }
        }

        public override string ToString()
        {
            return this.Path;
        }
    }
}
