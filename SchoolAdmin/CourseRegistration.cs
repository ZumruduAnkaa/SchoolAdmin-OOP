using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolAdmin
{
    internal class CourseRegistration
    {
		private Course course;

		public Course Course
		{
			get { return course; }
            set { course = value; }
		}

		private byte? result;

		public byte? Result
		{
			get { return result; }
			set 
			{
                if (value != null &&value > 20)
                {
					Console.WriteLine("Fout!");
                }
                else
                {
					result = value;
                }
            }
		}

        public CourseRegistration(Course course, byte? result)
        {
            Course = course;
            Result = result;
        }

    }
}
