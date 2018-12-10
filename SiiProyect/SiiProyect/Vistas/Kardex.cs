using SiiProyect.Vistas;
using SiiProyect.WebServices;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SiiProyect.Vistas
{
    class Kardex:ContentPage
    {
        private ListView lv_inst;
        private StackLayout st_inst;
        private List<Modelos.Kardex> list_inst;
        private WSKardex objWsKardex;
        public Kardex()
        {
            list_inst = new List<Modelos.Kardex>();
            objWsKardex = new WSKardex();
            CrearGUIAsync();
        }
        public void CrearGUIAsync()
        {
            Title = "Consulta de Kardex";
            var lblCvematBarra = new Label
            {
                Text = "Clave",
                TextColor = Color.White,
                WidthRequest = 80,
                HeightRequest = 35
            };
            var lblMateriaBarra = new Label
            {
                Text = "Materia",
                TextColor = Color.White,
                WidthRequest = 80,
                HeightRequest = 35
            };
            var lblCalificacionBarra = new Label
            {
                Text = "Calificación",
                TextColor = Color.White,
                WidthRequest = 100,
                HeightRequest = 35,
            };
            var lblOpcionBarra = new Label
            {
                Text = "Opción",
                TextColor = Color.White,
                WidthRequest = 80,
                HeightRequest = 35,
            };
            var lblCreditosBarra = new Label
            {
                Text = "Créditos",
                TextColor = Color.White,
                WidthRequest = 80,
                HeightRequest = 35,
            };
            
            var stackBarra = new StackLayout
            {
                Padding = new Thickness(10),
                Orientation = StackOrientation.Horizontal,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                BackgroundColor = Color.FromHex("#2196F3"),
                Children =
                {
                    lblCvematBarra,
                    lblMateriaBarra,
                    lblCalificacionBarra,
                    lblOpcionBarra,
                    lblCreditosBarra
                }
            };
            lv_inst = new ListView()
            {
                HasUnevenRows = true, //Estandarizar items
                ItemTemplate = new DataTemplate(typeof(ResultCell))
            };
            st_inst = new StackLayout()
            {
                Orientation = StackOrientation.Vertical,
                Padding = new Thickness(10),
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                Children =
                {
                    stackBarra,
                    lv_inst
                }
            };
            Content = st_inst;
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            try
            {
                lv_inst.IsVisible = false;
                list_inst = await objWsKardex.listaKardex();
                lv_inst.ItemsSource = list_inst;
                lv_inst.IsVisible = true;
            }
            catch (Exception e) { await DisplayAlert("", e.StackTrace, ""); }

        }
    }
    class ResultCell : ViewCell
    {
        public ResultCell()
        {
            var lblCvemat = new Label()
            {
                FontSize = 14,
                WidthRequest = 70,
                HeightRequest = 35,
                TextColor = Color.Gray,
                FontFamily = "Roboto"
            };
            lblCvemat.SetBinding(Label.TextProperty, "cvemat");
            var lblMateria = new Label
            {
                FontSize = 14,
                WidthRequest = 70,
                HeightRequest = 35,
                TextColor = Color.Gray,
                FontFamily = "Roboto"
            };
            lblMateria.SetBinding(Label.TextProperty, "materia.nombre");
            var lblCalificacion = new Label
            {
                FontSize = 14,
                WidthRequest = 70,
                HeightRequest = 35,
                TextColor = Color.Gray,
                FontFamily = "Roboto",
                FontAttributes = FontAttributes.Bold
            };
            lblCalificacion.SetBinding(Label.TextProperty, "calificacion");
            var lblOpcion = new Label
            {
                FontSize = 14,
                WidthRequest = 50,
                HeightRequest = 35,
                TextColor = Color.Gray,
                FontFamily = "Roboto",

            };
            lblOpcion.SetBinding(Label.TextProperty, "oportunidad.descripcion");
            var lblCreditos = new Label
            {
                FontSize = 14,
                WidthRequest = 50,
                HeightRequest = 35,
                TextColor = Color.Gray,
                FontFamily = "Roboto",

            };
            lblCreditos.SetBinding(Label.TextProperty, "materia.creditos");
            
            var stackList = new StackLayout
            {
                Padding = new Thickness(10),
                Orientation = StackOrientation.Horizontal,
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.Center,
                Children =
                {
                    lblCvemat,
                    lblMateria,
                    lblCalificacion,
                    lblOpcion,
                    lblCreditos
                }
            };
            View = stackList;
        }

    }
}
