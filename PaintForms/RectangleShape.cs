using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaintForms
{
    public class RectangleShape : Shape
    {
        public RectangleShape()
        {
            TypeID = "rectangle";
        }
        public int width { get; set; }
        public int height { get; set; }
    }
}
