using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PaintForms
{
    public class CircleShape : Shape
    {
        public CircleShape() 
        {
            TypeID = "circle";
        }
        [JsonIgnore]
        public int Radius { get; set; }

        [JsonIgnore]
        public int Diameter
        {
            get
            {
                return Radius*2;
            }
        }
    }
}
