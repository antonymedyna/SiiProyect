using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace SiiProyect.Vistas
{
    class Ip:ContentPage
    {
        private Entry txtIp;
        public Ip()
        {
            crearGUI();
        }
        private void crearGUI()
        {
            Title = "IP";
            txtIp = new Entry
            {
                Text = Settings.Settings.ip,
            };
            Button btnIp = new Button
            {
                Text = "Asignar"
            };
            btnIp.Clicked += Btn_Clicked;
            StackLayout stk = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                Children =
                {
                    txtIp,
                    btnIp
                }
            };
            Content = stk;
        }

        private void Btn_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtIp.Text))
            {
                DisplayAlert("Error", "Debes introducir una ip", "Aceptar");
                txtIp.Focus();
                return;
            }
            Settings.Settings.ip = txtIp.Text;
            DisplayAlert("Servidor","Ip Asignada "+txtIp.Text,"Aceptar");
        }
    }
}
