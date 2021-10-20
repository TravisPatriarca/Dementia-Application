using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Drawing;

namespace Assignment1
{
    public class EventPerson : Event
    {
        public Person person;
        public string Details { get; set; }

        public EventPerson()
        {
            EventName = "Person";
            //scale icon to 25% original size
            Icon = new Bitmap(Properties.Resources.person, new Size(Properties.Resources.person.Width / 4, Properties.Resources.person.Height / 4));
        }

        public override void LoadXElement(XNamespace ns, XElement element)
        {
            base.LoadXElement(ns, element);
            int personID = Convert.ToInt32(element.Descendants(ns + "personid").First().Value);
            person = PersonDB.GetPersonById(personID);
            Details = element.Descendants(ns + "details").First().Value;
        }

        public override XElement ToXML()
        {
            var element = base.ToXML();
            element.Add(new XElement("personid", person.PersonID));
            element.Add(new XElement("details", Details));

            return element;
        }
    }
}
