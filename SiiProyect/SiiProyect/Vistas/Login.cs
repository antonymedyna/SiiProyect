using SiiProyect.WebServices;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using XLabs.Forms.Controls;

namespace SiiProyect.Vistas
{
    class Login : ContentPage
    {
        private ActivityIndicator aiIndicadorLogin;
        private Image imgBarra1, imgBarra2;
        private Entry txtUsuarioLogin, txtContrasenaLogin;
        private CheckBox checkbox;
        private Button btnLogin;
        private Label lblLogin;
        private StackLayout stkLogin1;
        private StackLayout stkLogin2;
        private StackLayout stkLogin3;
        private StackLayout stkLogin;
        public Login()
        {
            //InitializeComponent();
            BackgroundColor = Color.White;
            NavigationPage.SetHasNavigationBar(this, false);
            var sub = new AbsoluteLayout();
            this.BackgroundColor = Color.White;
            this.Content = sub;
            imgBarra1 = new Image
            {
                Source = "imagenSep2.png",
                Aspect = Aspect.Fill,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                WidthRequest = 180,
                HeightRequest = 80
            };
            imgBarra2 = new Image
            {
                Source = "imagenSep1.png",
                Aspect = Aspect.Fill,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Start,
                WidthRequest = 180,
                HeightRequest = 80
            };
            stkLogin1 = new StackLayout
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                Orientation = StackOrientation.Horizontal,
                Children = {
                    imgBarra1,
                    imgBarra2
                }
            };
            Label lblUsuario = new Label
            {
                Text = "No. Control: *",
                FontSize = 23,
                TextColor = Color.White,
                WidthRequest = 300,
                BackgroundColor = Color.FromHex("#2196F3"),
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center
            };
            txtUsuarioLogin = new Entry
            {
                Placeholder = "Ej. 14030678",
                Keyboard = Keyboard.Numeric,
                PlaceholderColor = Color.Gray,
                HorizontalTextAlignment = TextAlignment.Center,
                TextColor = Color.FromHex("#2196F3"),
                HorizontalOptions = LayoutOptions.Center,
                WidthRequest = 300
            };
            Label lblContrasena = new Label
            {
                Text = "Contraseña: *",
                TextColor = Color.White,
                WidthRequest = 300,
                FontSize = 23,
                BackgroundColor = Color.FromHex("#2196F3"),
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center,
            };
            txtContrasenaLogin = new Entry
            {
                IsPassword = true,
                Placeholder = "**********",
                PlaceholderColor = Color.Gray,
                HorizontalTextAlignment = TextAlignment.Center,
                TextColor = Color.FromHex("#2196F3"),
                HorizontalOptions = LayoutOptions.Center,
                WidthRequest = 300
            };
            checkbox = new CheckBox
            {
                DefaultText = "Recordar Contraseña",
                FontSize = 13,
                TextColor = Color.FromHex("#2196F3"),
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                WidthRequest = 200
            };
            btnLogin = new Button
            {
                Text = "Iniciar",
                BackgroundColor = Color.FromHex("#2196F3"),
                TextColor = Color.White,
                WidthRequest = 300
            };
            btnLogin.Clicked += Btn_Cliked;
            aiIndicadorLogin = new ActivityIndicator
            {
                HorizontalOptions = LayoutOptions.Center
            };
            stkLogin2 = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                HorizontalOptions = LayoutOptions.Center,
                BackgroundColor = Color.White,
                WidthRequest = 300,
                VerticalOptions = LayoutOptions.Center,
                Padding = new Thickness(0, 50, 0, 0),
                Children =
                {
                    lblUsuario,
                    txtUsuarioLogin,
                    lblContrasena,
                    txtContrasenaLogin,
                    checkbox,
                    btnLogin,
                    aiIndicadorLogin
                }
            };
            lblLogin = new Label
            {
                Text = "By Antony Medyna",
                FontSize = 13,
                TextColor = Color.FromHex("#2196F3"),
                HorizontalOptions = LayoutOptions.CenterAndExpand
            };
            Button btnIp = new Button
            {
                BackgroundColor = Color.White,
                Text = "ip",
                TextColor = Color.White,
                WidthRequest = 200,
            };
            btnIp.Clicked += async (sender, args) => await Navigation.PushModalAsync(new Ip());
            stkLogin3 = new StackLayout
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                Padding = new Thickness(0, 50, 0, 0),
                Orientation = StackOrientation.Vertical,
                Children = {
                    lblLogin,
                    btnIp
                }
            };
            stkLogin = new StackLayout
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Start,
                Padding = new Thickness(0, 10, 0, 0),
                Orientation = StackOrientation.Vertical,
                Children = {
                    stkLogin1,
                    stkLogin2,
                    stkLogin3
                }
            };
            if (!String.IsNullOrEmpty(Settings.Settings.nocont) && !String.IsNullOrEmpty(Settings.Settings.password))
            {
                txtUsuarioLogin.Text = Settings.Settings.nocont;
                txtContrasenaLogin.Text = Settings.Settings.password;
            }
            Content = stkLogin;
        }

        private async void Btn_Cliked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUsuarioLogin.Text))
            {
                await DisplayAlert("Error", "Debes introducir un usuario", "Aceptar");
                txtUsuarioLogin.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtContrasenaLogin.Text))
            {
                await DisplayAlert("Error", "Debes de introducir una contraseña", "Aceptar");
                txtContrasenaLogin.Focus();
                return;
            }
            aiIndicadorLogin.IsRunning = true;
            WSLogin objWSL = new WSLogin();
            try
            {
                bool resultado = await objWSL.ConexionAsync(txtUsuarioLogin.Text, txtContrasenaLogin.Text);
                Console.WriteLine("<"+resultado+">");
                if (resultado)
                {
                    if (checkbox.Checked)
                    {
                        Settings.Settings.nocont = txtUsuarioLogin.Text;
                        Settings.Settings.password = txtContrasenaLogin.Text;
                    }
                    else
                    {
                        Settings.Settings.nocont = txtUsuarioLogin.Text;
                        Settings.Settings.password = null;
                    }
                    //Application.Current.MainPage = new MainPage();
                    await Navigation.PushModalAsync(new DashBoardAlumno());
                }
                else
                {
                    await DisplayAlert("Error", "Usuario o Contraseña Incorrectos", "Aceptar");
                    txtUsuarioLogin.Focus();
                    return;
                }
            }
            catch (Exception)
            {
                await DisplayAlert("Error", "Usuario o Contraseña Incorrectos", "Aceptar");
                txtUsuarioLogin.Focus();
                return;
            }
            aiIndicadorLogin.IsRunning = false;
        }

    }
}
