using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookieControl
{
    class QuadCode
    {
        List<SVGline> lineCMD =new List<SVGline>();
        List<SVGcurve> curveCMD = new List<SVGcurve>();
        List<SVGellipse> ellipseCMD = new List<SVGellipse>();

        //add list to combine all in categorized order

        public SVGelement addLine(point start, point end,string[] matricies)
        {
            transformMatrix finalMatrix = transform.combineMatricies(matricies);
            start = transform.multiplyPointByMatrix(start, finalMatrix);
            end = transform.multiplyPointByMatrix(end, finalMatrix);
            return new SVGline(start, end);
        }
        public SVGelement addCurve(point point1, point point2, point handle1, point handle2,string[] matricies)
        {
            transformMatrix finalMatrix = transform.combineMatricies(matricies);
            return new SVGcurve(point1,point2,handle1,handle2,finalMatrix);
        }
        public SVGelement addEllipse(point center, point radius,string[] matricies)
        {
            transformMatrix finalMatrix = transform.combineMatricies(matricies);
            return new SVGellipse(center,radius,finalMatrix);
        }
        public void categorize()
        {
            //order elements by least distance
        }
    }
}
