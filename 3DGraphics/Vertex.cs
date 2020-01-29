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

        public Vertex(Vertex v)
        {
            this.x = v.x;
            this.y = v.y;
            this.z = v.z;
        }

        public Vertex(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public Vertex(double x, double y, double z, Vector normalVector, double Tx, double Ty)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.normalVector = normalVector;
            this.Tx = Tx;
            this.Ty = Ty;
        }

        public void Draw(Color color)
        {
            for (int i = -2; i < 3; i++)
                for (int j = -2; j < 3; j++)
                {
                    if (this.x + i < 0 || this.x + i >= Form.dbm.Width || this.y + j < 0 || this.y + j >= Form.dbm.Height) 
                        continue;
                    Form.dbm.SetPixel((int)x + i, (int)y + j, color);
                }
            return;
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
            screenPosition.values[2] = (transformationPosition.values[2] + 1) / 2;

        }
    }
}
