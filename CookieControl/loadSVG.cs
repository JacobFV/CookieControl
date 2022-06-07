using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookieControl
{
    class loadSVG
    {
        /* This is where the SVG file elements get loaded into Cookie Cutter Control Software.
           After being processed with attributes, the elements are converted into an SVGelement
           array. Then Processor.shortPath returns the shortest possible distance between all the
           SVGelements, which is stored into memory while being sent over in one instruction at a
           time to the Cookie Cutter. On the client side, the Arduino waits to get a go command,
           after which, it moves along a path given to it by this program. Once the servo motors
           move to the desired location, the client sends a completed signal back to the control
           software. This process is repeated until all the SVGelements have been cut out. */
        public static SVGElementArray getElements(string URL)
        {
            SVGElementArray allElements = new SVGElementArray();

            /* process elements by getting their attribute values and
               running their attributes though their appropriate void */

            allElements = Quadify.path(URL);
            /* Quadify path converts a path's d's and poinits into SVGelements.
                It supports lines, ellipses, arcto's, cubic, & quadradic curves */

            copyOver(Quadify.rect(URL), ref allElements);
            /* Quadify rect takes the rectangle transforms and combines the rectangles into 
               one matrix and then creates SVGlines based on their deminsional attributes */

            copyOver(Quadify.line(URL), ref allElements);
            /* Quadify line takes the x1, y1, x2, & y2 values of an XML SVG line and after
               mulitplying out the matricies, creates a new SVGline */

            copyOver(Quadify.polygon(URL), ref allElements);
            copyOver(Quadify.polyline(URL), ref allElements);
            /* Polygon and polyline take in a series of points from polyline
               or polygon element and process them into an SVGElement array */

            copyOver(Quadify.circle(URL), ref allElements);
            copyOver(Quadify.ellipse(URL), ref allElements);
            /* Quadify circle and polygon are relativly simple; These functions parse the 
               radius and center locations of an ellipse or circle to make an SVGellise*/

            allElements = Processer.shortPath(allElements);
            /* Processor.shortPath finds the shortest possible path connecting all the elements */
            return allElements;

        }
        static void copyOver(SVGElementArray elementsToAdd,ref SVGElementArray original)
        {
            for (int elementNum = 0; elementNum < elementsToAdd.SVGelement.Count; elementNum++)
            {
                original.SVGelement.Add(elementsToAdd.SVGelement[elementNum]);
            }
        }
    }
}
