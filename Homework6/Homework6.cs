using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Homeworklib6;

namespace Homework6
{
    internal class Homework6
    {
        static void Main(string[] args)
        {
            Person person = new Person
            {
                Name = "Beknur",
                Age = 20
            };

            string personInfo = Person.GetPersonInfo(person);
            Console.WriteLine(personInfo);


            Console.WriteLine(Constants.MyString);
            Console.WriteLine(Constants.MyNumber);

            Console.ReadLine();
        }
    }
}
