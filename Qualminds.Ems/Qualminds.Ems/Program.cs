using Qualminds.Ems.Core.ContractsandInfrastructure;
using Qualminds.Ems.Core.Entities;
using Qualminds.Ems.Infrastructure.IO;
using System.Text;
using System.Text.Json;


Console.WriteLine("Enter your Path");
string directoryPath = Console.ReadLine();
//string directoryPath = filePath;
string fileName = "Employee.csv";
IEmployeeService employeeService=new EmployeeService(Path.Combine(directoryPath, fileName));
StringBuilder stringBuilder = new StringBuilder();
if (File.Exists(Path.Combine(directoryPath, fileName)))
{
    Console.WriteLine($"Created {fileName} with predefined headers");
    Console.WriteLine("Do you want to enter Employee Details type yes or else no");
    string employeeDetails = Console.ReadLine();
    Add(employeeDetails);
    void Add(string value)
    {
        string result = "yes";
        if (result == value)
        {
            Console.WriteLine("\nAdding Employees Details:\n");
            Console.WriteLine("Enter Employee Name:");
            string EName = Console.ReadLine();
            //var employee = employeeService.AddEmployee(new Employee { Name="" });
            Console.WriteLine("Enter Employee Designation:");
            string EDesignation = Console.ReadLine();
            var ed= employeeService.AddEmployee(new Employee { Name = EName, Designation = EDesignation });
            Console.WriteLine("do you want more details enter yes or no");
            string adding = Console.ReadLine();
            Add(adding);

        }
        else if (value != "no")
        {
            Console.WriteLine("Please enter valid Input");
            Console.WriteLine("Do you want Adding Employees Details please enter Yes else No");
            string addingResult = Console.ReadLine();
            Add(addingResult);
        }
    }
    Console.WriteLine("Display the Employee Details type yes");
    string displayDetails = Console.ReadLine();
    if (displayDetails == "yes")
    {
        StringBuilder employees = employeeService.GetEmployees();
        Console.WriteLine("Id \t\t\t\t\t  Name \t Designation");
        Console.WriteLine(employees);
    }
    Console.WriteLine("Do you want delete the file plase enter yes");
    string delete = Console.ReadLine();
    if (delete == "yes")
    {
        employeeService.DeleteEmployees();
        Console.WriteLine("Successfully delete the file");
    }

    //var afroz = employeeService.AddEmployee(new Employee { Name = "Afroz", Designation = "Asst.Programmer" });
    //var mallika = employeeService.AddEmployee(new Employee { Name = "Mallika", Designation = "Associate Engineer" });
    //Console.WriteLine($"Employees added successfully. Here are thier newly created IDs:{afroz.Name}:{afroz.Id},{mallika.Name}:{mallika.Id}");
    //employeeService.AddEmployees(new List<Employee>()
    //{
    //   new Employee { Name="Navneet", Designation = "Programmer"},
    //   new Employee { Name = "Bhupal", Designation = "Asst. Programmer" },
    //   new Employee { Name = "Parmeshwar", Designation = "Associate Engineer" }
    //});

    //var employees = employeeService.GetEmployees();
    //var stringifiedEmployees = JsonSerializer.Serialize(employees);
    //Console.WriteLine("\nList of all Employees:\n");
    //Console.WriteLine(stringifiedEmployees);
}
