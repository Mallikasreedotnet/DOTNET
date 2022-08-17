using AutoMapper;
using EmployeeRecordBook.Configurations;
using EmployeeRecordBook.Core.Contracts.Infrastructure;
using EmployeeRecordBook.Core.Entities;
using EmployeeRecordBook.Infrastructure.Data;
using EmployeeRecordBook.Infrastructure.Repositories;
using EmployeeRecordBook.ViewModels;

Console.WriteLine("Hello, World!");

#region Configure and Register AutoMapper
var config = new MapperConfiguration(config => config.AddProfile(new AutoMapperProfile()));
IMapper mapper = config.CreateMapper();

#endregion

using (var employeeContext = new EmployeeContext())
{
    IEmployeeRepository employeeRepository = new EmployeeRepository(employeeContext);

    var emp = await employeeRepository.GetEmployeesAsync(1,3,"Id");
    foreach (var item in emp)
    {
        Console.WriteLine($"employee:{item.Id} {item.Name} {item.Email} {item.Salary} ");
    }
}