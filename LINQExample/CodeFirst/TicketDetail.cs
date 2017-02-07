using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst
{
    public class TicketDetail
    {
        [Key, ForeignKey("Ticket")]
        [Column(Order = 1)]
        public string ticketID { get; set; }
        [Key]
        [Column(Order = 2)]
        public string pnr { get; set; }
        [ForeignKey("Passenger")]
        public int passengerID { get; set; } 
        public virtual Ticket Ticket { get; set; }
        public virtual Passenger Passenger { get; set; }
    }
}
