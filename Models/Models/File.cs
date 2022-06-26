using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Models
{
    [Table("file")]
    public class File
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("name")]
        public string Name { get; set; }

        [Required]
        [Column("size")]
        public double Size { get; set; }

        [Required]
        [Column("extension")]
        public string Extension { get; set; }

        [Required]
        [Column("path")]
        public string Path { get; set; }
    }
}
