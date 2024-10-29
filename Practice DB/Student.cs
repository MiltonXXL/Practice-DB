using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_DB
{
    internal class Student
    {
        //public int StudentId;
        public int StudentID { get; set; }
        //public string Name
        public string FirstName { get; set; }
        //public string City
        public string LastName { get; set; }
        public string City { get; set; }

        public Student(string firstName, string lastName, string city)
        {
            FirstName = firstName;
            LastName = lastName;
            City = city;
        }
    }
}
