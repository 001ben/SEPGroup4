using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FileManagerNs.Models
{
    [Table("ApplicationDbFile")]
    public class ApplicationDbFile
    {
        [Key]
        public int ApplicationDbFileId { get; set; }

        [ForeignKey("ApplicationDbFiles")]
        public int ApplicationDbFilesId { get; set; }

        public virtual ApplicationDbFiles ApplicationDbFiles { get; set; }

        public byte[] Data { get; set; }
        public string FileName { get; set; }
        public string MimeType { get; set; }
    }
}