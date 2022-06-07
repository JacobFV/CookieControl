using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
namespace CookieControl
{
    class readSVG
    {
        public static void getElements(string[] attributes ,string elementKind, string URL, ref List<attributeArray> elements)
        {
            XmlDocument doc = new XmlDocument();
            
            doc.Load(URL);

            XmlNamespaceManager nsmgr = new XmlNamespaceManager(doc.NameTable);
            nsmgr.AddNamespace("svg", "http://www.w3.org/2000/svg");

            foreach (XmlNode match in doc.SelectNodes(".//svg:"+elementKind, nsmgr))
            {
                var element = (XmlElement)match;
                attributeArray currentAtributes = new attributeArray();
                for (int i = 0; i < attributes.Length; i++)
                {
                    string attr = element.GetAttribute(attributes[i]);
                    attr = (attr == "") ? null : attr;
                    currentAtributes.atributes.Add(attr);
                }

                var fatherElement = (XmlElement)match;

                //go down looking for transforms
                while (fatherElement.GetAttribute("transform") != "")
                {
                    currentAtributes.atributes.Add(fatherElement.GetAttribute("transform"));
                    fatherElement = (XmlElement)fatherElement.ParentNode;
                }
                elements.Add(currentAtributes);
            }
        }
    }
}