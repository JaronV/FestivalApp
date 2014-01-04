using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FestivalApp.View;
using System.Collections.ObjectModel;
using FestivalLib.Model;
using GalaSoft.MvvmLight.Command;
using System.Windows.Input;
using System.Windows.Forms;

namespace FestivalApp.ViewModel
{
    class TicketVM : ObservableObject, IPage
    {
        public TicketVM()
        {
            _tickettypes = TicketType.GetTicketType();
           _tickets = FestivalLib.Model.Ticket.GetTickets();
           _uniekeDagen = Festival.aantalDagen();
           //if (Festival.DatumsAanwezig())
           //{
           //    Festival Festi = Festival.GetData();
           //    beginDatum = Festi.StartDate;
           //    eindeDatum = Festi.EndDate;
           //}
        }
        public string Name
        {
              
            get
            {
                return "Ticketing"; //hier geven we de exacte naam van de usercontrol terug
            }
           
        }
        #region tickettype gedeelte
        private ObservableCollection<TicketType> _tickettypes = new ObservableCollection<TicketType>();

        private TicketType _selectedType;

        public TicketType SelectedTicketType
        {
            get { return _selectedType; }
            set { _selectedType = value; OnPropertyChanged("SelectedTicketType"); }
        }

        public ObservableCollection<TicketType> Tickettypes
        {
            get { return _tickettypes; }
            set { _tickettypes = value; OnPropertyChanged("Tickettypes"); }
        }

        //Tickettype commands
        public ICommand AddTickettypeCommand
        {
            get
            {
                return new RelayCommand(AddTickettype);
            }
        }
        public ICommand SaveTickettypeCommand
        {
            get
            {
                return new RelayCommand(SaveTickettype);
            }
        }
        public ICommand DeleteTickettypeCommand
        {
            get
            {
                return new RelayCommand(DeleteTickettype);
            }
        }

        //Tickettype methods
        public void AddTickettype()
        {
            TicketType newType = new TicketType();
            Tickettypes.Add(newType);

            SelectedTicketType = newType;

        }
        public void SaveTickettype()
        {
            TicketType.AddType(SelectedTicketType);
        }
        public void DeleteTickettype()
        {
            TicketType.DeleteType(SelectedTicketType);
            Tickettypes.Remove(SelectedTicketType);
        }
        #endregion

        #region Ticketgedeelte
        private ObservableCollection<DateTime> _uniekeDagen;

        public ObservableCollection<DateTime> UniekeDagen
        {
            get { return _uniekeDagen; }
            set { _uniekeDagen = value; OnPropertyChanged("UniekeDagen"); }
        }
        
        private ObservableCollection<FestivalLib.Model.Ticket> _tickets = new ObservableCollection<FestivalLib.Model.Ticket>();

        public ObservableCollection<FestivalLib.Model.Ticket> Tickets
        {
            get { return _tickets; }
            set { _tickets = value; OnPropertyChanged("Tickets"); }
        }
        private FestivalLib.Model.Ticket _selectedTicket;

        public FestivalLib.Model.Ticket SelectedTicket
        {
            get { return _selectedTicket; }
            set { _selectedTicket = value; OnPropertyChanged("SelectedTicket"); }
        }


        //ticket Commands
        public ICommand AddTicketCommand
        {
            get
            {
                return new RelayCommand(AddTicket);
            }
        }
        public ICommand SaveTicketCommand
        {
            get
            {
                return new RelayCommand(SaveTicket/*, SaveValidBand*/);
            }
        }    
        public ICommand DeleteTicketCommand
        {
            get
            {
                return new RelayCommand(DeleteTicket);
            }
        }
        public ICommand EditTicketCommand
        {
            get
            {
                return new RelayCommand(EditTicket);
            }
        }
        public ICommand EditTicketTypeCommand
        {
            get
            {
                return new RelayCommand(EditTicketType);
            }
        }

        private void EditTicketType()
        {
            TicketType.EditTicket(SelectedTicketType);
        }
        private void AddTicket()
        {
            FestivalLib.Model.Ticket nieuw = new FestivalLib.Model.Ticket();
            Tickets.Add(nieuw);

            SelectedTicket = nieuw;

        }

        private void SaveTicket()
        {
            if (SaveValidTicket())
            {
                FestivalLib.Model.Ticket.AddType(SelectedTicket);
                Tickets = FestivalLib.Model.Ticket.GetTickets();
            }
            else { MessageBox.Show("zijn alle velden correct aangevuld?"); }
        }

        private void DeleteTicket()
        {
            FestivalLib.Model.Ticket.DeleteType(SelectedTicket);
            Tickets.Remove(SelectedTicket);
        }
        private void EditTicket()
        {
            FestivalLib.Model.Ticket.EditTicket(SelectedTicket);
        }
        #endregion
        private bool SaveValidTicket()
        {
            if (SelectedTicket != null)
            {
                return SelectedTicket.IsValid();
            }
            else return false;
        }

        private bool SaveValidTicketType()
        {
            if (SelectedTicketType != null)
            {
                return SelectedTicketType.IsValid();
            }
            else return false;
        }
        public ICommand PrintTicketCommand
        {
            get { return new RelayCommand(PrintTicket); }
        }

        private void PrintTicket()
        {
            FestivalLib.Model.Ticket ticket = SelectedTicket;
            Festival festival = Festival.GetData();
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            DialogResult result = fbd.ShowDialog();
            if (result == DialogResult.OK)
            {
                string sPad = fbd.SelectedPath;
                FestivalLib.Model.Ticket.PrintWord(ticket, festival, sPad);
            }
        }
    }
}
