using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HolidayManagement.ApplicationLogic.Services;
using HolidayManagement.ViewModels.HolidayApplication;
using HolidayManagement.ViewModels.HolidayApplications;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HolidayManagement.Controllers
{
    public class HolidayApplicationController : Controller
    {
        private readonly HolidayApplicationService holidayApplicationService;
        private readonly HolidayService holidayService;
        private readonly UserManager<IdentityUser> userManager;
        private readonly EmployeeService employeeService;

        public HolidayApplicationController(HolidayApplicationService holidayApplicationService,
                                            HolidayService holidayService,
                                            UserManager<IdentityUser> userManager,
                                            EmployeeService employeeService)
        {
            this.holidayApplicationService = holidayApplicationService;
            this.holidayService = holidayService;
            this.userManager = userManager;
            this.employeeService = employeeService;
        }

        public IActionResult GetAllForEmployee()
        {
            try
            {
                var userId = userManager.GetUserId(User);

                var viewModel = new HolidayApplicationViewModel
                {
                    Employee = employeeService.GetByUserId(userId),
                    HolidayApplications = holidayApplicationService.GetAllForEmployee(userId)
                };

                return PartialView("_GetAllForEmployee", viewModel);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        public IActionResult Create()
        {
            try
            {
                var viewModel = new CreateHolidayApplicationViewModel
                {
                    Holidays = holidayService.GetAll()
                };

                return PartialView("_Create", viewModel);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public IActionResult Create([FromForm]CreateHolidayApplicationViewModel viewModel)
        {
            try
            {
                var userId = userManager.GetUserId(User);
                holidayApplicationService.Add(viewModel.HolidayId,
                                              userId,
                                              viewModel.StartDay,
                                              viewModel.EndDay,
                                              viewModel.Reasons);
                return RedirectToAction("GetAllForEmployee");
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            } 
        }

        public IActionResult Cancel(Guid id)
        {
            try
            {
                holidayApplicationService.Cancel(id);
                return RedirectToAction("GetAllForEmployee");
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        public IActionResult GetAllActive()
        {
            try
            {
                var viewModel = new HolidayApplicationViewModel
                {
                    HolidayApplications = holidayApplicationService.GetAllActive()
                };

                return PartialView("_GetAllActive", viewModel);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        public IActionResult Accept(Guid id)
        {
            try
            {
                holidayApplicationService.Accept(id);
                return RedirectToAction("GetAllActive");
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        public IActionResult Reject(Guid id)
        {
            try
            {
                holidayApplicationService.Reject(id);
                return RedirectToAction("GetAllActive");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        public IActionResult Details(Guid id)
        {
            try
            {
                var viewModel = new DetailsHolidayApplicationViewModel
                {
                    HolidayApplication = holidayApplicationService.GetById(id)
                };

                return PartialView("_Details", viewModel);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}