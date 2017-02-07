using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst
{
    public class Passenger
    {

        public Passenger()
        {
            this.TicketDetails = new HashSet<TicketDetail>();
        }
        public int passengerID { get; set; }
        public string name { get; set; }
        public string contact { get; set; }
        public string emailAddress { get; set; }
        public DateTime dateOfBirth { get; set; }

        public virtual ICollection<TicketDetail> TicketDetails { get; set; }
    }
}
