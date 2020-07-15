using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindDupFile.Store
{
    public class StoreDbContext : DbContext
    {
        public StoreDbContext():
            base("fileDB")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<StoreDbContext, ContextMigrationConfiguration>(true));

        }

        public DbSet<SFileInfo> SFileInfos { get; set; }

    }
}
