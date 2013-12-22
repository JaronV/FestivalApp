using FestivalLib.Model;
using SSA_Festival.Models;
using SSA_Festival.Models._DAL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SSA_Festival.Controllers
{
    public class TicketController : Controller
    {
        //
        // GET: /Ticket/

        //public ActionResult Index()
        //{
        //    return View();
        //}

      //  [Authorize(Roles = "Registered, Admin")]
        public ActionResult Reserveer()
        {
            TicketTypeVM vm = new TicketTypeVM();
            vm.lstTypes = new SelectList(TicketRepository.GetTicketTypes().ToList(), "ID", "Name");
            return View("Reserveer", vm);
        }

        [HttpPost]
        public ActionResult Insert(TicketTypeVM vm)
        {
            Ticket ticket = vm.Ticket;
            ticket.tickettype = TicketType.GetTicketTypeByID(vm.SelectedType);
            TicketRepository.ReserveerTicket(vm.Ticket);
            return RedirectToAction("Index", "Home");
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Summary()
        {
            ObservableCollection<Ticket> lstAlleTickets = TicketRepository.GetAllTickets();
            return View(lstAlleTickets);
        }
    }
}
