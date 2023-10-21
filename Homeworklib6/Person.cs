using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homeworklib6
{
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public static string GetPersonInfo(Person person)
        {
            return $"Name: {person.Name}, Age: {person.Age}";
        }
    }
}
