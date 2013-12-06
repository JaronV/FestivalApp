using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FestivalApp.Model
{
    class LineUp
    {
        public String ID { get; set; }
        public DateTime Date { get; set; }
        public string From { get; set; }
        public string Until { get; set; }
        public Stage stage { get; set; }
        public Band band { get; set; }

    }
}
