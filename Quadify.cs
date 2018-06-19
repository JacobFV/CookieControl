using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookieControl
{
    class Quadify
    {
        public static SVGElementArray rect(string URL)
        {
            //attributes to look for from a rect
            List<attributeArray> attributeValues = new List<attributeArray>();
            readSVG.getElements(allElementAttributes.rect, "rect", URL, ref attributeValues);
            if (attributeValues.Count > 0)
            {
                SVGElementArray polylines = new SVGElementArray();
                //seporate the attributes that are more than the attribute list
                //these are the transformMatricieStrings
                for (int elementNum = 0; elementNum < attributeValues.Count; elementNum++)
                {
                    string[] matricies = new string[0];
                    int numTransforms = attributeValues[elementNum].atributes.Count
                        - allElementAttributes.rect.Count();
                    //seporate the transform matricies from the other attributes
                    for (int transformNum = 0; transformNum < numTransforms; transformNum++)
                    {
                        Array.Resize(ref matricies, matricies.Length + 1);
                        matricies[transformNum] = attributeValues[elementNum].atributes
                            [allElementAttributes.rect.Count() + transformNum];
                    }

                    //convert rectangle points to SVGline
                    double rectX;
                    rectX = double.Parse(attributeValues[elementNum].atributes[0]);
                    double rectY;
                    rectY = double.Parse(attributeValues[elementNum].atributes[1]);
                    double rectWidth;
                    rectWidth = double.Parse(attributeValues[elementNum].atributes[2]);
                    double rectHeight;
                    rectHeight = double.Parse(attributeValues[elementNum].atributes[3]);

                    point topLeft = new point();
                    point topRight = new point();
                    point bottomRight = new point();
                    point bottomLeft = new point();

                    topLeft.x = rectX;
                    topLeft.y = rectY;
                    topRight.x = rectX + rectWidth;
                    topRight.y = rectY;
                    bottomRight.x = rectX + rectWidth;
                    bottomRight.y = rectY + rectHeight;
                    bottomLeft.x = rectX;
                    bottomLeft.y = rectY + rectHeight;

                    SVGElementArray singleRectangle = new SVGElementArray();
                    singleRectangle = polylineToQuadLine(new point[4] { topLeft, topRight, bottomRight, bottomLeft }, matricies,true);
                    
                    polylines.SVGelement.Add(singleRectangle.SVGelement[0]);  //add the single rectangle to the polyline array
                    polylines.SVGelement.Add(singleRectangle.SVGelement[1]);  //add the single rectangle to the polyline array
                    polylines.SVGelement.Add(singleRectangle.SVGelement[2]);  //add the single rectangle to the polyline array
                    polylines.SVGelement.Add(singleRectangle.SVGelement[3]);  //add the single rectangle to the polyline array
                }
                return polylines;
            }
            else
            {
                return new SVGElementArray();
            }
        }
        public static SVGElementArray line(string URL)
        {
            //attributes to look for from a line
            SVGElementArray lines = new SVGElementArray();
            List<attributeArray> attributeValues = new List<attributeArray>();
            readSVG.getElements(allElementAttributes.line, "line", URL, ref attributeValues);
            if (attributeValues.Count > 0) { 
            //seporate the attributes that are more than the attribute list
            //these are the transformMatricieStrings
                for (int elementNum = 0; elementNum < attributeValues.Count; elementNum++)
                {
                    string[] matricies = new string[0];
                    int numTransforms = attributeValues[elementNum].atributes.Count
                        - allElementAttributes.line.Count();
                    //seporate the transform matricies from the other attributes
                    for (int transformNum = 0; transformNum < numTransforms; transformNum++)
                    {
                        Array.Resize(ref matricies, matricies.Length + 1);
                        matricies[transformNum] = attributeValues[elementNum].atributes
                            [allElementAttributes.line.Count() + transformNum];
                    }

                    //convert lineangle points to SVGline
                    double lineX1 = double.Parse(attributeValues[elementNum].atributes[0]);
                    double lineY1 = double.Parse(attributeValues[elementNum].atributes[1]);
                    double lineX2 = double.Parse(attributeValues[elementNum].atributes[2]);
                    double lineY2 = double.Parse(attributeValues[elementNum].atributes[3]);

                    point start = new point();
                    point end = new point();

                    start.x = lineX1;
                    start.y = lineY1;
                    end.x = lineX2;
                    end.y = lineY2;

                    QuadCode quadCode = new QuadCode();
                    lines.SVGelement.Add(quadCode.addLine(start, end, matricies));
                }
                return lines;
            }
            else
            {
                return new SVGElementArray();
            }
        }
        public static SVGElementArray polygon(string URL)
        {
            //attributes to look for from a polygon
            List<attributeArray> attributeValues = new List<attributeArray>();
            readSVG.getElements(allElementAttributes.polygon, "polygon", URL, ref attributeValues);
            if (attributeValues.Count > 0)
            {
                SVGElementArray polylines = new SVGElementArray();
                //seporate the attributes that are more than the attribute list
                //these are the transformMatricieStrings
                for (int elementNum = 0; elementNum < attributeValues.Count; elementNum++)
                {
                    string[] matricies = new string[0];
                    int numTransforms = attributeValues[elementNum].atributes.Count
                        - allElementAttributes.polygon.Count();
                    //seporate the transform matricies from the other attributes
                    for (int transformNum = 0; transformNum < numTransforms; transformNum++)
                    {
                        Array.Resize(ref matricies, matricies.Length + 1);
                        matricies[transformNum] = attributeValues[elementNum].atributes
                            [allElementAttributes.polygon.Count() + transformNum];
                    }
                    //convert points string to points
                    point[] seporatePointVals = new point[0];
                    string[] seporatePoints = attributeValues[elementNum].atributes[0].Split(new char[2] { ' ', ',' });
                    int rem=0;
                    Math.DivRem(seporatePoints.Length, 2, out rem);
                    if (rem == 0)
                    {
                        for (int pointNum = 0; pointNum < seporatePoints.Length; pointNum += 2)
                        {
                            Array.Resize(ref seporatePointVals, seporatePointVals.Length + 1);
                            seporatePointVals[pointNum / 2].x = double.Parse(seporatePoints[pointNum]);
                            seporatePointVals[pointNum / 2].y = double.Parse(seporatePoints[pointNum + 1]);
                        }
                    }
                    //convert polygon points to SVGline
                    SVGElementArray somePolylines = polylineToQuadLine(seporatePointVals, matricies, true);
                    for (int SVGelement = 0; SVGelement < somePolylines.SVGelement.Count; SVGelement++)
                    {
                        polylines.SVGelement.Add(somePolylines.SVGelement[SVGelement]);
                    }
                }
                return polylines;
            }
            else
            {
                return new SVGElementArray();
            }
        }
        public static SVGElementArray polyline(string URL)
        {
            //attributes to look for from a polyline
            List<attributeArray> attributeValues = new List<attributeArray>();
            readSVG.getElements(allElementAttributes.polyline, "polyline", URL, ref attributeValues);
            if (attributeValues.Count > 0)
            {
                SVGElementArray polylines = new SVGElementArray();
                //seporate the attributes that are more than the attribute list
                //these are the transformMatricieStrings
                for (int elementNum = 0; elementNum < attributeValues.Count; elementNum++)
                {
                    string[] matricies = new string[0];
                    int numTransforms = attributeValues[elementNum].atributes.Count
                        - allElementAttributes.polyline.Count();
                    //seporate the transform matricies from the other attributes
                    for (int transformNum = 0; transformNum < numTransforms; transformNum++)
                    {
                        Array.Resize(ref matricies, matricies.Length + 1);
                        matricies[transformNum] = attributeValues[elementNum].atributes
                            [allElementAttributes.polyline.Count() + transformNum];
                    }
                    //convert points string to points
                    point[] seporatePointVals = new point[0];
                    string[] seporatePoints = attributeValues[elementNum].atributes[0].Split(new char[2] { ' ', ',' });
                    int rem = 0;
                    Math.DivRem(seporatePoints.Length, 2, out rem);
                    if (rem == 0)
                    {
                        for (int pointNum = 0; pointNum < seporatePoints.Length; pointNum += 2)
                        {
                            Array.Resize(ref seporatePointVals, seporatePointVals.Length + 1);
                            seporatePointVals[pointNum / 2].x = double.Parse(seporatePoints[pointNum]);
                            seporatePointVals[pointNum / 2].y = double.Parse(seporatePoints[pointNum + 1]);
                        }
                    }
                    //convert polyline points to SVGlines
                    SVGElementArray somePolylines = polylineToQuadLine(seporatePointVals, matricies, false);
                    for (int SVGelement = 0; SVGelement < somePolylines.SVGelement.Count; SVGelement++)
                    {
                        polylines.SVGelement.Add(somePolylines.SVGelement[SVGelement]);
                    }
                }
                return polylines;
            }
            else
            {
                return new SVGElementArray();
            }
        }
        public static SVGElementArray ellipse(string URL)
        {
            //attributes to look for from an ellipse
            SVGElementArray ellipses = new SVGElementArray();
            List<attributeArray> attributeValues = new List<attributeArray>();
            readSVG.getElements(allElementAttributes.ellipse, "ellipse", URL, ref attributeValues);
            if (attributeValues.Count > 0)
            {
                //seporate the attributes that are more than the attribute list
                //these are the transformMatricieStrings
                for (int elementNum = 0; elementNum < attributeValues.Count; elementNum++)
                {
                    string[] matricies = new string[0];
                    int numTransforms = attributeValues[elementNum].atributes.Count
                        - allElementAttributes.ellipse.Count();
                    //seporate the transform matricies from the other attributes
                    for (int transformNum = 0; transformNum < numTransforms; transformNum++)
                    {
                        Array.Resize(ref matricies, matricies.Length + 1);
                        matricies[transformNum] = attributeValues[elementNum].atributes
                            [allElementAttributes.ellipse.Count() + transformNum];
                    }

                    //convert ellipse to SVGellipse
                    point center = new point();
                    point radius = new point();

                    center.x = double.Parse(attributeValues[elementNum].atributes[0]);
                    center.y = double.Parse(attributeValues[elementNum].atributes[1]);
                    radius.x = double.Parse(attributeValues[elementNum].atributes[2]);
                    radius.y = double.Parse(attributeValues[elementNum].atributes[3]);

                    QuadCode quadCode = new QuadCode();
                    ellipses.SVGelement.Add(quadCode.addEllipse(center, radius, matricies));
                }
                return ellipses;
            }
            else
            {
                return new SVGElementArray();
            }
        }
        public static SVGElementArray circle(string URL)
        {
            //attributes to look for from a circle
            SVGElementArray circles = new SVGElementArray();
            List<attributeArray> attributeValues = new List<attributeArray>();
            readSVG.getElements(allElementAttributes.circle, "circle", URL, ref attributeValues);
            if (attributeValues.Count > 0)
            {
                //seporate the attributes that are more than the attribute list
                //these are the transformMatricieStrings
                for (int elementNum = 0; elementNum < attributeValues.Count; elementNum++)
                {
                    string[] matricies = new string[0];
                    int numTransforms = attributeValues[elementNum].atributes.Count
                        - allElementAttributes.circle.Count();
                    //seporate the transform matricies from the other attributes
                    for (int transformNum = 0; transformNum < numTransforms; transformNum++)
                    {
                        Array.Resize(ref matricies, matricies.Length + 1);
                        matricies[transformNum] = attributeValues[elementNum].atributes
                            [allElementAttributes.circle.Count() + transformNum];
                    }

                    //convert circle to SVGellipse
                    point center = new point();
                    point radius = new point();

                    center.x = double.Parse(attributeValues[elementNum].atributes[0]);
                    center.y = double.Parse(attributeValues[elementNum].atributes[1]);
                    radius.x = double.Parse(attributeValues[elementNum].atributes[2]);
                    radius.y = radius.x;

                    QuadCode quadCode = new QuadCode();
                    circles.SVGelement.Add(quadCode.addEllipse(center, radius, matricies));
                }
                return circles;
            }
            else
            {
                return new SVGElementArray();
            }
        }
        public static SVGElementArray path(string URL)
        {
            //attributes to look for from a path
            SVGElementArray pathElements = new SVGElementArray();
            List<attributeArray> attributeValues = new List<attributeArray>();
            readSVG.getElements(allElementAttributes.path, "path", URL, ref attributeValues);
            if (attributeValues.Count > 0)
            {
                //seporate the attributes that are more than the attribute list
                //these are the transformMatricieStrings
                for (int elementNum = 0; elementNum < attributeValues.Count; elementNum++)
                {
                //convert dVals and points to SVGelementArrays
                }
                for (int elementNum = 0; elementNum < attributeValues.Count; elementNum++)
                {
                    SVGElementArray moreElements = processPath.path(attributeValues[elementNum]);
                    //copy onto pathElements
                    for (int pathElementNum = 0; pathElementNum < moreElements.SVGelement.Count; pathElementNum++)
                    {
                        pathElements.SVGelement.Add(moreElements.SVGelement[pathElementNum]);
                    }
                }
                return pathElements;
            }
            else
            {
                return new SVGElementArray();
            }
        }
        public static SVGElementArray polylineToQuadLine(point[] points, string[] matricies,bool closedFigure)
        {
            //add two lines for every two points
            var quadCode = new QuadCode();
            SVGElementArray lines = new SVGElementArray();
            for (int pointNum = 1; pointNum < points.Length; pointNum++)
            {
                lines.SVGelement.Add(quadCode.addLine(points[pointNum - 1], points[pointNum], matricies));
            }
            //draw a line closing the start and end points
            if (closedFigure)
            {
                lines.SVGelement.Add(quadCode.addLine(points[0], points[points.Length - 1], matricies));
            }
            return lines;
        }
    }
}
