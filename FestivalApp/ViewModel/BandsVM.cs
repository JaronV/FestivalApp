using FestivalApp.Model;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using FestivalApp.View;

namespace FestivalApp.ViewModel
{
    class BandsVM : ObservableObject, IPage
    {
   

        public string Name
        {
            get
            {
                return "Bands"; //hier geven we de exacte naam van de usercontrol terug
            }
        }

        public BandsVM()
        {
            _bands = Band.getBands();
            _genres = Genre.GetGenres();
          
        }
        #region fields
        private ObservableCollection<Band> _bands = new ObservableCollection<Band>();
        private ObservableCollection<Genre> _genres = new ObservableCollection<Genre>();
        private ObservableCollection<Genre> _huidigegenres = new ObservableCollection<Genre>();
        private Band _selectedBand;
        private Genre _selectedAlleGenre;
        private Genre _selectedHuidigeGenre;

        public ObservableCollection<Genre> Huidigegenres
        {
            get { return _huidigegenres; }
            set { _huidigegenres = value; OnPropertyChanged("Huidigegenres"); }
        }

        public ObservableCollection<Genre> Genres
        {
            get { return _genres; }
            set { _genres = value; OnPropertyChanged("Genres"); }
        }

        public ObservableCollection<Band> Bands
        {
            get { return _bands; }
            set { _bands = value; OnPropertyChanged("Bands"); }
        }
        public Genre SelectedAlleGenre
        {
            get { return _selectedAlleGenre; }
            set { _selectedAlleGenre = value; OnPropertyChanged("SelectedAlleGenre"); }
        }


        public Genre SelectedHuidigeGenre
        {
            get { return _selectedHuidigeGenre; }
            set { _selectedHuidigeGenre = value; OnPropertyChanged("SelectedHuidigeGenre"); }
        }

        public Band SelectedBand
        {
            get { return _selectedBand;  }
            set { _selectedBand = value; OnPropertyChanged("SelectedBand"); _huidigegenres = Genre.GetGenreByID(SelectedBand.ID); OnPropertyChanged("Huidigegenres"); }
        }

        #endregion

        public ICommand AddBandCommand
        {
            get
            {
                return new RelayCommand(AddBand);
            }
        }

        public ICommand SaveBandCommand
        {
            get
            {
                return new RelayCommand(SaveBand);
            }
        }

        public ICommand DeleteBandCommand
        {
            get
            {
                return new RelayCommand(DeleteBand);
            }
        }

        public ICommand VoegGenreToeCommand
        {
            get
            {
                return new RelayCommand(VoegGenreToe);
            }
        }
        public ICommand VerwijderGenreCommand
        {
            get
            {
                return new RelayCommand(VerwijderGenre);
            }
        }

   

        private void AddBand()
        {
            Band b = new Band();
            Bands.Add(b);
            SelectedBand = b;
        }

        private void SaveBand()
        {
            Band.AddType(SelectedBand, Huidigegenres);
        }

        private void DeleteBand()
        {
            Band.DeleteType(SelectedBand);
            Bands.Remove(SelectedBand);
        }
 
        private void VoegGenreToe()
        {
            Huidigegenres.Add(SelectedAlleGenre);

        }

        private void VerwijderGenre()
        {
            Huidigegenres.Remove(SelectedHuidigeGenre);
        }
        
        
        }
    }

