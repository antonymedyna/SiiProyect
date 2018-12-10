using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace SiiProyect.Vistas
{
    class HorariosSemestre: ContentPage
    {
        public HorariosSemestre()
        {
            Title = "Horarios del Semestre";
            var browser = new WebView
            {
                WidthRequest = 350,
                HeightRequest = 700,
                Source = "https://gacela.itc.mx/inscripciones/consultas/horarios_semestre.php"
            };
            StackLayout stkWeb = new StackLayout
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Start,
                Orientation = StackOrientation.Horizontal,
                Children =
                {
                    browser
                }
            };
            Content = stkWeb;
        }
    }
}
