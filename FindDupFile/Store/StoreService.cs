using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FindDupFile.Store
{
    public class StoreService
    {
        private StoreDbContext db;

        public StoreService()
        {
            this.db = new StoreDbContext();
            this.CreateDBOrNotExists();
        }

        public void CreateDBOrNotExists()
        {
            this.db.SFileInfos.FirstOrDefault();
        }
        
        public void AddFileInfoIfNotExists(IList<ScanFileInfo> scanFileInfos)
        {
            foreach(var item in scanFileInfos)
            {
                var fileName = Path.GetFileName(item.Path).ToUpper();
                var dbfileInfo = this.db.SFileInfos.SingleOrDefault(x => x.Path == item.Path);
                if (dbfileInfo != null)
                {
                    if (dbfileInfo.Size == item.Size &&
                       dbfileInfo.MD5 == item.MD5)
                        continue;

                    dbfileInfo.Size = item.Size;
                    dbfileInfo.MD5 = item.MD5;
                    continue;
                }

                var sfileInfo = new SFileInfo();

                sfileInfo.Id = Guid.NewGuid().ToString().ToUpper();
                sfileInfo.Path = item.Path.ToUpper();
                sfileInfo.DirPath = Path.GetDirectoryName(item.Path).ToUpper();
                sfileInfo.Ext = Path.GetExtension(item.Path).ToUpper();
                sfileInfo.MD5 = item.MD5.ToUpper();
                sfileInfo.FileName = Path.GetFileName(item.Path).ToUpper();
                sfileInfo.Size = FileHelper.HumanReadableFilesize(item.Path);

                this.db.SFileInfos.Add(sfileInfo);
            }

            this.db.SaveChanges();
        }

        public string GetFileMD5(string filename)
        {
            filename = filename.ToUpper();

            if (!File.Exists(filename))
                return "FILE_NOT_EXISTS";

            var sfileInfo = this.db.SFileInfos
                .SingleOrDefault(x => x.Path == filename);
            if (sfileInfo != null)
                return sfileInfo.MD5;

            return MD5Helper.GetMD5HashFromFile(filename);
        }
    }
}
