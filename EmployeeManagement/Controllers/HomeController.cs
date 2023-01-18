﻿using EmployeeManagement.Models;
using EmployeeManagement.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

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
        public string Index()
        {
            return _employeeRepository.GetEmployee(1).Name;
        }
        public ViewResult Details()
        {
            HomeDetailsViewModel homeDetailsViewModel = new HomeDetailsViewModel()
            {
                Employee = _employeeRepository.GetEmployee(1),
                PageTitle = "Employee Details"
            };

            //Employee model = _employeeRepository.GetEmployee(1);

            //ViewData["Employee"] = model;
            //ViewData["PageTitle"] = "Employee Details";

            //ViewBag.Employee = model;
            //ViewBag.PageTitle = "Employee Details";

            return View(homeDetailsViewModel);
        }
    }
}
    