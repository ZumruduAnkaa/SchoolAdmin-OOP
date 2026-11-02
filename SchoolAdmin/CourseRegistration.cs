using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolAdmin
{
    internal class CourseRegistration
    {
		private Cursus course;

		public Cursus Course
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

        public CourseRegistration(Cursus course, byte? result)
        {
            Course = course;
            Result = result;
        }

    }
}
