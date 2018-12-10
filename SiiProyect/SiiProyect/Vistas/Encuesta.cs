using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace SiiProyect.Vistas
{
    class Encuesta:ContentPage
    {
        private StackLayout stackIniciar;
        private WebView browser;
        public Encuesta()
        {
            crearGUI();
        }
        public void crearGUI()
        {
            Title = "Encuesta de Servicios";
            Label lblTitulo = new Label
            {
                Text = "Encuesta de satisfacción de servicios.",
                TextColor = Color.White,
                WidthRequest = 300
            };
            var stackTitulo = new StackLayout
            {
                Padding = new Thickness(10),
                Orientation = StackOrientation.Horizontal,
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                BackgroundColor = Color.DeepSkyBlue,
                Children =
                {
                    lblTitulo
                }
            };
            Label lblDescripcion = new Label
            {
                Text = "Gracias por responder esta encuesta, el objetivo es medir la percepción de los estudiantes sobre la calidad de los servicios que brinda el Tecnológico Nacional de México en Celaya. Las respuestas serán de gran ayuda para realizar mejoras en ellos.",
                TextColor = Color.Black,
                WidthRequest = 300
            };
            Button btnIniciar = new Button
            {
                Text = "Iniciar",
                BackgroundColor = Color.FromHex("#2196F3"),
                TextColor = Color.White,
                WidthRequest = 300
            };
            btnIniciar.Clicked += Btn_Cliked;
            stackIniciar = new StackLayout
            {
                Padding = new Thickness(10),
                Orientation = StackOrientation.Vertical,
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                HeightRequest = 200,
                Children =
                {
                    lblDescripcion,
                    btnIniciar
                }
            };
            browser = new WebView
            {
                IsVisible = false,
                WidthRequest = 350,
                HeightRequest = 700,
                Source = "https://docs.google.com/forms/d/e/1FAIpQLScwTxEa_Rd9Bi9WoluT64GUYIk1pf_flZ8nZqNwrhoDxJN3jA/formResponse"
            };
            StackLayout stkWeb = new StackLayout
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Start,
                Orientation = StackOrientation.Vertical,
                Children =
                {
                    stackIniciar,
                    browser
                }
            };
            Content = stkWeb;
        }

        private void Btn_Cliked(object sender, EventArgs e)
        {
            stackIniciar.HeightRequest = 0;
            stackIniciar.IsVisible = false;
            browser.IsVisible = true;
        }
    }
}
