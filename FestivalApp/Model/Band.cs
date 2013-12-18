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
    class Band
    {
        public int ID { get; set; }
        public String Name { get; set; }
        public byte Picture { get; set; }
        public String Description { get; set; }
        public String Twitter { get; set; }
        public String Facebook { get; set; }
      //  public ObservableCollection<Genre> Genres { get; set; }
        public static ObservableCollection<Band> Soorten = new ObservableCollection<Band>();


        public static ObservableCollection<Band> getBands()
        {
            Soorten = new ObservableCollection<Band>();
            string sql = "SELECT * FROM Bands";

            DbDataReader reader = Database.GetData(sql);

            while (reader.Read())
            {
                Soorten.Add(VerwerkRij(reader));

            }
            return Soorten;


        }

       
        private static Band VerwerkRij(IDataRecord rij)
        {
            Band type = new Band();

            type.ID = Convert.ToInt32(rij["ID"].ToString());
            type.Name = rij["Name"].ToString();
        //    type.Picture =Convert.ToByte( rij["Picture"].ToString());
            type.Facebook = rij["Facebook"].ToString();
            type.Twitter = rij["Twitter"].ToString();
            type.Description = rij["Description"].ToString();
            return type;
        
        }


        public static void AddType(Band SelectedBand,ObservableCollection<Genre> Huidigegenres)
        {
            try
            {
                int aantal = CountBands();
               
                DbParameter paramName = Database.AddParameter("@Name", SelectedBand.Name);
                DbParameter paramDesc = Database.AddParameter("@Description", SelectedBand.Description);
                DbParameter paramFB = Database.AddParameter("@FB", SelectedBand.Facebook);
                DbParameter paramTwit = Database.AddParameter("@Twitter", SelectedBand.Twitter);
                DbParameter paramPic = Database.AddParameter("@pic", SelectedBand.Picture);
               // DbParameter parambandid = Database.AddParameter("@bandid",
                Database.ModifyData("INSERT INTO Bands (Name,Picture,Description,Twitter,Facebook) values (@Name,@pic,@Description,@FB,@Twitter)", paramName, paramDesc, paramFB, paramTwit, paramPic);

                foreach (Genre item in Huidigegenres)
                {
                    DbParameter paramBandid = Database.AddParameter("@BandID", aantal);
                    DbParameter paramGenreID = Database.AddParameter("@genreID", item.ID);
                    Database.ModifyData("INSERT INTO Bands_Genre (BandID,GenreID) values (@BandID,@genreid)", paramBandid, paramGenreID); 
                }
              
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }

        public static void DeleteType(Band SelectedBand)
        {
            throw new NotImplementedException();
        }

        public static int CountBands()
        {
            int aantal = 0;
            string sql = "SELECT count(*) as aantal FROM [Bands]";

         
            DbDataReader reader = Database.GetData(sql);
            while (reader.Read())
            {
                aantal = Int32.Parse(reader["aantal"].ToString());
            }
            aantal++;
            return aantal;

        }
    
}
}
