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
    class WSCargaAcademica
    {
        HttpClient http;
        public async Task<List<Modelos.CargaAcademica>> listaCargaAcademica()
        {
            List<Modelos.CargaAcademica> listaCarga = null;
            try
            {
                http = new HttpClient();
                http.BaseAddress = new Uri(Settings.Settings.ip);

                //var authData = string.Format("{0}:{1}", "intertecs", "1nt3rt3c5");                        //auth
                //var authHeaderValue = Convert.ToBase64String(Encoding.UTF8.GetBytes(authData)); //auth
                //http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authHeaderValue);

                var result = await http.GetAsync("/ws/sii/cargaacademica/" + Settings.Settings.nocont + "/" + Settings.Settings.token);//+Settings.settings.token);
                var cadena = result.Content.ReadAsStringAsync().Result;
                listaCarga = new List<Modelos.CargaAcademica>();
                var objJson = JObject.Parse(cadena);
                var arrJson = objJson.SelectToken("carga").ToList();

                Modelos.CargaAcademica carga;
                foreach (var kar in arrJson)
                {
                    carga = new Modelos.CargaAcademica();
                    carga = JsonConvert.DeserializeObject<Modelos.CargaAcademica>(kar.ToString());
                    listaCarga.Add(carga);
                }
            }
            catch (Exception e)
            {

                e.ToString();
            }
            return listaCarga;
        }
    }
}
