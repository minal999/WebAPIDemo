using WebAPIDemo.Data;
using WebAPIDemo.Models;

namespace WebAPIDemo.Repositories
{
    public class StudentRepository : IStudentRepository
    {

        private readonly ApplicationDbContext _context;

        public StudentRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public int AddStudent(Student stud)
        {
            _context.students.Add(stud);
            var res = _context.SaveChanges();
            return res;
        }

        public int DeleteStudent(int id)
        {
            int res = 0;
            var stud = _context.students.Find(id);
            if (stud != null)
            {
                _context.students.Remove(stud);
                res = _context.SaveChanges();
            }
            return res;
        }

        public IEnumerable<Student> GetAllStudents()
        {
            return _context.students.ToList();
        }

        public Student GetStudentById(int id)
        {
            var stud = _context.students.Find(id);
            return stud;
        }

        public int UpdateStudent(Student stud)
        {
            int res = 0;
            var s = _context.students.Where(x => x.Id == stud.Id).FirstOrDefault();
            if (s != null)
            {
                s.Name = stud.Name;
                s.Sub1 = stud.Sub1;
                s.Sub2 = stud.Sub2;
                s.Sub3 = stud.Sub3;
                s.Percentage = stud.Percentage;

                res = _context.SaveChanges();
            }
            return res;

        }
    }
}
