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
    //Dit is het hart van de applicatie
    class ApplicationVM : ObservableObject
    {

        public ApplicationVM()
        {
            _pages = new ObservableCollection<IPage>();

            //hieronder vul je deze collectie oop met ALLE viewmodel-klassen (die horen bij een usercontrol)
            _pages.Add(new MainPageVM());
            _pages.Add(new TicketVM());
            _pages.Add(new ContactpersoonVM());
            _pages.Add(new InstellingenVM());
            _pages.Add(new BandsVM());

            //bij het opstarten mag onmiddelijk al de eerste usercontrol worden getoond 
            CurrentPage = Pages[0];

        }

        //dit attribuut (en bijhordende property) houden de zichtbare usercontrol bij. Pas op, hieronder wordt in principe de ViewModel-klasse
        //(horende bij deze usercontrol bij gehouden)
        //De omzetting van ViewModel-klasse naar de juiste UserControl zit in MainWindow.xaml!
        private IPage _currentPage;
        public IPage CurrentPage
        {
            get
            {
                return _currentPage;
            }
            set
            {
                _currentPage = value;
                OnPropertyChanged("CurrentPage");
            }
        }

        private ObservableCollection<IPage> _pages;

        public ObservableCollection<IPage> Pages
        {
            get { return _pages; }
            set { _pages = value; OnPropertyChanged("Pages"); }
        }

        //deze methode wordt gebruikt door de buttons die op MainWindow zitten
        //deze buttons doen de getoonde usercontrols veranderen
        public ICommand ChangePageCommand
        {
            get { return new RelayCommand<IPage>(ChangePage); }
        }

        private void ChangePage(IPage page)
        {
            CurrentPage = page;
        }
    }
}
