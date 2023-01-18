using System;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeManagement.Models
{
    //<access modifier> <type> className <implements / extends> className
    public class MockEmployeeRepository : IEmployeeRepository
    {
        private List<Employee> _employeeList;

        public MockEmployeeRepository()
        {
            _employeeList = new List<Employee>()
            {
                new Employee() { Id = 1, Name = "Mary", Department = "HR", Email = "mary@gmail.com" },
                new Employee() { Id = 2, Name = "John", Department = "IT", Email = "john@gmail.com" },
                new Employee() { Id = 3, Name = "Sam", Department = "Sales", Email = "sam@gmail.com" }
            };
        }
       public Employee GetEmployee(int Id) 
        {
            return _employeeList.FirstOrDefault(e => e.Id == Id);
        }
    }
}
