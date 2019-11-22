using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPlannerV1.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        [Required]
        [MaxLength(50)]
        public String Username { get; set; }
        [Required]
        [MaxLength(200)]
        public String Name { get; set; }
        [Required]
        [MaxLength(50)]
        [DataType(DataType.Password)]
        public String Password { get; set; }

        //[DataType(DataType.Password)]
        //[Compare("Password")]
        //[NotMapped]
        //public string ConfirmPassword { get; set; }
    }
}
