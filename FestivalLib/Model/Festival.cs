using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FestivalLib.Model
{
    public class Festival
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public String Naam { get; set; }
  
        public static Festival GetData()
        {
            Festival nieuw= new Festival();
           
            string sql = "SELECT * FROM Festival";

            DbDataReader reader = Database.GetData(sql);

            while (reader.Read())
            {
              nieuw =  VerwerkRij(reader);

            }
            return nieuw;
        }

        private static Festival VerwerkRij(IDataRecord rij)
        {

            Festival nieuw = new Festival();

            nieuw.StartDate = Convert.ToDateTime( rij["StartDate"].ToString());
            nieuw.EndDate = Convert.ToDateTime(rij["EndDate"].ToString());

            return nieuw;
        }
        public static void AddType(Festival festi)
        {
            try
            {
                DbParameter paramstart = Database.AddParameter("@start", festi.StartDate);
                DbParameter paramend = Database.AddParameter("@end", festi.EndDate);
               


                Database.ModifyData("INSERT INTO Festival (StartDate,EndDate) values (@start,@end)",paramstart,paramend);


            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
        }

        public static void DeleteType()
        {
            try
            {
                

                Database.ModifyData("DELETE * FROM Festival ");

            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
        }
        public static bool DatumsAanwezig()
        {
            int aantal = 0;
            string sql = "SELECT count(*) as aantal FROM [Festival]";


            DbDataReader reader = Database.GetData(sql);
            while (reader.Read())
            {
                aantal = Int32.Parse(reader["aantal"].ToString());
            }

            if (aantal == 1)
            {
                return true;
            }
            else { return false; }

        }

        public static ObservableCollection<DateTime> aantalDagen()
        {
            ObservableCollection<DateTime> lstDagen = new ObservableCollection<DateTime>();
            Festival festival = GetData();
            TimeSpan timespan =  festival.EndDate -  festival.StartDate;
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
