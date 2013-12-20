using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FestivalLib.Model
{
    public class LineUp
    {
        public String ID { get; set; }
        public DateTime Date { get; set; }
        public DateTime From { get; set; }
        public DateTime Until { get; set; }
        public Stage stage { get; set; }
        public Band band { get; set; }

        private static ObservableCollection<Band> lstBands = Band.getBands();

        private static ObservableCollection<LineUp> lstAlleLineUps = GetLineUps();

          private static LineUp CreateLineUp(DbDataReader reader)
        {
            LineUp lineup = new LineUp();
            lineup.ID = Convert.ToString(reader["lineup_id"]);
            lineup.Date = Convert.ToDateTime(reader["lineup_date"]);
            lineup.From = Convert.ToDateTime(reader["lineup_from"]);
            lineup.Until = Convert.ToDateTime(reader["lineup_until"]);
            //lineup.From = reader["lineup_from"].ToString();
            //lineup.Until = reader["lineup_until"].ToString();
            //lineup.Stage = //een methode die de stage name ophaalt -> enkel name (string) is genoeg
            lineup.band = Band.GetBandByID(Convert.ToInt32(reader["lineup_band"]));
            return lineup;
        }

        public static ObservableCollection<LineUp> GetBandsByLineUpIDAndDate(int id, DateTime date)
        {
            //string datum = date.ToString("yyyy-MM-dd HH:mm:ss.fff");
           ObservableCollection<LineUp> lstGevondenLineUps = new ObservableCollection<LineUp>();
            string sql = "SELECT * FROM lineup WHERE lineup_stage = @ID AND  lineup_date=@Date";
              DbParameter paramid = Database.AddParameter("@ID",id);
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
            DbDataReader reader = Database.GetData("SELECT * FROM lineup WHERE lineup_stage = " + id + ";");
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
            string sql = "SELECT * FROM lineup WHERE lineup_id = " + id + "";
            DbDataReader reader = Database.GetData(sql);
            while (reader.Read())
            {
                gevondenLineUp = CreateLineUp(reader);
            }

            return gevondenLineUp;
        }

        public static void AddLineUp(LineUp lineup)
        {
            string sql = "INSERT INTO lineup(lineup_date, lineup_from, lineup_until, lineup_stage, lineup_band) VALUES (@date, @from, @until, @stageid, @bandid);";
            string from = lineup.From.ToShortTimeString();
            string until = lineup.Until.ToShortTimeString();
            DbParameter par1 = Database.AddParameter("@date", lineup.Date);
            DbParameter par2 = Database.AddParameter("@from", from);
            DbParameter par3 = Database.AddParameter("@until",until );
            DbParameter par4 = Database.AddParameter("@stageid", lineup.stage.ID);
            DbParameter par5 = Database.AddParameter("@bandid", lineup.band.ID);

            int i = Database.ModifyData(sql, par1, par2, par3, par4, par5);
            if (i == 0)
            {
                MessageBox.Show("Toevoegen mislukt", "Error", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error, System.Windows.MessageBoxResult.OK);
            }
            Console.WriteLine(i + " row(s) are affected");
        }

      

        #region Methods

      

        //berekend hoeveel tijd er tussen het begin en einde van een optreden zit, dit wordt oa gebruikt voor de breedte van de stackpanel te bepalen
        public static double calculateTimespan(DateTime dtFrom, DateTime dtUntil)
        {
            string sFrom = dtFrom.ToString("HH:mm");
            string sUntil = dtUntil.ToString("HH:mm");

            string[] arrsSplitFrom = sFrom.Split(':');
            double dFromHour = Convert.ToDouble(arrsSplitFrom[0]);
            double dFromMinute = Convert.ToDouble(arrsSplitFrom[1]);
            double dFrom = dFromHour + (dFromMinute / 60);

            string[] arrsSplitUntil = sUntil.Split(':');
            double dUntilHour = Convert.ToDouble(arrsSplitUntil[0]);
            double dUntilMinute = Convert.ToDouble(arrsSplitUntil[1]);
            double dUntil = dUntilHour + (dUntilMinute / 60);

            double dTimespan = (dUntil - dFrom) * 100;

            return dTimespan;
        }
        #endregion


    }
}
