using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    public class Renderer
    {
        double aspect;

        public Renderer()
        {
            this.aspect = (double)Form.dbm.Width / (double)Form.dbm.Height;
        }

        private Matrix projectionMatrix(double fov, double far, double close)
        {
            double[,] values = new double[4, 4];

            double ctg = 1 / Math.Tan(fov / 2);

            values[0, 0] = ctg / aspect;
            values[1, 1] = ctg;
            values[2, 2] = (far + close) / (far - close);
            values[3, 2] = -1;
            values[2, 3] = (-2 * far * close) / (far - close);

            return new Matrix(values);
        }

        public void render(Scene scene)
        {
            Matrix projection = projectionMatrix(scene.camera.fov, scene.camera.far, scene.camera.close);

            Matrix viewMatrix = scene.camera.getViewMatrix();

            foreach(Model model in scene.models)
            {
                Matrix modelMatrix = model.getModelMatrix();
                foreach (Vertex v in model.mesh.vertices)
                    v.Transform(Form.dbm.Width, Form.dbm.Height, projection, viewMatrix, modelMatrix);

                foreach(Triangle t in model.mesh.triangles)
                {
                    if (Form.backfaceCulling == true && Tools.cross(t.vertices[0], t.vertices[1], t.vertices[2]) < 0) continue;
                    Triangle triangle = new Triangle(new Vertex(t.vertices[0].screenPosition.values[0],
                        t.vertices[0].screenPosition.values[1], t.vertices[0].screenPosition.values[2]),
                        new Vertex(t.vertices[1].screenPosition.values[0],
                        t.vertices[1].screenPosition.values[1], t.vertices[1].screenPosition.values[2]),
                        new Vertex(t.vertices[2].screenPosition.values[0],
                        t.vertices[2].screenPosition.values[1], t.vertices[2].screenPosition.values[2])
                        );

                    triangle.Draw(Color.Red);
                }
            }

        }
    }
}
