using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    [Serializable]
    public abstract class Model
    {
        public Vector position { get; set; }
        public Vector rotation { get; set; }
        public Vector scale { get; set; }

        public Mesh mesh;
        public string name;
    }
}
