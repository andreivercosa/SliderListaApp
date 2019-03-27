using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using SliderListaApp.Model;

namespace SliderListaApp
{
    public partial class MunicipiosPage : ContentPage
    {
        public MunicipiosPage(List<Municipios> lista)
        {
            InitializeComponent();
            listaMunicipio.ItemsSource = lista;
        }
    }
}
