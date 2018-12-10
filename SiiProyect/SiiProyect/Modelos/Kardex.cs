using System;
using System.Collections.Generic;
using System.Text;

namespace SiiProyect.Modelos
{
    class Kardex
    {
        public string cvemat { get; set; }
        public Materia materia { get; set; }
        public int calificacion { get; set; }
        public Oportunidad oportunidad { get; set; }
        public int creditosMateris { get; set; }
    }
}
