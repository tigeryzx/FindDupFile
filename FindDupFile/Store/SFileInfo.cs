using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindDupFile.Store
{
    [Table("SFileInfo")]
    public class SFileInfo
    {
        [Key]
        public string Id { get; set; }

        public string DirPath { get; set; }

        public string Path { get; set; }

        public string FileName { get; set; }

        public string Ext { get; set; }

        public string Size { get; set; }

        public string MD5 { get; set; }
    }
}
