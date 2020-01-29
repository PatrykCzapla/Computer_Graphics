using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    [Serializable]
    public class Camera
    {
        public Vector position;
        public Vector point;
        public Vector UWorld = new Vector(0, 1, 0);
        public double fov;
        public double far;
        public double close;

        public Camera(Vector position, Vector point, double fov, double far, double close)
        {
            this.position = position;
            this.point = point;
            this.fov = fov;
            this.far = far;
            this.close = close;
        }

        public Matrix getViewMatrix()
        {
            Vector dir = new Vector(position.values[0] - point.values[0],
                position.values[1] - point.values[1], position.values[2] - point.values[2]);
            dir = dir.normalize();

            Vector R = UWorld.crossProduct(dir);
            R.normalize();

            Vector U = dir.crossProduct(R);
            U.normalize();

            double[,] View = new double[4, 4];
            View[0, 0] = R.values[0];
            View[0, 1] = R.values[1];
            View[0, 2] = R.values[2];

            View[1, 0] = U.values[0];
            View[1, 1] = U.values[1];
            View[1, 2] = U.values[2];

            View[2, 0] = dir.values[0];
            View[2, 1] = dir.values[1];
            View[2, 2] = dir.values[2];

            View[3, 3] = 1;

            Matrix ViewMatrix = new Matrix(View);

            double[,] tmp = new double[4, 4];
            tmp[0, 0] = 1;
            tmp[1, 1] = 1;
            tmp[2, 2] = 1;
            tmp[3, 3] = 1;

            tmp[0, 3] = -position.values[0];
            tmp[1, 3] = -position.values[1];
            tmp[2, 3] = -position.values[2];

            Matrix matrix = new Matrix(tmp);

            return ViewMatrix.MatrixByMatrix(matrix);
        }
    }
}
