using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Assignment1
{
    public class EventTracklog : Event
    {
        public string Filepath { get; set; }

        public EventTracklog()
        {
            EventName = "Track log";
        }

        public override void LoadXElement(XNamespace ns, XElement element)
        {
            base.LoadXElement(ns, element);
            Filepath = element.Descendants(ns + "filepath").First().Value;
        }

        public override XElement ToXML()
        {
            var element = base.ToXML();
            element.Add(new XElement("filepath", Filepath));

            return element;
        }
    }
}
