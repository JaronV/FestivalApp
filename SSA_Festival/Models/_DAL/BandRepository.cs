using FestivalLib.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SSA_Festival.Models._DAL
{
    public class BandRepository
    {
        public static Band GetBandByID(int ID)
        {
            Band gevondenBand = Band.GetBandByID(ID);
            return gevondenBand;
        }
    }
}