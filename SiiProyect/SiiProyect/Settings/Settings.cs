using Plugin.Settings;
using Plugin.Settings.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace SiiProyect.Settings
{
    class Settings
    {
        private static ISettings AppSettings =>
            CrossSettings.Current;

        public static String ip
        {
            get => AppSettings.GetValueOrDefault(nameof(ip), string.Empty);
            set => AppSettings.AddOrUpdateValue(nameof(ip), value);
        }
        public static String token
        {
            get => AppSettings.GetValueOrDefault(nameof(token), string.Empty);
            set => AppSettings.AddOrUpdateValue(nameof(token), value);
        }
        public static String nocont
        {
            get => AppSettings.GetValueOrDefault(nameof(nocont), string.Empty);
            set => AppSettings.AddOrUpdateValue(nameof(nocont), value);
        }
        public static String password
        {
            get => AppSettings.GetValueOrDefault(nameof(password), string.Empty);
            set => AppSettings.AddOrUpdateValue(nameof(password), value);
        }
        //Datos Alumno
        public static String nombreAlumno
        {
            get => AppSettings.GetValueOrDefault(nameof(nombreAlumno), string.Empty);
            set => AppSettings.AddOrUpdateValue(nameof(nombreAlumno), value);
        }
        public static String especialidad
        {
            get => AppSettings.GetValueOrDefault(nameof(especialidad), string.Empty);
            set => AppSettings.AddOrUpdateValue(nameof(especialidad), value);
        }
        public static String sexo
        {
            get => AppSettings.GetValueOrDefault(nameof(sexo), string.Empty);
            set => AppSettings.AddOrUpdateValue(nameof(sexo), value);
        }
        public static String curp
        {
            get => AppSettings.GetValueOrDefault(nameof(curp), string.Empty);
            set => AppSettings.AddOrUpdateValue(nameof(curp), value);
        }
        public static string dia
        {
            get => AppSettings.GetValueOrDefault(nameof(dia), string.Empty);
            set => AppSettings.AddOrUpdateValue(nameof(dia), value);
        }
        public static String mes
        {
            get => AppSettings.GetValueOrDefault(nameof(mes), string.Empty);
            set => AppSettings.AddOrUpdateValue(nameof(mes), value);
        }
        public static String anio
        {
            get => AppSettings.GetValueOrDefault(nameof(anio), string.Empty);
            set => AppSettings.AddOrUpdateValue(nameof(anio), value);
        }
        public static String correo
        {
            get => AppSettings.GetValueOrDefault(nameof(correo), string.Empty);
            set => AppSettings.AddOrUpdateValue(nameof(correo), value);
        }
        public static String telefono
        {
            get => AppSettings.GetValueOrDefault(nameof(telefono), string.Empty);
            set => AppSettings.AddOrUpdateValue(nameof(telefono), value);
        }
    }
}
