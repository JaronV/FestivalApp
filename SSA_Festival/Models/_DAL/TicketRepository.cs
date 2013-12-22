using FestivalLib.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;

namespace SSA_Festival.Models._DAL
{
    public class TicketRepository
    {
        public static void ReserveerTicket(Ticket ticket)
        {
            Ticket.AddType(ticket);
        }

        public static ObservableCollection<TicketType> GetTicketTypes()
        {
            ObservableCollection<TicketType> lstAlleTicketTypes = TicketType.GetTicketType();
            return lstAlleTicketTypes;
        }

        public static ObservableCollection<Ticket> GetAllTickets()
        {
            ObservableCollection<Ticket> lst = Ticket.GetTickets();
            return lst;
        }
    }
}