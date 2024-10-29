using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentManagerD
{
    class Program
    {
        static void Main(string[] args)
        {   
            // es wir eine Objekt Insatnz der Klasse 'UniversityManager' erstellt um damit die methode 'MaleStudens()' aufzurufen
            UniversityManager um = new UniversityManager(); 
            um.MaleStudens();

            Console.WriteLine("\n");

            um.FemaleStudens();
        }
    }

    class UniversityManager
    {
        public List<University> universities;
        public List<Student> students;

        // Konstruktor
        public UniversityManager()
        {
            // Initialisieren der Listen
            universities = new List<University>();
            students = new List<Student>();

            // Befüllen der Universitätenliste
            universities.Add(new University { Id = 1, Name = "Yale" });
            universities.Add(new University { Id = 2, Name = "Beijing Tech" });

            // Befüllen der Studentenliste
            students.Add(new Student { Id = 1, Name = "Carla", Gender = "female", Age = 17, UniversityId = 1 });
            students.Add(new Student { Id = 2, Name = "Toni",  Gender = "male", Age = 21, UniversityId = 1 });
            students.Add(new Student { Id = 3, Name = "Leyla", Gender = "female", Age = 19, UniversityId = 2 });
            students.Add(new Student { Id = 4, Name = "James", Gender = "male", Age = 25, UniversityId = 2 });
            students.Add(new Student { Id = 5, Name = "Linda", Gender = "female", Age = 22, UniversityId = 2 });
            students.Add(new Student { Id = 6, Name = "Fritz", Gender = "male", Age = 44, UniversityId = 1 });
        }

        // Methode die jeden student ausgiebt dessen Geschlecht männlich ist
        public void MaleStudens()
        {   // Linq | IEnumerable ist eien Collection die mit der 'maleStudents' variable referenziert wird
            IEnumerable<Student> maleStudents = from student in students where student.Gender == "male" select student;
            Console.WriteLine("Männliche Studenten: ");

            foreach (Student student in maleStudents)
            {
                student.Print(); // gibt die methode aus der 'Student' klasse aus
            }
        }

        // Methode die jeden student ausgiebt dessen Geschlecht weiblich ist
        public void FemaleStudens()
        {   // Linq | IEnumerable ist eien Collection die mit der 'femaleStudents' variable referenziert wird
            IEnumerable<Student> femaleStudents = from student in students where student.Gender == "female" select student;
            Console.WriteLine("Weibliche Studenten: ");

            foreach (Student student in femaleStudents)
            {
                student.Print(); // gibt die methode aus der 'Student' klasse aus
            }
        }

    }
    // Blaupause für die Universität
    class University
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public void Print()
        {
            Console.WriteLine("Universität {0} mit der Id {1}", Name, Id);
        }
    }

    // Blaupause für die Studenten
    class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }

        // Foreign Key == Fremdschlüssel
        public int UniversityId { get; set; }
        public void Print()
        {
            Console.WriteLine("Student {0} mit der Id {1}, dem Geschlecht {2} " +
                "und Alter {3} von der University mit Id {4}", Name, Id, Gender, Age, UniversityId); // Reihenfolge beachten!
        }
    }
}