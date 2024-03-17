using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaintForms
{
    public class SquareShape : Shape
    {
        public SquareShape() 
        {
            TypeID = "square";
        }
        public int side { get; set; }
    }
}
