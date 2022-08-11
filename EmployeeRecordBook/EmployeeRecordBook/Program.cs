// See https://aka.ms/new-console-template for more information
using EmployeeRecordBook.Core.Entities;
using EmployeeRecordBook.Core.Infrastructure.Repositories;
using EmployeeRecordBook.Infrastructure.Data;
using EmployeeRecordBook.Infrastructure.Repositories;



//var departmentRepository = new DepartmentRepository();
//departmentRepository.Create(new Department() { DepartmentName = "HR" });
//departmentRepository.Create(new Department() { DepartmentName = "IT" });
//departmentRepository.Create(new Department() { DepartmentName = "Accouting" });

using(var employeeContext = new EmployeeContext())
{
    IEmployeeRepository employeeRepository = new EmployeeRepository(employeeContext);
    var anil = await employeeRepository.CreateAsync(new Employee
    {
        Name = "Anil Kumar",
        Email="anil@gmail.com",
        Salary=10000m,
        DepartmentId=1
    });

    var sunil = await employeeRepository.CreateAsync(new Employee
    {
        Name = "Sunil Kumar",
        Email = "sunil@gmail.com",
        Salary = 10000m,
        DepartmentId = 2
    });
    Console.WriteLine($"Created Employees : {anil.EmployeeId} {anil.Name},{sunil.EmployeeId} {sunil.Name}");

    var employees = await employeeRepository.GetEmployeesAsync();
    Console.WriteLine($"Total Employee Records: {employees.Count()}");

    var updatedAnilData = new Employee
    {
        Name = "Anil Kumar",
        Email = "anil@gmail.com",
        Salary = 12000m,
        DepartmentId = 1
    };
    var updatedEmployee = await employeeRepository.UpdateAsync(anil.EmployeeId,updatedAnilData);
    Console.WriteLine($"Updated Employees : {updatedEmployee.EmployeeId} {updatedEmployee.Name} {updatedEmployee.Email} {updatedEmployee.Salary}");

    await employeeRepository.DeleteAsync(sunil?.EmployeeId??0);
    var deletedRecord = await employeeRepository.GetEmployeeAsync(sunil?.EmployeeId??0);
    Console.WriteLine($"Was record deleted successfully? {deletedRecord == null : true ? false}");
}