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

namespace StoreApp.DataModel
{
    class GenreVM : ObservableObject
    {
        public GenreVM()
        {
            GetGenreFromAPI();
        }

        private List<Genre> _genres;

        public List<Genre> Genres
        {
            get { return _genres; }
            set { _genres = value; OnPropertyChanged("Genres"); }
        }
        private ObservableCollection<Genre> _nieuweGenres;

        public ObservableCollection<Genre> NieuweGenres
        {
            get { return _nieuweGenres; }
            set { _nieuweGenres = value; }
        }
        public async void GetGenreFromAPI()
        {

            NieuweGenres = new ObservableCollection<Genre>();
                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Accept.Add(new
                System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/xml"));
              
                HttpResponseMessage response = await client.GetAsync("http://localhost:18358/api/Genre");

                if (response.IsSuccessStatusCode)
                {
                    try
                    {
                        Stream stream = await response.Content.ReadAsStreamAsync();
                        DataContractSerializer dxml = new DataContractSerializer(typeof(List<FestivalLibPortable.Genre>));
                        Genres = dxml.ReadObject(stream) as List<Genre>;
                        
                    }
                    catch (Exception e)
                    {
                    }
                    
                }
                foreach (Genre g in Genres)
                {
                    NieuweGenres.Add(g);
                }
            
        }
    }
}
