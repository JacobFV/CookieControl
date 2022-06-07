using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CookieControl
{
    static class CookieCutterControl
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>

        //Cookie Cutter Control Software v 1.0
        //Written by Jacob Valdez 2015
        //in 9th grade at Waxahachie Global High School
        [STAThread]
        static void Main(/*string[] args*/)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new CookieWare());
            /*
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.Title = "CookieWare";

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Console.WriteLine("Cookie Cutter Control Software v1.0");
            Console.WriteLine("Press any key to begin");
            Console.ReadKey(true);
            start();
        }
        static void start()
        {
            string fileName = openSVG();
            Console.WriteLine("File " + fileName + " loaded");
            SVGElementArray processedElements = loadSVG.getElements(fileName);
            options(processedElements);
        }
        static void listElement(SVGelement element)
        {
            if (element is SVGline)
            {
                SVGline line = (SVGline)element;
                Console.WriteLine("line from " + line.start.stringPoint()
                                  + " to " + line.end.stringPoint());
            }
            if (element is SVGcurve)
            {
                SVGcurve curve = (SVGcurve)element;
                Console.WriteLine("curve from " + curve.point1.stringPoint()
                                  + " to " + curve.point2.stringPoint() +
                                  " handle 1 " + curve.handle1.stringPoint() +
                                  " handle 2 " + curve.handle2.stringPoint() +
                                  " matrix " + curve.transform.a.ToString() + ", "
                                            + curve.transform.b.ToString() + ", "
                                            + curve.transform.c.ToString() + ", "
                                            + curve.transform.d.ToString() + ", "
                                            + curve.transform.e.ToString() + ", "
                                            + curve.transform.f.ToString());
            }
            if (element is SVGellipse)
            {
                SVGellipse ellipse = (SVGellipse)element;
                Console.WriteLine("ellipse @ " + ellipse.center.stringPoint()
                                  + " radius " + ellipse.radius.stringPoint() +
                                  " matrix " + ellipse.transform.a.ToString() + ", "
                                            + ellipse.transform.b.ToString() + ", "
                                            + ellipse.transform.c.ToString() + ", "
                                            + ellipse.transform.d.ToString() + ", "
                                            + ellipse.transform.e.ToString() + ", "
                                            + ellipse.transform.f.ToString());
            }
        }
        static void options(SVGElementArray processedElements)
        {
            Console.WriteLine();
            Console.WriteLine("Press c to cut");
            Console.WriteLine("Press s to simulate");
            Console.WriteLine("Press v to view all SVGelements");
            Console.WriteLine("Press o to open a new file");
            Console.WriteLine("Press q to quit");

            switch (Console.ReadKey(true).KeyChar)
            {
                default:
                    Console.WriteLine("Please reenter the key");
                    options(processedElements);
                    break;
                case 'c':
                case 'C':
                    //cut
                    messenger serialMessenger = new messenger();
                    serialMessenger.sendElements(ref processedElements);
                    System.Threading.Thread.Sleep(10); //JUST ADD THIS MIGHT NOT WORK
                    // IT'S SUPPOSED TO PREVENT ELEMENT 160 FROM APPEARING AFTER LIST
                    options(processedElements);
                    break;
                case 's':
                case 'S':
                    //simulate
                    options(processedElements);
                    break;
                case 'v':
                case 'V':
                    foreach (SVGelement element in processedElements.SVGelement)
                    {
                        listElement(element);
                    }
                    if (processedElements.SVGelement.Count() == 1)
                    {
                        Console.WriteLine("There is 1 element in the SVG file",
                            processedElements.SVGelement.Count());
                    }
                    else
                    {
                        Console.WriteLine("There are {0} elements in the SVG file",
                            processedElements.SVGelement.Count);
                    }
                    options(processedElements);
                    break;
                case 'o':
                case 'O':
                    start();
                    break;
                case 'q':
                case 'Q':
                    quit();
                    break;
            }
        }
        static string openSVG()
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.FileName = "choose a file";
            openFileDialog1.InitialDirectory = "C:\\Users\\" + Environment.UserName + "\\Desktop";
            openFileDialog1.ShowDialog();
            string fileName = openFileDialog1.FileName;
            string extension = fileName.Substring(fileName.Length - 4);
            if (extension != ".svg" && extension != ".xml")
            {
                DialogResult result;
                result = MessageBox.Show("Please select an SVG file", "File Invalid",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                if (result == DialogResult.Cancel)
                {
                    quit();
                }
                fileName = openSVG();
            }
            return fileName;
        }
        static void quit()
        {
            Console.WriteLine();
            string goodBye = "Goodbye";
            foreach (char letter in goodBye)
            {
                Console.Write(letter);
                System.Threading.Thread.Sleep(20);
            }
            System.Threading.Thread.Sleep(225);
            Console.Write(" :)");
            System.Threading.Thread.Sleep(400);
            System.Threading.Thread.CurrentThread.Abort();
        */
        }
    }
}