using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FestivalApp.Model;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight.Command;
using System.Windows.Input;

namespace FestivalApp.ViewModel
{
    class InstellingenVM : ObservableObject, IPage
    {

        public InstellingenVM()
        {
            _tickettypes = TicketType.GetTicketType();
            _contactPersonTypes = ContactpersonType.GetContactPersonType();
            _genres = Genre.GetGenres();
            _podiums = Stage.GetStages();

            
        }
        public string Name
        {
            get
            {
                return "Instellingen"; //hier geven we de exacte naam van de usercontrol terug
            }
        }
        private ObservableCollection<TicketType>_tickettypes = new ObservableCollection<TicketType>();
        private ObservableCollection<ContactpersonType> _contactPersonTypes = new ObservableCollection<ContactpersonType>();
        private ObservableCollection<Genre> _genres = new ObservableCollection<Genre>();
        private ObservableCollection<Stage> _podiums = new ObservableCollection<Stage>();
       
        #region "selected velden listbox"


        private TicketType _selectedType;

        public TicketType SelectedTicketType
        {
            get { return _selectedType; }
            set { _selectedType = value; OnPropertyChanged("SelectedTicketType"); }
        }

        private ContactpersonType _selectedContactPerson;

        public ContactpersonType SelectedContactPerson
        {
            get { return _selectedContactPerson; }
            set { _selectedContactPerson = value; OnPropertyChanged("SelectedContactPerson"); }
        }

        private Genre _selectedGenre;

        public Genre SelectedGenre
        {
            get { return _selectedGenre; }
            set { _selectedGenre = value; OnPropertyChanged("SelectedGenre"); }
        }

        private Stage _selectedStage;

        public Stage SelectedStage
        {
            get { return _selectedStage; }
            set { _selectedStage = value; OnPropertyChanged("SelectedStage"); }
        }

        #endregion

        #region "fields"
        public ObservableCollection<TicketType> Tickettypes
        {
          get { return _tickettypes; }
            set { _tickettypes = value; OnPropertyChanged("Tickettypes"); }
        }

        public ObservableCollection<ContactpersonType> ContactPersonTypes
        {
            get { return _contactPersonTypes; }
            set { _contactPersonTypes = value; OnPropertyChanged("ContactPersonTypes"); }
        }
        public ObservableCollection<Stage> Podiums
        {
            get { return _podiums; }
            set { _podiums = value; OnPropertyChanged("Podiums"); }
        }
        public ObservableCollection<Genre> Genres
        {
            get { return _genres; }
            set { _genres = value; OnPropertyChanged("Genres"); }
        }

        #endregion

        #region commands
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

        //GenreCommands
        public ICommand AddGenreCommand
        {
            get
            {
                return new RelayCommand(AddGenre);
            }
        }      
        public ICommand SaveGenreCommand
        {
            get
            {
                return new RelayCommand(SaveGenre);
            }
        }

      
        public ICommand DeleteGenreCommand
        {
            get
            {
                return new RelayCommand(DeleteGenre);
            }
        }
        //Podium command
        public ICommand AddStageCommand
        {
            get
            {
                return new RelayCommand(AddStage);
            }
        }
        public ICommand SaveStageCommand
        {
            get
            {
                return new RelayCommand(SaveStage);
            }
        }


        public ICommand DeleteStageCommand
        {
            get
            {
                return new RelayCommand(DeleteStage);
            }
        }


        //Podium command
        public ICommand AddContactPersonTypeCommand
        {
            get
            {
                return new RelayCommand(AddContactPersonType);
            }
        }

       
        public ICommand SaveContactPersonTypeCommand
        {
            get
            {
                return new RelayCommand(SaveContactPersonType);
            }
        }

    

        public ICommand DeleteContactPersonTypeCommand
        {
            get
            {
                return new RelayCommand(DeleteContactPerson);
            }
        }

        

        #endregion
        //Stage methods

        public void AddStage()
        {
            Stage newStage = new Stage();
            Podiums.Add(newStage);

            SelectedStage = newStage;
        }
        public void SaveStage()
        {
            Stage.AddType(SelectedStage); 
        }
        public void DeleteStage()
        {
            Stage.DeleteType(SelectedStage);
            Podiums.Remove(SelectedStage);
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

        //Genre methods
        private void AddGenre()
        {
            Genre newGenre = new Genre();
            Genres.Add(newGenre);

            SelectedGenre = newGenre;
        }
        private void SaveGenre()
        {
            Genre.AddType(SelectedGenre);  
        }
        private void DeleteGenre()
        {
            Genre.DeleteType(SelectedGenre);
            Genres.Remove(SelectedGenre);
        }
        //ContactpersonType methods

        private void AddContactPersonType()
        {
            ContactpersonType NewType = new ContactpersonType();
            ContactPersonTypes.Add(NewType);

            SelectedContactPerson = NewType;
        }

        private void SaveContactPersonType()
        {
            ContactpersonType.AddType(SelectedContactPerson); 
        }

        private void DeleteContactPerson()
        {
            ContactpersonType.DeleteType(SelectedContactPerson);
            ContactPersonTypes.Remove(SelectedContactPerson);
        }
    }
}
