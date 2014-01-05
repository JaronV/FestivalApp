using FestivalLibPortable;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace StoreApp.DataModel
{
    public class LineUpVM:ObservableObject
    {
        public LineUpVM()
        {
            GetBandFromAPI();
        }
        private List<List<FestivalLibPortable.Stage>> _stages;

        public List<List<FestivalLibPortable.Stage>> Stages
        {
            get { return _stages; }
            set { _stages = value; OnPropertyChanged("Stages"); }
        }
        private String _name;

        public String Name
        {
            get { return _name; }
            set { _name = value; OnPropertyChanged("Name"); }
        }
        private ObservableCollection<FestivalLibPortable.Stage> _nieuweStages;

        public ObservableCollection<FestivalLibPortable.Stage> NieuweStages
        {
            get { return _nieuweStages; }
            set { _nieuweStages = value; OnPropertyChanged("NieuweStages"); }
        }

        
        public void GoToGenre(int id)
        {
        }

        public async void GetBandFromAPI()
        {
            NieuweStages = new ObservableCollection<Stage>();
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new
            System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/xml"));

            HttpResponseMessage response = await client.GetAsync("http://localhost:18358/api/LineUp");
            if (response.IsSuccessStatusCode)
            {
                Stream stream = await response.Content.ReadAsStreamAsync();


                DataContractSerializer dxml = new DataContractSerializer(typeof(List<List<FestivalLibPortable.Stage>>));
                Stages = dxml.ReadObject(stream) as List<List<FestivalLibPortable.Stage>>;
                foreach (List<FestivalLibPortable.Stage> St in Stages)
                {
                    foreach (Stage s in St)
                    {
                        Stage nieuw = s;
                        NieuweStages.Add(nieuw);
                       
                    }
                }
                stream.Dispose();
            }
        }



        
    }
}
