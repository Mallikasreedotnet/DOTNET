using EmployeeRecordBook.Core.Dtos;
using EmployeeRecordBook.Core.Entities;
using EmployeeRecordBook.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace EmployeeRecordBook.Infrastructure.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeContext _employeeContext;
        public EmployeeRepository(EmployeeContext employeeContext)
        {
            _employeeContext = employeeContext;
        }
        public async Task<Employee> CreateAsync(Employee employee)
        {
            _employeeContext.Employees.Add(employee);
            await _employeeContext.SaveChangesAsync();
            return employee;
        }
        public async Task CreateRangeAsync(IEnumerable<Employee> employees)
        {
            // Not ideal way to use DB Context instance here, instead use constuctor injection. 
            using (var employeeContext = new EmployeeContext())
            {
                employeeContext.Employees.AddRange(employees);
                await employeeContext.SaveChangesAsync();
            }
        }


        public async Task<IEnumerable<EmployeeDto>> GetEmployeesAsync(/*int pageIndex,int pageSize,*/ string sortField, string sortorder = "asc", string? filterText = null)
        {

            //var employeeQuery = from employee in _employeeContext.Employees.Include(e => e.Department)
            //                    select new EmployeeDto
            //                    {
            //                        Id = employee.Id,
            //                        Name = employee.Name,
            //                        Salary = employee.Salary,
            //                        DepartmentName = employee.Department.Name
            //                    };

            if (sortorder == "des")
            {
                IEnumerable<EmployeeDto> empquery = null;
                switch (sortField)
                {
                    case "Id":
                        empquery = from employee in _employeeContext.Employees.Include(e => e.Department).OrderByDescending(emp => emp.Id)
                                   select new EmployeeDto
                                   {
                                       Id = employee.Id,
                                       Name = employee.Name,
                                       Email = employee.Email,
                                       Salary = employee.Salary,
                                       DepartmentName = employee.Department.Name
                                   };
                        break;

                    case "Name":
                        empquery = from employee in _employeeContext.Employees.Include(e => e.Department).OrderByDescending(emp => emp.Name)
                                   select new EmployeeDto
                                   {
                                       Id = employee.Id,
                                       Name = employee.Name,
                                       Email = employee.Email,
                                       Salary = employee.Salary,
                                       DepartmentName = employee.Department.Name
                                   };
                        break;
                    case "Email":
                        empquery = from employee in _employeeContext.Employees.Include(e => e.Department).OrderByDescending(emp => emp.Email)
                                   select new EmployeeDto
                                   {
                                       Id = employee.Id,
                                       Name = employee.Name,
                                       Email = employee.Email,
                                       Salary = employee.Salary,
                                       DepartmentName = employee.Department.Name
                                   };
                        break;
                    case "Salary":
                        empquery = from employee in _employeeContext.Employees.Include(e => e.Department).OrderByDescending(emp => emp.Salary)
                                   select new EmployeeDto
                                   {
                                       Id = employee.Id,
                                       Name = employee.Name,
                                       Email = employee.Email,
                                       Salary = employee.Salary,
                                       DepartmentName = employee.Department.Name
                                   };
                        break;
                        //default:
                        //throw new ArgumentOutOfRangeException();
                        //break;

                }
                return empquery;
            }
            else
            {
                IEnumerable<EmployeeDto> empquery = null;
                switch (sortField)
                {
                    case "Id":
                        empquery = from employee in _employeeContext.Employees.Include(e => e.Department).OrderBy(emp => emp.Id)
                                   select new EmployeeDto
                                   {
                                       Id = employee.Id,
                                       Name = employee.Name,
                                       Email = employee.Email,
                                       Salary = employee.Salary,
                                       DepartmentName = employee.Department.Name
                                   };
                        break;

                    case "Name":
                        empquery = from employee in _employeeContext.Employees.Include(e => e.Department).OrderBy(emp => emp.Name)
                                   select new EmployeeDto
                                   {
                                       Id = employee.Id,
                                       Name = employee.Name,
                                       Email = employee.Email,
                                       Salary = employee.Salary,
                                       DepartmentName = employee.Department.Name
                                   };
                        break;
                    case "Email":
                        empquery = from employee in _employeeContext.Employees.Include(e => e.Department).OrderBy(emp => emp.Email)
                                   select new EmployeeDto
                                   {
                                       Id = employee.Id,
                                       Name = employee.Name,
                                       Email = employee.Email,
                                       Salary = employee.Salary,
                                       DepartmentName = employee.Department.Name
                                   };
                        break;
                    case "Salary":
                        empquery = from employee in _employeeContext.Employees.Include(e => e.Department).OrderBy(emp => emp.Salary)
                                   select new EmployeeDto
                                   {
                                       Id = employee.Id,
                                       Name = employee.Name,
                                       Email = employee.Email,
                                       Salary = employee.Salary,
                                       DepartmentName = employee.Department.Name
                                   };
                        break;
                }
                return empquery;
                //return await _employeeContext.Employees.ToListAsync();
                //  return await employeeQuery.ToListAsync();  // Executes DB Query in DB and Get results.
            }
        }

        public async Task<Employee> GetEmployeeAsync(int employeeId)
        {
            return await _employeeContext.Employees.FindAsync(employeeId);
        }
        public async Task<Employee> UpdateAsync(int employeeId, Employee employee)
        {
            var employeeToBeUpdated = await GetEmployeeAsync(employeeId);
            employeeToBeUpdated.Name = employee.Name;
            employeeToBeUpdated.Email = employee.Email;
            employeeToBeUpdated.Salary = employee.Salary;
            employeeToBeUpdated.DepartmentId = employee.DepartmentId;
            _employeeContext.Employees.Update(employeeToBeUpdated);
            _employeeContext.SaveChanges();  // Actual execution of the command happens here with DB.
            return employeeToBeUpdated;
        }
        public async Task DeleteAsync(int employeeId)
        {
            var employeeToBeDeleted = await GetEmployeeAsync(employeeId);
            _employeeContext.Employees.Remove(employeeToBeDeleted);
            await _employeeContext.SaveChangesAsync();
        }

        public Task<IEnumerable<EmployeeDto>> GetEmployeesAsync()
        {
            throw new NotImplementedException();
        }


        //public Task<IEnumerable<EmployeeDto>> GetEmployeesAsync()
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<Employee> UpdateAsync(int employeeId, Employee employee)
        //{
        //    throw new NotImplementedException();
        //}
    }
}