using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Common;


namespace FestivalLib.Model
{
   public class TicketType
    {
        public int ID { get; set; }
        public String Name { get; set; }
        public double Price { get; set; }
        public int AvailableTickets { get; set; }
        public DateTime Datum { get; set; }
        public  static ObservableCollection<TicketType> Soorten = new ObservableCollection<TicketType>();

        public static void DeleteType(TicketType type)
        {
            try
            {
                  DbParameter paramName = Database.AddParameter("@Name",type.Name );

                  Database.ModifyData("DELETE FROM TicketType WHERE Name = @Name", paramName);
            }
            catch (Exception e)
            {

                throw e;
            }
        }
        public override string ToString()
        {
            return Name;
        }
        public static void AddType(TicketType newticket)
        {
            string datum = newticket.Datum.ToShortDateString();
            try
            {
             
                DbParameter paramName = Database.AddParameter("@Name",newticket.Name );
                DbParameter paramPrijs = Database.AddParameter("@Price",newticket.Price );
                DbParameter paramTicket = Database.AddParameter("@AvailableTickets",newticket.AvailableTickets );
                DbParameter paramDatum = Database.AddParameter("@datum", datum);

                Database.ModifyData("INSERT INTO TicketType (Name,Price,AvailableTickets,Datum) values (@Name,@Price,@AvailableTickets,@datum)", paramName, paramPrijs, paramTicket,paramDatum);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }


        }
        public static ObservableCollection<TicketType> GetTicketType()
        {
            Soorten = new ObservableCollection<TicketType>();

            string sql = "SELECT * FROM Tickettype";

            DbDataReader reader = Database.GetData(sql);

            while (reader.Read())
            {
                Soorten.Add(VerwerkRij(reader));
                
            }
            return Soorten;

        }

        public static TicketType VerwerkRij(IDataRecord rij)
        {
            TicketType type = new TicketType();

            type.ID = Convert.ToInt32(rij["ID"].ToString());
            type.AvailableTickets = Convert.ToInt32( rij["AvailableTickets"].ToString());
            type.Name = rij["Name"].ToString();
            type.Price = Convert.ToInt32(rij["Price"].ToString());
            type.Datum = Convert.ToDateTime(rij["Datum"]);
            return type;

        }


        public static TicketType GetTicketTypeByID(int p)
        {
            TicketType nieuw = new TicketType();
            string sql = "SELECT * FROM TicketType WHERE ID like @ID";
            DbParameter paramID = Database.AddParameter("@ID", p);
            DbDataReader reader = Database.GetData(sql, paramID);

            while (reader.Read())
            {
                nieuw = VerwerkRij(reader);
            }
            return nieuw;
            
        }
    }
}
