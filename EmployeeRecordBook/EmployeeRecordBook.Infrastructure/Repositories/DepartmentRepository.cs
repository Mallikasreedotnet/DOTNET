using EmployeeRecordBook.Core.Entities;
using EmployeeRecordBook.Infrastructure.Data;

namespace EmployeeRecordBook.Infrastructure.Repositories
{
    public class DepartmentRepository
    {
        public void Create(Department department)
        {
            using (var employeeContext = new EmployeeContext())
            {
                employeeContext.Departments.Add(department);
                employeeContext.SaveChanges();

            }
        }
    }
}
