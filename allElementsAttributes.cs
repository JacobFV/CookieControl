using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookieControl
{
    public struct allElementAttributes
    {
        public static string[] path = { "d", "points" };
        public static string[] line = { "x1", "y1", "x2", "y2" };
        public static string[] rect = { "x", "y", "width", "height" };
        public static string[] polyline = { "points" };
        public static string[] polygon = { "points" };
        public static string[] ellipse = { "cx", "cy", "rx", "ry" };
        public static string[] circle = { "cx", "cy", "r" };
        public static string[] text = {"style" }; //make sure to also get the inerText for the text property
                                         //typically, the style is located in a parent, not the tspan itself
    }
}