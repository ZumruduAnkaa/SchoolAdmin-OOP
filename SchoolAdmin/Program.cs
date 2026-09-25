namespace SchoolAdmin
{
    internal class Program
    {
        public static void Main()
        {
            Console.WriteLine("Wat wil je doen?");
            Console.WriteLine("1. DemonstreerStudenten uitvoeren");
            Console.Write(">");
            string keuze = Console.ReadLine();

            switch (keuze)
            {
                case "1":
                    DemoStudent1();
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
            said.Courses.Add("Programmeren");
            said.Courses.Add("Databanken");

            Student mieke = new Student();
            mieke.Name = "Mieke Vermeulen";
            mieke.Birthdate = new DateTime(1998, 1, 1);
            mieke.StudentNumber = Student.StudentCounter++;
            mieke.Courses.Add("Communicatie");

            Console.WriteLine(said.GenerateNameCard());
            Console.WriteLine(said.DetermineWorkLoad());

            Console.WriteLine(mieke.GenerateNameCard());
            Console.WriteLine(mieke.DetermineWorkLoad());
        }
    }
}