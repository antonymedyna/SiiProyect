﻿using SiiProyect.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace SiiProyect.Services
{
    public static class ServicioCorreo
    {
        public static void EnviarCorreo(string direccion, string asunto, string mensaje)
        {
            var correo = DependencyService.Get<ICorreo>();
            correo.CrearCorreo(direccion, asunto, mensaje);
        }
    }
}
