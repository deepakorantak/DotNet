using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst
{
    public class FlightCode
    {
        [Key, ForeignKey("Flight")]
        public int flightID { get; set; }
        public string flightCode { get; set; }
        public string airLines { get; set; }
        public virtual Flight Flight { get; set; }

    }
}
