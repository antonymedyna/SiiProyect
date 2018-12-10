using SiiProyect.Modelos;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace SiiProyect.Vistas
{
    class DashBoardCargaAcademica:MasterDetailPage
    {
        private MenuDashBoard menuPage;
        private string sportSelected;
        private CargaAcademica cargaAcademica;
        //private Fondo fondo;
        public DashBoardCargaAcademica()
        {
            crearGui();
        }

        private void crearGui()
        {
            menuPage = new MenuDashBoard();
            cargaAcademica = new CargaAcademica();
            menuPage.OpcionesMenu.ItemSelected += (sender, e) => NavigationTo(e.SelectedItem as MenuOpcion);
            
            Master = menuPage;
            Detail = new NavigationPage(cargaAcademica);
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
