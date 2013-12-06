
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
    class Genre
    {
        public int ID { get; set; }
        public String Name { get; set; }
        public static ObservableCollection<Genre> Soorten = new ObservableCollection<Genre>();

        public static ObservableCollection<Genre> GetGenres()
        {


            string sql = "SELECT * FROM Genre";

            DbDataReader reader = Database.GetData(sql);

            while (reader.Read())
            {
                Soorten.Add(VerwerkRij(reader));

            }
            return Soorten;

        }

        public static Genre VerwerkRij(IDataRecord rij)
        {
            Genre type = new Genre();

            type.ID = Convert.ToInt32(rij["ID"].ToString());
            type.Name = rij["Name"].ToString();
     
            return type;

        }
        public static void AddType(Genre newgenre)
        {
            try
            {

                DbParameter paramName = Database.AddParameter("@Name", newgenre.Name);
                Database.ModifyData("INSERT INTO Genre (Name) values (@Name)", paramName);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static void DeleteType(Genre genre)
        {
            try
            {
                DbParameter paramName = Database.AddParameter("@Name", genre.Name);

                Database.ModifyData("DELETE FROM Genre WHERE Name = @Name", paramName);
            }
            catch (Exception e)
            {

                throw e;
            }
            
        }
    }
}
