using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookieControl
{
    class processPath
    {
        public static SVGElementArray path(attributeArray attributeValues)
        {
            //0 = d's : 1 = points
            //takes in d and points to make an SVGElementArray

            //!!ADD SUPPORT FOR POINTS TO POLYLINE CONVERSION!!

            SVGElementArray returnElements = new SVGElementArray();
            List<char> allCMD = new List<char>();
            //transforming
            string[] matricies = new string[0];
            int numTransforms = attributeValues.atributes.Count
                - allElementAttributes.path.Count();
            //seporate the transform matricies from the other attributes
            for (int transformNum = 0; transformNum < numTransforms; transformNum++)
            {
                Array.Resize(ref matricies, matricies.Length + 1);
                matricies[transformNum] = attributeValues.atributes
                    [allElementAttributes.path.Count() + transformNum];
            }
            transformMatrix finalMatrix = transform.combineMatricies(matricies);
            string dVal = attributeValues.atributes[0];
            string[] seporateDVals = dVal.Split(new char[2] { ' ', ',' });
            char CMD = ' ';
            point handle0 = new point();
            point handle1 = new point();
            point startPoint = new point();
            point currentPoint = new point();
            point previousPoint = new point();
            QuadCode quadCode = new QuadCode();
            List<point> moveTos = new List<point>();
            //going through the loop
            for (int dValIndex = 0; dValIndex < seporateDVals.Length - 1; dValIndex++)
            {
                //look for a cmd
                char firstChar = seporateDVals[dValIndex][0];
                if (char.IsLetter(firstChar) == true)
                {
                    CMD = firstChar;
                    if (seporateDVals[dValIndex].Length > 1)
                    {
                        seporateDVals[dValIndex] = seporateDVals[dValIndex].Substring(1);
                    }
                    else
                    {
                        dValIndex++;
                    }
                    allCMD.Add(CMD);
                }
                double firstVal = double.Parse(seporateDVals[dValIndex]);
                switch (CMD)
                {
                    case 'M': //move to point absolute
                        startPoint.x = firstVal;
                        dValIndex++;
                        startPoint.y = double.Parse(seporateDVals[dValIndex]);
                        currentPoint = startPoint;
                        moveTos.Add(startPoint);
                        break;
                    case 'm': //move to point relative
                        startPoint.x = currentPoint.x + firstVal;
                        dValIndex++;
                        startPoint.y = currentPoint.y + double.Parse(seporateDVals[dValIndex]);
                        currentPoint = startPoint;
                        moveTos.Add(startPoint);
                        break;
                    case 'L': //line to point absolute
                        currentPoint.x = firstVal;
                        dValIndex++;
                        currentPoint.y = double.Parse(seporateDVals[dValIndex]);
                        returnElements.SVGelement.Add(quadCode.addLine(previousPoint, currentPoint, matricies));
                        break;
                    case 'l': //line to point relative
                        currentPoint.x += firstVal;
                        dValIndex++;
                        currentPoint.y += double.Parse(seporateDVals[dValIndex]);
                        returnElements.SVGelement.Add(quadCode.addLine(previousPoint, currentPoint, matricies));
                        break;
                    case 'H': //horizontal line absolute
                        currentPoint.x = firstVal;
                        currentPoint.y = 0;
                        returnElements.SVGelement.Add(quadCode.addLine(previousPoint, currentPoint, matricies));
                        break;
                    case 'h': //horizontal line relative
                        currentPoint.x += firstVal;
                        returnElements.SVGelement.Add(quadCode.addLine(previousPoint, currentPoint, matricies));
                        break;
                    case 'V': //vertical line absolute
                        currentPoint.x = 0;
                        currentPoint.y = firstVal;
                        returnElements.SVGelement.Add(quadCode.addLine(previousPoint, currentPoint, matricies));
                        break;
                    case 'v': //vertical line relative
                        currentPoint.y += firstVal;
                        returnElements.SVGelement.Add(quadCode.addLine(previousPoint, currentPoint, matricies));
                        break;
                    case 'C': // Cubic bezier curve absolute
                    case 'S':
                        handle0.x = firstVal;
                        dValIndex++;
                        handle0.y = double.Parse(seporateDVals[dValIndex]);
                        dValIndex++;
                        handle1.x = double.Parse(seporateDVals[dValIndex]);
                        dValIndex++;
                        handle1.y = double.Parse(seporateDVals[dValIndex]);
                        dValIndex++;
                        currentPoint.x = double.Parse(seporateDVals[dValIndex]);
                        dValIndex++;
                        currentPoint.y = double.Parse(seporateDVals[dValIndex]);
                        returnElements.SVGelement.Add(quadCode.addCurve(previousPoint, handle0, handle1, currentPoint, matricies));
                        break;
                    case 'c': // Cubic bezier curve relative
                    case 's':
                        handle0.x = previousPoint.x + firstVal;
                        dValIndex++;
                        handle0.y = previousPoint.y + double.Parse(seporateDVals[dValIndex]);
                        dValIndex++;
                        handle1.x = previousPoint.x + double.Parse(seporateDVals[dValIndex]);
                        dValIndex++;
                        handle1.y = previousPoint.y + double.Parse(seporateDVals[dValIndex]);
                        dValIndex++;
                        currentPoint.x += double.Parse(seporateDVals[dValIndex]);
                        dValIndex++;
                        currentPoint.y += double.Parse(seporateDVals[dValIndex]);
                        returnElements.SVGelement.Add(quadCode.addCurve(previousPoint, handle0, handle1, currentPoint, matricies));
                        break;
                    case 'Q': // Cubic bezier curve absolute
                    case 'T':
                        handle0.x = firstVal;
                        dValIndex++;
                        handle0.y = double.Parse(seporateDVals[dValIndex]);
                        dValIndex++;
                        currentPoint.x = double.Parse(seporateDVals[dValIndex]);
                        dValIndex++;
                        currentPoint.y = double.Parse(seporateDVals[dValIndex]);
                        returnElements.SVGelement.Add(quadCode.addCurve(previousPoint, handle0, handle0, currentPoint, matricies));
                        break;
                    case 'q': // Cubic bezier curve relative
                    case 't':
                        handle0.x = previousPoint.x + firstVal;
                        dValIndex++;
                        handle0.y = previousPoint.y + double.Parse(seporateDVals[dValIndex]);
                        dValIndex++;
                        currentPoint.x += double.Parse(seporateDVals[dValIndex]);
                        dValIndex++;
                        currentPoint.y += double.Parse(seporateDVals[dValIndex]);
                        returnElements.SVGelement.Add(quadCode.addCurve(previousPoint, handle0, handle0, currentPoint, matricies));
                        break;
                    case 'A': //Arcto absolute
                        //????????????????????
                        break;
                    case 'a': //Arcto relative
                        //????????????????????
                        break;
                    case 'Z': //closing line to start point
                    case 'z':
                        returnElements.SVGelement.Add(quadCode.addLine(startPoint, currentPoint, matricies));
                        break;
                }
                previousPoint = currentPoint;
            }
            if (allCMD.Count == 2)
            {
                if (allCMD[0].ToString().ToUpper() == "M" & allCMD[1].ToString().ToUpper() == "Z")
                {
                    return Quadify.polylineToQuadLine(moveTos.ToArray(), matricies, true);
                }
            }
            else if (allCMD.Count == 1)
            {
                if (allCMD[0].ToString().ToUpper() == "M")
                {
                    return Quadify.polylineToQuadLine(moveTos.ToArray(), matricies, true);
                }
            }
            return returnElements;
        }
    }
}
