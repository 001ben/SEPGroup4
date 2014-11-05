using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FileManagerNs.Models
{
    [Table("ApplicationDbFiles")]
    public class ApplicationDbFiles
    {
        [Key]
        public int ApplicationDbFilesId { get; set; }
        public int ApplicationID { get; set; }

        public virtual ICollection<ApplicationDbFile> Files { get; set; }
    }
}