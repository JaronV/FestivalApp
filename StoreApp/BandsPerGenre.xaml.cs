using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using StoreApp.DataModel;
using System.Net.Http;
using System.Runtime.Serialization;
using System.ComponentModel;
using FestivalLibPortable;
// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace StoreApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class BandsPerGenre : Page
    {
        public BandsPerGenre()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The Parameter
        /// property is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            int i = (int)e.Parameter;
            GetBandFromAPI(i);

            
        }
        private List<FestivalLibPortable.Band> _bands;

        public List<FestivalLibPortable.Band> Bands
        {
            get { return _bands; }
            set { _bands = value;  }
        }

       

        public async void GetBandFromAPI(int id)
        {
            
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new
            System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/xml"));

            HttpResponseMessage response = await client.GetAsync("http://localhost:18358/api/Genre/" + id);
            if (response.IsSuccessStatusCode)
            {
                Stream stream = await response.Content.ReadAsStreamAsync();


                DataContractSerializer dxml = new DataContractSerializer(typeof(List<FestivalLibPortable.Band>));
                Bands = dxml.ReadObject(stream) as List<FestivalLibPortable.Band>;
                stream.Dispose();
                DeBands.ItemsSource = Bands;
            }
           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(ItemsPage));
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(LineUp));
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Genres));
        }

       
    }
}
