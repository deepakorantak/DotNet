using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst
{
    public class Flight
    {
        public Flight()
        {
            this.Tickets = new HashSet<Ticket>();
        }
        public int flightID { get; set; }
        public string originCity { get; set; }
        public string  destinationCity { get; set; }
        public DateTime startTime { get; set; }
        public DateTime endTime { get; set; }

        public FlightCode FlightCode { get; set; }

        public ICollection<Ticket> Tickets { get; set; }
    }
}
