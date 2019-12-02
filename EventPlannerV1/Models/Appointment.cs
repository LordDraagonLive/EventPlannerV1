using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPlannerV1.Models
{
    /// <summary>
    /// Inherits Event class
    /// </summary>
    public class Appointment :Event
    {
        [MaxLength(100)]
        public String Location { get; set; }

        //public int UserId { get; set; }
        //[ForeignKey(nameof(UserId))]
        //public User User { get; set; }

        //[ForeignKey("Contact")]
        public int? ContactId { get; set; }
        [ForeignKey(nameof(ContactId))]
        public Contact Contact { get; set; }

    }
}
