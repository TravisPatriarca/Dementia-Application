using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Drawing;

namespace Assignment1
{
    public class EventTweet : Event
    {
        public string Text { get; set; }

        public EventTweet()
        {
            EventName = "Tweet";
            //scale icon to 25% original size
            Icon = new Bitmap(Properties.Resources.twitter, new Size(Properties.Resources.twitter.Width / 4, Properties.Resources.twitter.Height / 4));
        }

        public override void LoadXElement(XNamespace ns, XElement element)
        {
            base.LoadXElement(ns, element);
            Text = element.Descendants(ns + "text").First().Value;
        }

        public override XElement ToXML()
        {
            var element = base.ToXML();
            element.Add(new XElement("text", Text));

            return element;
        }
    }
}
