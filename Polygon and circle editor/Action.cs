using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

/// <summary>
/// Action class represents any action on figures such as moving figures, vertices or edges, adding vertex on edge of polygon, removing figures etc.
/// </summary>

namespace Polygon_and_circle_editor
{
    public class Action
    {
        public string description = "";
        public List<Polygon> polygons = new List<Polygon>();
        public List<Circle> circles = new List<Circle>();
        public Color currentColor;

        public Action(string description, List<Polygon> polygons, List<Circle> circles, Color currentColor)
        {
            this.description = description;
            this.currentColor = currentColor;
            foreach (Polygon p in polygons)
                this.polygons.Add(new Polygon(p));
            foreach (Circle c in circles)
                this.circles.Add(new Circle(c));
        }
    }
}
