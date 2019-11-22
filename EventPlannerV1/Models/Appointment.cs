using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPlannerV1.Models
{
    /// <summary>
    /// Inherits Event class
    /// </summary>
    class Appointment :Event
    {
        [MaxLength(100)]
        public String Location { get; set; }

        public Contact Contact { get; set; }

    }
}
