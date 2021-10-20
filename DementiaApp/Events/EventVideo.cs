using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Drawing;

namespace Assignment1
{
    public class EventVideo : Event
    {
        public string Filepath { get; set; }

        public EventVideo()
        {
            EventName = "Video";
            //scale icon to 25% original size
            Icon = new Bitmap(Properties.Resources.video, new Size(Properties.Resources.video.Width / 4, Properties.Resources.video.Height / 4));
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
