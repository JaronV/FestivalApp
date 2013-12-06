using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FestivalApp.View;
namespace FestivalApp.ViewModel
{
    class TicketVM : ObservableObject, IPage
    {
        public string Name
        {
              
            get
            {
                return "Ticket"; //hier geven we de exacte naam van de usercontrol terug
            }
           
        }

        public string _test;
        public string Test
        {
            get
            {
                return _test;
            }
            set { _test = value;
            OnPropertyChanged("Test");
            }
        }
      
    }
}
