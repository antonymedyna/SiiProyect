using SiiProyect.Modelos;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace SiiProyect.Vistas.DashBoard
{
    class DashBoardHorariosSemestre: MasterDetailPage
    {
        private MenuDashBoard menuPage;
        private string sportSelected;
        private HorariosSemestre horariosSemestre;
        //private Fondo fondo;
        public DashBoardHorariosSemestre()
        {
            crearGui();
        }

        private void crearGui()
        {
            menuPage = new MenuDashBoard();
            horariosSemestre = new HorariosSemestre();
            menuPage.OpcionesMenu.ItemSelected += (sender, e) => NavigationTo(e.SelectedItem as MenuOpcion);

            Master = menuPage;
            Detail = new NavigationPage(horariosSemestre);
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
