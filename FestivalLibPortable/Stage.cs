using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace FestivalLibPortable
{
   public class Stage
    {
       public int ID { get; set; }
        public String Name { get; set; }
        public IEnumerable<LineUp> Bands { get; set; }
        public DateTime datum { get; set; }
        public LineUp lineup { get; set; }
    }
}
