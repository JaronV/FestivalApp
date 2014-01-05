using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FestivalLibPortable;
using System.Collections.ObjectModel;
using System.Data.Common;
using FestivalLib.model;
using System.Data;
namespace RestService.Models._DAL
{
    public class StageRepository
    {

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
        private static Stage CreateStage(DbDataReader rij)
        {
            Stage stage = new Stage();
            stage.ID = Int32.Parse(rij["ID"].ToString());
            stage.Name = Convert.ToString(rij["Name"]);
            //stage.Bands = LineUpRepository.GetBandsByLineUpID(Convert.ToInt32(rij["ID"]));
            stage.Bands = LineUpRepository.GetBandsByLineUpID(Convert.ToInt32(rij["ID"]));
            return stage;
        }

        private static Stage CreateStageWithDate(DbDataReader reader, DateTime date)
        {
            Stage stage = new Stage();
            stage.ID = Int32.Parse(reader["ID"].ToString());
            stage.Name = Convert.ToString(reader["Name"]);
            stage.Bands = LineUpRepository.GetBandsByLineUpIDAndDate(Convert.ToInt32(reader["ID"]), date);
            stage.datum = date;
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
            DbDataReader reader = Database.GetData("SELECT * FROM  stages WHERE ID = @id", par1);
            while (reader.Read())
            {
                gevondenStage.Name = reader["Name"].ToString();
            }
            return gevondenStage;
        }
    }
}