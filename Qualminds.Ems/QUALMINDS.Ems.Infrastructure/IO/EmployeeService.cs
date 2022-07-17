using Qualminds.Ems.Core.Constants;
using Qualminds.Ems.Core.ContractsandInfrastructure;
using Qualminds.Ems.Core.Entities;
using System.Text;

namespace Qualminds.Ems.Infrastructure.IO
{
    public class EmployeeService: IEmployeeService
    {
        private readonly string _filepath;
        StringBuilder stringBuilder = new StringBuilder();
        public EmployeeService(string filepath)
        {
            _filepath = filepath;
            InitializeEmployeeService();
        }
        public bool InitializeEmployeeService()
        {
            if (!File.Exists(_filepath))
            {
                StreamWriter? streamWriter = null;
                try
                {
                    streamWriter = File.CreateText(_filepath);
                    streamWriter.WriteLine($"{FileConstants.EmployeeIdField}{FileConstants.Detlimeter}\t\t{FileConstants.EmployeeNameField}{FileConstants.Detlimeter}\t\t{FileConstants.EmployeeDesignationField}{FileConstants.Detlimeter}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    streamWriter?.Flush();
                    streamWriter?.Close();
                }
                return true;
            }
            return false;
        }
        public Employee AddEmployee(Employee employee)
        {
            employee.Id = Guid.NewGuid();
            File.AppendAllText(_filepath,$"{employee.Id}{FileConstants.Detlimeter}{employee.Name}{FileConstants.Detlimeter}{employee.Designation}\n");
            return employee;
        }
        public IEnumerable<Employee> AddEmployees(IEnumerable<Employee> employees)
        {
            throw new NotImplementedException();
        }
        public StringBuilder GetEmployees()
        {
            var employeesCommaSeparatedList=File.ReadAllLines(_filepath).Skip(1);
            foreach(var employeeRow in employeesCommaSeparatedList)
            {
                var employeeData = employeeRow.Split(FileConstants.Detlimeter);
                //yield return new Employee { Id = Guid.Parse(employeeData[0]), Name = employeeData[1], Designation = employeeData[2] };
                stringBuilder.AppendLine($"{Guid.Parse(employeeData[0])}\t {employeeData[1]}\t  {employeeData[2]}");

            }
            return stringBuilder;
        }
        public void DeleteEmployees()
        {
            //File.Delete(_filepath);
        }

        public void DeleteEmployee()
        {
            throw new NotImplementedException();
        }
    }
}
