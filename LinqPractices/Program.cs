using LinqPractices.DbOperations;
using System;
using System.Linq;
namespace LinqPractices
{
    internal class Program
    {
        static void Main( string[] args )
        {
            DatabaseGenerator.Initalize();
            LinqDbContext _context = new LinqDbContext();

            //var students = _context.Students.ToList<Student>();


            //Find()
            Console.WriteLine("*** Find ***");
            var student = _context.Students.Where(student => student.StudentId == 1).FirstOrDefault();
            Console.Write("Where => ");
            Console.WriteLine(student.Name);
            student = _context.Students.Find(2);
            Console.Write("Find => ");
            Console.WriteLine(student.Name);

            //FirstOrDefault()
            Console.WriteLine();
            Console.WriteLine("*** FirstOrDefault ***");
            student = _context.Students.Where(student => student.Surname == "Mehmetoğlu").FirstOrDefault();
            Console.Write("Where.FirstOrDefault => ");
            Console.WriteLine(student.Name);
            student = _context.Students.FirstOrDefault(student => student.Surname == "Mehmetoğlu");
            Console.Write("FirstOrDefault => ");
            Console.WriteLine(student.Name);

            //SingleOrDefault()
            Console.WriteLine();
            Console.WriteLine("*** SingleOrDefault ***");
            student = _context.Students.Where(student => student.Surname == "Ahmetoğlu").SingleOrDefault();
            Console.Write("SingleOrDefault => ");
            Console.WriteLine(student.Name);

            //ToList()
            Console.WriteLine();
            Console.WriteLine("*** ToList ***");
            var studentList = _context.Students.Where(student => student.ClassId == 2).ToList();
            foreach ( var item in studentList )
            {
                Console.WriteLine(item.Name + " " + item.Surname);
            }

            //OrderBy()
            Console.WriteLine();
            Console.WriteLine("*** OrderBy ***");
            studentList = _context.Students.OrderBy(student => student.Name).ToList();
            foreach ( var item in studentList )
            {
                Console.WriteLine(item.Name + " " + item.Surname);
            }

            //OrderByDescending()
            Console.WriteLine();
            Console.WriteLine("*** OrderByDescending ***");
            studentList = _context.Students.OrderByDescending(student => student.StudentId).ToList();
            foreach ( var item in studentList )
            {
                Console.WriteLine(item.StudentId + " - " + item.Name + " " + item.Surname);
            }

            //Anonymous Object Result 
            Console.WriteLine();
            Console.WriteLine("*** Anonymous Object Result ***");
            var anonymousObject = _context.Students
                                .Where(student => student.ClassId == 2)
                                .Select(student => new
                                {
                                    Id = student.StudentId,
                                    Fullname = student.Name + " " + student.Surname
                                });
            Console.WriteLine(anonymousObject.ToList());
            foreach ( var obj in anonymousObject )
            {
                Console.WriteLine(obj.Id + " - " + obj.Fullname);
            }
        }

    }
}
