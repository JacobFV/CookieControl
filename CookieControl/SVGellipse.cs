using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookieControl
{
    class SVGellipse : SVGelement
    {
        public point center;
        public point radius;
        public transformMatrix transform;

        public SVGellipse(point center, point radius, transformMatrix transform)
        {
            this.center = center;
            this.radius = radius;
            this.transform = transform;
        }
    }
}
