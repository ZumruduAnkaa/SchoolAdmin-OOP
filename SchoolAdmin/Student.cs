using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Text;

namespace SchoolAdmin
{
    public class Student
    {
        public string Name;
        public DateTime Birthdate;
        public uint StudentNumber;
        private List<string> Courses = new List<string>();

        public static uint StudentCounter = 1;

        public string GenerateNameCard()
        {
            return $"{Name} (Student)";
        }

        public byte DetermineWorkLoad()
        {
            return (byte)(Courses.Count * 10);
        }
    }
}
