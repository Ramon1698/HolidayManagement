using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HolidayManagement.ApplicationLogic.Services;
using HolidayManagement.ViewModels.Holidays;
using Microsoft.AspNetCore.Mvc;

namespace HolidayManagement.Controllers
{
    public class HolidayController : Controller
    {
        private readonly HolidayService holidayService;

        public HolidayController(HolidayService holidayService)
        {
            this.holidayService = holidayService;
        }

        public IActionResult Index()
        {
            try
            {
                var viewModel = new HolidaysViewModel
                {
                    Holidays = holidayService.GetAll()
                };

                return View(viewModel);

            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        public IActionResult GetHolidays()
        {
            try
            {
                var viewModel = new HolidaysViewModel
                {
                    Holidays = holidayService.GetAll()
                };

                return PartialView("_GetHolidays", viewModel);

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        public IActionResult Create()
        {
            return PartialView("_Create", new CreateHolidayViewModel { });
        }

        [HttpPost]
        public IActionResult Create(CreateHolidayViewModel viewModel)
        {
            try
            {
                holidayService.Add(viewModel.Type, viewModel.Days, viewModel.Description);
                return RedirectToAction("Index");
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        public IActionResult ReadMore(Guid id)
        {
            try
            {
                var holidayDb = holidayService.GetById(id);

                var viewModel = new DetailsHolidayViewModel
                {
                    Type = holidayDb.Type,
                    Days = holidayDb.Days,
                    Description = holidayDb.Description
                };

                return PartialView("_ReadMore", viewModel);
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
                holidayService.Remove(id);
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
                var holidayDb = holidayService.GetById(id);

                var viewModel = new EditHolidayViewModel
                {
                    Id = id,
                    Type = holidayDb.Type,
                    Days = holidayDb.Days,
                    Description = holidayDb.Description
                };

                return PartialView("_Edit", viewModel);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public IActionResult Edit([FromForm]EditHolidayViewModel viewModel)
        {
            try
            {
                holidayService.Update(viewModel.Id, viewModel.Type, viewModel.Days, viewModel.Description);
                return RedirectToAction("Index");
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}