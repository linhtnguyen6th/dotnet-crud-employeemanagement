using EmployeeManagement.Models;
using System.Collections.Generic;

namespace EmployeeManagement.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Employee> Employees { get; set; }
        public string PageTitle { get; set; }
    }
}
