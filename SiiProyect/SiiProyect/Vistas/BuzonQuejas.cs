using SiiProyect.WebServices;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace SiiProyect.Vistas
{
    class BuzonQuejas : ContentPage
    {
        private Entry txtDescripcion;
        private Picker pTipo;
        private Button btnEnviar;
        public BuzonQuejas()
        {
            Title = "Formato para Quejas";
            var lblFormato = new Label
            {
                Text = "En el Servicio del Instituto Tecnológico de Celaya estamos involucrados en un proceso de mejora de la calidad. Es evidente que para mejorar necesitamos su ayuda. Por tanto, como punto de partida, se ha habilitado este buzón para que el usuario pueda hacernos llegar sus quejas, sugerencias y agradecimientos sobre cualquier faceta de nuestra Institución. ",
                TextColor = Color.Gray,
                FontSize = 14,
                WidthRequest = 300,
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                HorizontalTextAlignment = TextAlignment.Start,
            };
            var lblCorreo = new Label
            {
                Text = Settings.Settings.correo,
                TextColor = Color.Gray,
                FontSize = 28,
                WidthRequest = 400
            };
            var lblTipo = new Label
            {
                Text = "Tipo de Queja",
                TextColor = Color.White,
                BackgroundColor = Color.FromHex("#2196F3"),
                FontSize = 18,
                WidthRequest = 310,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Start
            };
            pTipo = new Picker
            {
                WidthRequest = 500,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.CenterAndExpand
            };
            pTipo.Items.Add("Queja");
            pTipo.Items.Add("Sugerencia");
            pTipo.Items.Add("Agradecimiento");
            pTipo.Items.Add("Asesoria");
            pTipo.Items.Add("Pregunta");
            var lblDescripcion = new Label
            {
                Text = "Descripcion",
                FontSize = 18,
                BackgroundColor = Color.FromHex("#2196F3"),
                TextColor = Color.White,
                WidthRequest = 310,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Start,
            };
            txtDescripcion = new Entry
            {
                Margin = 1,
                WidthRequest = 300,
                HeightRequest = 200,
                Placeholder = "Describe...",
                PlaceholderColor = Color.Gray
             };
            btnEnviar = new Button
            {
                Text = "Enviar",
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                WidthRequest = 300,
                BackgroundColor = Color.FromHex("#2196F3"),
                TextColor = Color.White,
            };
            btnEnviar.Clicked += Btn_Clicked;
            var stkQuejas = new StackLayout
            {
                Padding = new Thickness(10,10,0,0),
                Orientation = StackOrientation.Vertical,
                HorizontalOptions = LayoutOptions.Center,
                BackgroundColor = Color.White,
                WidthRequest = 500,
                Children =
                {
                    lblFormato,
                    lblCorreo,
                    lblTipo,
                    pTipo,
                    lblDescripcion,
                    txtDescripcion,
                    btnEnviar
                }
            };
            ScrollView scroll = new ScrollView
            {
                Content = stkQuejas
            };
            Content = scroll;
        }

        private async void Btn_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtDescripcion.Text))
            {
                await DisplayAlert("Error", "Debes introducir una descripcion", "Aceptar");
                txtDescripcion.Focus();
                return;
            }
            try
            {
                Console.WriteLine("<" + pTipo.SelectedItem + ">");
                WSAlumno objWSAlumno = new WSAlumno();
                if (await objWSAlumno.insertarQueja(Settings.Settings.correo, pTipo.SelectedItem.ToString(), txtDescripcion.Text))
                {
                    txtDescripcion.Text = "";
                    await DisplayAlert("Queja", "Se ha enviado la queja", "Aceptar");
                }
                return;
            }
            catch (Exception) {
                await DisplayAlert("Error", "Debes seleccionar una queja", "Aceptar");
                txtDescripcion.Focus();
                return;
            }
        }
    }
}
