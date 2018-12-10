using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SiiProyect.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace SiiProyect.WebServices
{
    class WSAlumno
    {
        HttpClient http;
        public async Task<List<Modelos.Alumno>> listaAlumno()
        {
            List<Modelos.Alumno> listaAlumno = null;
            try
            {
                http = new HttpClient();
                http.BaseAddress = new Uri(Settings.Settings.ip);

                //var authData = string.Format("{0}:{1}", "intertecs", "1nt3rt3c5");                        //auth
                //var authHeaderValue = Convert.ToBase64String(Encoding.UTF8.GetBytes(authData)); //auth
                //http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authHeaderValue);

                var result = await http.GetAsync("/ws/sii/alumnoinfo/" + Settings.Settings.nocont + "/" + Settings.Settings.token);//+Settings.settings.token);
                var cadena = result.Content.ReadAsStringAsync().Result;
                listaAlumno = new List<Modelos.Alumno>();
                var objJson = JObject.Parse(cadena);
                var arrJson = objJson.SelectToken("alumnoinfo").ToList();

                Modelos.Alumno alumno;
                foreach (var kar in arrJson)
                {
                    alumno = new Modelos.Alumno();
                    alumno = JsonConvert.DeserializeObject<Modelos.Alumno>(kar.ToString());
                    Settings.Settings.nocont = alumno.nocont;
                    Settings.Settings.nombreAlumno = alumno.nombre;
                    Settings.Settings.especialidad = alumno.especialidad.nombre;
                    Settings.Settings.sexo = alumno.sexo;
                    Settings.Settings.curp = alumno.curp;
                    Settings.Settings.correo = alumno.correo;
                    Settings.Settings.dia = alumno.dia;
                    Settings.Settings.mes = alumno.mes;
                    Settings.Settings.anio = alumno.anio;
                    Settings.Settings.telefono = alumno.telefono;
                    listaAlumno.Add(alumno);
                }
            }
            catch (Exception e)

            {
                e.ToString();
            }
            return listaAlumno;
        }
        public async Task<Boolean> putAlumnoInfo(String sexo,String telefono,String correo,
                                                String curp,String estadonacimiento, String fechanacimiento)
        {
            Boolean flag = false;
            List<ActualizarAlumno> listSubjects = new List<ActualizarAlumno>();
            try
            {
                //var uri = new Uri(string.Format(Constants.RestUrl, string.Empty));
                ActualizarAlumno sub = new ActualizarAlumno();
                sub.sexo = sexo;
                sub.telefono = telefono;
                sub.correo = correo;
                sub.curp = curp;
                sub.estadonacimiento = estadonacimiento;
                sub.fechanacimiento = fechanacimiento;
                var json = JsonConvert.SerializeObject(sub);
                //var content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpClient httpClient = new HttpClient();
                httpClient.BaseAddress = new Uri(Settings.Settings.ip);
                //var authData = string.Format("{0}:{1}", "root", "root");
                //var authHeaderValue = Convert.ToBase64String(Encoding.UTF8.GetBytes(authData));
                //httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authHeaderValue);

                //var resp = await httpClient.GetAsync("SIIWS_PATM/api/wslista/getlista/" + Settings.idStudent + "/" + Settings.token);
                var resp = await httpClient.PutAsync("/ws/sii/updatealumno/"+Settings.Settings.nocont+"/" + Settings.Settings.token, content);
                if (resp.IsSuccessStatusCode)
                    flag = true;
            }
            catch (Exception e)
            {

                e.ToString();
            }

            return flag;
        }
        public async Task<Boolean> insertarQueja(String email, String tipoQueja, String descripcion)
        {
            Boolean flag = false;
            List<ActualizarAlumno> listSubjects = new List<ActualizarAlumno>();
            try
            {
                //var uri = new Uri(string.Format(Constants.RestUrl, string.Empty));
                InsertarQueja sub = new InsertarQueja();
                sub.email = email;
                sub.tipoqueja = tipoQueja;
                sub.descripcion = descripcion;
                var json = JsonConvert.SerializeObject(sub);
                //var content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpClient httpClient = new HttpClient();
                httpClient.BaseAddress = new Uri(Settings.Settings.ip);
                //var authData = string.Format("{0}:{1}", "root", "root");
                //var authHeaderValue = Convert.ToBase64String(Encoding.UTF8.GetBytes(authData));
                //httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authHeaderValue);

                //var resp = await httpClient.GetAsync("SIIWS_PATM/api/wslista/getlista/" + Settings.idStudent + "/" + Settings.token);
                var resp = await httpClient.PostAsync("/ws/sii/buzonquejas/" + Settings.Settings.token, content);
                if (resp.IsSuccessStatusCode)
                    flag = true;
            }
            catch (Exception e)
            {

                e.ToString();
            }

            return flag;
        }
    }
}
