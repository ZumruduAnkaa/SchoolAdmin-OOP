using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolAdmin
{
    public class Cursus
    {
        public string Title;
        public List<Student> Students = new List<Student>();

        private byte creditPoints;

        public byte CreditPoints
        {
            get { return creditPoints; }
            private set { creditPoints = value; }
        }

        private int id = maxId;
        public int Id
        {
            get { return id; }
        }

        private static int maxId = 1;

        public static List<Cursus> AllCourses = new List<Cursus>();

        public void ShowOverview()
        {
            
        }


    }
}
