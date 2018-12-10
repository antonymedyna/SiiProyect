using SiiProyect.Modelos;
using SiiProyect.Settings;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace SiiProyect.Vistas
{
    internal class DashBoardAlumno: MasterDetailPage
    {
        private MenuDashBoard menuPage;
        private string sportSelected;
        private Alumno alumno;
        //private Fondo fondo;
        public DashBoardAlumno()
        {
            crearGui();
        }

        private void crearGui()
        {
            menuPage = new MenuDashBoard();
            alumno = new Alumno();
            menuPage.OpcionesMenu.ItemSelected += (sender, e) => NavigationTo(e.SelectedItem as MenuOpcion);
            
            Master = menuPage;
            Detail = new NavigationPage(alumno);
        }
        private void NavigationTo(MenuOpcion item)
        {
            Page pagina = (Page)Activator.CreateInstance(item.TargetType);//crear instancia de pagina
            switch (pagina.GetType().Name)
            {
                case "Alumno":
                    Detail = new NavigationPage(pagina);
                    IsPresented = false;
                    break;
                case "BuzonQuejas":
                    Detail = new NavigationPage(pagina);
                    IsPresented = false;
                    break;
                case "Correo":
                    Detail = new NavigationPage(pagina);
                    IsPresented = false;
                    break;
                case "Login":
                    Detail = new NavigationPage(pagina);
                    IsPresented = false;
                    break;
            }
        }
        protected override bool OnBackButtonPressed()
        {
            DisplayAlert("UPS!.", "Debes Cerrar Sesion", "Aceptar");
            return true;
        }

    }
}
