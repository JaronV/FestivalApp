using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FestivalLib.Model;
using DBHelper;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FestivalLib.Model
{
    public class Genre : IDataErrorInfo
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "De naam is verplicht")]
        public String Name { get; set; }
        public static ObservableCollection<Genre> Soorten = new ObservableCollection<Genre>();

        public static ObservableCollection<Genre> GetGenres()
        {
            Soorten = new ObservableCollection<Genre>();

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

        public static ObservableCollection<Genre> GetGenreByID(int bandID)
        {
            ObservableCollection<Genre> list = new ObservableCollection<Genre>();


            string sql = "SELECT ID,Name FROM [Bands_Genre] INNER JOIN [Genre] on [Bands_Genre].[GenreID] = [Genre].[ID] WHERE BandID = @ID";
            
         
            DbParameter par = Database.AddParameter("@ID", bandID);
            DbDataReader reader = Database.GetData(sql,par);

            while (reader.Read())
            {
                list.Add(VerwerkRij(reader));

            }
            return list;
  
        }
        public static void EditGenre(Genre gen)
        {
            try
            {

                string sql = "UPDATE Genre SET Name=@name WHERE ID=@ID;";

                DbParameter par1 = Database.AddParameter("@name", gen.Name);

                DbParameter parID = Database.AddParameter("@ID", Convert.ToInt32(gen.ID));

                Database.ModifyData(sql, par1, parID);



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
