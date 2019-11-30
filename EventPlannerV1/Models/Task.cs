using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPlannerV1.Models
{
    /// <summary>
    /// Inherits Event class
    /// </summary>
    public class Task: Event
    {

        //public int UserId { get; set; }
        //[ForeignKey(nameof(UserId))]
        //public User User { get; set; }
    }
}
