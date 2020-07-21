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
                if (File.Exists(this.Path))
                {
                    if (string.IsNullOrEmpty(this._Size))
                        this._Size = FileHelper.HumanReadableFilesize(this.Path);
                }
                else
                    this.Size = "NE";
                
                return this._Size;
            }
            set
            {
                this._Size = value;
            }
        }

        public override string ToString()
        {
            return this.Path;
        }
    }
}
