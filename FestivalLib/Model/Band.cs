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
    public class Band : IDataErrorInfo
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "De naam is verplicht")]
        public String Name { get; set; }

        public byte[] Picture { get; set; }

        [Required(ErrorMessage = "De Beschrijving is verplicht")]
        public String Description { get; set; }

        [Required(ErrorMessage = "Twitter is verplicht")]
        public String Twitter { get; set; }

        [Required(ErrorMessage = "Facebook is verplicht")]
        public String Facebook { get; set; }
      //  public ObservableCollection<Genre> Genres { get; set; }
        public static ObservableCollection<Band> Soorten = new ObservableCollection<Band>();
        public static ObservableCollection<Band> lstAlleBands = getBands();

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
        public override string ToString()
        {
            return Name;
        }
       
        private static Band VerwerkRij(IDataRecord rij)
        {
            Band type = new Band();

            type.ID = Convert.ToInt32(rij["ID"].ToString());
            type.Name = rij["Name"].ToString();
           type.Picture =(byte[]) rij["Picture"];
            type.Facebook = rij["Facebook"].ToString();
            type.Twitter = rij["Twitter"].ToString();
            type.Description = rij["Description"].ToString();
            return type;
        
        }


        public static void AddType(Band SelectedBand,ObservableCollection<Genre> Huidigegenres)
        {
            try
            {
 
                DbParameter paramName = Database.AddParameter("@Name", SelectedBand.Name);
                DbParameter paramDesc = Database.AddParameter("@Description", SelectedBand.Description);
                DbParameter paramFB = Database.AddParameter("@FB", SelectedBand.Facebook);
                DbParameter paramTwit = Database.AddParameter("@Twitter", SelectedBand.Twitter);
                DbParameter paramPic = Database.AddParameter("@pic", SelectedBand.Picture);
               
                Database.ModifyData("INSERT INTO Bands (Name,Picture,Description,Twitter,Facebook) values (@Name,@pic,@Description,@FB,@Twitter)", paramName, paramDesc, paramFB, paramTwit, paramPic);

                int id = getBandIdByName(SelectedBand);
                foreach (Genre item in Huidigegenres)
                {

                    DbParameter paramBandid = Database.AddParameter("@BandID", id);
                    DbParameter paramGenreID = Database.AddParameter("@genreID", item.ID);
                    Database.ModifyData("INSERT INTO Bands_Genre (BandID,GenreID) values (@BandID,@genreid)", paramBandid, paramGenreID); 
                }
              
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }

        private static int getBandIdByName(Band band)
        {
            int id = 0;
            string sql = "SELECT ID FROM [Bands] WHERE Name=@Name";
            DbParameter bandname = Database.AddParameter("@Name", band.Name);

            DbDataReader reader = Database.GetData(sql,bandname);
            while (reader.Read())
            {
                id = Int32.Parse(reader["ID"].ToString());
            }
            return id;
        }

        public static void DeleteType(Band SelectedBand)
        {
            string sql = "DELETE FROM Bands WHERE ID = @ID;";

            DbParameter parID = Database.AddParameter("@ID",SelectedBand.ID);

            Database.ModifyData(sql, parID);
           
            
        }

      
        public static ObservableCollection<Band> GetBandsByString(string search)
        {
            ObservableCollection<Band> lstGevondenBands = new ObservableCollection<Band>();
            foreach (Band band in lstAlleBands)
            {
                if (band.Name.ToUpper().Contains(search.ToUpper()) || band.Description.ToUpper().Contains(search.ToUpper()) || band.Facebook.ToUpper().Contains(search.ToUpper()) || band.Twitter.ToUpper().Contains(search.ToUpper()))
                {
                    lstGevondenBands.Add(band);
                }
            }

            return lstGevondenBands;
        }

        public static Band GetBandByID(int id)
        {
            Band gevondenBand = new Band();
            gevondenBand = lstAlleBands.Single(i => i.ID == id);

            return gevondenBand;
        }
        public static void DeleteBandFromLineUp(int lineupID)
        {
            string sql = "DELETE  FROM lineup WHERE lineup_band = @lineupID;";
            DbParameter parLineUpID = Database.AddParameter("@lineupID", lineupID);
            Database.ModifyData(sql, parLineUpID);
           
           
        }
        public static void DeleteLineUp(int lineupID)
        {
            string sql = "DELETE  FROM lineup WHERE lineup_id = @lineupID;";
            DbParameter parLineUpID = Database.AddParameter("@lineupID", lineupID);
            Database.ModifyData(sql, parLineUpID);


        }

        public static void EditBand(Band band, ObservableCollection<Genre> Huidigegenres)
        {
            try
            {
                //band gedeelte
                string sql = "UPDATE Bands SET Name=@name, Picture=@picture, Description=@description, Twitter=@twitter, Facebook=@facebook WHERE ID=@ID;";

                DbParameter par1 = Database.AddParameter("@name", band.Name);
                DbParameter par2 = Database.AddParameter("@picture", band.Picture);
                DbParameter par3 = Database.AddParameter("@description", band.Description);
                DbParameter par4 = Database.AddParameter("@twitter", band.Twitter);
                DbParameter par5 = Database.AddParameter("@facebook", band.Facebook);

                DbParameter parID = Database.AddParameter("@ID", Convert.ToInt16(band.ID));

               Database.ModifyData(sql, par1, par2, par3, par4, par5, parID);
                //genre gedeelte

                //verwijderen 
               DbParameter bandID = Database.AddParameter("@bandID", Convert.ToInt16(band.ID));
               string sql2 = "DELETE FROM Bands_Genre WHERE BandID = @bandID;";
               Database.ModifyData(sql2, bandID);

                //toevoegen
               foreach (Genre item in Huidigegenres)
               {
                   DbParameter bandID2 = Database.AddParameter("@bandID", Convert.ToInt16(band.ID));
                   DbParameter paramGenreID = Database.AddParameter("@genreID", item.ID);
                   Database.ModifyData("INSERT INTO Bands_Genre (BandID,GenreID) values (@BandID,@genreid)", bandID2, paramGenreID);
               }



         
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
