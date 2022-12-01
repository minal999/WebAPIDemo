using WebAPIDemo.Data;
using WebAPIDemo.Models;

namespace WebAPIDemo.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDbContext _context;

        public EmployeeRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public int AddEmployee(Employee emp)
        {
            _context.employees.Add(emp);
            var res = _context.SaveChanges();
            return res;
        }

        public int DeleteEmployee(int id)
        {
            int res = 0;
            var emp = _context.employees.Find(id);
            if (emp != null)
            {
                _context.employees.Remove(emp);
                res = _context.SaveChanges();
            }
            return res;
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return _context.employees.ToList();
        }

        public Employee GetEmployeeById(int id)
        {
            var emp = _context.employees.Find(id);
            return emp;
        }

        public int UpdateEmployee(Employee emp)
        {
            int res = 0;
            var e = _context.employees.Where(x => x.Id == emp.Id).FirstOrDefault();
            if (e != null)
            {
                e.Name = emp.Name;
                e.Salary = emp.Salary;

                res = _context.SaveChanges();
            }
            return res;
        }
    }
}
