using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPlannerV1.Models
{
    public abstract class Event
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EventId { get; set; }

        [Required]
        [MaxLength(50)]
        public String EventTitle { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime StartDateTime { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime EndDateTime { get; set; }
        //[Required]
        //[MaxLength(50)]
        //public String EventType { get; set; }
        // Discriminator column is a auto-gen column which will determine
        // if the Event is a task or an appointment
        [Required]
        public bool Recurr { get; set; }
        [MaxLength(500)]
        public String EventNote { get; set; }

        public int UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public User User { get; set; }

    }
}
