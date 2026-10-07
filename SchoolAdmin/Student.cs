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

        private List<CourseResult> results = new List<CourseResult>();


        public static uint StudentCounter = 1;


        private int age;

        public int Age
        {
            get 
            {
                DateTime today = DateTime.Today;

                int years = today.Year - Birthdate.Year;
                if (Birthdate.Date > today.AddYears(-age)) age--;
                return age;
            }        
        }




        public string GenerateNameCard()
        {
            return $"{Name} (Student)";
        }

        public byte DetermineWorkLoad()
        {
            return (byte)(Courses.Count * 10);
        }

        public void RegisterForCourse(string course)
        {
            if (!Courses.Contains(course))
            {
                Courses.Add(course);
            }
        }

        //H12_3
        public void RegisterCourseResult(string name, byte result)
        {
            CourseResult courseResult = new CourseResult(name, result);
            results.Add(courseResult);
        }

    }
}
