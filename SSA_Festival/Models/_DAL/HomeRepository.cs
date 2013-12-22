using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FestivalLib.Model;
namespace SSA_Festival.Models._DAL
{
    public class HomeRepository
    {
        public static Festival GetFestival()
        {
            Festival festival = Festival.GetData();
            return festival;
        }
    }
}