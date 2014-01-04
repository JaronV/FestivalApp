using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FestivalLibPortable
{
    public class LineUp
    {
        public String ID { get; set; }
        public String Date { get; set; }
        public String From { get; set; }
        public String Until { get; set; }
        public Stage stage { get; set; }
        public Band band { get; set; }
    }
}
