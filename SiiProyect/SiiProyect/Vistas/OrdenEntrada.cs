using SiiProyect.WebServices;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace SiiProyect.Vistas
{
    class OrdenEntrada:ContentPage
    {
        private List<Modelos.OrdenEntrada> list_orden;
        private ListView lv_orden;
        private WSOrdenEntrada objWSOrden;
        public OrdenEntrada()
        {
            list_orden = new List<Modelos.OrdenEntrada>();
            objWSOrden = new WSOrdenEntrada();
            crearGUI();
        }
        public void crearGUI()
        {
            Title = "Orden de Entrada";
            Label lblDia = new Label
            {
                Text = "Día",
                TextColor = Color.White,
                WidthRequest = 80,
                HeightRequest = 35,
            };
            Label lblMes = new Label
            {
                Text = "Mes",
                TextColor = Color.White,
                WidthRequest = 80,
                HeightRequest = 35,
            };
            Label lblAnio = new Label
            {
                Text = "Año",
                TextColor = Color.White,
                WidthRequest = 80,
                HeightRequest = 35,
            };
            Label lblHora = new Label
            {
                Text = "Hora",
                TextColor = Color.White,
                WidthRequest = 80,
                HeightRequest = 35,
            };
            StackLayout stkBarra = new StackLayout
            {
                Padding = new Thickness(10),
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.Start,
                Orientation = StackOrientation.Horizontal,
                BackgroundColor = Color.FromHex("#2196F3"),
                Children = {
                    lblDia,
                    lblMes,
                    lblAnio,
                    lblHora
                }
            };
            lv_orden = new ListView()
            {
                HasUnevenRows = true, //Estandarizar items
                ItemTemplate = new DataTemplate(typeof(ResultCellll))
            };
            StackLayout stkOrden = new StackLayout
            {
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                Padding = new Thickness(10),
                VerticalOptions = LayoutOptions.Center,
                Orientation = StackOrientation.Vertical,
                Children = {
                    stkBarra,
                    lv_orden
                }
            };
            Content = stkOrden;
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            try
            {
                lv_orden.IsVisible = false;
                list_orden = await objWSOrden.listaOrden();
                lv_orden.ItemsSource = list_orden;
                lv_orden.IsVisible = true;
            }
            catch (Exception e) { await DisplayAlert("", e.StackTrace, ""); }

        }
    }
    class ResultCellll : ViewCell
    {
        public ResultCellll()
        {
            var lblDia = new Label()
            {
                FontSize = 14,
                WidthRequest = 80,
                HeightRequest = 35,
                TextColor = Color.Gray,
                FontFamily = "Roboto"
            };
            lblDia.SetBinding(Label.TextProperty, "dia");
            var lblMes = new Label
            {
                FontSize = 14,
                WidthRequest = 80,
                HeightRequest = 35,
                TextColor = Color.Gray,
                FontFamily = "Roboto"
            };
            lblMes.SetBinding(Label.TextProperty, "mes");
            var lblAnio = new Label
            {
                FontSize = 14,
                WidthRequest = 80,
                HeightRequest = 35,
                TextColor = Color.Gray,
                FontFamily = "Roboto",
                FontAttributes = FontAttributes.Bold
            };
            lblAnio.SetBinding(Label.TextProperty, "anio");
            var lblHora = new Label
            {
                FontSize = 14,
                WidthRequest = 80,
                HeightRequest = 35,
                TextColor = Color.Gray,
                FontFamily = "Roboto",
                FontAttributes = FontAttributes.Bold
            };
            lblHora.SetBinding(Label.TextProperty, "hora");
            var stackList = new StackLayout
            {
                Padding = new Thickness(10),
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Start,
                Orientation = StackOrientation.Horizontal,
                Children =
                {
                    lblDia,
                    lblMes,
                    lblAnio,
                    lblHora
                }
            };
            View = stackList;
        }

    }
}
