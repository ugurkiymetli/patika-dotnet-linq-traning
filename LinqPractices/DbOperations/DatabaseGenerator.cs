using System.Linq;

namespace LinqPractices.DbOperations
{
    internal class DatabaseGenerator
    {
        public static void Initalize()
        {
            using ( var context = new LinqDbContext() )
            {
                if ( context.Students.Any() )
                    return;
                context.Students.AddRange(
                    new Student()
                    {
                        Name = "Ahmet",
                        Surname = "Ahmetoğlu",
                        ClassId = 1
                    },
                    new Student()
                    {
                        Name = "Ayşe",
                        Surname = "Ayşekızı",
                        ClassId = 1
                    },
                    new Student()
                    {
                        Name = "Mehmet",
                        Surname = "Mehmetoğlu",
                        ClassId = 2
                    },
                    new Student()
                    {
                        Name = "Fatma",
                        Surname = "Fatmakızı",
                        ClassId = 2
                    },
                    new Student()
                    {
                        Name = "Ahmet",
                        Surname = "Mehmetoğlu",
                        ClassId = 1
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
