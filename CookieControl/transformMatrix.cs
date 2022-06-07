using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookieControl
{
    public class transformMatrix
    {
        public double a = 1;
        public double b = 0;
        public double c = 0;
        public double d = 1;
        public double e = 0;
        public double f = 0;

        public transformMatrix(
            double a,
            double b,
            double c,
            double d,
            double e,
            double f)
        {
            this.a = a;
            this.b = b;
            this.c = c;
            this.d = d;
            this.e = e;
            this.f = f;
        }
        string printMatrix(){
            return this.a.ToString() + ", " +
                   this.b.ToString() + ", " +
                   this.c.ToString() + ", " +
                   this.d.ToString() + ", " +
                   this.e.ToString() + ", " +
                   this.f.ToString();
        }
    }
}
