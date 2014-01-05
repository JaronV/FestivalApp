using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Common;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace FestivalLib.Model
{
    public class TicketType : IDataErrorInfo
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "De naam is verplicht")]
        public String Name { get; set; }
        [Required(ErrorMessage = "De Prijs is verplicht")]
        public double Price { get; set; }
        [Required(ErrorMessage = "Aantal is verplicht")]
        public int AvailableTickets { get; set; }
        [Required(ErrorMessage = "Datum is verplicht")]
        public DateTime Datum { get; set; }
        public  static ObservableCollection<TicketType> Soorten = new ObservableCollection<TicketType>();
        public string kortedatum { get; set; }
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
            type.kortedatum = Convert.ToDateTime(rij["Datum"]).ToShortDateString();
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
        public static void EditTicket(TicketType tick)
        {
            try
            {
                //band gedeelte
                string sql = "UPDATE TicketType SET Name=@name, Price=@price, AvailableTickets=@available, Datum=@datum WHERE ID=@ID;";

                DbParameter par1 = Database.AddParameter("@name", tick.Name);
                DbParameter par2 = Database.AddParameter("@price", tick.Price);
                DbParameter par3 = Database.AddParameter("@datum", tick.Datum);
                DbParameter par4 = Database.AddParameter("@available", tick.AvailableTickets);
              
                DbParameter parID = Database.AddParameter("@ID", Convert.ToInt16(tick.ID));

                Database.ModifyData(sql, par1, par2, par3, par4, parID);



            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }

        public bool IsValid()
        {
            return Validator.TryValidateObject(this, new ValidationContext(this, null, null), null, true);
        }

        public string Error
        {
            get { return null; }
        }

        public string this[string columnName]
        {
            get
            {
                try
                {
                    object value = this.GetType().GetProperty(columnName).GetValue(this);
                    Validator.ValidateProperty(value, new ValidationContext(this, null, null) { MemberName = columnName });
                }
                catch (ValidationException ex)
                {
                    return ex.Message;
                }
                return String.Empty;
            }
        }
    }
}
