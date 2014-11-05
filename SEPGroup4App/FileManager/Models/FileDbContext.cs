using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FileManagerNs.Models
{
    public class FileDbContext : DbContext
    {
        public FileDbContext()
            :base(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\brownben\Source\Repos\SEPGroup4\SEPGroup4App\FileManager\App_Data\FileDb.mdf;Integrated Security=True")
        {
        }

        public DbSet<ApplicationDbFiles> ApplicationFiles { get; set; }
        public DbSet<ApplicationDbFile> Files { get; set; }
    }
}