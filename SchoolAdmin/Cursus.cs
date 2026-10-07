using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolAdmin
{
    public class Cursus
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

        public static List<Cursus> AllCourses = new List<Cursus>();

        // H12_2
        public Cursus(string title, List<Student> students, byte creditPoints)
        {
            Title = title;
            Students = students;
            CreditPoints = creditPoints;

            id = maxId;
            maxId++;

            AllCourses.Add(this);
        }

        public Cursus(string title, List<Student> students) : this(title, students, 3)
        {
        }

        public Cursus(string title) : this(title, new List<Student>())
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


    }
}
