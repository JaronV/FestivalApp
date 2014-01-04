﻿using FestivalLibPortable;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.DataModel
{
    public class LineUpVM:ObservableObject
    {
        public LineUpVM()
        {
            GetBandFromAPI();
        }
        private List<Band> _lineUps;

        public List<Band> LineUps
        {
            get { return _lineUps; }
            set { _lineUps = value; OnPropertyChanged("LineUps"); }
        }

        public async void GetBandFromAPI()
        {

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new
            System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/xml"));

            HttpResponseMessage response = await client.GetAsync("http://localhost:18358/api/band");
            if (response.IsSuccessStatusCode)
            {
                Stream stream = await response.Content.ReadAsStreamAsync();

                //DataContractJsonSerializer djs = new
                //DataContractJsonSerializer(typeof(List<FestivalLibPort.Band>));
                //Bands = djs.ReadObject(stream) as List<FestivalLibPort.Band>; 
                DataContractSerializer dxml = new DataContractSerializer(typeof(List<FestivalLibPortable.Band>));
                LineUps = dxml.ReadObject(stream) as List<FestivalLibPortable.Band>;
            }
        }

        
    }
}