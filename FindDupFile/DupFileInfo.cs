using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindDupFile
{
    public class DupFileInfo : ScanFileInfo
    {
        public int DupCount { get; set; }

        public override string ToString()
        {
            return string.Format($"[{this.DupCount}]{this.Path}");
        }
    }
}
