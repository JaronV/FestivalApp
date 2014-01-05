using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FestivalLib.Model
{
    public class Ticket : IDataErrorInfo
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "De naam is verplicht")]
        public String Ticketholder { get; set; }

        [Required(ErrorMessage = "Email is verplicht")]
        public String TicketholderEmail { get; set; }

        [Required(ErrorMessage = "Type is verplicht")]
        public TicketType tickettype { get; set; }

        [Required(ErrorMessage = "Aantal is verplicht")]
        public int Amount { get; set; }

        [Required(ErrorMessage = "Datum is verplicht")]
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
                DbParameter paramName = Database.AddParameter("@Name", SelectedTicket.ID);

                Database.ModifyData("DELETE FROM Ticket WHERE ID = @Name", paramName);

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
        public static void PrintWord(Ticket ticket, Festival festival, string sPad)
        {
            string sFileNaam = ticket.ID + "_" + ticket.Ticketholder + ".docx";
            string sFullPad = sPad + "\\" + sFileNaam;
            try
            {
                File.Copy("C:\\Users\\jerry_000\\Dropbox\\2NMCT4\\S1\\Business applications\\Project\\FestivalApp\\word\\template.docx", sFullPad, true);
               
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }

            WordprocessingDocument newDoc = WordprocessingDocument.Open(sFullPad, true);
            IDictionary<string, BookmarkStart> bookmarks = new Dictionary<string, BookmarkStart>();
            foreach (BookmarkStart bms in newDoc.MainDocumentPart.RootElement.Descendants<BookmarkStart>())
            {
                bookmarks[bms.Name] = bms;
            }

            //Festival name moet iets anders qua opmaak zijn
            Run runTitle = new Run(new Text(festival.Naam));

            RunProperties propTitle = new RunProperties();
            RunFonts fontTitle = new RunFonts() { Ascii = "Segoe UI", HighAnsi = "Segoe UI" };
            FontSize sizeTitle = new FontSize() { Val = "36" };

            propTitle.Append(fontTitle);
            propTitle.Append(sizeTitle);
            runTitle.PrependChild<RunProperties>(propTitle);

            bookmarks["FestivalTitle"].Parent.InsertAfter<Run>(runTitle, bookmarks["FestivalTitle"]);

            bookmarks["Name"].Parent.InsertAfter<Run>(new Run(new Text(ticket.Ticketholder)), bookmarks["Name"]);
            bookmarks["Email"].Parent.InsertAfter<Run>(new Run(new Text(ticket.TicketholderEmail)), bookmarks["Email"]);
            bookmarks["Day"].Parent.InsertAfter<Run>(new Run(new Text(ticket.tickettype.Name)), bookmarks["Day"]);
            bookmarks["Type"].Parent.InsertAfter<Run>(new Run(new Text(ticket.tickettype.Name)), bookmarks["Type"]);
            bookmarks["Amount"].Parent.InsertAfter<Run>(new Run(new Text(ticket.Amount.ToString())), bookmarks["Amount"]);
            bookmarks["Price"].Parent.InsertAfter<Run>(new Run(new Text(ticket.tickettype.Price.ToString())), bookmarks["Price"]);
            double iTotalPrice = ticket.Amount * ticket.tickettype.Price;
            bookmarks["Totalprice"].Parent.InsertAfter<Run>(new Run(new Text(iTotalPrice.ToString())), bookmarks["Totalprice"]);

            //BARCODE TOEVOEGEN            
            //string code = Guid.NewGuid().ToString();
            string code = GenerateUnique(ticket.TicketholderEmail);
            Run run = new Run(new Text(code));

            RunProperties prop = new RunProperties();
            RunFonts font = new RunFonts() { Ascii = "Free 3 of 9 Extended", HighAnsi = "Free 3 of 9 Extended" };
            FontSize size = new FontSize() { Val = "96" };

            prop.Append(font);
            prop.Append(size);
            run.PrependChild<RunProperties>(prop);

            bookmarks["Barcode"].Parent.InsertAfter<Run>(run, bookmarks["Barcode"]);

            newDoc.Close();
            MessageBox.Show(sFullPad + " is opgeslaan");
        }

        public static string GenerateUnique(string sEmail)
        {
            string ticks = DateTime.UtcNow.Ticks.ToString();
            string s1 = ticks.Substring(ticks.Length / 2, ticks.Length - (ticks.Length / 2));

            return s1;
        }
        public static Ticket GetTicketByID(int id)
        {
            Ticket gevondenTicket = new Ticket();
            foreach (Ticket ticket in Soorten)
            {
                if (ticket.ID == id)
                {
                    gevondenTicket = ticket;
                }
            }
            return gevondenTicket;
        }
        public static void EditTicket(Ticket tick)
        {

            try
            {
                //band gedeelte
                string sql = "UPDATE Ticket SET TicketHolder=@name, TicketHolderEmail=@email, TicketType=@type, Amount=@amount WHERE ID=@ID;";

                DbParameter par1 = Database.AddParameter("@name", tick.Ticketholder);
                DbParameter par2 = Database.AddParameter("@email", tick.TicketholderEmail);
                DbParameter par3 = Database.AddParameter("@type", tick.tickettype.ID);
                DbParameter par4 = Database.AddParameter("@amount", tick.Amount);
                DbParameter parID = Database.AddParameter("@ID", Convert.ToInt16(tick.ID));

                Database.ModifyData(sql, par1, par2, par3, par4, parID);
   


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }
    }
}
