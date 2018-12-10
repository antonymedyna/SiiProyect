using SiiProyect.Modelos;
using System;
using System.Collections.Generic;
using System.Text;

namespace SiiProyect.Vistas
{
    class MenuDataOptions : List<MenuOpcion>
    {
        public MenuDataOptions()
        {
            this.Add(new MenuOpcion()
            {
                Title = "Inicio",
                IconSource = "iconoInicio.png",
                TargetType = typeof(Alumno),
            });
            this.Add(new MenuOpcion()
            {
                Title = "Buzon de Quejas",
                IconSource = "iconoBuzon.png",
                TargetType = typeof(BuzonQuejas),
            });
            this.Add(new MenuOpcion()
            {
                Title = " Enviar Correo",
                IconSource = "iconoCorreo.png",
                TargetType = typeof(Correo),
            });
            this.Add(new MenuOpcion()
            {
                Title = "Cerrar Sesion",
                IconSource = "iconoCerrarSesion.png",
                TargetType = typeof(Login),
            });
        }
    }
}
