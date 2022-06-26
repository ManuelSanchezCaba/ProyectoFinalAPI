using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Models
{
    [Table("institutions")]
    public class Institution
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("name")]
        public string Name { get; set; }

        [Required]
        [Column("phone")]
        public string Phone { get; set; }

        [Required]
        [Column("address_id")]
        public int AddressId { get; set; }

        [Required]
        [Column("website")]
        public string Website { get; set; }

        [Required]
        [Column("email")]
        [EmailAddress]
        public string email { get; set; }
    }
}
