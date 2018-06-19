using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookieControl
{
    class Processer
    {
        public static SVGElementArray shortPath(SVGElementArray allElements)
        {
            //variables
            double distance = 0;
            double previousDistance = 0;
            point currentPoint = new point();
            point previousLocation = new point();
            SVGElementArray reOrdered = new SVGElementArray();
            bool[] done = new bool[allElements.SVGelement.Count];
            List<processorPoint> points = new List<processorPoint>();

            //convert to points
            for (int elementNum = 0; elementNum < allElements.SVGelement.Count; elementNum++)
            {
                SVGelement element = allElements.SVGelement[elementNum];

                if (element is SVGellipse)
                {
                    SVGellipse ellipse = (SVGellipse)allElements.SVGelement[elementNum];
                    for (double angle = 0; angle <= 6.3; angle += 0.1)
                    {
                        point locAtAngle = new point();
                        locAtAngle.x = Math.Cos(angle) * ellipse.radius.x + ellipse.center.x;
                        locAtAngle.y = Math.Sin(angle) * ellipse.radius.y + ellipse.center.y;
                        points.Add(new processorPoint(locAtAngle, elementNum));
                    }
                    Array.Resize(ref done, done.Length + 63);
                }
                else if (element is SVGline)
                {
                    SVGline line = (SVGline)allElements.SVGelement[elementNum];
                    points.Add(new processorPoint(line.start, elementNum));
                    points.Add(new processorPoint(line.end, elementNum));
                    Array.Resize(ref done, done.Length + 2);
                }
                else if (element is SVGcurve)
                {
                    SVGcurve curve = (SVGcurve)allElements.SVGelement[elementNum];
                    points.Add(new processorPoint(curve.point1, elementNum));
                    points.Add(new processorPoint(curve.point2, elementNum));
                    Array.Resize(ref done, done.Length + 2);
                }
            }

            previousLocation.x = 0;
            previousLocation.y = 0;

            //find shortest distance
            for (int elementNum = 0; elementNum < allElements.SVGelement.Count; elementNum++)
            {
                int index = 0;
                previousDistance = double.MaxValue;
                for (int comparerIndex = 0; comparerIndex < points.Count; comparerIndex++)
                {
                    currentPoint.x = points[comparerIndex].loc.x;
                    currentPoint.y = points[comparerIndex].loc.y;
                    distance = Math.Sqrt(Math.Pow((previousLocation.x - currentPoint.x), 2)
                        + Math.Pow((previousLocation.y - currentPoint.y), 2));
                    if (distance < previousDistance & done[points[comparerIndex].index] == false)
                    {
                        previousDistance = distance;
                        index = points[comparerIndex].index;
                    }
                }
                //after cycling through all points, assign the goal to have been  done
                done[index] = true;

                /* check which of the two points are closer
                   pass out which point in particular was chosen
                   then reorder with the closest point first */

                reOrdered.SVGelement.Add(allElements.SVGelement[index]);

                if (reOrdered.SVGelement[reOrdered.SVGelement.Count - 1] is SVGline)
                {
                    SVGline line = (SVGline)reOrdered.SVGelement[reOrdered.SVGelement.Count - 1];
                    double dToStart = Math.Sqrt(Math.Pow(previousLocation.x - line.start.x,2) + Math.Pow(previousLocation.y - line.start.y,2));
                    double dToEnd = Math.Sqrt(Math.Pow(previousLocation.x - line.end.x, 2) + Math.Pow(previousLocation.y - line.end.y, 2));
                    if (dToEnd < dToStart)
                    {
                        SVGline newLine = new SVGline(line.end, line.start);
                        reOrdered.SVGelement.RemoveAt(reOrdered.SVGelement.Count - 1);
                        reOrdered.SVGelement.Add(newLine);
                    }
                }

                if (reOrdered.SVGelement[reOrdered.SVGelement.Count - 1] is SVGcurve)
                {
                    SVGcurve curve = (SVGcurve)reOrdered.SVGelement[reOrdered.SVGelement.Count - 1];
                    double dToStart = Math.Sqrt(Math.Pow(previousLocation.x - curve.point1.x, 2) + Math.Pow(previousLocation.y - curve.point1.y, 2));
                    double dToEnd = Math.Sqrt(Math.Pow(previousLocation.x - curve.point2.x, 2) + Math.Pow(previousLocation.y - curve.point2.y, 2));
                    if (dToEnd < dToStart)
                    {
                        SVGcurve newCurve = new SVGcurve(curve.point2, curve.handle2, curve.handle1, curve.point1, curve.transform);
                        reOrdered.SVGelement.RemoveAt(reOrdered.SVGelement.Count - 1);
                        reOrdered.SVGelement.Add(newCurve);
                    }
                }
                
                if (reOrdered.SVGelement[reOrdered.SVGelement.Count - 1] is SVGellipse)
                {
                    SVGellipse ellipse = (SVGellipse)allElements.SVGelement[index];
                    reOrdered.SVGelement.RemoveAt(reOrdered.SVGelement.Count - 1);
                    reOrdered.SVGelement.Add(ellipse);
                }

                previousLocation = currentPoint;
            }
            return reOrdered;
        }
    }
}