using FestivalLibPortable;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.DataModel
{
    class BandGenreVM : ObservableObject, INotifyPropertyChanged
    {
        public BandGenreVM()
        {
            GetBandFromAPI();
        }
        public BandGenreVM(int id)
        {
            GetBandFromAPI(id);

        }
        private List<FestivalLibPortable.Band> _bands;

        public List<FestivalLibPortable.Band> Bands
        {
            get { return _bands; }
            set { _bands = value; OnPropertyChanged("Bands"); }
        }
        private ObservableCollection<Band> _nieuweBands;

        public ObservableCollection<Band> NieuweBands
        {
            get { return _nieuweBands; }
            set { _nieuweBands = value; OnPropertyChanged("NieuweBands"); }
        }

         public async void GetBandFromAPI(int id)
        {
            NieuweBands = new ObservableCollection<Band>();
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new
            System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/xml"));

            HttpResponseMessage response = await client.GetAsync("http://localhost:18358/api/genre/"+id);
            if (response.IsSuccessStatusCode)
            {
                Stream stream = await response.Content.ReadAsStreamAsync();

                
                DataContractSerializer dxml = new DataContractSerializer(typeof(List<FestivalLibPortable.Band>));
                Bands = dxml.ReadObject(stream) as List<FestivalLibPortable.Band>;
                stream.Dispose();
            }
            foreach (Band b in Bands)
            {
                NieuweBands.Add(b);
            }
        }

         public async void GetBandFromAPI()
         {

             HttpClient client = new HttpClient();
             client.DefaultRequestHeaders.Accept.Add(new
             System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/xml"));

             HttpResponseMessage response = await client.GetAsync("http://localhost:18358/api/band/");
             if (response.IsSuccessStatusCode)
             {
                 Stream stream = await response.Content.ReadAsStreamAsync();


                 DataContractSerializer dxml = new DataContractSerializer(typeof(List<FestivalLibPortable.Band>));
                 Bands = dxml.ReadObject(stream) as List<FestivalLibPortable.Band>;
                 stream.Dispose();
             }
         }
    }
}
