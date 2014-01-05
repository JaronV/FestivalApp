using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FestivalLibPortable;
using System.Data.Common;
using System.Collections.ObjectModel;
using FestivalLib.model;
namespace RestService.Models._DAL
{
    public class LineUpRepository
    {
        private static LineUp CreateLineUp(DbDataReader reader)
        {
            LineUp lineup = new LineUp();
            lineup.ID = Convert.ToString(reader["lineup_id"]);
            lineup.Date = Convert.ToDateTime(reader["lineup_date"]).ToShortDateString();
            lineup.From = reader["lineup_from"].ToString();
            lineup.Until = reader["lineup_until"].ToString() ;
            //lineup.Stage = //een methode die de stage name ophaalt -> enkel name (string) is genoeg
            lineup.band = BandRepository.GetBandByID(Convert.ToInt32(reader["lineup_band"]));
            return lineup;
        }

        public static ObservableCollection<LineUp> GetBandsByLineUpIDAndDate(int id, DateTime date)
        {
            //string datum = date.ToString("yyyy-MM-dd HH:mm:ss.fff");
            ObservableCollection<LineUp> lstGevondenLineUps = new ObservableCollection<LineUp>();
            string sql = "SELECT * FROM lineup WHERE lineup_stage = @ID AND  lineup_date=@Date";
            DbParameter paramid = Database.AddParameter("@ID", id);
            DbParameter paramdate = Database.AddParameter("@Date", date);
            DbDataReader reader = Database.GetData(sql, paramid, paramdate);

            while (reader.Read())
            {
                lstGevondenLineUps.Add(CreateLineUp(reader));
            }
            return lstGevondenLineUps;
        }

        public static ObservableCollection<LineUp> GetBandsByLineUpID(int id)
        {
            ObservableCollection<LineUp> lstGevondenLineUps = new ObservableCollection<LineUp>();
            DbParameter paramid = Database.AddParameter("@ID", id);
            DbDataReader reader = Database.GetData("SELECT * FROM lineup WHERE lineup_stage = @ID", paramid);
            while (reader.Read())
            {
                lstGevondenLineUps.Add(CreateLineUp(reader));
            }
            return lstGevondenLineUps;
        }

        public static ObservableCollection<LineUp> GetLineUps()
        {
            ObservableCollection<LineUp> lstLineUps = new ObservableCollection<LineUp>();
            string sql = "SELECT * FROM lineup";
            DbDataReader reader = Database.GetData(sql);
            while (reader.Read())
            {
                lstLineUps.Add(CreateLineUp(reader));
            }
            return lstLineUps;
        }

        public static LineUp GetLineUpByID(int id)
        {
            LineUp gevondenLineUp = new LineUp();
            DbParameter paramid = Database.AddParameter("@ID", id);
            string sql = "SELECT * FROM lineup WHERE lineup_id = @ID";
            DbDataReader reader = Database.GetData(sql, paramid);
            while (reader.Read())
            {
                gevondenLineUp = CreateLineUp(reader);
            }

            return gevondenLineUp;
        }
    }
}