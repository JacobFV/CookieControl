using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookieControl
{
    public struct point
    {
        public double x;
        public double y;

        public string stringPoint()
        {
            return this.x.ToString() + "," + this.y.ToString();
        }
    }
}
