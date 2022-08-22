using EmployeeRecordBook.Core.Dtos;
using EmployeeRecordBook.Core.Entities;
using EmployeeRecordBook.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace EmployeeRecordBook.Infrastructure.Repositories.EntityFramework
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
        public async Task<IEnumerable<EmployeeDto>> GetEmployeesAsync(int pageIndex, int pageSize, string sortField, string sortOrder = "asc", string? filterText = null)
        {
            IEnumerable<EmployeeDto> empList;
            IEnumerable<EmployeeDto> orderData;
            empList = await (from employee in _employeeContext.Employees.Include(e => e.Department)
                             where filterText == null || employee.Name.Contains(filterText)
                             select new EmployeeDto
                             {
                                 Id = employee.Id,
                                 Name = employee.Name,
                                 Email = employee.Email,
                                 Salary = employee.Salary,
                                 DepartmentName = employee.Department.Name
                             }).ToListAsync();

            orderData = OrderBy(sortField, empList, sortOrder, pageIndex, pageSize);
            return orderData.ToList();
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
        public async Task<IEnumerable<EmployeeDto>> GetEmployeeAsync()
        {
            var employeeQuery = (from employee in _employeeContext.Employees.Include(e => e.Department)
                                 select new EmployeeDto
                                 {
                                     Id = employee.Id,
                                     Name = employee.Name,
                                     Salary = employee.Salary,
                                     Email = employee.Email,
                                     DepartmentName = employee.Department.Name
                                 }).AsNoTracking();
            //return await _employeeContext.Employees.ToListAsync();
            return await employeeQuery.ToListAsync();  // Executes DB Query in DB and Get results.
        }
        private IEnumerable<EmployeeDto> OrderBy(string sortField, IEnumerable<EmployeeDto> collection, string sortOrder, int pageIndex, int pageSize)
        {
            switch (sortOrder)
            {
                case "desc":

                    switch (sortField)
                    {
                        case "Id":
                            return collection.OrderByDescending(a => a.Id).Skip((pageIndex - 1) * pageSize).Take(pageSize);
                        case "Name":
                            return collection.OrderByDescending(a => a.Name).Skip((pageIndex - 1) * pageSize).Take(pageSize);
                        case "Email":
                            return collection.OrderByDescending(a => a.Email).Skip((pageIndex - 1) * pageSize).Take(pageSize);
                        case "Salary":
                            return collection.OrderByDescending(a => a.Salary).Skip((pageIndex - 1) * pageSize).Take(pageSize);
                        default:
                            return collection;
                    }
                case "asc":

                    switch (sortField)
                    {
                        case "Id":
                            return collection.OrderBy(a => a.Id).Skip((pageIndex - 1) * pageSize).Take(pageSize);
                        case "Name":
                            return collection.OrderBy(a => a.Name).Skip((pageIndex - 1) * pageSize).Take(pageSize);
                        case "Email":
                            return collection.OrderBy(a => a.Email).Skip((pageIndex - 1) * pageSize).Take(pageSize);
                        case "Salary":
                            return collection.OrderBy(a => a.Salary).Skip((pageIndex - 1) * pageSize).Take(pageSize);
                        default:
                            return collection;
                    }
                default:
                    throw new ArgumentException("Invalid argument!");
            }
        }
    }
}