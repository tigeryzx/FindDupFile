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
        private List<SFileInfo> DBFileInfoCache = new List<SFileInfo>();

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
                var dbfileInfo = this.DBFileInfoCache.SingleOrDefault(x => x.Path == item.Path.ToUpper());
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
            var dirPath = Path.GetDirectoryName(filename).ToUpper();

            if (!File.Exists(filename))
                return "FILE_NOT_EXISTS";

            // 先从缓存取，缓存没有加载目录下所有文件信息，若再没有生成MD5
            SFileInfo sfileInfo = this.DBFileInfoCache
                .SingleOrDefault(x => x.Path == filename);

            if (sfileInfo == null && this.DBFileInfoCache.Count(x => x.DirPath.StartsWith(dirPath)) <= 0)
            {
                this.DBFileInfoCache.AddRange(this.db.SFileInfos
                   .Where(x => x.DirPath == dirPath));
            }

            sfileInfo = this.DBFileInfoCache
                .SingleOrDefault(x => x.Path == filename);

            if (sfileInfo != null)
                return sfileInfo.MD5;

            return MD5Helper.GetMD5HashFromFile(filename);
        }

        public void ClearCache()
        {
            this.DBFileInfoCache.Clear();
        }
    }
}
