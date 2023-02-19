using System.Collections.Generic;

namespace EmployeeManagement.Models
{
    //<access modifier> <interface / abstract> className
    public interface IEmployeeRepository
    {
        //method declaration with no body
        //<type> methodName (<type> args)
        Employee GetEmployee(int Id);
        IEnumerable<Employee> GetAllEmployee();
        Employee Add(Employee employee);
    }
}
