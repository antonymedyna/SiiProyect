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
    class WSCorreo
    {
        HttpClient http;
        public async Task<List<Modelos.Correo>> listaCorreos()
        {
            List<Modelos.Correo> listaCorreo = null;
            try
            {
                http = new HttpClient();
                http.BaseAddress = new Uri(Settings.Settings.ip);

                //var authData = string.Format("{0}:{1}", "intertecs", "1nt3rt3c5");                        //auth
                //var authHeaderValue = Convert.ToBase64String(Encoding.UTF8.GetBytes(authData)); //auth
                //http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authHeaderValue);

                var result = await http.GetAsync("/ws/sii/correos/" + Settings.Settings.nocont + "/" + Settings.Settings.token);//+Settings.settings.token);
                var cadena = result.Content.ReadAsStringAsync().Result;
                listaCorreo = new List<Modelos.Correo>();
                var objJson = JObject.Parse(cadena);
                var arrJson = objJson.SelectToken("correo").ToList();

                Modelos.Correo correo;
                foreach (var kar in arrJson)
                {
                    correo = new Modelos.Correo();
                    correo = JsonConvert.DeserializeObject<Modelos.Correo>(kar.ToString());
                    listaCorreo.Add(correo);
                }
            }
            catch (Exception e)
            {

                e.ToString();
            }
            return listaCorreo;
        }
    }
}
