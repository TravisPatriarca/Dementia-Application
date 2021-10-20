/*
 * Stores person data
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    public class Person
    {
        public int PersonID { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string Relation { get; set; }

        public Person()
        {
            Name = "";
            Relation = "";
            ImageUrl = "";
        }

        public Person(string name, string rel, string imgUrl)
        {
            Name = name;
            Relation = rel;
            ImageUrl = imgUrl;
        }
    }
}
