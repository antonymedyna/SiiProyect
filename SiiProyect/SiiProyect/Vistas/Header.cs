using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace SiiProyect.Vistas
{
    class Header : Frame
    {
        public Header()
        {
            Padding = new Thickness(0, 5, 0, 0);
            HeightRequest = 200;

            //Fondo del Header
            var Backgroundbox = new BoxView
            {
                Color = Color.FromHex("#2196F3"),
                HeightRequest = 100,
            };

            Image BackgroundImg = new Image
            {
                Source = "logoItc.png",
                WidthRequest = 100,
                HeightRequest = 100
            };

            //Imagen de la escuela que esta siguiendo
            Image imgSchool = new Image
            {
                //Source = App.imgSchool,
            };

            //Imagen del evento deportivo
            Image imgEvento = new Image
            {
                Source = "a"+Settings.Settings.nocont+".png",
                WidthRequest = 100,
                HeightRequest = 100
            };

            Image imgLince = new Image
            {
                Source = "imagenSep1.png",
                Opacity = 0.6,
                WidthRequest = 100,
                HeightRequest = 100
            };

            //Enfasis de fondo del nombre de escuela y lema
            var Blackbox = new BoxView
            {
                Color = Color.Black,
                HeightRequest = 30,
                Opacity = 0.25
            };

            Label lblSii = new Label
            {
                //Text = App.nameSchoolCorto,
                //Text = App.SportTitle,
                Text = "SII Alumno",
                FontAttributes = FontAttributes.Bold,
                FontSize = 14,
                TextColor = Color.White,
                FontFamily = "Roboto"
            };
            Label lblNombre = new Label
            {
                Text = "Nombre: " + Settings.Settings.nombreAlumno,
                FontSize = 12,
                TextColor = Color.White,
                FontFamily = "Roboto"
            };
            Label lblEspecialidad = new Label
            {
                Text = "Especialidad: " + Settings.Settings.especialidad,
                FontSize = 12,
                TextColor = Color.White,
                FontFamily = "Roboto"
            };
            Label lblNoControl = new Label
            {
                Text = "No. Control: "+Settings.Settings.nocont,
                FontSize = 12,
                TextColor = Color.White,
                FontFamily = "Roboto"
            };

            //Estructura del Header
            var layoutConstant = new RelativeLayout();

            layoutConstant.Children.Add(
            Backgroundbox,
            Constraint.Constant(0),
            Constraint.Constant(0),
            Constraint.RelativeToParent((parent) => { return parent.Width; }),
            Constraint.RelativeToParent((parent) => { return parent.Height; })
            );
            layoutConstant.Children.Add(
            imgLince,
            Constraint.Constant(0),
            Constraint.Constant(0),
            Constraint.RelativeToParent((parent) => { return parent.Width * 1.2; }),
            Constraint.RelativeToParent((parent) => { return parent.Height * 1.2; })
            );
            layoutConstant.Children.Add(
            Blackbox,
            Constraint.Constant(0),
            Constraint.Constant(125),
            Constraint.RelativeToParent((parent) => { return parent.Width; }),
            Constraint.RelativeToParent((parent) => { return parent.Height; })
            );
            layoutConstant.Children.Add(
            imgSchool,
            Constraint.Constant(10),
            Constraint.Constant(30),
            Constraint.Constant(90),
            Constraint.Constant(90)
            );
            layoutConstant.Children.Add(
            imgEvento,
            //Constraint.Constant(245),
            Constraint.RelativeToParent((parent) => {
                return (parent.Width * 1) - 100;
            }),
            Constraint.Constant(30),
            Constraint.Constant(100),
            Constraint.Constant(100)
            );
            layoutConstant.Children.Add(
            lblSii,
            Constraint.Constant(5),
            Constraint.Constant(130),
            Constraint.RelativeToParent((parent) => { return parent.Width; }),
            Constraint.RelativeToParent((parent) => { return parent.Height; })
            );
            layoutConstant.Children.Add(
            lblNombre,
            Constraint.Constant(5),
            Constraint.Constant(145),
            Constraint.RelativeToParent((parent) => { return parent.Width; }),
            Constraint.RelativeToParent((parent) => { return parent.Height; })
            );
            layoutConstant.Children.Add(
            lblNoControl,
            Constraint.Constant(5),
            Constraint.Constant(160),
            Constraint.RelativeToParent((parent) => { return parent.Width; }),
            Constraint.RelativeToParent((parent) => { return parent.Height; })
            );
            layoutConstant.Children.Add(
            lblEspecialidad,
            Constraint.Constant(5),
            Constraint.Constant(175),
            Constraint.RelativeToParent((parent) => { return parent.Width; }),
            Constraint.RelativeToParent((parent) => { return parent.Height; })
            );

            //Main Stack
            Content = layoutConstant;
        }
    }
}
