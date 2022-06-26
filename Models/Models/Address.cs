using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Models
{
    [Table("addresses")]
    public class Address
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("street")]
        public string Street { get; set; }

        [Required]
        [Column("country")]
        public string Country { get; set; }

        [Required]
        [Column("city")]
        public string City { get; set; }

        [Required]
        [Column("province")]
        public string Province { get; set; }

        [Required]
        [Column("postal_code")]
        public string PostalCode { get; set; }
    }
}
