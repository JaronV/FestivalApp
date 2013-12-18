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
    class ContactpersonType
    {
        public int ID { get; set; }
        public String Name { get; set; }
        public static ObservableCollection<ContactpersonType> Soorten = new ObservableCollection<ContactpersonType>();


        public static ObservableCollection<ContactpersonType> GetContactPersonType()
        {
            Soorten = new ObservableCollection<ContactpersonType>();

            string sql = "SELECT * FROM ContactPersonType";

            DbDataReader reader = Database.GetData(sql);

            while (reader.Read())
            {
                Soorten.Add(VerwerkRij(reader));
                
            }
            return Soorten;
        }

        public static ContactpersonType VerwerkRij(IDataRecord rij)
        {
            ContactpersonType type = new ContactpersonType();

            type.ID = Convert.ToInt32(rij["ID"].ToString());
            type.Name = rij["Name"].ToString();

            return type;

        }



        public static void AddType(ContactpersonType SelectedContactPerson)
        {
            try
            {

                DbParameter paramName = Database.AddParameter("@Name", SelectedContactPerson.Name);
                Database.ModifyData("INSERT INTO ContactPersonType (Name) values (@Name)", paramName);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }

        public static void DeleteType(ContactpersonType SelectedContactPerson)
        {
            try
            {
                DbParameter paramName = Database.AddParameter("@Name", SelectedContactPerson.Name);

                Database.ModifyData("DELETE FROM ContactPersonType WHERE Name = @Name", paramName);
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

        public static ContactpersonType GetContactPersonTypeByID(int i)
        {
            ContactpersonType nieuw = new ContactpersonType();
            string sql = "SELECT * FROM ContactPersonType WHERE ID like @ID";
            DbParameter paramID = Database.AddParameter("@ID", i);
            DbDataReader reader = Database.GetData(sql,paramID);

            while (reader.Read())
            {
             nieuw =  VerwerkRijSpecial(reader);
            }
            return nieuw;
        }

        private static ContactpersonType VerwerkRijSpecial(IDataRecord rij)
        {
            ContactpersonType type = new ContactpersonType();

            type.ID = Convert.ToInt32(rij["ID"].ToString());
            type.Name = rij["Name"].ToString();

            return type;
        }
    }
}
