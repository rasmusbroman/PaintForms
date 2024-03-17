using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaintForms
{
    public class TriangleShape : Shape
    {
        public TriangleShape() 
        {
            TypeID = "triangle";
        }

        public Point[] points {  get; set; }
    }
}
