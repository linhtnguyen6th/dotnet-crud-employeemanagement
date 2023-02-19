using EmployeeManagement.Models;
using EmployeeManagement.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeManagement.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;

        //constructor injection
        public HomeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        [Route("")]
        [Route("Home")]
        [Route("Home/Index")]
        public ViewResult Index()
        {
            var model = new HomeViewModel
            {
                Employees = _employeeRepository.GetAllEmployee(),
                PageTitle = "Home"
            };
                
            return View(model);
        }

        // The ? makes id route parameter optional. To make it required remove ?
        [Route("Home/Details/{id?}")]
        // ? makes id method parameter nullable
        public ViewResult Details(int? id)
        {
            HomeDetailsViewModel homeDetailsViewModel = new HomeDetailsViewModel()
            {
                // If "id" is null use 1, else use the value passed from the route
                Employee = _employeeRepository.GetEmployee(id??1),
                PageTitle = "Employee Details"
            };

            //Employee model = _employeeRepository.GetEmployee(1);

            //ViewData["Employee"] = model;
            //ViewData["PageTitle"] = "Employee Details";

            //ViewBag.Employee = model;
            //ViewBag.PageTitle = "Employee Details";

            //var square = new Square();
            //Common.CalculateArea(square);
            //Common.ModifyWidth(square);

            return View(homeDetailsViewModel);
        }

        [Route("Home/Create")]
        [HttpGet]
        //public ViewResult Create()
        //{
        //    HomeCreateViewModel homeCreateViewModel = new HomeCreateViewModel()
        //    {
        //        PageTitle = "Create Employee"
        //    };
        //    return View(homeCreateViewModel);
        //}
        public ViewResult Create()
        {
            return View();
        }

        [Route("Home/Create")]
        [HttpPost]      
        public IActionResult Create(Employee employee)
        {
            if(ModelState.IsValid)
            { 
                Employee newEmployee = _employeeRepository.Add(employee);
                return RedirectToAction("details", new { id = newEmployee.Id });
            }
            return View();
        }
    }

    //public class Shape
    //{
    //    public int Width { get; set; }
    //}

    //public class Square : Shape, IEmployeeRepository
    //{
    //    public int Length { get; set; }

    //    public IEnumerable<Employee> GetAllEmployee()
    //    {
    //        throw new System.NotImplementedException();
    //    }

    //    public Employee GetEmployee(int Id)
    //    {
    //        throw new System.NotImplementedException();
    //    }
    //}

    //public static class Common
    //{
    //    public static int CalculateArea(Shape shape)
    //    {
    //        return 1;
    //    }

    //    public static void ModifyWidth(Shape shape)
    //    {
    //        shape.Width = 1;
    //    }
    //}
}
    