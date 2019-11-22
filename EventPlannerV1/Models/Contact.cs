using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPlannerV1.Models
{
    public class Contact
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ContactId { get; set; }

        [Required]
        [MaxLength(200)]
        public String Name { get; set; }
        [MaxLength(100)]
        [DataType(DataType.EmailAddress)]
        public String Email { get; set; }
        [MaxLength(200)]
        public String Address { get; set; }
        [MaxLength(50)]
        [DataType(DataType.PhoneNumber)]
        public String TelNo { get; set; }
        [MaxLength(500)]
        public String Note { get; set; }

        public User User { get; set; }

    }
}
