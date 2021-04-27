using System;
using UniversityApp.Data;
using UniversityApp.Domain;

namespace UniversityApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var db = new UniversityDbContext();
            //db.Universities.Add(new University() { Name = "Ahram Canadian University" });
            //db.Students.Add(new Student() { Name = "Zeyad", Grade = 76 });
            //db.SaveChanges();
            //Console.WriteLine("Database saved successfully.");
            var university = db.Universities.Find(3);
            Console.WriteLine(university.Name);

            var student = db.Students.Find(2);
            Console.WriteLine(student.Name);
        }
    }
}
