using SiiProyect.WebServices;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace SiiProyect.Vistas
{
    class Correo:ContentPage
    {
        private ListView lv_correo;
        private List<Modelos.Correo> list_correo;
        private WSCorreo objWsCorreo;
        public Correo()
        {
            list_correo = new List<Modelos.Correo>();
            objWsCorreo = new WSCorreo();
            Title = "Correo";
            Label lblContactos = new Label
            {
                Text = "Contactos",
                TextColor = Color.White,
                WidthRequest = 500,
                HeightRequest = 50,
                FontSize = 40
            };
            StackLayout stkTitulo = new StackLayout
            {
                Padding = new Thickness(10),
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                Orientation = StackOrientation.Horizontal,
                BackgroundColor = Color.FromHex("#2196F3"),
                Children = {
                    lblContactos
                }
            };
            lv_correo = new ListView()
            {
                HasUnevenRows = true,
                ItemTemplate = new DataTemplate(typeof(ResultCellCorreos))
            };
            lv_correo.ItemSelected += (sender, e) =>
            {
                Modelos.Correo sub = (Modelos.Correo)e.SelectedItem;
                Services.ServicioCorreo.EnviarCorreo(sub.correo+";14030678@itcelaya.edu.mx", "", "");
                DisplayAlert("Correcto", "Correo Enviado", "Aceptar");
            };
            StackLayout stkLista = new StackLayout
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                Orientation = StackOrientation.Vertical,
                Children = {
                    lv_correo
                }
            };
            ScrollView scroll = new ScrollView
            {
                Content = stkLista
            };
            StackLayout layout = new StackLayout
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                Orientation = StackOrientation.Vertical,
                Children = {
                    stkTitulo,
                    scroll
                }
            };
            Content = layout;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            try
            {
                list_correo = await objWsCorreo.listaCorreos();
                lv_correo.ItemsSource = list_correo;
                lv_correo.IsVisible = true;
            }
            catch (Exception e) { await DisplayAlert("", e.StackTrace, ""); }

        }
    }
    class ResultCellCorreos : ViewCell
    {
        public ResultCellCorreos()
        {
            var imgContacto = new Image()
            {
                Source = "iconoContacto.png",
                WidthRequest = 50,
                HeightRequest = 50,
                VerticalOptions = LayoutOptions.Center
            };
            var lblNombre = new Label
            {
                FontSize = 30,
                WidthRequest = 300,
                HeightRequest = 30,
                TextColor = Color.FromHex("#2196F3"),
                FontFamily = "Roboto"
            };
            lblNombre.SetBinding(Label.TextProperty, "nombre");
            var lblCorreo = new Label
            {
                FontSize = 30,
                WidthRequest = 1,
                HeightRequest = 30,
                TextColor = Color.Gray,
                FontFamily = "Roboto",
                FontAttributes = FontAttributes.Bold,
                IsVisible = false
            };
            lblCorreo.SetBinding(Label.TextProperty, "correo");
            var lblCorreoText = new Label{
                Text = "Enviar Correo",
                FontSize = 15,
                WidthRequest = 150,
                HeightRequest = 30,
                TextColor = Color.Gray,
                FontFamily = "Roboto",
                FontAttributes = FontAttributes.Bold,
            };
            var stackList = new StackLayout
            {
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.Center,
                Orientation = StackOrientation.Horizontal,
                HeightRequest = 50,
                Children =
                {
                    imgContacto,
                    lblNombre,
                    lblCorreo,
                    lblCorreoText
                }
            };
            View = stackList;
        }
    }
}
