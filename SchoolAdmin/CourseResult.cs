using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolAdmin
{
    internal class CourseResult
    {
		private string name;

		public string Name
		{
			get { return name; }
		}

		private byte result;

		public byte Result
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

        public CourseResult(string name, byte result)
        {
            this.name = name;
            Result = result;
        }

    }
}
