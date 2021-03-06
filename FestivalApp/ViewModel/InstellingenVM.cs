﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FestivalLib.Model;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight.Command;
using System.Windows.Input;
using System.Windows.Forms;

namespace FestivalApp.ViewModel
{
    class InstellingenVM : ObservableObject, IPage
    {

        public InstellingenVM()
        {
            
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
        
        private ObservableCollection<ContactpersonType> _contactPersonTypes = new ObservableCollection<ContactpersonType>();
        private ObservableCollection<Genre> _genres = new ObservableCollection<Genre>();
        private ObservableCollection<Stage> _podiums = new ObservableCollection<Stage>();
       
        #region "selected velden listbox"
        private DateTime beginDatum =  DateTime.Today;

        public DateTime BeginDatum
        {
            get { return beginDatum; }
            set { beginDatum = value ; OnPropertyChanged("BeginDatum"); }
        }
        private DateTime eindDatum = DateTime.Today;
    
        public DateTime EindDatum
        {
            get { return eindDatum;  }
            set { eindDatum = value; OnPropertyChanged("EindDatum"); }
        }
        private String festivalNaam;

        public String FestivalNaam
        {
            get { return festivalNaam; }
            set { festivalNaam = value; OnPropertyChanged("FestivalNaam"); }
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

        public ICommand EditGenreCommand
        {
            get
            {
                return new RelayCommand(EditGenre);
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

        public ICommand EditStageCommand
        {
            get
            {
                return new RelayCommand(EditStage);
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

        public ICommand EditContactPersonTypeCommand
        {
            get
            {
                return new RelayCommand(Editcp);
            }
        }
        public ICommand AddFestivalCommand
        {
            get
            {
                return new RelayCommand(AddFestival);
            }
        }
    



        #endregion
        private bool SaveValidStage()
        {
            if (SelectedStage != null)
            {
                return SelectedStage.IsValid();
            }
            else return false;
        }
        private bool SaveValidGenre()
        {
            if (SelectedGenre != null)
            {
                return SelectedGenre.IsValid();
            }
            else return false;
        }
        private bool SaveValidType()
        {
            if (SelectedContactPerson != null)
            {
                return SelectedContactPerson.IsValid();
            }
            else return false;
        }
        private void AddFestival()
        {
            Festival.DeleteType();
          
            //DateTime.Today.ToString("yyyy-MM-dd")
            string begin = BeginDatum.ToString("yyyy-dd-MM");
            string einde = EindDatum.ToString("yyyy-dd-MM");

            Festival festi = new Festival();
            festi.StartDate = BeginDatum;
            festi.EndDate = EindDatum;
            festi.Naam = FestivalNaam;
            Festival.AddType(festi);
            
        }

        //Stage methods

        public void AddStage()
        {
            Stage newStage = new Stage();
            Podiums.Add(newStage);

            SelectedStage = newStage;
        }
        public void SaveStage()
        {
            if (SaveValidStage())
            {
                Stage.AddType(SelectedStage);
                Podiums = Stage.GetStages();
            }
            else { MessageBox.Show("zijn alle velden correct aangevuld?"); }
        }
        public void DeleteStage()
        {
            if (SelectedStage != null)
            {
                if (SelectedStage.ID != 0)
                {
                    Stage.DeleteType(SelectedStage);
                    Podiums.Remove(SelectedStage);
                }
                else
                {
                    MessageBox.Show("dit is een ongeldige actie");
                }

            }
            else
            {
                MessageBox.Show("Gelieve eerst een Item te selecteren");
            }
            
        }
        private void EditStage()
        {
            if (SelectedStage != null)
            {
                if (SelectedStage.ID != 0)
                {
                    Stage.EditStage(SelectedStage);
                }
                else
                {
                    MessageBox.Show("dit is een ongeldige actie");
                }

            }
            else
            {
                MessageBox.Show("Gelieve eerst een Item te selecteren");
            }
          
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
            if (SaveValidGenre())
            {
                Genre.AddType(SelectedGenre);
                Genres = Genre.GetGenres();
            }
            else { MessageBox.Show("zijn alle velden correct aangevuld?"); }
        }
        private void DeleteGenre()
        {
            if (SelectedGenre != null)
            {
                if (SelectedGenre.ID != 0)
                {
                    Genre.DeleteType(SelectedGenre);
                    Genres.Remove(SelectedGenre);
                    Genres = Genre.GetGenres();
                }
                else
                {
                    MessageBox.Show("dit is een ongeldige actie");
                }

            }
            else
            {
                MessageBox.Show("Gelieve eerst een Item te selecteren");
            }

            
        }
        private void EditGenre()
        {
            if (SelectedGenre != null)
            {
                if (SelectedGenre.ID != 0)
                {
                    Genre.EditGenre(SelectedGenre);
                }
                else
                {
                    MessageBox.Show("dit is een ongeldige actie");
                }

            }
            else
            {
                MessageBox.Show("Gelieve eerst een Item te selecteren");
            }
         
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
            if (SaveValidType())
            {
                ContactpersonType.AddType(SelectedContactPerson);
                ContactPersonTypes = ContactpersonType.GetContactPersonType();
            }
            else { MessageBox.Show("zijn alle velden correct aangevuld?"); }
        }
        private void DeleteContactPerson()
        {
            if (SelectedContactPerson != null)
            {
                if (SelectedContactPerson.ID != 0)
                {
                    ContactpersonType.DeleteType(SelectedContactPerson);
                    ContactPersonTypes.Remove(SelectedContactPerson);
                    ContactPersonTypes = ContactpersonType.GetContactPersonType();

                }
                else
                {
                    MessageBox.Show("dit is een ongeldige actie");
                }

            }
            else
            {
                MessageBox.Show("Gelieve eerst een Item te selecteren");
            }
         
      
        }
        private void Editcp()
        {
            if (SelectedContactPerson != null)
            {
                if (SelectedContactPerson.ID != 0)
                {
                    ContactpersonType.Editct(SelectedContactPerson);

                }
                else
                {
                    MessageBox.Show("dit is een ongeldige actie");
                }

            }
            else
            {
                MessageBox.Show("Gelieve eerst een Item te selecteren");
            }
         
           
        }

        
    }
}
