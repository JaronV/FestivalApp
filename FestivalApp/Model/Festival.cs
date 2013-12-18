using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FestivalApp.Model
{
    class Festival
    {
        public String StartDate { get; set; }
        public String EndDate { get; set; }
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

            nieuw.StartDate =  rij["StartDate"].ToString();
            nieuw.EndDate = rij["StartDate"].ToString();

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

        public static void DeleteType(Ticket SelectedTicket)
        {
            try
            {
                DbParameter paramName = Database.AddParameter("@Name", SelectedTicket.Ticketholder);

                Database.ModifyData("DELETE FROM TicketType WHERE Name = @Name", paramName);

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

    }
}
