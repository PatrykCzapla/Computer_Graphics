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
        public double aspect;

        public Renderer()
        {
            this.aspect = (double)Form.dbm.Width / (double)Form.dbm.Height;
        }               

        public void render(Scene scene)
        {
            Matrix projection = Matrix.projectionMatrix(scene.camera.fov, scene.camera.far, scene.camera.close, aspect);

            Matrix viewMatrix = scene.camera.getViewMatrix();

            foreach (Light l in Form.lights)
                l.Transform(Form.dbm.Width, Form.dbm.Height, projection, viewMatrix);

            foreach (Model model in scene.models)
            {
                Matrix modelMatrix = Matrix.getModelMatrix(model);
                foreach (Vertex v in model.mesh.vertices)
                    v.Transform(Form.dbm.Width, Form.dbm.Height, projection, viewMatrix, modelMatrix);

                foreach (Triangle t in model.mesh.triangles)
                {
                    if (Form.backfaceCulling == true && Tools.cross(t.vertices[0].screenPosition, t.vertices[1].screenPosition, t.vertices[2].screenPosition) < 0) continue;
                    t.Draw(Color.LightPink);
                }
            }

        }
    }
}
