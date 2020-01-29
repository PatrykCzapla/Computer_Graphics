using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    [Serializable]
    public class Model
    {
        public Vector position { get; set; }
        public Vector rotation { get; set; }
        public Vector scale { get; set; }

        public Mesh mesh;

        public string name;

        public Model(Mesh mesh, string name)
        {
            this.mesh = mesh;
            this.name = name;
            position = new Vector(0, 0, 0);
            rotation = new Vector(0, 0, 0);
            scale = new Vector(1, 1, 1);
        }

        public Matrix getModelMatrix()
        {
            Matrix rotations = Matrix.xRotation(rotation.values[0]).MatrixByMatrix(Matrix.yRotation(rotation.values[1])).MatrixByMatrix(Matrix.zRotation(rotation.values[2]));
            Matrix scales = Matrix.Scale(scale.values[0], scale.values[1], scale.values[2]);
            Matrix positions = Matrix.Translation(position.values[0], position.values[1], position.values[2]);

            return positions.MatrixByMatrix(rotations).MatrixByMatrix(scales);
        }

    }
}
