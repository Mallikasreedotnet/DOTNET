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
        IEnumerable<EmployeeDto> sortData;

        public async Task<IEnumerable<EmployeeDto>> OrderBy(string sortField, IEnumerable<EmployeeDto> Collection, string sortOrder, int pageIndex, int pageSize)
        {
            switch (sortOrder)
            {
                case "desc":

                    switch (sortField)
                    {
                        case "Id":
                            return sortData = Collection.OrderByDescending(a => a.Id).Skip((pageIndex - 1) * pageSize).Take(pageSize);
                        case "Name":
                            return sortData = Collection.OrderByDescending(a => a.Name).Skip((pageIndex - 1) * pageSize).Take(pageSize);
                        case "Email":
                            return sortData = Collection.OrderByDescending(a => a.Email).Skip((pageIndex - 1) * pageSize).Take(pageSize);
                        case "Salary":
                            return sortData = Collection.OrderByDescending(a => a.Salary).Skip((pageIndex - 1) * pageSize).Take(pageSize);
                        default:
                            return sortData = Collection;
                    }
                case "asc":

                    switch (sortField)
                    {
                        case "Id":
                            return sortData = Collection.OrderBy(a => a.Id).Skip((pageIndex - 1) * pageSize).Take(pageSize);
                        case "Name":
                            return sortData = Collection.OrderBy(a => a.Name).Skip((pageIndex - 1) * pageSize).Take(pageSize);
                        case "Email":
                            return sortData = Collection.OrderBy(a => a.Email).Skip((pageIndex - 1) * pageSize).Take(pageSize);
                        case "Salary":
                            return sortData = Collection.OrderBy(a => a.Salary).Skip((pageIndex - 1) * pageSize).Take(pageSize);
                        default:
                            return sortData = Collection;
                    }
            }
            return sortData;
        }
        IEnumerable<EmployeeDto> empQuery;
        IEnumerable<EmployeeDto> orderData;
        public async Task<IEnumerable<EmployeeDto>> GetEmployeesAsync(int pageIndex, int pageSize, string sortField, string sortOrder = "asc", string? filterText = null)
        {
            empQuery = from employee in _employeeContext.Employees.Include(e => e.Department)
                       where (filterText==null || employee.Name.Contains(filterText))
                       select new EmployeeDto
                       {
                           Id = employee.Id,
                           Name = employee.Name,
                           Email = employee.Email,
                           Salary = employee.Salary,
                           DepartmentName = employee.Department.Name
                       };

            orderData = await OrderBy(sortField, empQuery, sortOrder, pageIndex, pageSize);
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

        public Task<IEnumerable<EmployeeDto>> GetEmployeesAsync()
        {
            throw new NotImplementedException();
        }
    }
}