using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst
{
    public class Ticket
    {
        public Ticket()
        {
            this.TicketDetails = new HashSet<TicketDetail>();
        }
        public string ticketID { get; set; }
        public int flightID { get; set; }
        public DateTime travelDate  { get; set; }
        public DateTime bookingDate { get; set; }
        public int numberOfPassengers { get; set; }
        public double totalAmount { get; set; }
        public virtual Flight Flight { get; set; }

        public virtual ICollection<TicketDetail> TicketDetails { get; set; }
    }
}
