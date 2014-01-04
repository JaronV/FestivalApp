using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FestivalLib.Model;
using System.Windows.Input;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight.Command;

namespace FestivalApp.ViewModel
{
    //elke viewmodel-klasse laten erven van de klasse ObservableObject, de interface Ipage implementeren
    class MainPageVM : ObservableObject, IPage
    {
        public MainPageVM()
        {
           _bands = Band.getBands();
           _uniekeDagen = Festival.aantalDagen();
         // _stagesPerDag = Stage.GetStagesByDay(SelectedDag);
           _podiums = Stage.GetStages();
            _lineUp = new LineUp();
        }
    
        public string Name
        {
            get
            {
                return "Line Up"; //hier geven we de exacte naam van de usercontrol terug
            }
        }
        #region fields en props
        private DateTime geselecteerd;
        private ObservableCollection<Stage> _podiums = new ObservableCollection<Stage>();
        public ObservableCollection<Stage> Podiums
        {
            get { return _podiums; }
            set { _podiums = value; OnPropertyChanged("Podiums"); }
        }
        private DateTime _selectedDag;

        public DateTime SelectedDag
        {
            get { return _selectedDag; }
            set
            {
                _selectedDag = value;
                OnPropertyChanged("SelectedDag");
                StagesPerDag = Stage.GetStagesByDay(SelectedDag);
                geselecteerd = SelectedDag;
            }
        }
        

        private ObservableCollection<DateTime> _uniekeDagen;

        public ObservableCollection<DateTime> UniekeDagen
        {
            get { return _uniekeDagen; }
            set { _uniekeDagen = value; OnPropertyChanged("UniekeDagen"); }
        }

        private ObservableCollection<Stage> _stagesPerDag;

        public ObservableCollection<Stage> StagesPerDag
        {
            get { return _stagesPerDag; }
            set { _stagesPerDag = value; OnPropertyChanged("StagesPerDag"); }
        }

        private ObservableCollection<Band> _bands;

        public ObservableCollection<Band> Bands
        {
            get { return _bands; }
            set { _bands = value; OnPropertyChanged("Bands"); }
        }

        private LineUp _lineUp;

        public LineUp LineUp
        {
            get { return _lineUp; }
            set { _lineUp = value; OnPropertyChanged("LineUp"); }
        }

        #endregion

        #region commands
        public ICommand SaveLineUpCommand
        {
            get { return new RelayCommand(SaveLineUp); }
        }
        public void SaveLineUp()
        {
            LineUp.AddLineUp(LineUp);

            StagesPerDag = Stage.GetStagesByDay(SelectedDag);
        }


        public ICommand DeleteBandFromLineUpCommand
        {
            get { return new RelayCommand<int>(DeleteBandFromLineUp); }
        }
        public void DeleteBandFromLineUp(int id)
        {
            int bandID = Convert.ToInt32(LineUp.GetLineUpByID(id).band.ID);
           
               Band.DeleteBandFromLineUp(id);
               Bands = Band.getBands();
               StagesPerDag = Stage.GetStagesByDay(SelectedDag);

        }
        public ICommand DeleteStageCommand
        {
            get { return new RelayCommand<int>(DeleteStage); }
        }
        public void DeleteStage(int id)
        {
        
                Stage.DeleteStage(id);
                StagesPerDag = Stage.GetStagesByDay(SelectedDag);
           
        }

        #endregion
    }
}
