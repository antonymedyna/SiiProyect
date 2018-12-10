using SiiProyect.Modelos;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace SiiProyect.Vistas
{
    class DashBoardDatosPersonales:MasterDetailPage
    {
        private MenuDashBoard menuPage;
        private string sportSelected;
        private DatosPersonales datosPersonales;
        //private Fondo fondo;
        public DashBoardDatosPersonales()
        {
            crearGui();
        }

        private void crearGui()
        {
            menuPage = new MenuDashBoard();
            datosPersonales = new DatosPersonales();
            menuPage.OpcionesMenu.ItemSelected += (sender, e) => NavigationTo(e.SelectedItem as MenuOpcion);
            
            Master = menuPage;
            Detail = new NavigationPage(datosPersonales);
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
    }
}
