using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HolidayManagement.ApplicationLogic.Abstractions;
using HolidayManagement.ApplicationLogic.Services;
using HolidayManagement.ViewModels.Employees;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HolidayManagement.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly EmployeeService employeeService;
        private readonly UserManager<IdentityUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public EmployeeController(EmployeeService employeeService,
                                  UserManager<IdentityUser> userManager,
                                  RoleManager<IdentityRole> roleManager)
        {
            this.employeeService = employeeService;
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        public IActionResult Index()
        {
            try
            {
                var viewModel = new EmployeesViewModel 
                {
                    Employees = employeeService.GetAll()
                };

                return PartialView("_Index", viewModel);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        public IActionResult Create()
        {
            return PartialView("_Create");
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm]CreateEmployeeViewModel viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    IdentityUser user = new IdentityUser
                    {
                        UserName = viewModel.Email,
                        Email = viewModel.Email,
                        PhoneNumber = viewModel.PhoneNumber
                    };

                    await userManager.CreateAsync(user, viewModel.Password);
                    var createdUser = await userManager.FindByEmailAsync(viewModel.Email);
                    
                    employeeService.Add(createdUser.Id,
                                        viewModel.Name,
                                        viewModel.Email,
                                        viewModel.PhoneNumber,
                                        viewModel.HolidayDays);

                    if (await roleManager.FindByNameAsync(viewModel.Role) == null)
                    {
                        var role = new IdentityRole(viewModel.Role);
                        await roleManager.CreateAsync(role);
                        await userManager.AddToRoleAsync(user, role.Name);
                    }
                    else
                    {
                        await userManager.AddToRoleAsync(user, viewModel.Role);
                    }

                }

                return RedirectToAction("Index");
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        public IActionResult Remove(Guid id)
        {
            try
            {
                employeeService.Remove(id);
                return RedirectToAction("Index");
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            try
            {
                var employeeDb = employeeService.GetById(id);

                var viewModel = new EditEmployeeViewModel
                {
                    Id = id,
                    Name = employeeDb.Name,
                    Email = employeeDb.Email,
                    HolidayDays = employeeDb.HolidayDays,
                    PhoneNumber = employeeDb.PhoneNumber,
                };

                return PartialView("_Edit", viewModel);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public IActionResult Edit([FromForm]EditEmployeeViewModel viewModel)
        {
            try
            {
                employeeService.Update(viewModel.Id,
                                       viewModel.Name,
                                       viewModel.Email,
                                       viewModel.PhoneNumber,
                                       viewModel.HolidayDays);
                return RedirectToAction("Index");
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        public IActionResult Details(Guid id)
        {
            try
            {
                var viewModel = new DetailsEmployeeViewModel
                {
                    Employee = employeeService.GetById(id)
                };

                return PartialView("_Details", viewModel);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}