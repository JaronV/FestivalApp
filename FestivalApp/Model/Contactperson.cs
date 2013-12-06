using System;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FestivalApp.Model
{
    class Contactperson
    {
        public int ID { get; set; }
        public String Name { get; set; }
        public String Company { get; set; }
        public ContactpersonType JobRole { get; set; }
        public String City { get; set; }
        public String Email { get; set; }
        public String Phone { get; set; }
        public String Cellphone { get; set; }
        public static ObservableCollection<Contactperson> Soorten = new ObservableCollection<Contactperson>();

        public static ObservableCollection<Contactperson> GetContactPersonType()
        {


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
            type.JobRole = (ContactpersonType)rij["JobRole"];
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
                DbParameter paramCity = Database.AddParameter("@City", SelectedContactPerson.Name);
                DbParameter paramJobrole = Database.AddParameter("@JobRole", SelectedContactPerson.Name);
                DbParameter paramPhone = Database.AddParameter("@Phone", SelectedContactPerson.Name);
                DbParameter paramCellphone = Database.AddParameter("@Cellphone", SelectedContactPerson.Name);
                DbParameter paramEmail = Database.AddParameter("@Email", SelectedContactPerson.Name);

                Database.ModifyData("INSERT INTO ContactPerson (Name,Company,JobRole,City,Email,Phone,Cellphone) values (@Name,@Company,@City,@JobRole,@Phone,@Cellphone,@Email)", paramName, paramCompany, paramCity, paramJobrole, paramPhone, paramCellphone, paramEmail);
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

       


    }
}
