using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Media3D;

namespace WpfApplication1
{
    class ModelBuilder
    {
        public Model3DGroup MakeCube(ToothpickCollection toothpicks, Vector3D lookDirection)
        {
            var picks = new Model3DGroup();
            var xMin = toothpicks.xMin();
            var xMax = toothpicks.xMax();

            var yMin = toothpicks.yMin();
            var yMax = toothpicks.yMin();

            var w = 5;
            var h = 5;

            foreach (var pick in toothpicks.Toothpicks)
            {
                var x0 = Utility.Map(pick.x0, toothpicks.xMin(), toothpicks.xMax(), 1.0, w);
                var y0 = Utility.Map(pick.y0, toothpicks.yMin(), toothpicks.yMax(), 1.0, h);

                var x1 = Utility.Map(pick.x1, toothpicks.xMin(), toothpicks.xMax(), 1.0, w);
                var y1 = Utility.Map(pick.y1, toothpicks.yMin(), toothpicks.yMax(), 1.0, h);



            }

            return picks;
        }

        public Model3DGroup MakeCube(double c, double x, double y, double z)
        {
            var cube = new Model3DGroup();
            GeometryModel3D surface1 = new GeometryModel3D();//GeometryModel3D class object provides generalized transformation support for 3-D objects
            GeometryModel3D surface2 = new GeometryModel3D();
            GeometryModel3D surface3 = new GeometryModel3D();
            GeometryModel3D surface4 = new GeometryModel3D();
            GeometryModel3D surface5 = new GeometryModel3D();
            GeometryModel3D surface6 = new GeometryModel3D();

            MeshGeometry3D surface1Plane = new MeshGeometry3D();// MeshGeometry3D class represents a set of 3D surfaces
            MeshGeometry3D surface2Plane = new MeshGeometry3D();
            MeshGeometry3D surface3Plane = new MeshGeometry3D();
            MeshGeometry3D surface4Plane = new MeshGeometry3D();
            MeshGeometry3D surface5Plane = new MeshGeometry3D();
            MeshGeometry3D surface6Plane = new MeshGeometry3D();

            surface1Plane.Positions.Add(new Point3D(-c + x, -c + y, -c + z));
            surface1Plane.Positions.Add(new Point3D(-c + x, c + y, -c + z));
            surface1Plane.Positions.Add(new Point3D(c + x, c + y, -c + z));
            surface1Plane.Positions.Add(new Point3D(c + x, c + y, -c + z));
            surface1Plane.Positions.Add(new Point3D(c + x, -c + y, -c + z));
            surface1Plane.Positions.Add(new Point3D(-c + x, -c + y, -c + z));

            surface2Plane.Positions.Add(new Point3D(-c + x, -c + y, c + z));
            surface2Plane.Positions.Add(new Point3D(c + x, -c + y, c + z));
            surface2Plane.Positions.Add(new Point3D(c + x, c + y, c + z));
            surface2Plane.Positions.Add(new Point3D(c + x, c + y, c + z));
            surface2Plane.Positions.Add(new Point3D(-c + x, c + y, c + z));
            surface2Plane.Positions.Add(new Point3D(-c + x, -c + y, c + z));

            surface3Plane.Positions.Add(new Point3D(-c + x, -c + y, -c + z));
            surface3Plane.Positions.Add(new Point3D(c + x, -c + y, -c + z));
            surface3Plane.Positions.Add(new Point3D(c + x, -c + y, c + z));
            surface3Plane.Positions.Add(new Point3D(c + x, -c + y, c + z));
            surface3Plane.Positions.Add(new Point3D(-c + x, -c + y, c + z));
            surface3Plane.Positions.Add(new Point3D(-c + x, -c + y, -c + z));

            surface4Plane.Positions.Add(new Point3D(c + x, -c + y, -c + z));
            surface4Plane.Positions.Add(new Point3D(c + x, c + y, -c + z));
            surface4Plane.Positions.Add(new Point3D(c + x, c + y, c + z));
            surface4Plane.Positions.Add(new Point3D(c + x, c + y, c + z));
            surface4Plane.Positions.Add(new Point3D(c + x, -c + y, c + z));
            surface4Plane.Positions.Add(new Point3D(c + x, -c + y, -c + z));

            surface5Plane.Positions.Add(new Point3D(c + x, c + y, -c + z));
            surface5Plane.Positions.Add(new Point3D(-c + x, c + y, -c + z));
            surface5Plane.Positions.Add(new Point3D(-c + x, c + y, c + z));
            surface5Plane.Positions.Add(new Point3D(-c + x, c + y, c + z));
            surface5Plane.Positions.Add(new Point3D(c + x, c + y, c + z));
            surface5Plane.Positions.Add(new Point3D(c + x, c + y, -c + z));

            surface6Plane.Positions.Add(new Point3D(-c + x, c + y, -c + z));
            surface6Plane.Positions.Add(new Point3D(-c + x, -c + y, -c + z));
            surface6Plane.Positions.Add(new Point3D(-c + x, -c + y, c + z));
            surface6Plane.Positions.Add(new Point3D(-c + x, -c + y, c + z));
            surface6Plane.Positions.Add(new Point3D(-c + x, c + y, c + z));
            surface6Plane.Positions.Add(new Point3D(-c + x, c + y, -c + z));

            surface2Plane.TriangleIndices.Add(0);
            surface2Plane.TriangleIndices.Add(1);
            surface2Plane.TriangleIndices.Add(2);
            surface2Plane.TriangleIndices.Add(3);
            surface2Plane.TriangleIndices.Add(4);
            surface2Plane.TriangleIndices.Add(5);

            surface1Plane.TriangleIndices.Add(0);
            surface1Plane.TriangleIndices.Add(1);
            surface1Plane.TriangleIndices.Add(2);
            surface1Plane.TriangleIndices.Add(3);
            surface1Plane.TriangleIndices.Add(4);
            surface1Plane.TriangleIndices.Add(5);

            surface3Plane.TriangleIndices.Add(0);
            surface3Plane.TriangleIndices.Add(1);
            surface3Plane.TriangleIndices.Add(2);
            surface3Plane.TriangleIndices.Add(3);
            surface3Plane.TriangleIndices.Add(4);
            surface3Plane.TriangleIndices.Add(5);

            surface4Plane.TriangleIndices.Add(0);
            surface4Plane.TriangleIndices.Add(1);
            surface4Plane.TriangleIndices.Add(2);
            surface4Plane.TriangleIndices.Add(3);
            surface4Plane.TriangleIndices.Add(4);
            surface4Plane.TriangleIndices.Add(5);

            surface5Plane.TriangleIndices.Add(0);
            surface5Plane.TriangleIndices.Add(1);
            surface5Plane.TriangleIndices.Add(2);
            surface5Plane.TriangleIndices.Add(3);
            surface5Plane.TriangleIndices.Add(4);
            surface5Plane.TriangleIndices.Add(5);

            surface6Plane.TriangleIndices.Add(0);
            surface6Plane.TriangleIndices.Add(1);
            surface6Plane.TriangleIndices.Add(2);
            surface6Plane.TriangleIndices.Add(3);
            surface6Plane.TriangleIndices.Add(4);
            surface6Plane.TriangleIndices.Add(5);

            surface1Plane.Normals.Add(new Vector3D(0, 0, -1));
            surface1Plane.Normals.Add(new Vector3D(0, 0, -1));
            surface1Plane.Normals.Add(new Vector3D(0, 0, -1));
            surface1Plane.Normals.Add(new Vector3D(0, 0, -1));
            surface1Plane.Normals.Add(new Vector3D(0, 0, -1));
            surface1Plane.Normals.Add(new Vector3D(0, 0, -1));


            surface2Plane.Normals.Add(new Vector3D(0, 0, 1));
            surface2Plane.Normals.Add(new Vector3D(0, 0, 1));
            surface2Plane.Normals.Add(new Vector3D(0, 0, 1));
            surface2Plane.Normals.Add(new Vector3D(0, 0, 1));
            surface2Plane.Normals.Add(new Vector3D(0, 0, 1));
            surface2Plane.Normals.Add(new Vector3D(0, 0, 1));

            surface3Plane.Normals.Add(new Vector3D(0, -1, 0));
            surface3Plane.Normals.Add(new Vector3D(0, -1, 0));
            surface3Plane.Normals.Add(new Vector3D(0, -1, 0));
            surface3Plane.Normals.Add(new Vector3D(0, -1, 0));
            surface3Plane.Normals.Add(new Vector3D(0, -1, 0));
            surface3Plane.Normals.Add(new Vector3D(0, -1, 0));


            surface4Plane.Normals.Add(new Vector3D(1, 0, 0));
            surface4Plane.Normals.Add(new Vector3D(1, 0, 0));
            surface4Plane.Normals.Add(new Vector3D(1, 0, 0));
            surface4Plane.Normals.Add(new Vector3D(1, 0, 0));
            surface4Plane.Normals.Add(new Vector3D(1, 0, 0));
            surface4Plane.Normals.Add(new Vector3D(1, 0, 0));

            surface5Plane.Normals.Add(new Vector3D(0, 1, 0));
            surface5Plane.Normals.Add(new Vector3D(0, 1, 0));
            surface5Plane.Normals.Add(new Vector3D(0, 1, 0));
            surface5Plane.Normals.Add(new Vector3D(0, 1, 0));
            surface5Plane.Normals.Add(new Vector3D(0, 1, 0));
            surface5Plane.Normals.Add(new Vector3D(0, 1, 0));

            surface6Plane.Normals.Add(new Vector3D(-1, 0, 0));
            surface6Plane.Normals.Add(new Vector3D(-1, 0, 0));
            surface6Plane.Normals.Add(new Vector3D(-1, 0, 0));
            surface6Plane.Normals.Add(new Vector3D(-1, 0, 0));
            surface6Plane.Normals.Add(new Vector3D(-1, 0, 0));
            surface6Plane.Normals.Add(new Vector3D(-1, 0, 0));

            surface1Plane.TextureCoordinates.Add(new Point(1, 0));
            surface1Plane.TextureCoordinates.Add(new Point(1, 1));
            surface1Plane.TextureCoordinates.Add(new Point(0, 1));
            surface1Plane.TextureCoordinates.Add(new Point(0, 1));
            surface1Plane.TextureCoordinates.Add(new Point(0, 0));
            surface1Plane.TextureCoordinates.Add(new Point(1, 0));

            surface2Plane.TextureCoordinates.Add(new Point(0, 0));
            surface2Plane.TextureCoordinates.Add(new Point(1, 0));
            surface2Plane.TextureCoordinates.Add(new Point(1, 1));
            surface2Plane.TextureCoordinates.Add(new Point(1, 1));
            surface2Plane.TextureCoordinates.Add(new Point(0, 1));
            surface2Plane.TextureCoordinates.Add(new Point(0, 0));

            surface3Plane.TextureCoordinates.Add(new Point(0, 0));
            surface3Plane.TextureCoordinates.Add(new Point(1, 0));
            surface3Plane.TextureCoordinates.Add(new Point(1, 1));
            surface3Plane.TextureCoordinates.Add(new Point(1, 1));
            surface3Plane.TextureCoordinates.Add(new Point(0, 1));
            surface3Plane.TextureCoordinates.Add(new Point(0, 0));

            surface4Plane.TextureCoordinates.Add(new Point(1, 0));
            surface4Plane.TextureCoordinates.Add(new Point(1, 1));
            surface4Plane.TextureCoordinates.Add(new Point(0, 1));
            surface4Plane.TextureCoordinates.Add(new Point(0, 1));
            surface4Plane.TextureCoordinates.Add(new Point(0, 0));
            surface4Plane.TextureCoordinates.Add(new Point(1, 0));

            surface5Plane.TextureCoordinates.Add(new Point(1, 1));
            surface5Plane.TextureCoordinates.Add(new Point(0, 1));
            surface5Plane.TextureCoordinates.Add(new Point(0, 0));
            surface5Plane.TextureCoordinates.Add(new Point(0, 0));
            surface5Plane.TextureCoordinates.Add(new Point(1, 0));
            surface5Plane.TextureCoordinates.Add(new Point(1, 1));

            surface6Plane.TextureCoordinates.Add(new Point(0, 1));
            surface6Plane.TextureCoordinates.Add(new Point(0, 0));
            surface6Plane.TextureCoordinates.Add(new Point(1, 0));
            surface6Plane.TextureCoordinates.Add(new Point(1, 0));
            surface6Plane.TextureCoordinates.Add(new Point(1, 1));
            surface6Plane.TextureCoordinates.Add(new Point(0, 1));

            DiffuseMaterial surface1Material = new DiffuseMaterial(Brushes.Red);
            DiffuseMaterial surface2Material = new DiffuseMaterial(Brushes.Yellow);
            DiffuseMaterial surface3Material = new DiffuseMaterial(Brushes.Green);
            DiffuseMaterial surface4Material = new DiffuseMaterial(Brushes.Yellow);
            DiffuseMaterial surface5Material = new DiffuseMaterial(Brushes.Blue);
            DiffuseMaterial surface6Material = new DiffuseMaterial(Brushes.Brown);

            surface2.Material = surface2Material;
            surface6.Material = surface6Material;
            surface1.Material = surface1Material;
            surface3.Material = surface3Material;
            surface4.Material = surface4Material;
            surface5.Material = surface5Material;

            surface1.Geometry = surface1Plane;
            surface2.Geometry = surface2Plane;
            surface3.Geometry = surface3Plane;
            surface4.Geometry = surface4Plane;
            surface5.Geometry = surface5Plane;
            surface6.Geometry = surface6Plane;

            cube.Children.Add(surface1);
            cube.Children.Add(surface2);
            cube.Children.Add(surface3);
            cube.Children.Add(surface4);
            cube.Children.Add(surface5);
            cube.Children.Add(surface6);

            return cube;
        }

    }
}
