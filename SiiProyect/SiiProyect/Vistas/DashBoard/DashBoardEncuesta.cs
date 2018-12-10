using SiiProyect.Modelos;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace SiiProyect.Vistas
{
    class DashBoardEncuesta:MasterDetailPage
    {
        private MenuDashBoard menuPage;
        private string sportSelected;
        private Encuesta encuesta;
        //private Fondo fondo;
        public DashBoardEncuesta()
        {
            crearGui();
        }

        private void crearGui()
        {
            menuPage = new MenuDashBoard();
            encuesta = new Encuesta();
            menuPage.OpcionesMenu.ItemSelected += (sender, e) => NavigationTo(e.SelectedItem as MenuOpcion);
            
            Master = menuPage;
            Detail = new NavigationPage(encuesta);
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
