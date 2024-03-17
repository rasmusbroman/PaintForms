using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaintForms
{
    public abstract class Shape
    {   
        public string TypeID { get; protected set; }

        public Point Center { get; set; }

        public Color Color { get; set; }
    }
}