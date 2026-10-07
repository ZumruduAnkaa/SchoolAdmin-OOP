using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolAdmin
{
    internal class CourseResult
    {
		private int name;

		public int Name
		{
			get { return name; }
			set { name = value; }
		}

		private int result;

		public int Result
		{
			get { return result; }
			set 
			{
                if (value > 20)
                {
					Console.WriteLine("Fout!");
                }
                else
                {
					result = value;
                }
            }
		}

	}
}
