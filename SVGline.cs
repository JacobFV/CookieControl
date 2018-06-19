using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookieControl
{
    class SVGline : SVGelement
    {
        public point start;
        public point end;

        public SVGline(point start, point end)
        {
            this.start = start;
            this.end = end;
        }
    }
}