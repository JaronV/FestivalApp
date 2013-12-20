using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FestivalLib.Model
{
    public class Ticket : IDataErrorInfo
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "De naam is verplicht")]
        public String Ticketholder { get; set; }

        public String TicketholderEmail { get; set; }
        public TicketType tickettype { get; set; }
        public int Amount { get; set; }
        public DateTime Datum { get; set; }
        public static ObservableCollection<Ticket> Soorten = new ObservableCollection<Ticket>();


        public static ObservableCollection<Ticket> GetTickets()
        {
            Soorten = new ObservableCollection<Ticket>();

            string sql = "SELECT * FROM Ticket";

            DbDataReader reader = Database.GetData(sql);

            while (reader.Read())
            {
                Soorten.Add(VerwerkRij(reader));

            }
            return Soorten;
        }

        private static Ticket VerwerkRij(IDataRecord rij)
        {
            Ticket nieuw = new Ticket();

            nieuw.ID = Int32.Parse(rij["ID"].ToString());
            nieuw.Ticketholder = rij["TicketHolder"].ToString();
            nieuw.TicketholderEmail = rij["TicketHolderEmail"].ToString();
            nieuw.Amount = Int32.Parse( rij["Amount"].ToString());
            nieuw.tickettype = TicketType.GetTicketTypeByID(Convert.ToInt32(rij["TicketType"].ToString()));

            return nieuw;
        }

        public static void AddType(Ticket SelectedTicket)
        {
            try
            {
                DbParameter paramHolder = Database.AddParameter("@Holder", SelectedTicket.Ticketholder);
                DbParameter paramEmail = Database.AddParameter("@Email", SelectedTicket.TicketholderEmail);
                DbParameter paramAmount = Database.AddParameter("@Amount", SelectedTicket.Amount);
                DbParameter paramTicketType = Database.AddParameter("@Type", SelectedTicket.tickettype.ID);


                Database.ModifyData("INSERT INTO Ticket (TicketHolder,TicketHolderEmail,TicketType,Amount) values (@Holder,@Email,@Type,@Amount)", paramHolder,paramEmail,paramTicketType,paramAmount);


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
