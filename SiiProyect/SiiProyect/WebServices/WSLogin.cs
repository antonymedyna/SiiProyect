using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SiiProyect.Modelos;

namespace SiiProyect.WebServices
{
    class WSLogin
    {

        public async Task<bool> ConexionAsync(String user, String pwd)
        {
            HttpClient httpClient = new HttpClient();
            //192.168.100.56:5000
            httpClient.BaseAddress = new Uri(Settings.Settings.ip);

            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //var authData = string.Format("{0}:{1}", "root", "root");
            //var authHeaderValue = Convert.ToBase64String(Encoding.UTF8.GetBytes(authData));
            //ttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authHeaderValue);
            var respuesta = await httpClient.GetAsync("/ws/sii/login/" + user + "/" + pwd);
            var objJSON = respuesta.Content.ReadAsStringAsync().Result;
           
            Login objLogin = new Login();
            List<String> list = new List<string>();
            Console.WriteLine("<" + Settings.Settings.token + ">");
            Settings.Settings.token = null;
            
            if (objJSON != null)
            {
                objLogin = JsonConvert.DeserializeObject<Login>(objJSON);
                list.Add(objLogin.nocont);
                list.Add(objLogin.token);
                Settings.Settings.token = objLogin.token;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
