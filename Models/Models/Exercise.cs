using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Models
{
    [Table("exercises")]
    public class Exercise
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("file_id")]
        public int FileId { get; set; }

        [Required]
        [Column("title")]
        public string Title { get; set; }

        [Required]
        [Column("description")]
        public string Description { get; set; }
    }
}
