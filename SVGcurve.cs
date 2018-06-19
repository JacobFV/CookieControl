using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookieControl
{
    public class SVGcurve : SVGelement
    {
        public point point1;
        public point point2;
        public point handle1;
        public point handle2;
        public transformMatrix transform;

        public SVGcurve(point point1, point point2, point handle1, point handle2, transformMatrix transform)
        {
            this.point1 = point1;
            this.point2 = point2;
            this.handle1 = handle1;
            this.handle2 = handle2;
            this.transform = transform;
        }
    }
}
