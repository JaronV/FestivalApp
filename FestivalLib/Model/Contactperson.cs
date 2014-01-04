using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FestivalLib.Model;
using DBHelper;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace FestivalLib.Model
{
    public class Contactperson : IDataErrorInfo
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "De naam is verplicht")]
        public String Name { get; set; }
        [Required(ErrorMessage = "Het Bedrijf is verplicht")]
        public String Company { get; set; }
        [Required(ErrorMessage = "De Functie is verplicht")]
        public ContactpersonType JobRole { get; set; }
        [Required(ErrorMessage = "De Stad is verplicht")]
        public String City { get; set; }
        [Required(ErrorMessage = "Email is verplicht")]
        public String Email { get; set; }
        [Required(ErrorMessage = "Telefoon Nr is verplicht")]
        public String Phone { get; set; }
        [Required(ErrorMessage = "Gsm Nr is verplicht")]
        public String Cellphone { get; set; }
        public static ObservableCollection<Contactperson> Soorten = new ObservableCollection<Contactperson>();

        public static ObservableCollection<Contactperson> GetContactPersonType()
        {

            Soorten = new ObservableCollection<Contactperson>();
            string sql = "SELECT * FROM ContactPerson";

            DbDataReader reader = Database.GetData(sql);

            while (reader.Read())
            {
                Soorten.Add(VerwerkRij(reader));

            }
            return Soorten;


        }

        private static Contactperson VerwerkRij(IDataRecord rij)
        {
            Contactperson type = new Contactperson();

            type.ID = Convert.ToInt32(rij["ID"].ToString());
            type.Name = rij["Name"].ToString();
            type.Company = rij["Company"].ToString();
            type.City = rij["City"].ToString();

            type.JobRole = ContactpersonType.GetContactPersonTypeByID(Convert.ToInt32( rij["JobRole"].ToString()));
            type.Phone = rij["Phone"].ToString();
            type.Cellphone = rij["Cellphone"].ToString();
            type.Email = rij["Email"].ToString();
            return type;
        }

        public static void AddType(Contactperson SelectedContactPerson)
        {
            try
            {

                DbParameter paramName = Database.AddParameter("@Name", SelectedContactPerson.Name);
                DbParameter paramCompany = Database.AddParameter("@Company", SelectedContactPerson.Company);
                DbParameter paramCity = Database.AddParameter("@City", SelectedContactPerson.City);
                DbParameter paramJobrole = Database.AddParameter("@JobRole", SelectedContactPerson.JobRole.Name);
                DbParameter paramPhone = Database.AddParameter("@Phone", SelectedContactPerson.Phone);
                DbParameter paramCellphone = Database.AddParameter("@Cellphone", SelectedContactPerson.Cellphone);
                DbParameter paramEmail = Database.AddParameter("@Email", SelectedContactPerson.Email);

                Database.ModifyData("INSERT INTO ContactPerson (Name,Company,JobRole,City,Email,Phone,Cellphone) values (@Name,@Company,@JobRole,@City,@Email,@Phone,@Cellphone)", paramName, paramCompany, paramCity, paramJobrole, paramPhone, paramCellphone, paramEmail);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }

        public static void DeleteType(Contactperson SelectedContactPerson)
        {
            try
            {
                DbParameter paramName = Database.AddParameter("@Name", SelectedContactPerson.Name);

                Database.ModifyData("DELETE FROM ContactPerson WHERE Name = @Name", paramName);
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
        public static void EditCp(Contactperson cp)
        {
            try
            {
   

                string sql = "UPDATE ContactPerson SET Name=@name,Company = @company,JobRole = @role,City = @city,Email=@email,Phone = @phone,Cellphone= @cell WHERE ID=@ID;";

                DbParameter par1 = Database.AddParameter("@name", cp.Name);
                DbParameter par2 = Database.AddParameter("@company", cp.Company);
                DbParameter par3 = Database.AddParameter("@role", cp.JobRole);
                DbParameter par4 = Database.AddParameter("@city", cp.City);
                DbParameter par5 = Database.AddParameter("@email", cp.Email);
                DbParameter par6 = Database.AddParameter("@phone", cp.Phone);
                DbParameter par7 = Database.AddParameter("@cell", cp.Cellphone);
                DbParameter parID = Database.AddParameter("@ID", Convert.ToInt32(cp.ID));

                Database.ModifyData(sql, par1,par2,par3,par4,par5,par6,par7, parID);



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
