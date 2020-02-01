using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    [Serializable]
    public class Light
    {
        public Color color;
        public double intensity;
        public double attentuation;

        public Vector position;
        public Vector transformationPosition;
        public Vector screenPosition;

        public double Ac = 1;
        public double Al = 0.09;
        public double Aq = 0.032;

        public double ks = 0.3;
        public double kd = 0.7;
        public double ka = 0.3;
        public double shine = 2;

        public Light(Vector position, Color color, double intensity, double attentuation)
        {
            this.position = position;
            this.color = color;
            this.intensity = intensity;
            this.attentuation = attentuation;
        }

        public void Draw()
        {
            for (int i = -5; i < 6; i++)
                for (int j = -5; j < 6; j++)
                {
                    if (Math.Abs(i) + Math.Abs(j) > 6) continue;
                    if (this.screenPosition.values[0] + i < 0 || this.screenPosition.values[0] + i >= Form.dbm.Width || this.screenPosition.values[1] + j < 0 || this.screenPosition.values[1] + j >= Form.dbm.Height)
                        continue;
                    Form.dbm.SetPixel((int)screenPosition.values[0] + i, (int)screenPosition.values[1] + j, color);
                }
            return;
        }

        public void Transform(double W, double H, Matrix projectionMatrix, Matrix viewMatrix)
        {
            Vector vector = new Vector(new double[4] { position.values[0], position.values[1], position.values[2], 1 });

            transformationPosition = viewMatrix.MatrixByVector(vector);
           
            Vector tmp = projectionMatrix.MatrixByVector(transformationPosition);

            for (int i = 0; i < 3; i++)
                tmp.values[i] /= tmp.values[3];

            screenPosition = new Vector(0, 0, 0);

            screenPosition.values[0] = ((tmp.values[0] + 1) / 2) * W;
            screenPosition.values[1] = ((tmp.values[1] + 1) / 2) * H;
            screenPosition.values[2] = (tmp.values[2] + 1) / 2;
        }
    }
}
