using LinqPractices.DbOperations;
using System.Linq;
namespace LinqPractices
{
    internal class Program
    {
        static void Main( string[] args )
        {
            DatabaseGenerator.Initalize();
            LinqDbContext _context = new LinqDbContext();

            var students = _context.Students.ToList<Student>();

        }

    }
}
