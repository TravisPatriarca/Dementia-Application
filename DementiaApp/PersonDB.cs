/*
 * The 'personDB.cs' class is used to store, retrieve and add person objects.
 * The class is also used to save and load these persons to XML files
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Assignment1
{
    // DESIGN PATTERN: Singleton
    public class PersonDB
    {
        public static List<Person> people;
        private static int count;
        private static PersonDB instance = null;

        public static PersonDB Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new PersonDB();
                }
                return instance;
            }
        }

        private PersonDB()
        {
            people = new List<Person>();
            count = 0;
        }

        public static void AddPerson(Person person)
        {
            person.PersonID = count;
            people.Add(person);
            count++;
        }

        public static List<Person> GetPeople()
        {
            return people;
        }

        public void LoadXml(string xmlFile)
        {
            people = XDocument.Load(AppDomain.CurrentDomain.BaseDirectory + xmlFile).Root.Descendants("person")
                .Select(x => new Person
                {
                    Name = x.Element("name").Value,
                    Relation = x.Element("relation").Value,
                    ImageUrl = x.Element("imageUrl").Value,
                    PersonID = Convert.ToInt32(x.Attribute("id").Value)
                }).ToList();

            count = people.Count;
        }

        public void SaveXml(string xmlFile)
        {
            XDocument xmlDocument = new XDocument(
                new XDeclaration("1.0", "utf-8", "yes"),
                new XElement("people",
                    from person in people
                    select new XElement("person", new XAttribute("id", person.PersonID),
                        new XElement("name", person.Name),
                        new XElement("relation", person.Relation),
                        new XElement("imageUrl", person.ImageUrl))
                )
            );

            xmlDocument.Save(AppDomain.CurrentDomain.BaseDirectory + xmlFile);
        }

        public static Person GetPersonById(int personid)
        {
            foreach(Person person in people)
            {
                if (person.PersonID == personid)
                {
                    return person;
                }
            }

            return null;
        }
    }
}
