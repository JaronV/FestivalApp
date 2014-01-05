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
using FestivalLib.Model;
using System.IO;
using System.Windows;
using Microsoft.Win32;

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
          _imageSource = convertStringToByte("../../content/images/blank.jpg");
        }
        #region fields
        private ObservableCollection<Band> _bands = new ObservableCollection<Band>();
        private ObservableCollection<Genre> _genres = new ObservableCollection<Genre>();
        private ObservableCollection<Genre> _huidigegenres = new ObservableCollection<Genre>();
        private Band _selectedBand;
        private Genre _selectedAlleGenre;
        private Genre _selectedHuidigeGenre;
        private Band band;
        private byte[] _imageSource;

        public byte[] ImageSource
        {
            get { return _imageSource; }
            set { _imageSource = value; OnPropertyChanged("ImageSource"); }
        }
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
            set { _selectedBand = value;
                OnPropertyChanged("SelectedBand"); _huidigegenres = Genre.GetGenreByID(SelectedBand.ID);
                OnPropertyChanged("Huidigegenres"); band = SelectedBand;
                if (SelectedBand.Picture != null && SelectedBand.Picture.Length > 6)
                {
                    ImageSource = SelectedBand.Picture;
                }
                else
                {
                    ImageSource = convertStringToByte("../../content/images/blank.jpg");
                    SelectedBand.Picture = ImageSource;
                }
            }
        }

        #endregion
        #region commands
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
        public ICommand OpenImageCommand
        {
            get { return new RelayCommand(setImage); }
        }
        public ICommand EditBandCommand
        {
            get { return new RelayCommand(EditBand); }
        }
        #endregion

        private bool SaveValidBand()
        {
            if (SelectedBand != null)
            {
                return SelectedBand.IsValid();
            }
            else return false;
        }
        private void setImage()
        {
            Microsoft.Win32.OpenFileDialog ofd = new Microsoft.Win32.OpenFileDialog();
            ofd.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
          
            if (ofd.ShowDialog() == true)
            {
                FileStream fs = File.OpenRead(ofd.FileName);
                byte[] bytes = new byte[fs.Length];
                fs.Read(bytes, 0, Convert.ToInt32(fs.Length));
                SelectedBand.Picture = bytes;
                OnPropertyChanged("SelectedBand");
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
            if (SaveValidBand())
            {
                Band.AddType(SelectedBand, Huidigegenres);
                Bands = Band.getBands();
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Zijn alle velden correct aangevuld");
            }
        }

        private void DeleteBand()
        {
            if (SelectedBand != null)
            {
                if (SelectedBand.ID != 0)
                {
                    Band.DeleteBandFromLineUp(SelectedBand.ID);
                    Band.DeleteType(SelectedBand);
                    Bands.Remove(SelectedBand);

                  
           
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("dit is een ongeldige actie");
                }
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Gelieve eerst een Item te selecteren");
            }
           
        }
        private void EditBand()
        {
            if (SelectedBand != null)
            {
                if (SelectedBand.ID != 0)
                {
                    Band.EditBand(band, Huidigegenres);

                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("dit is een ongeldige actie");
                }
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Gelieve eerst een Item te selecteren");
            }
           
        }
 
        private void VoegGenreToe()
        {
            Huidigegenres.Add(SelectedAlleGenre);

        }

        private void VerwijderGenre()
        {
            Huidigegenres.Remove(SelectedHuidigeGenre);
        }
        private static byte[] convertStringToByte(string sPad)
        {
            //volgende 4 lijnen code = om geselecteerde image om te zetten naar BLOB capable formaat
            byte[] btImage = null;
            FileStream fstStream = new FileStream(sPad, FileMode.Open, FileAccess.Read);
            BinaryReader brReader = new BinaryReader(fstStream);
            btImage = brReader.ReadBytes((int)fstStream.Length);
            return btImage;
        }
        
        }
    }

