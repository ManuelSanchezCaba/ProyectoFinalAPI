using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Models
{
    [Table("licenses")]
    public class License
    {
        [Key]
        [Column("code")]
        public string Code { get; set; }

        [Required]
        [Column("institution_id")]
        public int InstitutionId { get; set; }

        [Required]
        [Column("status_id")]
        public int StatusId { get; set; }
    }
}
