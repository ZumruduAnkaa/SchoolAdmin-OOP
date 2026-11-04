namespace SchoolAdmin
{
    internal class Program
    {
        public static void Main()
        {
            bool doorgaan = true;


            while (doorgaan)
            {
                Console.WriteLine("Wat wil je doen?");
                Console.WriteLine("1. DemonstreerStudenten uitvoeren");
                Console.WriteLine("2. DemonstreerCursussen uitvoeren");
                Console.WriteLine("3. Student uit tekstformaat inlezen");
                Console.WriteLine("4. DemonstreerCursussen uitvoeren (H3)");
                Console.WriteLine("5. DemonstreerStudieprogramma uitvoeren (H3_4)");
                Console.WriteLine("0. Stoppen");
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

                    case "3":
                        ReadTextFormatStudent();
                        break;

                    case "4":
                        DemoCourses_H3();
                        break;

                    case "5":
                        DemoStudyProgram();
                        break;

                    case "0":
                        doorgaan = false;
                        break;

                    default:
                        Console.WriteLine("Ongeldige keuze");
                        break;
                }
                Console.WriteLine();
            }

        }

        private static void DemoStudent1()
        {
            Course communicatie = new Course("Communicatie");
            Course programmeren = new Course("Programmeren");
            Course webtechnologie = new Course("Webtechnologie");
            Course databanken = new Course("Databanken");

            Student said = new Student();
            said.Name = "Said Aziz";
            said.Birthdate = new DateTime(2000, 6, 1);
            said.StudentNumber = Student.StudentCounter++;
            said.RegisterForCourse("Programmeren");
            said.RegisterForCourse("Databanken");
            said.RegisterCourseResult(programmeren, null);   // H13_3
            said.RegisterCourseResult(databanken, 12);    // H13_3


            Student mieke = new Student();
            mieke.Name = "Mieke Vermeulen";
            mieke.Birthdate = new DateTime(1998, 1, 1);
            mieke.StudentNumber = Student.StudentCounter++;
            mieke.RegisterForCourse("Communicatie");
            mieke.RegisterCourseResult(communicatie, 14); // H13_3

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
            Course communicatie = new Course("Communicatie", studenten, 6);

            // 3 studiepunten (constructor 2)
            Course programmeren = new Course("Programmeren", studenten);

            // enkel de titel (constructor 3)
            Course webtechnologie = new Course("Webtechnologie");
            Course databanken = new Course("Databanken");

            // Said bij webtechnologie en Mieke bij databanken
            webtechnologie.Students.Add(said);
            databanken.Students.Add(mieke);

            communicatie.ShowOverview();
            programmeren.ShowOverview();
            webtechnologie.ShowOverview();
            databanken.ShowOverview();
        }

        //H12_4
        private static void ReadTextFormatStudent()
        {
            //Tekst inlezen
            Console.WriteLine("Geef de tekstvoorstelling van 1 student in CSV-formaat:");
            Console.WriteLine(">");
            string input = Console.ReadLine();

            //Opsplitsen van puntkomma
            string[] parts = input.Split(';');

            //Naam een geboortedatum
            string name = parts[0];
            int day = int.Parse(parts[1]);
            int month = int.Parse(parts[2]);
            int year = int.Parse(parts[3]);

            //Nieuwe student
            Student student = new Student();
            student.Name = name;
            student.Birthdate = new DateTime(year, month, day);
            student.StudentNumber = Student.StudentCounter++;

            //Cursussen - H3_3 SchoolAdmin: gelinkte objecten
            for (int i = 4; i < parts.Length; i += 2)
            {
                int courseId = int.Parse(parts[i]);
                byte result = byte.Parse(parts[i + 1]);

                Course? course = Course.SearchCourseById(courseId);
                if (course is not null)
                {
                    student.RegisterCourseResult(course, result);
                }
                else
                {
                    Console.WriteLine($"Cursus met de Id {courseId} bestaat niet.");
                }
            }

            Console.WriteLine();
            student.ShowOverview();

        }

        private static void DemoCourses_H3()
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
            Course communicatie = new Course("Communicatie", studenten, 6);

            // 3 studiepunten (constructor 2)
            Course programmeren = new Course("Programmeren", studenten);

            // enkel de titel (constructor 3)
            Course webtechnologie = new Course("Webtechnologie");
            Course databanken = new Course("Databanken");

            // Said bij webtechnologie en Mieke bij databanken
            webtechnologie.Students.Add(said);
            databanken.Students.Add(mieke);


            Course? gevonden = Course.SearchCourseById(2);
            if (gevonden is null)
            {
                Console.WriteLine("Cursus niet gevonden");
            }
            else
            {
                gevonden.ShowOverview();
            }

            Course? nietBestaand = Course.SearchCourseById(99);
            Console.WriteLine(nietBestaand is null ? "99 is geen cursus" : "fout");
        }

        //H3_4 + H3_5
        private static void DemoStudyProgram()
        {
            Course communicatie = new Course("Communicatie");
            Course programmeren = new Course("Programmeren");
            Course databanken = new Course("Databanken");

            List<Course> coursesProgrammeren = new List<Course>() { communicatie, programmeren, databanken };
            List<Course> CoursesSNB = new List<Course>() { communicatie, programmeren, databanken };

            Course programmerenSNB = new Course("Programmeren");
            CoursesSNB[1] = programmerenSNB;

            StudyProgram programmerenProgram = new StudyProgram("Programmeren");
            StudyProgram snbProgram = new StudyProgram("Systeem- en netwerkbeheer");

            programmerenProgram.Courses = coursesProgrammeren;
            snbProgram.Courses = CoursesSNB;

            snbProgram.Courses.Remove(databanken);

            snbProgram.Courses[1].Title = "Scripting";

            programmerenProgram.ShowOverview();
            snbProgram.ShowOverview();
        }
    }
}