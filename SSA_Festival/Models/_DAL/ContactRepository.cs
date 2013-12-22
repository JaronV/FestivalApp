using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;
using FestivalLib.Model;
namespace SSA_Festival.Models._DAL
{
    public class ContactRepository
    {
        public static ObservableCollection<Contactperson> GetContacts()
        {
            ObservableCollection<Contactperson> lstContacts = new ObservableCollection<Contactperson>();
            lstContacts = Contactperson.GetContactPersonType();
            return lstContacts;
        }
    }
}