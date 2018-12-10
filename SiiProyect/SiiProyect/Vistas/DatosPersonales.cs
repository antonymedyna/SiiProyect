using SiiProyect.WebServices;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace SiiProyect.Vistas
{
    class DatosPersonales:ContentPage
    {
        private Label lblDatos, lblNoCont, lblNombre,
                      lblEspecialidad, lblSexo,
                      lblEmail, lblFechaNacimiento;
        private Entry txtNoCont, txtNombre,
                      txtEspecialidad, txtSexo,txtTelefono,txtCorreo,
                      txtCurp,txtFechaNacimiento;
        private DatePicker dpFechaNacimiento;
        private Picker pEstadoNacimiento; 
        private StackLayout stkNoCont, stkNombre,
                            stkEspecialidad, stkSexo,stkTelefono,stkCorreo,stkCurp,
                            stkEstadoNacimiento, stkFechaNacimiento,stkGuardar;
        private StackLayout stkDatos;
        private Button btnGuardar;
        public DatosPersonales()
        {
            Title = "Datos Personales";
            lblNoCont = new Label
            {
                Text = "No. Control: ",
                WidthRequest = 100,
                FontSize = 18,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                TextColor = Color.FromHex("#2196F3"),
            };
            txtNoCont = new Entry
            {
                Placeholder = Settings.Settings.nocont,
                PlaceholderColor = Color.Green,
                HorizontalTextAlignment = TextAlignment.Start,
                TextColor = Color.Green,
                IsEnabled = false,
                WidthRequest = 250
            };
            stkNoCont = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.Center,
                BackgroundColor = Color.White,
                WidthRequest = 500,
                Children =
                {
                    lblNoCont,
                    txtNoCont
                }
            };
            lblNombre = new Label
            {
                Text = "Nombre: ",
                WidthRequest = 120,
                FontSize = 18,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center,
                TextColor = Color.FromHex("#2196F3"),
            };
            txtNombre = new Entry
            {
                Placeholder = Settings.Settings.nombreAlumno,
                PlaceholderColor = Color.Green,
                HorizontalTextAlignment = TextAlignment.Start,
                TextColor = Color.Green,
                IsEnabled = false,
                WidthRequest = 250
            };
            stkNombre = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.Center,
                BackgroundColor = Color.White,
                WidthRequest = 500,
                Children =
                {
                    lblNombre,
                    txtNombre
                }
            };
            lblEspecialidad = new Label
            {
                Text = "Especialidad:",
                WidthRequest = 130,
                FontSize = 18,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center,
                TextColor = Color.FromHex("#2196F3"),
            };
            txtEspecialidad = new Entry
            {
                Placeholder = Settings.Settings.especialidad,
                PlaceholderColor = Color.Gray,
                TextColor = Color.Green,
                HorizontalTextAlignment = TextAlignment.Start,
                IsEnabled = false,
                WidthRequest = 250
            };
            stkEspecialidad = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.Center,
                BackgroundColor = Color.White,
                WidthRequest = 500,
                Children =
                {
                    lblEspecialidad,
                    txtEspecialidad
                }
            };
            lblSexo = new Label
            {
                Text = "Sexo: ",
                WidthRequest = 100,
                FontSize = 18,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                TextColor = Color.FromHex("#2196F3"),
            };
            txtSexo = new Entry
            {
                Placeholder = "M/F",
                Text = Settings.Settings.sexo,
                PlaceholderColor = Color.Gray,
                TextColor = Color.FromHex("#2196F3"),
                HorizontalTextAlignment = TextAlignment.Start,
                WidthRequest = 250
            };
            stkSexo = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.Center,
                BackgroundColor = Color.White,
                WidthRequest = 500,
                Children =
                {
                    lblSexo,
                    txtSexo
                }
            };
            var lblTelefono = new Label
            {
                Text = "Telefono: ",
                WidthRequest = 100,
                FontSize = 18,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                TextColor = Color.FromHex("#2196F3"),
            };
            txtTelefono = new Entry
            {
                Placeholder = "(000) 000-00-00",
                Text = Settings.Settings.telefono,
                PlaceholderColor = Color.Gray,
                TextColor = Color.FromHex("#2196F3"),
                HorizontalTextAlignment = TextAlignment.Start,
                WidthRequest = 250
            };
            stkTelefono = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.Center,
                BackgroundColor = Color.White,
                WidthRequest = 500,
                Children =
                {
                    lblTelefono,
                    txtTelefono
                }
            };
            var lblCorreo = new Label
            {
                Text = "Correo: ",
                WidthRequest = 100,
                FontSize = 18,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                TextColor = Color.FromHex("#2196F3"),
            };
            txtCorreo = new Entry
            {
                Placeholder = "Ejemplo@itcelaya.edu.mx",
                Text = Settings.Settings.correo,
                PlaceholderColor = Color.Gray,
                HorizontalTextAlignment = TextAlignment.Start,
                TextColor = Color.FromHex("#2196F3"),
                WidthRequest = 250,
            };
            stkCorreo = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.Center,
                BackgroundColor = Color.White,
                WidthRequest = 500,
                Children =
                {
                    lblCorreo,
                    txtCorreo
                }
            };
            var lblCurp = new Label
            {
                Text = "Curp: ",
                WidthRequest = 100,
                FontSize = 18,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                TextColor = Color.FromHex("#2196F3"),
            };
            txtCurp = new Entry
            {
                Placeholder = "MEMA960301HGTDLN02",
                Text = Settings.Settings.curp,
                PlaceholderColor = Color.Gray,
                TextColor = Color.FromHex("#2196F3"),
                HorizontalTextAlignment = TextAlignment.Start,
                WidthRequest = 250
            };
            stkCurp = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.Center,
                BackgroundColor = Color.White,
                WidthRequest = 500,
                Children =
                {
                    lblCurp,
                    txtCurp
                }
            };
            var lblEstadoNacimiento = new Label
            {
                Text = "Es. Naci.: ",
                WidthRequest = 100,
                FontSize = 18,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                TextColor = Color.FromHex("#2196F3"),
            };
            pEstadoNacimiento = new Picker
            {
                TextColor = Color.FromHex("#2196F3"),
                WidthRequest = 250,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.CenterAndExpand
            };
            pEstadoNacimiento.Items.Add("Aguascalientes");
            pEstadoNacimiento.Items.Add("Baja California");
            pEstadoNacimiento.Items.Add("Baja California Sur");
            pEstadoNacimiento.Items.Add("Campeche");
            pEstadoNacimiento.Items.Add("Coahuila");
            pEstadoNacimiento.Items.Add("Colima");
            pEstadoNacimiento.Items.Add("Chiapas");
            pEstadoNacimiento.Items.Add("Chihuahua");
            pEstadoNacimiento.Items.Add("Distrito Federal");
            pEstadoNacimiento.Items.Add("Durango");
            pEstadoNacimiento.Items.Add("Guanajuato");
            pEstadoNacimiento.Items.Add("Guerrero");
            pEstadoNacimiento.Items.Add("Hidalgo");
            pEstadoNacimiento.Items.Add("Jalisco");
            pEstadoNacimiento.Items.Add("México");
            pEstadoNacimiento.Items.Add("Michoacán");
            pEstadoNacimiento.Items.Add("Morelos");
            pEstadoNacimiento.Items.Add("Nayarit");
            pEstadoNacimiento.Items.Add("Nuevo León");
            pEstadoNacimiento.Items.Add("Oaxaca");
            pEstadoNacimiento.Items.Add("Puebla");
            pEstadoNacimiento.Items.Add("Querétaro");
            pEstadoNacimiento.Items.Add("Quintana Roo");
            pEstadoNacimiento.Items.Add("San Luis Potosí");
            pEstadoNacimiento.Items.Add("Sinaloa");
            pEstadoNacimiento.Items.Add("Sonora");
            pEstadoNacimiento.Items.Add("Tabasco");
            pEstadoNacimiento.Items.Add("Tamaulipas");
            pEstadoNacimiento.Items.Add("Tlaxcala");
            pEstadoNacimiento.Items.Add("Veracruz");
            pEstadoNacimiento.Items.Add("Yucatán");
            pEstadoNacimiento.Items.Add("Zacatecas");

            stkEstadoNacimiento = new StackLayout
            {

                Orientation = StackOrientation.Horizontal,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.Center,
                BackgroundColor = Color.White,
                WidthRequest = 500,
                Children =
                {
                    lblEstadoNacimiento,
                    pEstadoNacimiento
                }
            };
            lblFechaNacimiento = new Label
            {
                Text = "Fecha Nacimiento: ",
                WidthRequest = 100,
                FontSize = 18,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                TextColor = Color.FromHex("#2196F3"),
            };
            dpFechaNacimiento = new DatePicker
            {
                //Date = new DateTime(2018, 03, 02),
                Date = new DateTime(int.Parse(Settings.Settings.anio),
                                    int.Parse(Settings.Settings.mes),
                                    int.Parse(Settings.Settings.dia)),
                TextColor = Color.FromHex("#2196F3"),
                WidthRequest = 250
            };
            stkFechaNacimiento = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.Center,
                BackgroundColor = Color.White,
                WidthRequest = 500,
                Children =
                {
                    lblFechaNacimiento,
                    dpFechaNacimiento
                }
            };
            btnGuardar = new Button
            {
                Text = "Guardar Información",
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                WidthRequest = 300,
                BackgroundColor = Color.FromHex("#2196F3"),
                TextColor = Color.White,
            };
            btnGuardar.Clicked += Btn_ClickedAsync;
            stkGuardar = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.Center,
                BackgroundColor = Color.White,
                Padding = new Thickness(0,20,0,0),
                WidthRequest = 500,
                Children =
                {
                    btnGuardar
                }
            };
            stkDatos = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                BackgroundColor = Color.White,
                WidthRequest = 500,
                Children =
                {
                    stkNoCont,
                    stkNombre,
                    stkEspecialidad,
                    stkSexo,
                    stkTelefono,
                    stkCorreo,
                    stkCurp,
                    stkEstadoNacimiento,
                    stkFechaNacimiento,
                    stkGuardar
                }
            };
            Content = stkDatos;
        }

        private async void Btn_ClickedAsync(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSexo.Text))
            {
                await DisplayAlert("Error", "Debes introducir un sexo", "Aceptar");
                txtSexo.Focus();
                return;
            }
            if (txtSexo.Text.Length > 1)
            {
                await DisplayAlert("Error", "El sexo debe ser M o F", "Aceptar");
                txtSexo.Focus();
                return;
            }
            if (!txtSexo.Text.Equals("F") && !txtSexo.Text.Equals("M"))
            {
                await DisplayAlert("Error", "El sexo debe ser F o M", "Aceptar");
                txtSexo.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtCorreo.Text))
            {
                await DisplayAlert("Error", "Debes introducir un email", "Aceptar");
                txtCorreo.Focus();
                return;
            }
            
            WSAlumno objWSAlumno = new WSAlumno();
            if (await objWSAlumno.putAlumnoInfo(txtSexo.Text,txtTelefono.Text, txtCorreo.Text,txtCurp.Text, pEstadoNacimiento.SelectedItem.ToString(), dpFechaNacimiento.Date.ToString()))
            {
                await DisplayAlert("Datos Personales", "Información Actualizada", "Aceptar");
            }
        }
    }
}
