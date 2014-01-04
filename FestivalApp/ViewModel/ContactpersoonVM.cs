using FestivalLib.Model;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FestivalApp.ViewModel
{
    class ContactpersoonVM : ObservableObject, IPage
    {
        public string Name
        {
            get
            {
                return "Contactpersoon"; //hier geven we de exacte naam van de usercontrol terug
            }
        }

        public ContactpersoonVM()
        {
           _contactPersons = Contactperson.GetContactPersonType();
            _jobroles = ContactpersonType.GetContactPersonType();
        }

        #region fields
        private ObservableCollection<Contactperson> _contactPersons = new ObservableCollection<Contactperson>();
        private ObservableCollection<ContactpersonType> _jobroles = new ObservableCollection<ContactpersonType>();

        public ObservableCollection<ContactpersonType> Jobroles
        {
            get { return _jobroles; }
            set { _jobroles = value; }
        }

        public ObservableCollection<Contactperson> ContactPersons
        {
            get { return _contactPersons; }
            set { _contactPersons = value; OnPropertyChanged("ContactPersons"); }
        }
        private ObservableCollection<Contactperson> _gefilterdeContacts;

        public ObservableCollection<Contactperson> GefilterdeContacts
        {
            get { return _gefilterdeContacts; }
            set { _gefilterdeContacts = value; OnPropertyChanged("GefilterdeContacts"); }
        }    
        #endregion

        #region "selected veld"
        private Contactperson _selectedContactPersoon;

        public Contactperson SelectedContactPersoon
        {
            get { return _selectedContactPersoon; }
            set { _selectedContactPersoon = value; OnPropertyChanged("SelectedContactPersoon"); }
        }
        #endregion

        #region commands

        public ICommand AddContactPersonCommand
        {
            get
            {
                return new RelayCommand(AddContactPerson);
            }
        }
  
        public ICommand SaveContactPersonCommand
        {
            get
            {
                return new RelayCommand(SaveContactPerson);
            }
        }

      

        public ICommand DeleteContactPersonCommand
        {
            get
            {
                return new RelayCommand(DeleteContactPerson);
            }
        }
        public ICommand EditContactPersonCommand
        {
            get
            {
                return new RelayCommand(EditContact);
            }
        }
        


        #endregion
        //methods
        private void AddContactPerson()
        {
            Contactperson person = new Contactperson();
            ContactPersons.Add(person);
            SelectedContactPersoon = person;
        }

        private void SaveContactPerson()
        {
            Contactperson.AddType(SelectedContactPersoon);
            ContactPersons = Contactperson.GetContactPersonType();
        }

        private void DeleteContactPerson()
        {
            Contactperson.DeleteType(SelectedContactPersoon);
            ContactPersons.Remove(SelectedContactPersoon);
        }
        private void EditContact()
        {
            Contactperson.EditCp(SelectedContactPersoon);
        }
        //public ICommand SearchCommand
        //{

        //    get { return new RelayCommand<string>(Search); }
        //}
        //private void Search(string str)
        //{
        //    Console.WriteLine(str);
        //    GefilterdeContacts = Contactperson.GetContactsByString(Contacts, str);
        //}
    }
}
