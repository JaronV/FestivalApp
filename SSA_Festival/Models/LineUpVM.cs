using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FestivalLib.Model;
using FestivalLib;

namespace SSA_Festival.Models
{
    public class LineUpVM
    {
       // public LineUp LineUp { get; set; }
        public int SelectedPod { get; set; }
        public DateTime SelectedDag { get; set; }
        public SelectList lstDagen { get; set; }
        public SelectList lstPodia { get; set; }
        public ObservableCollection<LineUp> LineUps { get; set; }
    }
}