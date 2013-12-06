using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FestivalApp.ViewModel
{
    //elke viewmodel-klasse laten erven van de klasse ObservableObject, de interface Ipage implementeren
    class MainPageVM : ObservableObject, IPage
    {
        //deze property MOET uitgewerkt zijn omwille van de interface IPage
        public string Name
        {
            get
            {
                return "Line Up"; //hier geven we de exacte naam van de usercontrol terug
            }
        }
    }
}
