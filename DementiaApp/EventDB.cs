using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;

namespace Assignment1
{
    // DESIGN PATTERN: Singleton
    public class EventDB
    {
        private static EventDB instance = null;
        public static Dictionary<string, Event> eventDictionary;
        private static int Count { get; set; }

        public static EventDB Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new EventDB();
                }
                return instance;
            }
        }

        private EventDB()
        {
            eventDictionary = new Dictionary<string, Event>();
            Count = 0; 
        }

        public static void AddEvent(Event eventItem)
        {
            eventItem.EventID = Count.ToString();
            eventDictionary.Add(eventItem.EventID, eventItem);
            Count++;
        }

        public static Event GetEvent(string eventID)
        {
            return eventDictionary[eventID];
        }

        public static void SetEvent(Event eventObj, string eventID)
        {
            eventDictionary[eventID] = eventObj;
        }

        public void LoadXml(string xmlFile)
        {
            XDocument doc = XDocument.Load(AppDomain.CurrentDomain.BaseDirectory + xmlFile);
            XNamespace ns = "http://www.xyz.org/lifelogevents";

            foreach (XElement event_ in doc.Descendants(ns + "Event")) {
                var eventObj = EventFactory.GetEvent(ns, event_);
                if (eventObj != null)
                {
                    AddEvent(eventObj);
                }
            }
        }

        public void SaveXml(string xmlFile)
        {
            XDocument xmlDocument = new XDocument(new XDeclaration("1.0", "utf-8", "yes"));
            XNamespace myNs = "http://www.xyz.org/lifelogevents";
            XNamespace SoapNs = "http://www.w3.org/2001/12/soap-envelope";

            XElement soap = new XElement(SoapNs + "Envelope", new XAttribute(XNamespace.Xmlns + "SOAP-ENV", SoapNs.NamespaceName), new XAttribute(SoapNs + "encodingStyle", "http://www.w3.org/2001/12/soap-encoding"));
            XElement root = new XElement(SoapNs + "Body");
            root.Add(new XAttribute(XNamespace.Xmlns + "lle", myNs));
            foreach(var eventItem in eventDictionary.Values)
            {
                root.Add(eventItem.ToXML());
            }

            soap.Add(root);
            xmlDocument.Add(soap);

            foreach (XElement el in root.Descendants())
            {
                el.Name = myNs + el.Name.LocalName;
            }
            xmlDocument.Save(AppDomain.CurrentDomain.BaseDirectory + xmlFile);
        }

        public Event GetEventFromPoint(double x, double y)
        {
            foreach (Event eventItem in eventDictionary.Values)
            {
                if (eventItem.Location.X == x && eventItem.Location.Y == y)
                {
                    return eventItem;
                }
            }

            return null;
        }

        public List<Coord> GetPointList()
        {
            List<Coord> coordList = new List<Coord>();
            foreach(Event eventItem in eventDictionary.Values)
            {
                coordList.Add(eventItem.Location);
            }

            return coordList;
        }
    }
}
