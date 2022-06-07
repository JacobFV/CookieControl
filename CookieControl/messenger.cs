using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CookieControl
{
    public class messenger
    {
        private int incoming;
        serial serialClass = new serial();
        public void close()
        {
            serialClass.closeSerial();
        }
        public void addOne()
        {
            incoming++;
        }
        public void sendElements(ref SVGElementArray elements, string portName)
        {
            //create serial object here and event handler in this class
            if (serialClass.loadSerial(portName) == true)
            {
                serialClass.write("D"); //change this to "C" at release
                //start sending over instructions
                for (int elementNum = 0; elementNum < elements.SVGelement.Count; elementNum++)
                {
                    while (serialClass.newVal == false) { }
                    serialClass.newVal = false;
                    if (elements.SVGelement[elementNum] is SVGline)
                    {
                        serialClass.write("l");
                        SVGline line = (SVGline)elements.SVGelement[elementNum];
                        serialClass.log(line.start.x,
                                        line.start.y,
                                        line.end.x,
                                        line.end.y);
                    }
                    if (elements.SVGelement[elementNum] is SVGcurve)
                    {
                        serialClass.write("c");
                        SVGcurve curve = (SVGcurve)elements.SVGelement[elementNum];
                        serialClass.log(curve.point1.x,
                                        curve.point1.y,
                                        curve.point2.x,
                                        curve.point2.y,
                                        curve.transform.a,
                                        curve.transform.b,
                                        curve.transform.c,
                                        curve.transform.d,
                                        curve.transform.e,
                                        curve.transform.f,
                                        curve.handle1.x,
                                        curve.handle1.y,
                                        curve.handle2.x,
                                        curve.handle2.y);
                    }
                    if (elements.SVGelement[elementNum] is SVGellipse)
                    {
                        serialClass.write("e");
                        SVGellipse ellipse = (SVGellipse)elements.SVGelement[elementNum];
                        serialClass.log(ellipse.center.x,
                                        ellipse.center.y,
                                        ellipse.radius.x,
                                        ellipse.radius.y,
                                        ellipse.transform.a,
                                        ellipse.transform.b,
                                        ellipse.transform.c,
                                        ellipse.transform.d,
                                        ellipse.transform.e,
                                        ellipse.transform.f,
                                        0, 359.99999); //add code later to find the quickest route
                    }
                }
            }
            else
            {
                MessageBox.Show("No Cookie Cutter found");
            }
        }
    }
}