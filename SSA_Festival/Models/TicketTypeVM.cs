using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FestivalLib.Model;
using System.Web.Mvc;
namespace SSA_Festival.Models
{
    public class TicketTypeVM
    {
        public Ticket Ticket { get; set; }
        public int SelectedType { get; set; }
        public SelectList lstTypes { get; set; }
    }
}