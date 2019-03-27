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
    public partial class MainPage : ContentPage
    {
        async void listarUF(object sender, System.EventArgs e)
        {
                var client = new HttpClient();
                var json = await client.GetStringAsync($"http://ibge.herokuapp.com/estado/UF");
                var dados = JsonConvert.DeserializeObject<Object>(json);

                JObject ufs = JObject.Parse(json);

                Dictionary<string, string> dadosUF = ufs.ToObject<Dictionary<string, string>>();
                List<string> listaUF = new List<string>();
                foreach (KeyValuePair<string, string> ufsdados in dadosUF)
                {
                    UFs ObjUF = new UFs();
                    ObjUF.sigla = ufsdados.Key;
                    ObjUF.codigo = ufsdados.Value;
                    listaUF.Add(ObjUF.sigla);
                }

                SgUF.Text = listaUF[Convert.ToInt32(sliderUF.Value)];
        }
        public MainPage()
        {
            InitializeComponent();
        }

        async void Handle_Clicked(object sender, System.EventArgs e)
        {
            string UF = SgUF.Text;
            var client = new HttpClient();
            var json = await client.GetStringAsync($"http://ibge.herokuapp.com/municipio/?val={UF}");
            var dados = JsonConvert.DeserializeObject<Object>(json);

            JObject municipios = JObject.Parse(json);

            Dictionary<string, string> dadosMunicipios = municipios.ToObject<Dictionary<string, string>>();

            List<Municipios> lista = new List<Municipios>();
            foreach (KeyValuePair<string, string> municipio in dadosMunicipios)
            {
                Municipios ObjMunicipio = new Municipios();
                ObjMunicipio.nome = municipio.Key;
                ObjMunicipio.codigo = municipio.Value;
                lista.Add(ObjMunicipio);
            }
            Navigation.PushAsync(new MunicipiosPage(lista));
        }
    }
}