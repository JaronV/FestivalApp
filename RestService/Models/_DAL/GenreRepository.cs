using FestivalLib.model;
using FestivalLibPortable;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Web;

namespace RestService.Models._DAL
{
    public class GenreRepository
    {
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
        public static ObservableCollection<Genre> GetGenresByID(int bandID)
        {
            ObservableCollection<Genre> list = new ObservableCollection<Genre>();


            string sql = "SELECT ID,Name FROM [Bands_Genre] INNER JOIN [Genre] on [Bands_Genre].[GenreID] = [Genre].[ID] WHERE BandID = @ID";


            DbParameter par = Database.AddParameter("@ID", bandID);
            DbDataReader reader = Database.GetData(sql, par);

            while (reader.Read())
            {
                list.Add(VerwerkRij(reader));

            }
            return list;

        }
    }
}