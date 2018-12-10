using SiiProyect.WebServices;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace SiiProyect.Vistas
{
    class CargaAcademica:ContentPage
    {
        private ListView lv_alumno, lv_cargaAcademica;
        private List<Modelos.CargaAcademica> list_cargaAcademica;
        private WSCargaAcademica objWSCarga;
        public CargaAcademica()
        {
            list_cargaAcademica = new List<Modelos.CargaAcademica>();
            objWSCarga = new WSCargaAcademica();
            Title = "Carga Academica";
            Label lblCargaClave = new Label
            {
                Text = "Clave",
                TextColor = Color.White,
                WidthRequest = 100,
                HeightRequest = 35,
            };
            Label lblCargaGrupo = new Label
            {
                Text = "Grupo",
                TextColor = Color.White,
                WidthRequest = 100,
                HeightRequest = 35,
            };
            Label lblCargaMateria = new Label
            {
                Text = "Materia",
                TextColor = Color.White,
                WidthRequest = 100,
                HeightRequest = 35,
            };
            StackLayout stkCarga1 = new StackLayout
            {
                Padding = new Thickness(10),
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.Center,
                Orientation = StackOrientation.Horizontal,
                BackgroundColor = Color.FromHex("#2196F3"),
                Children = {
                    lblCargaClave,
                    lblCargaGrupo,
                    lblCargaMateria
                }
            };
            lv_cargaAcademica = new ListView()
            {
                HasUnevenRows = true,
                ItemTemplate = new DataTemplate(typeof(ResultCellCargaAcademica))
            };
            lv_cargaAcademica.ItemSelected += (sender, e) =>
            {
                Modelos.CargaAcademica sub = (Modelos.CargaAcademica)e.SelectedItem;
                DisplayAlert("Correcto", "Seleccion " + sub.cvemat, "Aceptar");
            };
            StackLayout st_inst = new StackLayout()
            {
                Orientation = StackOrientation.Vertical,
                Padding = new Thickness(10),
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                Children =
                {
                    stkCarga1,
                    lv_cargaAcademica
                }
            };
            Content = st_inst;
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            try
            {
                list_cargaAcademica = await objWSCarga.listaCargaAcademica();
                lv_cargaAcademica.ItemsSource = list_cargaAcademica;
            }
            catch (Exception e) { await DisplayAlert("", e.StackTrace, ""); }
        }
    }
    class ResultCellCargaAcademica : ViewCell
    {
        public ResultCellCargaAcademica()
        {
            var lblCargaClave = new Label()
            {
                FontSize = 10,
                WidthRequest = 100,
                HeightRequest = 35,
                TextColor = Color.Gray,
                FontFamily = "Roboto"
            };
            lblCargaClave.SetBinding(Label.TextProperty, "cvemat");
            var lblCargaGrupo = new Label
            {
                FontSize = 10,
                WidthRequest = 50,
                HeightRequest = 35,
                TextColor = Color.Gray,
                FontFamily = "Roboto"
            };
            lblCargaGrupo.SetBinding(Label.TextProperty, "nogpo");
            var lblCargaMateria = new Label
            {
                FontSize = 10,
                WidthRequest = 120,
                HeightRequest = 35,
                TextColor = Color.Gray,
                FontFamily = "Roboto",
                FontAttributes = FontAttributes.Bold
            };
            lblCargaMateria.SetBinding(Label.TextProperty, "materia");
            var stackList = new StackLayout
            {
                Padding = new Thickness(10),
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.Center,
                Orientation = StackOrientation.Horizontal,
                Children =
                {
                    lblCargaClave,
                    lblCargaGrupo,
                    lblCargaMateria
                }
            };
            View = stackList;
        }
    }
}
