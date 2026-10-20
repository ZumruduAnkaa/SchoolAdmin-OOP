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


        public int Age
        {
            get 
            {
                DateTime today = DateTime.Today;

                int years = today.Year - Birthdate.Year;
                if (Birthdate.Date > today.AddYears(-years))
                {
                    years--;
                }
                return years;
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

        //H12_4
        public double Average()
        {
            if (results.Count == 0)
            {
                return 0;
            }

            double sum = 0;
            foreach (CourseResult result in results)
            {
                sum += result.Result;
            }
            return sum / results.Count;
        }

        //H12_4
        public void ShowOverview()
        {
            Console.WriteLine($"{Name}, {Age} jaar");
            Console.WriteLine();
            Console.WriteLine("Cijferrapport:");
            Console.WriteLine("**********");

            foreach (var result in results)
            {
                Console.WriteLine($"{(result.Name + ":").PadRight(16)}{result.Result}");
            }

            Console.WriteLine($"{"Gemiddelde".PadRight(16)}{Average():F1}");
        }

    }
}
