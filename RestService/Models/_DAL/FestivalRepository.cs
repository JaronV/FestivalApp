using FestivalLib.model;
using FestivalLibPortable;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Web;

namespace RestService.Models._DAL
{
    public class FestivalRepository
    {
        public static Festival GetData()
        {
            Festival nieuw = new Festival();

            string sql = "SELECT * FROM Festival";

            DbDataReader reader = Database.GetData(sql);

            while (reader.Read())
            {
                nieuw = VerwerkRij(reader);

            }
            return nieuw;
        }

        private static Festival VerwerkRij(IDataRecord rij)
        {

            Festival nieuw = new Festival();

            nieuw.StartDate = Convert.ToDateTime(rij["StartDate"].ToString());
            nieuw.EndDate = Convert.ToDateTime(rij["EndDate"].ToString());

            return nieuw;
        }
     
    

        public static ObservableCollection<DateTime> aantalDagen()
        {
            ObservableCollection<DateTime> lstDagen = new ObservableCollection<DateTime>();
            Festival festival = GetData();
            TimeSpan timespan = festival.EndDate - festival.StartDate;
            DateTime volgendeDag = Convert.ToDateTime(festival.StartDate);
            for (int i = 0; i < timespan.Days + 1; i++)
            {
                TimeSpan ts = TimeSpan.FromDays(i);
                volgendeDag = festival.StartDate.Add(ts);

                lstDagen.Add(volgendeDag.Date);
            }

            return lstDagen;
        }
    }
}