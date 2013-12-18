using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FestivalApp.View;
using System.Collections.ObjectModel;
using FestivalApp.Model;
using GalaSoft.MvvmLight.Command;
using System.Windows.Input;
namespace FestivalApp.ViewModel
{
    class TicketVM : ObservableObject, IPage
    {
        public TicketVM()
        {
            _tickettypes = TicketType.GetTicketType();
           _tickets = FestivalApp.Model.Ticket.GetTickets();
           if (Festival.DatumsAanwezig())
           {
               Festival Festi = Festival.GetData();
               beginDatum = Festi.StartDate;
               eindeDatum = Festi.EndDate;
           }
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
        private String beginDatum;

        public String BeginDatum
        {
            get { return beginDatum; }
            set { beginDatum = value; OnPropertyChanged("BeginDatum"); }
        }
        private String eindeDatum;

        public String EindeDatum
        {
            get { return eindeDatum; }
            set { eindeDatum = value; OnPropertyChanged("EindeDatum"); }
        }
        private ObservableCollection<FestivalApp.Model.Ticket> _tickets = new ObservableCollection<Model.Ticket>();

        public ObservableCollection<FestivalApp.Model.Ticket> Tickets
        {
            get { return _tickets; }
            set { _tickets = value; OnPropertyChanged("Tickets"); }
        }
        private FestivalApp.Model.Ticket _selectedTicket;

        public FestivalApp.Model.Ticket SelectedTicket
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

        private void AddTicket()
        {
            FestivalApp.Model.Ticket nieuw = new FestivalApp.Model.Ticket();
            Tickets.Add(nieuw);

            SelectedTicket = nieuw;

        }

        private void SaveTicket()
        {
            if (SaveValidBand())
            {
                FestivalApp.Model.Ticket.AddType(SelectedTicket);
            }
        }

        private void DeleteTicket()
        {
            FestivalApp.Model.Ticket.DeleteType(SelectedTicket);
            Tickets.Remove(SelectedTicket);
        }

        #endregion
        private bool SaveValidBand()
        {
            if (SelectedTicket != null)
            {
                return SelectedTicket.IsValid();
            }
            else return false;
        }
    }
}
