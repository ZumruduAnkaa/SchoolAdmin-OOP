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

        private List<CourseRegistration> courseRegistrations = new List<CourseRegistration>();


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
        public void RegisterCourseResult(string name, byte? result)
        {
            CourseRegistration courseRegistration = new CourseRegistration(name, result);
            courseRegistrations.Add(courseRegistration);
        }

        //H12_4 +  H3_1
        public double Average()
        {
            double sum = 0;
            int count = 0;

            foreach (CourseRegistration registration in courseRegistrations)
            {
                if (registration.Result != null)
                {
                    sum += (double)registration.Result;
                    count++;
                }
            }

            if (count == 0)
            {
                return 0;
            }

            return sum / count;
        }

        //H12_4
        public void ShowOverview()
        {
            Console.WriteLine($"{Name}, {Age} jaar");
            Console.WriteLine();
            Console.WriteLine("Cijferrapport:");
            Console.WriteLine("**********");

            foreach (var registration in courseRegistrations)
            {
                Console.WriteLine($"{(registration.Name + ":").PadRight(16)}{registration.Result}");
            }

            Console.WriteLine($"{"Gemiddelde".PadRight(16)}{Average():F1}");
        }

    }
}
