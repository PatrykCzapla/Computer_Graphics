using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    [Serializable]
    public class Vertex
    {
        public double x, y, z;

        public Vector normalVector;
        public Vector tangentVector;
        public Vector binormalVector;

        public double Tx, Ty;

        public Vector transformationPosition;
        public Vector screenPosition;

        public Vector transformationNormal;
        public Vector inCameraPosition;

        public Vertex(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public Vertex(double x, double y, double z, Vector normalVector, double Tx = -1, double Ty = -1)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.normalVector = normalVector;
            this.Tx = Tx;
            this.Ty = Ty;
        }

        public void Transform(double W, double H, Matrix projectionMatrix, Matrix viewMatrix, Matrix modelMatrix)
        {
            Vector vector = new Vector(new double[4]{ x, y, z, 1});
            
            transformationPosition = projectionMatrix.MatrixByVector(viewMatrix.MatrixByVector(modelMatrix.MatrixByVector(vector)));

            screenPosition = new Vector(0, 0, 0);

            for (int i = 0; i < 3; i++)
                transformationPosition.values[i] /= transformationPosition.values[3];
            screenPosition.values[0] = ((transformationPosition.values[0] + 1) / 2) * W;
            screenPosition.values[1] = ((transformationPosition.values[1] + 1) / 2) * H;
            screenPosition.values[2] = (transformationPosition.values[2] + 1)/ 2;

            double[] tmp = { normalVector.values[0], normalVector.values[1], normalVector.values[2], 0 };
            transformationNormal = viewMatrix.MatrixByVector(modelMatrix.MatrixByVector(new Vector(tmp)));
            inCameraPosition = viewMatrix.MatrixByVector(modelMatrix.MatrixByVector(vector));

        }

        public void makeNormal(Vector center)
        {
            normalVector = new Vector(x - center.values[0], y - center.values[1], z - center.values[2]);
            normalVector = normalVector.normalize();
        }
    }
}
