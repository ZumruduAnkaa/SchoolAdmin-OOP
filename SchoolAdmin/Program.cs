namespace SchoolAdmin
{
    internal class Program
    {
        public static void Main()
        {
            Console.WriteLine("Wat wil je doen?");
            Console.WriteLine("1. DemonstreerStudenten uitvoeren");
            Console.WriteLine("2. DemonstreerCursussen uitvoeren");
            Console.Write(">");
            string keuze = Console.ReadLine();

            switch (keuze)
            {
                case "1":
                    DemoStudent1();
                    break;

                case "2":
                    DemoCourses();
                    break;

                default:
                    Console.WriteLine("Ongeldige keuze");
                    break;
            }

            

        }

        private static void DemoStudent1()
        {
            Student said = new Student();
            said.Name = "Said Aziz";
            said.Birthdate = new DateTime(2000, 6, 1);
            said.StudentNumber = Student.StudentCounter++;
            said.RegisterForCourse("Programmeren");
            said.RegisterForCourse("Databanken");
            said.RegisterCourseResult("Programmeren", 15);   // H13_3
            said.RegisterCourseResult("Databanken", 12);    // H13_3


            Student mieke = new Student();
            mieke.Name = "Mieke Vermeulen";
            mieke.Birthdate = new DateTime(1998, 1, 1);
            mieke.StudentNumber = Student.StudentCounter++;
            mieke.RegisterForCourse("Communicatie");
            mieke.RegisterCourseResult("Communicatie", 14); // H13_3

            Console.WriteLine(said.GenerateNameCard());
            Console.WriteLine(said.DetermineWorkLoad());

            Console.WriteLine(mieke.GenerateNameCard());
            Console.WriteLine(mieke.DetermineWorkLoad());
        }

        // H12_2
        private static void DemoCourses()
        {
            // studenten maken
            Student said = new Student();
            said.Name = "Said Aziz";
            said.Birthdate = new DateTime(2000, 6, 1);
            said.StudentNumber = Student.StudentCounter++;

            Student mieke = new Student();
            mieke.Name = "Mieke Vermeulen";
            mieke.Birthdate = new DateTime(1998, 1, 1);
            mieke.StudentNumber = Student.StudentCounter++;

            // lijst van studenten maken
            List<Student> studenten = new List<Student>();
            studenten.Add(said);
            studenten.Add(mieke);

            // 6 studiepunten (constructor 1)
            Cursus communicatie = new Cursus("Communicatie", studenten, 6);

            // 3 studiepunten (constructor 2)
            Cursus programmeren = new Cursus("Programmeren", studenten);

            // enkel de titel (constructor 3)
            Cursus webtechnologie = new Cursus("Webtechnologie");
            Cursus databanken = new Cursus("Databanken");

            // Said bij webtechnologie en Mieke bij databanken
            webtechnologie.Students.Add(said);
            databanken.Students.Add(mieke);

            communicatie.ShowOverview();
            programmeren.ShowOverview();
            webtechnologie.ShowOverview();
            databanken.ShowOverview();
        }
    }
}