using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Models
{
    [Table("sections_details")]
    public class SectionDetail
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("section_id")]
        public int SectionId { get; set; }

        [Required]
        [Column("user_id")]
        public int UserId { get; set; }
    }
}
