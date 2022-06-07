using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookieControl
{
    public class SVGelement
    {
        //used for making quick trick arrays of quadCode elements
        public string elementToString()
        {
            string returnString = "";
            if (this is SVGline)
            {
                SVGline line = (SVGline)this;
                returnString = "line from " +
                               line.start.x.ToString() + "," +
                               line.start.y.ToString() + " to " +
                               line.start.x.ToString() + "," +
                               line.start.y.ToString();
            }
            if (this is SVGellipse)
            {
                SVGellipse ellispe = (SVGellipse)this;
                returnString = "ellispe at " +
                               ellispe.center.x.ToString() + "," +
                               ellispe.center.y.ToString() + " rx " +
                               ellispe.radius.x.ToString() + " ry " +
                               ellispe.radius.y.ToString() + " with matrix " +
                               ellispe.transform.ToString();
            }
            if (this is SVGcurve)
            {
                SVGcurve curve = (SVGcurve)this;
                returnString = "curve from " +
                               curve.point1.x.ToString() + "," +
                               curve.point1.y.ToString() + " to " +
                               curve.point2.x.ToString() + ", " +
                               curve.point2.y.ToString() + " with matrix " +
                               curve.transform.ToString();
            }
            return returnString;
        }
    }
}
