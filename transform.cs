using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookieControl
{
    class transform
    {
        public static transformMatrix combineMatricies(string[] matricieStrings)
        {
            //NEED TO ADD CODE TO HANDLE MORE THAN "MATRIX(A,B,C,D,E,F)" ADD TRANSLATE, SKEW, SCALE, & ROTATE
            ///<summary>
            ///combineMatricies combines the values of many matricie strings into one matrix
            ///</summary>

            List<transformMatrix> matricies = new List<transformMatrix>();
            for (int matrixNumber = 0; matrixNumber < matricieStrings.Length; matrixNumber++)
            {
                //trim off the )
                matricieStrings[matrixNumber] = matricieStrings[matrixNumber].TrimEnd(')');
                char[] stringSplitChars = { ',', ' ' };
                string[] stringVals = matricieStrings[matrixNumber].Split(stringSplitChars);
                switch (matricieStrings[matrixNumber].Substring(0, 5))
                {
                    case "trans":
                        double Xtrans = double.Parse(stringVals[0].Substring(10));
                        double Ytrans = 0;
                        try
                        {
                            Ytrans = double.Parse(stringVals[1]);
                        }
                        catch { }
                        matricies.Add(new transformMatrix(1, 0, 0, 1, Xtrans, Ytrans));
                        break;
                    case "skewX":
                        /*         |  1  , tan(a) | 
                        skeyX(a) = |  0  ,   1    |
                                   |  0  ,   0    |  */
                        double angleX = double.Parse(stringVals[0].Substring(6));
                        matricies.Add(new transformMatrix(1, Math.Tan(angleX), 0, 1, 0, 0));
                        break;
                    case "skewY":
                        /*         |   1   ,  0  | 
                        skeyX(a) = | tan(a),  1  |
                                   |   0   ,  0  |  */
                        double angleY = double.Parse(stringVals[0].Substring(6));
                        matricies.Add(new transformMatrix(1, 0, Math.Tan(angleY), 1, 0, 0));
                        break;
                    case "scale":
                        double Xscale = double.Parse(stringVals[0].Substring(6));
                        double Yscale = 0;
                        try
                        {
                            Yscale = double.Parse(stringVals[1]);
                            matricies.Add(new transformMatrix(Xscale, 0, 0, Yscale, 0, 0));
                        }
                        catch
                        {
                            Yscale = 0;
                            matricies.Add(new transformMatrix(Xscale, 0, 0, Xscale, 0, 0));
                        }
                        break;
                    case "rotat":
                        /*              | 1 , 0 | |cos(a)  ,-sin(a)| | 1 , 0 |
                        rotate(a,x,y) = | 0 , 1 |+|+sin(a) , cos(a)|+| 0 , 1 |
                                        | x , y | |   0    ,   0   | |-x ,-y | */
                        double angle = double.Parse(stringVals[0].Substring(7));
                        double Xorigin = 0;
                        double Yorigin = 0;
                        try
                        {
                            Xorigin = double.Parse(stringVals[1]);
                            Yorigin = double.Parse(stringVals[2]);
                        }
                        catch { }
                        matricies.Add(new transformMatrix(1, 0, 0, 1, Xorigin, Yorigin));
                        matricies.Add(new transformMatrix(Math.Cos(angle), -Math.Sin(angle),
                            Math.Sin(angle), Math.Cos(angle), 0, 0));
                        matricies.Add(new transformMatrix(1, 0, 0, 1, -Xorigin, -Yorigin));
                        break;
                    case "matri": //matrix transformation
                        transformMatrix currentTransformMatrix = new transformMatrix(1, 0, 0, 1, 0, 0);
                        currentTransformMatrix.a = double.Parse(stringVals[0].Substring(7));
                        currentTransformMatrix.b = double.Parse(stringVals[1]);
                        currentTransformMatrix.c = double.Parse(stringVals[2]);
                        currentTransformMatrix.d = double.Parse(stringVals[3]);
                        currentTransformMatrix.e = double.Parse(stringVals[4]);
                        currentTransformMatrix.f = double.Parse(stringVals[5]);

                        matricies.Add(currentTransformMatrix);
                        break;
                }
            }

            if (matricies.Count >= 1)
            {

                //now do the multiplying stuff to make one big matricie
                transformMatrix previousMatrix = new transformMatrix(1, 0, 0, 1, 0, 0);
                transformMatrix currentMatrix = new transformMatrix(1, 0, 0, 1, 0, 0);
                transformMatrix nextMatrix = matricies[0];

                for (int matrixNumber = 1; matrixNumber < matricies.Count; matrixNumber++)
                {
                    previousMatrix = currentMatrix;
                    currentMatrix = matricies[matrixNumber];

                    /*  prev.  current         next
                        |A,B|   |G,H|   | GA+IB  ,  HA+JB |
                        |C,D| * |I,J| = | GC+ID  ,  HC+JD |
                        |E,F|   |K,L|   |GE+IF+K , HE+JF+L|  */

                    nextMatrix.a = currentMatrix.a * previousMatrix.a + currentMatrix.c * previousMatrix.b;
                    nextMatrix.b = currentMatrix.b * previousMatrix.a + currentMatrix.d * previousMatrix.b;
                    nextMatrix.c = currentMatrix.a * previousMatrix.c + currentMatrix.c * previousMatrix.d;
                    nextMatrix.d = currentMatrix.b * previousMatrix.c + currentMatrix.d * previousMatrix.d;
                    nextMatrix.e = currentMatrix.a * previousMatrix.e + currentMatrix.c * previousMatrix.f + currentMatrix.e;
                    nextMatrix.f = currentMatrix.b * previousMatrix.e + currentMatrix.d * previousMatrix.f + currentMatrix.f;

                    currentMatrix = nextMatrix;
                }
                return nextMatrix;
            }
            else
            {
                return new transformMatrix(1, 0, 0, 1, 0, 0);
            }

        }
        public static point multiplyPointByMatrix(point origionalPoint, transformMatrix matricix)
        {
            point newPoint = new point();
            newPoint.x = matricix.a * origionalPoint.x + matricix.c * origionalPoint.y + matricix.e;
            newPoint.y = matricix.b * origionalPoint.x + matricix.d * origionalPoint.y + matricix.f;
            return newPoint;
        }
    }
}
