using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Models
{
    [Table("sections_header")]
    public class SectionHeader
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("name")]
        public string Name { get; set; }

        [Required]
        [Column("institution_id")]
        public int InstitutionId { get; set; }

        [Required]
        [Column("subject_id")]
        public int SubjectId { get; set; }

        [Required]
        [Column("status_id")]
        public int StatusId { get; set; }
    }
}
