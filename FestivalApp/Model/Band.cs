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
        public ObservableCollection<Genre> Genres { get; set; }
        public static ObservableCollection<Band> Soorten = new ObservableCollection<Band>();


        public static ObservableCollection<Band> getBands()
        {
            string sql = "SELECT * FROM ContactPerson";

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
            type.Name = rij["ID"].ToString();
            type.Picture =Convert.ToByte( rij["ID"].ToString());
            type.Facebook = rij["Facebook"].ToString();
            type.Twitter = rij["Twitter"].ToString();
          //  type.Genres =  rij["Genre"].ToString();
            type.Description = rij["Description"].ToString();
            return type;
        
        }


        public static void AddType(Band SelectedBand)
        {
            throw new NotImplementedException();
        }

        public static void DeleteType(Band SelectedBand)
        {
            throw new NotImplementedException();
        }
    }
}
