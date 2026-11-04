using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace SchoolAdmin
{
    public class Course
    {
        public string Title;
        public List<Student> Students;

        private byte creditPoints;

        public byte CreditPoints
        {
            get { return creditPoints; }
            private set { creditPoints = value; }
        }

        private int id;
        public int Id
        {
            get { return id; }
        }

        private static int maxId = 1;

        private static List<Course> allCourses = new List<Course>();
        public static ImmutableList<Course> AllCourses
        {
            get { return allCourses.ToImmutableList<Course>(); } 
        }

        // H12_2
        public Course(string title, List<Student> students, byte creditPoints)
        {
            Title = title;
            Students = students;
            CreditPoints = creditPoints;

            id = maxId;
            maxId++;

            allCourses.Add(this);
        }

        public Course(string title, List<Student> students) : this(title, students, 3)
        {
        }

        public Course(string title) : this(title, new List<Student>())
        {
        }

        public void ShowOverview()
        {
            Console.WriteLine($"{Title} ({Id}) ({CreditPoints} stp)");
            foreach (Student student in Students)
            {
                Console.WriteLine(student.Name);
            }
        }

        //H3_2
        public static Course? SearchCourseById(int id)
        {
            foreach (Course course in AllCourses)
            {
                if (course.id == id)
                {
                    return course;
                }
            }

            return null;
        }


    }
}
