using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Models
{
    [Table("pi_servers")]
    public class PiServer
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("serial_number")]
        public string SerialNumber { get; set; }

        [Required]
        [Column("model")]
        public string Model { get; set; }

        [Required]
        [Column("license_id")]
        public string LicenseId { get; set; }

        [Required]
        [Column("status_id")]
        public int StatusId { get; set; }

        [Required]
        [Column("specification")]
        public string Specification { get; set; }
    }
}
