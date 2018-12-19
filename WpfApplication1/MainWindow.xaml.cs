using Entities;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Media3D;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();

            DrawToothpicks();
            DrawScene();

        }

        private void DrawToothpicks()
        {

            var toothpicks = new ToothpickCollection(5);

            foreach(var pick in toothpicks.Toothpicks)
            {

                
                
            }



        }



      
        private void DrawScene()
        {
            Viewport3D Viewport = new Viewport3D(); //Viewport3D class provides a rendering surface for 3-D visual content
            PerspectiveCamera Camera = new PerspectiveCamera();//PerspectiveCamera class object represents a perspective projection camera
            DirectionalLight myDLight = new DirectionalLight();//DirectionalLight class object provides effect along a direction
            AmbientLight AmLight = new AmbientLight();//AmbientLight class objects provides Lights every surface uniformly a bright AmbientLight creates  because of lack of shading, but a low-intensity AmbientLight approximatesthe effect of light that has been scattered by reflecting between diffuse surfaces in the scene.            

            Camera.Position = new Point3D(-5, 2, 3);//setting the camera position in world coordinates
            Camera.LookDirection = new Vector3D(5, -2, -3);//defininig the direction in which the camera looking in world coordinates
            AmLight.Color = Colors.White;//setting the color of light
        
            Vector3D vecD = new Vector3D(-50, -90, 0);
            Rotation3D RD = new AxisAngleRotation3D(vecD, 1);
            RotateTransform3D RotateTrans = new RotateTransform3D(RD);//RotateTransform3D class specify rotation transformation that is parameterized

            //Define an animation for the rotation

            DoubleAnimation myAnimation = new DoubleAnimation();
            myAnimation.From = 1;
            myAnimation.To = 361;
            myAnimation.Duration = new Duration(TimeSpan.FromMilliseconds(3000));//Defining time in second for cube that will be rotate
            myAnimation.RepeatBehavior = RepeatBehavior.Forever;

            RotateTrans.Rotation.BeginAnimation(AxisAngleRotation3D.AngleProperty, myAnimation);

            //Add transformation to the model
            Transform3DGroup Transgroup = new Transform3DGroup();//Transform3DGroup class contains a collection of Transform3Ds.
            Model3DGroup Modelgroup = new Model3DGroup();//The Model3DGroup class is itself a Model3D and is often used to group multiple GeometryModel3Ds

            Transgroup.Children.Add(RotateTrans);

            Modelgroup.Transform = Transgroup;

            Modelgroup.Children.Add(AmLight);
            Viewport.Camera = Camera;

            ModelVisual3D ModelVisualD = new ModelVisual3D();//ModelVisual3D class contains 3-D models

            ModelVisualD.Content = Modelgroup;

            Viewport.Children.Add(ModelVisualD);

            var mb = new ModelBuilder();

            var cubes = new List<Model3DGroup>();
            cubes.Add(mb.MakeCube(0.5, 0.5, 0.1, 0));
            cubes.Add(mb.MakeCube(0.5, 0.5, 0.1, 1.5));
            cubes.Add(mb.MakeCube(0.5, 1.5, 0.1, 1.5));


            foreach (var c in cubes)
            {
                Modelgroup.Children.Add(c);
            }

            this.Content = Viewport;
        }

    }
}
