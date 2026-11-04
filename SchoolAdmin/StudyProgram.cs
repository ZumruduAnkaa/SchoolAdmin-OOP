using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace SchoolAdmin
{
    public class StudyProgram
    {
        private string name;

        public string Name
        {
            get { return name; }
        }

        private List<Course> courses = new List<Course>();

        public ImmutableList<Course> Courses
        {
            get { return courses.ToImmutableList<Course>(); }
            set { courses = value.ToList<Course>(); }
        }

        public StudyProgram(string name)
        {
            this.name = name;
        }

        public void ShowOverview()
        {
            Console.WriteLine(Name);
            foreach (var course in Courses)
            {
                course.ShowOverview();
            }
        }
    }
}
