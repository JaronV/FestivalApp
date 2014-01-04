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
    public class Stage : IDataErrorInfo
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "De naam is verplicht")]
        public String Name { get; set; }

        public static ObservableCollection<Stage> Soorten = new ObservableCollection<Stage>();
       public ObservableCollection<LineUp> Bands { get; set; }
       private static ObservableCollection<Stage> lstAlleStages = GetAlleStages();

     private static ObservableCollection<LineUp> lstAlleLineUps = LineUp.GetLineUps();

        public static ObservableCollection<Stage> GetStages()
        {
            Soorten = new ObservableCollection<Stage>();

            string sql = "SELECT * FROM Stages";

            DbDataReader reader = Database.GetData(sql);

            while (reader.Read())
            {
                Soorten.Add(VerwerkRij(reader));

            }
            return Soorten;

        }
        public override string ToString()
        {
            return Name;
        }
        public static Stage VerwerkRij(IDataRecord rij)
        {
            Stage type = new Stage();

            type.ID = Convert.ToInt32(rij["ID"].ToString());
            type.Name = rij["Name"].ToString();

            return type;

        }
        public static void AddType(Stage SelectedStage)
        {
            try
            {

                DbParameter paramName = Database.AddParameter("@Name", SelectedStage.Name);
                Database.ModifyData("INSERT INTO Stages (Name) values (@Name)", paramName);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
        public static void DeleteType(Stage SelectedStage)
        {
            try
            {
                DbParameter paramName = Database.AddParameter("@Name", SelectedStage.Name);

                Database.ModifyData("DELETE FROM Stages WHERE Name = @Name", paramName);
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        



        private static Stage CreateStage(DbDataReader rij)
        {
            Stage stage = new Stage();
            stage.ID = Int32.Parse(rij["ID"].ToString());
            stage.Name = Convert.ToString(rij["Name"]);
            stage.Bands = LineUp.GetBandsByLineUpID(Convert.ToInt32(rij["ID"]));
            return stage;
        }

        private static Stage CreateStageWithDate(DbDataReader reader, DateTime date)
        {
            Stage stage = new Stage();
            stage.ID = Int32.Parse(reader["ID"].ToString());
            stage.Name = Convert.ToString(reader["Name"]);
            stage.Bands = LineUp.GetBandsByLineUpIDAndDate(Convert.ToInt32(reader["ID"]), date);
            return stage;
        }

        public static ObservableCollection<Stage> GetAlleStages()
        {
            ObservableCollection<Stage> lstStages = new ObservableCollection<Stage>();
            DbDataReader reader = Database.GetData("SELECT * FROM stages");
            while (reader.Read())
            {
                lstStages.Add(CreateStage(reader));
            }
            return lstStages;
        }

        public static ObservableCollection<Stage> GetStagesByDay(DateTime date)
        {
            ObservableCollection<Stage> lstStages = new ObservableCollection<Stage>();
            DbDataReader reader = Database.GetData("SELECT * FROM stages");
            while (reader.Read())
            {
                lstStages.Add(CreateStageWithDate(reader, date));
            }

            return lstStages;
        }

        public static Stage GetStageByID(int id)
        {
            Stage gevondenStage = new Stage();
            DbParameter par1 = Database.AddParameter("@id", id);
            DbDataReader reader = Database.GetData("SELECT * FROM  stages WHERE ID = @id",par1);
            while (reader.Read())
            {
                gevondenStage.Name = reader["Name"].ToString();
            }
            return gevondenStage;
        }
        public static void DeleteStage(int id)
        {
            string sql = "DELETE FROM stages WHERE ID = @id;";

            DbParameter par1 = Database.AddParameter("@id", id);

            Database.ModifyData(sql, par1);
           
         
        }
        public static void EditStage(Stage stag)
        {
            try
            {
                
                string sql = "UPDATE Ticket SET Name=@name WHERE ID=@ID;";

                DbParameter par1 = Database.AddParameter("@name", stag.Name);
              
                DbParameter parID = Database.AddParameter("@ID", Convert.ToInt32(stag.ID));

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
