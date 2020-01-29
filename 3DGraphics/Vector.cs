using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    [Serializable]
    public class Vector
    {
        int size;
        public double[] values;

        public Vector(double[] values)
        {
            this.values = values;
            this.size = values.Length;
        }

        public Vector(double value0, double value1, double value2)
        {
            this.values = new double[3];
            this.size = 3;
            values[0] = value0;
            values[1] = value1;
            values[2] = value2;
        }

        public Vector normalize()
        {
            double[] normalized = new double[size];
            double length = 0;
            foreach(double value in values)
                length += value * value;
            length = Math.Sqrt(length);
            for (int i = 0; i < size; i++)
                normalized[i] = values[i] / length;
            return new Vector(normalized);
        }

        public Vector crossProduct(Vector v)
        {
            if (size != 3 || v.size != 3) return null;
            return new Vector(values[1] * v.values[2] - v.values[1] * values[2],
                values[2] * v.values[0] - values[0] * v.values[2], values[0] * v.values[1] - values[1] * v.values[0]);
        }
    }
}
