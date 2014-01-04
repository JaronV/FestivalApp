using FestivalLibPortable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RestService.Models;
using System.Data.Common;
using FestivalLib.model;


namespace RestService.Models._DAL
{
    public class BandRepository
    {        
        private static Band CreateBand(DbDataReader reader)
        {

            Band band = new Band();
            band.ID = Convert.ToString(reader["ID"]);
            band.Name = Convert.ToString(reader["Name"]);
            band.Picture = (byte[])reader["Picture"];
            band.Descr = Convert.ToString(reader["Description"]);
            band.Twitter = Convert.ToString(reader["Twitter"]);
            band.Facebook = Convert.ToString(reader["Facebook"]);
            //band.Genres = Genre.GetGenresByBandID(Convert.ToInt32(reader["band_id"]));
            return band;
        }

        public static List<Band> GetBands()
        {
            List<Band> lstBands = new List<Band>();
            DbDataReader reader = Database.GetData("SELECT * FROM Bands");
            while (reader.Read())
            {
                lstBands.Add(CreateBand(reader));
            }
            return lstBands;
        }

        public static Band GetBandByID(int id)
        {
            Band gevondenBand = new Band();
            string sql = "SELECT * FROM Bands WHERE ID=@id;";
            DbParameter parID = Database.AddParameter("@id", id);
            DbDataReader reader = Database.GetData(sql, parID);           
            while (reader.Read())
            {
                gevondenBand = CreateBand(reader);
            }            
            return gevondenBand;
        }
    }
}