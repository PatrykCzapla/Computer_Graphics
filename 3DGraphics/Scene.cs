using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    [Serializable]
    public class Scene
    {
        public List<Model> models = new List<Model>();

        public Camera camera;

        public List<Light> lights;

        public Scene(List<Model> models, Camera camera, List<Light> lights)
        {
            this.models = models;
            this.camera = camera;
            this.lights = lights;
        }
    }
}
