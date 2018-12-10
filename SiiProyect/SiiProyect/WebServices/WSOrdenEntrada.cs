using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SiiProyect.WebServices
{
    class WSOrdenEntrada
    {
        HttpClient http;
        public async Task<List<Modelos.OrdenEntrada>> listaOrden()
        {
            List<Modelos.OrdenEntrada> listaOrden = null;
            try
            {
                http = new HttpClient();
                http.BaseAddress = new Uri(Settings.Settings.ip);

                //var authData = string.Format("{0}:{1}", "intertecs", "1nt3rt3c5");                        //auth
                //var authHeaderValue = Convert.ToBase64String(Encoding.UTF8.GetBytes(authData)); //auth
                //http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authHeaderValue);

                var result = await http.GetAsync("/ws/sii/alumnoorden/" + Settings.Settings.nocont + "/" + Settings.Settings.token);//+Settings.settings.token);
                var cadena = result.Content.ReadAsStringAsync().Result;
                listaOrden = new List<Modelos.OrdenEntrada>();
                var objJson = JObject.Parse(cadena);
                var arrJson = objJson.SelectToken("alumnoorden").ToList();

                Modelos.OrdenEntrada orden;
                foreach (var kar in arrJson)
                {
                    orden = new Modelos.OrdenEntrada();
                    orden = JsonConvert.DeserializeObject<Modelos.OrdenEntrada>(kar.ToString());
                    listaOrden.Add(orden);
                }
            }
            catch (Exception e)

            {
                e.ToString();
            }
            return listaOrden;
        }
    }
}
