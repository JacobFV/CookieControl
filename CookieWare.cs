using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Drawing.Design;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace CookieControl
{
    public partial class CookieWare : Form
    {
        messenger serialMessenger = new messenger();
        SVGElementArray elements = new SVGElementArray();
        double slideSpeed = 0;
        double acceleration = .5;

        public CookieWare()
        {
            InitializeComponent();
        }

        private void CookieWare_load(object sender, EventArgs e)
        {
            Material.Text = "Steel";
            portComboBox.Text = "COM3";
        }

        private void openButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.FileName = "";
            openFileDialog1.InitialDirectory = "C:\\Users\\" + Environment.UserName + "\\";
            DialogResult result = openFileDialog1.ShowDialog();
            if (result != DialogResult.Cancel)
            {
                elements = loadSVG.getElements(openFileDialog1.FileName);/*
                using (StreamReader sr = File.OpenText(openFileDialog1.FileName))
                {
                    string s = "";
                    while ((s = sr.ReadLine()) != null)
                    {
                        viewer.DocumentText += s;
                    }
                }*/
                string doc = "<!DOCTYPE html> <html> <body> "+ "hello <svg width=\""
                    /*+(viewer.Width-5).ToString()*/+"250\" height=\""
                    /*+(viewer.Height-5).ToString()*/+"250\" >";
                foreach (SVGelement element in elements.SVGelement)
                {
                    doc += svgify(element);
                }
                doc += "</svg>" + " </body> </html>";
                /*
                using (FileStream fs = File.Create("C:\\\\bin\\CookieWareCookies"))
                {
                    Byte[] info =
                        new UTF8Encoding(true).GetBytes("This is some text in the file.");

                    // Add some information to the file.
                    fs.Write(info, 0, info.Length);
                }*/
                //viewer.Navigate("");
                viewer.Visible = true;
                slideSpeed = .5;
                acceleration = 1.15;
                animationTimer.Start();
            }
            
        }

        private void cutButton_Click(object sender, EventArgs e)
        {
            serialMessenger.sendElements(ref elements, portComboBox.Text);
            viewer.Visible = true;
            slideSpeed = -.5;
            acceleration = 1.15;
            animationTimer.Start();
        }

        private string svgify(SVGelement element)
        {
            string returnText = "";
            if (element is SVGcurve)
            {
                SVGcurve curve = (SVGcurve)element;
                returnText = makeSVGpath(
                             "M " + curve.point1.x.ToString() + " "
                                  + curve.point1.y.ToString() + " "
                           + "C " + curve.handle1.x.ToString() + " "
                                  + curve.handle1.y.ToString() + " "
                                  + curve.handle2.x.ToString() + " "
                                  + curve.handle2.y.ToString() + " "
                                  + curve.point2.x.ToString() + " "
                                  + curve.point2.y.ToString() + " ");
            }
            else if (element is SVGline)
            {
                SVGline line = (SVGline)element;
                returnText = makeSVGpath(
                             "M" + line.start.x.ToString() + " "
                                 + line.start.y.ToString() + " "
                           + "L" + line.end.x.ToString() + " "
                                 + line.end.y.ToString() + " ");
            }
            else if (element is SVGellipse)
            {
                SVGellipse ellipse = (SVGellipse)element;
                returnText = "<ellipse rx=\"" + ellipse.radius.x.ToString() +
                             "\" ry=\"" + ellipse.radius.y.ToString() +
                             "\" cx=\"" + ellipse.center.x.ToString() +
                             "\" cy=\"" + ellipse.center.y.ToString() +
                             "\" fill=\"none\" stroke=\"black\" stroke-width=\"1\" />";
            }
            return returnText;
        }

        private string makeSVGpath(string d)
        {
            string final = "<path d='" + d + 
                "' fill='none' stroke='black' stroke-width='1' />";
            return final;
        }

        private void animationTimer_Tick(object sender, EventArgs e)
        {
            viewer.Top += (int)slideSpeed;
            slideSpeed *= acceleration;
            if (viewer.Top > 12)
            {
                animationTimer.Stop();
                viewer.Top = 12;
            }
            if (viewer.Top + viewer.Height < 0)
            {
                animationTimer.Stop();
            }
        }

        private void CookieWare_FormClosing(object sender, FormClosingEventArgs e)
        {
            serialMessenger.close();
        }
    }
}