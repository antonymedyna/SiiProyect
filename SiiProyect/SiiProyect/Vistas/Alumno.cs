using SiiProyect.Settings;
using SiiProyect.Vistas.DashBoard;
using SiiProyect.WebServices;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Xamarin.Forms;
using XLabs.Forms;

namespace SiiProyect.Vistas
{
    class Alumno:ContentPage
    {
        private ListView lv_alumno,lv_cargaAcademica;
        private ImageButton btnKardex;
        private ImageButton btnCargaAcademica;
        private ImageButton btnOrdenEntrada;
        private ImageButton btnDatosPersonales;
        private ImageButton btnEncuesta;
        private ImageButton btnHorariosSemestre;
        private ImageButton btnInscripcion;
        private StackLayout stkLinea1;
        private StackLayout stkLinea2;
        private StackLayout stkLinea3;
        private StackLayout stkLinea4;
        private StackLayout stkLinea5;
        private StackLayout stkLinea6;
        private StackLayout stkLinea7;
        private StackLayout seccion1,seccion2,seccion3;
        private StackLayout layout;
        private ScrollView scroll;
        private List<Modelos.Alumno> list_alumno;
        private List<Modelos.CargaAcademica> list_cargaAcademica;
        private WSAlumno objWsAlumno;
        private WSCargaAcademica objWSCarga;
        private string sportSelected;

        public Alumno()
        {
            list_alumno = new List<Modelos.Alumno>();
            list_cargaAcademica = new List<Modelos.CargaAcademica>();
            objWsAlumno = new WSAlumno();
            objWSCarga = new WSCargaAcademica();
            crearGUI();
        }
        private void crearGUI()
        {
            Title = Settings.Settings.nocont;
            var command = new Command(async () =>
            {
                await App.Current.MainPage.DisplayActionSheet(
                    "Información de " + Settings.Settings.nombreAlumno,
                    "Aceptar", null,
                    "No. Control: " + Settings.Settings.nocont,
                    "Nombre: " + Settings.Settings.nombreAlumno,
                    "Especialidad: " + Settings.Settings.especialidad);

            });
            ImageButton btnAlumno = new ImageButton
            {
                Source = "a"+Settings.Settings.nocont+".png",
                WidthRequest = 80,
                Command = command,
                HeightRequest = 80
            };
            StackLayout stkBarra1 = new StackLayout
            {
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.Center,
                Orientation = StackOrientation.Vertical,
                WidthRequest = 100,
                Children = {
                    btnAlumno
                }
            };
            Label lblNombre = new Label
            {
                Text = "Nombre",
                TextColor = Color.Black,
                WidthRequest = 100,
                HeightRequest = 30,
            };
            Label lblNoCont = new Label
            {
                Text = "No. Control",
                TextColor = Color.Black,
                WidthRequest = 100,
                HeightRequest = 30,
            };
            Label lblEspecialidad = new Label
            {
                Text = "Especialidad",
                TextColor = Color.Black,
                WidthRequest = 100,
                HeightRequest = 30,
            };
            StackLayout stkBarra2 = new StackLayout
            {
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.Center,
                Orientation = StackOrientation.Vertical,
                WidthRequest = 100,
                Children = {
                    lblNombre,
                    lblNoCont,
                    lblEspecialidad
                }
            };
            lv_alumno = new ListView()
            {
                HasUnevenRows = true,
                ItemTemplate = new DataTemplate(typeof(ResultCelll))
            };
            StackLayout stkBarra3 = new StackLayout
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                Orientation = StackOrientation.Vertical,
                WidthRequest = 100,
                Children = {
                    lv_alumno
                }
            };
            seccion1 = new StackLayout
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                Orientation = StackOrientation.Horizontal,
                HeightRequest = 100,
                Children = {    
                    stkBarra1,
                    stkBarra2,
                    stkBarra3
                }
            };
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
            Label lblCargaCal1 = new Label
            {
                Text = "Ca1",
                TextColor = Color.White,
                WidthRequest = 100,
                HeightRequest = 35,
            };
            Label lblCargaCal2 = new Label
            {
                Text = "Cal2",
                TextColor = Color.White,
                WidthRequest = 100,
                HeightRequest = 35,
            };
            Label lblCargaCal3 = new Label
            {
                Text = "Cal3",
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
                    lblCargaMateria,
                    lblCargaCal1,
                    lblCargaCal2,
                    lblCargaCal3

                }
            };
            lv_cargaAcademica = new ListView()
            {
                HasUnevenRows = true,
                ItemTemplate = new DataTemplate(typeof(ResultCellCarga))
            };
            lv_cargaAcademica.ItemSelected += (sender, e) =>
            {
                Modelos.CargaAcademica sub = (Modelos.CargaAcademica)e.SelectedItem;
                DisplayAlert("Correcto", "Seleccion " + sub.cvemat, "Aceptar");
            };
            seccion2 = new StackLayout
            {
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.Center,
                Orientation = StackOrientation.Vertical,
                HeightRequest = 315,
                Children = {
                    stkCarga1,
                    lv_cargaAcademica
                }
            };
            btnKardex = new ImageButton
            {
                Source = "iconoFondoKardex.png",
                Aspect = Aspect.Fill,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                WidthRequest = Application.Current.MainPage.Width,
                HeightRequest = 100
            };
            btnKardex.Clicked += async (sender,args)=> await Navigation.PushModalAsync(new DashBoardKardex());
            btnCargaAcademica = new ImageButton
            {
                Source = "iconoFondoCargaAcademica.png",
                Aspect = Aspect.Fill,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                WidthRequest = Application.Current.MainPage.Width,
                HeightRequest = 100
            };
            btnCargaAcademica.Clicked += async (sender, args) => await Navigation.PushModalAsync(new DashBoardCargaAcademica());
            btnOrdenEntrada = new ImageButton
            {
                Source = "iconoFondoOrdenEntrada.png",
                Aspect = Aspect.Fill,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                WidthRequest = Application.Current.MainPage.Width,
                HeightRequest = 100
            };
            btnOrdenEntrada.Clicked += async (sender, args) => await Navigation.PushModalAsync(new DashBoardOrdenEntrada());
            btnDatosPersonales = new ImageButton
            {
                Source = "iconoFondoDatosPersonales.png",
                Aspect = Aspect.Fill,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                WidthRequest = Application.Current.MainPage.Width,
                HeightRequest = 100
            };
            btnDatosPersonales.Clicked += async (sender, args) => await Navigation.PushModalAsync(new DashBoardDatosPersonales());
            btnEncuesta = new ImageButton
            {
                Source = "iconoFondoEncuesta.png",
                Aspect = Aspect.Fill,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                WidthRequest = Application.Current.MainPage.Width,
                HeightRequest = 100
            };
            btnEncuesta.Clicked += async (sender, args) => await Navigation.PushModalAsync(new DashBoardEncuesta());
            btnHorariosSemestre = new ImageButton
            {
                Source = "iconoHorariosSemestre.png",
                Aspect = Aspect.Fill,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                WidthRequest = Application.Current.MainPage.Width,
                HeightRequest = 100
            };
            btnHorariosSemestre.Clicked += async (sender, args) => await Navigation.PushModalAsync(new DashBoardHorariosSemestre());
            btnInscripcion = new ImageButton
            {
                Source = "iconoFondoInscripcion.png",
                Aspect = Aspect.Fill,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                WidthRequest = Application.Current.MainPage.Width,
                HeightRequest = 100
            };
            btnInscripcion.Clicked += async (sender, args) => await Navigation.PushModalAsync(new DashBoardInscripcion());
            stkLinea1 = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                Children = { btnKardex }
            };
            stkLinea2 = new StackLayout
            {
                
                Orientation = StackOrientation.Horizontal,
                Children = { btnCargaAcademica }
            };
            stkLinea3 = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                Children = { btnDatosPersonales }
            };
            stkLinea4 = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                Children = { btnEncuesta }
            };
            stkLinea5 = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                Children = { btnOrdenEntrada }
            };
            stkLinea6 = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                Children = { btnHorariosSemestre }
            };
            stkLinea7 = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                Children = { btnInscripcion }
            };
            seccion3 = new StackLayout
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                Orientation = StackOrientation.Vertical,
                Children = {
                    stkLinea1,
                    stkLinea2,
                    stkLinea3,
                    stkLinea4,
                    stkLinea5,
                    stkLinea6,
                    stkLinea7
                }
            };
            layout = new StackLayout
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                Orientation = StackOrientation.Vertical,
                Children = {
                    seccion1,
                    seccion2,
                    seccion3
                }
            };
            scroll = new ScrollView
            {
                Content = layout
            };
            Content = scroll;
        }

        private void Btn_Clicked(object sender, EventArgs e)
        {
            Console.WriteLine("Antony");
            Command Command = new Command(async () =>
            {
                sportSelected = await App.Current.MainPage.DisplayActionSheet("Disciplinas", "Cancelar", null,
                    "Ajedrez", "Atletismo", "Básquetbol", "Béisbol",
                    "Fútbol", "Natación", "Tenis",
                    "Vóleibol de Playa", "Vóleibol de Sala");
                if (sportSelected == null)
                    sportSelected = App.SportTitle;
                if (!sportSelected.Equals("Cancelar"))
                {
                    App.SportTitle = sportSelected;
                    switch (App.SportTitle)
                    {
                        case "Ajedrez":
                            App.SportNumber = 1;
                            App.tipoCompetencia = 1; //Individual
                                    break;
                        case "Atletismo":
                            App.SportNumber = 2;
                            App.tipoCompetencia = 2; //Equipo
                                    break;
                        case "Básquetbol":
                            App.SportNumber = 3;
                            App.tipoCompetencia = 2;
                            break;
                        case "Béisbol":
                            App.SportNumber = 4;
                            App.tipoCompetencia = 2;
                            break;
                        case "Fútbol":
                            App.SportNumber = 5;
                            App.tipoCompetencia = 2;
                            break;
                        case "Natación":
                            App.SportNumber = 6;
                            App.tipoCompetencia = 2;
                            break;
                        case "Tenis":
                            App.SportNumber = 7;
                            App.tipoCompetencia = 1;
                            break;
                        case "Vóleibol de Playa":
                            App.SportNumber = 8;
                            App.tipoCompetencia = 2;
                            break;
                        case "Vóleibol de Sala":
                            App.SportNumber = 9;
                            App.tipoCompetencia = 2;
                            break;
                    }
                }
            });
            //    }
            //);
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            try
            {
                lv_alumno.IsVisible = false;
                list_alumno = await objWsAlumno.listaAlumno();
                lv_alumno.ItemsSource = list_alumno;
                list_cargaAcademica = await objWSCarga.listaCargaAcademica();
                lv_cargaAcademica.ItemsSource = list_cargaAcademica;
                lv_alumno.IsVisible = true;
                lv_cargaAcademica.IsVisible = true;
            }
            catch (Exception e) { await DisplayAlert("", e.StackTrace, ""); }
        }
    }
    class ResultCelll : ViewCell
    {
        public ResultCelll()
        {
            var lblNoCont = new Label()
            {
                FontSize = 10,
                WidthRequest = 100,
                HeightRequest = 30,
                TextColor = Color.Gray,
                FontFamily = "Roboto"
            };
            lblNoCont.SetBinding(Label.TextProperty, "nocont");
            var lblEspecialidadNombre = new Label
            {
                FontSize = 10,
                WidthRequest = 100,
                HeightRequest = 30,
                TextColor = Color.Gray,
                FontFamily = "Roboto"
            };
            lblEspecialidadNombre.SetBinding(Label.TextProperty, "especialidad.nombre");
            var lblNombre = new Label
            {
                FontSize = 10,
                WidthRequest = 100,
                HeightRequest = 30,
                TextColor = Color.Gray,
                FontFamily = "Roboto",
                FontAttributes = FontAttributes.Bold
            };
            lblNombre.SetBinding(Label.TextProperty, "nombre");

            var stackList = new StackLayout
            {
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                Orientation = StackOrientation.Vertical,
                WidthRequest = 100,
                Children =
                {
                    lblNombre,
                    lblNoCont,
                    lblEspecialidadNombre
                }
            };
            View = stackList;
        }
    }
    class ResultCellCarga : ViewCell
    {
        public ResultCellCarga()
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
                WidthRequest = 100,
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
            var lblCargaCal1 = new Label
            {
                FontSize = 10,
                WidthRequest = 100,
                HeightRequest = 35,
                TextColor = Color.Gray,
                FontFamily = "Roboto",
                FontAttributes = FontAttributes.Bold
            };
            lblCargaCal1.SetBinding(Label.TextProperty, "cal1");
            var lblCargaCal2 = new Label
            {
                FontSize = 10,
                WidthRequest = 100,
                HeightRequest = 35,
                TextColor = Color.Gray,
                FontFamily = "Roboto",
                FontAttributes = FontAttributes.Bold
            };
            lblCargaCal2.SetBinding(Label.TextProperty, "cal2");
            var lblCargaCal3 = new Label
            {
                FontSize = 10,
                WidthRequest = 100,
                HeightRequest = 35,
                TextColor = Color.Gray,
                FontFamily = "Roboto",
                FontAttributes = FontAttributes.Bold
            };
            lblCargaCal3.SetBinding(Label.TextProperty, "cal3");
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
                    lblCargaMateria,
                    lblCargaCal1,
                    lblCargaCal2,
                    lblCargaCal3
                }
            };
            View = stackList;
        }
    }
}
