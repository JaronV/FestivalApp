
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
    class Stage
    {
        public int ID { get; set; }
        public String Name { get; set; }

        public static ObservableCollection<Stage> Soorten = new ObservableCollection<Stage>();

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
    }
}
