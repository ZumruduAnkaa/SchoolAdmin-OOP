using System;
using System.Collections.Generic;
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

        public List<Course> Courses = new List<Course>();

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
