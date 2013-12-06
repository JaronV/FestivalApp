using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FestivalApp.Model
{
    class Ticket
    {
        public String ID { get; set; }
        public String Ticketholder { get; set; }
        public String TicketholderEmail { get; set; }
        public TicketType tickettype { get; set; }
        public int Amount { get; set; }
    }
}
