#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DataAccess.Contexts;
using DataAccess.Entities;
using Business.Services;
using Business;
using Business.Models;
using Microsoft.AspNetCore.Authorization;

namespace MVC.Controllers
{
    [Authorize]
    public class ReadingsController : Controller
    {
        private readonly IReadingService _readingService;
        private readonly IUserService _userService;
        private readonly IRoleService _roleService;

        public ReadingsController(IReadingService readingService, IUserService userService, IRoleService roleService)
        {
            _readingService = readingService;
        }
        #region User and Role Service Constructor Injections


        #endregion


        public IActionResult Index(int id)
        {
            List<ReadingModel> readingList = _readingService.GetList();
            return View(readingList);
        }
        public IActionResult Details(int id)
        {
            ReadingModel reading = _readingService.GetItem(id);
            if (reading == null)
            {
                return NotFound();
            }
            return View(reading);
        }

        public IActionResult Create()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ReadingModel reading)
        {
            if (ModelState.IsValid)
            {
                var result = _readingService.Add(reading);
                if (result.IsSuccessful)
                {
                    TempData["Message"] = result.Message;
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError("", result.Message);
            }

            return View(reading);
        }
        public IActionResult Edit(int id)
        {
            ReadingModel reading = _readingService.Query().SingleOrDefault(r => r.Id == id);
            if (reading == null)
            {
                return NotFound();
            }
        
            return View(reading);
        }

        [Authorize(Roles = "admin,readr")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ReadingModel reading)
        {
            if (ModelState.IsValid)
            {
                var result = _readingService.Update(reading);
                if (result.IsSuccessful)
                {
                    TempData["Message"] = result.Message;
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError("", result.Message);
            }

            return View(reading);
        }
        public IActionResult Delete(int id)
        {
            ReadingModel reading = _readingService.Query().SingleOrDefault(r => r.Id == id);
            if (reading == null)
            {
                return NotFound();
            }
            return View(reading);
        }

        [Authorize(Roles = "admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var result = _readingService.Delete(id);
            TempData["Message"] = result.Message;
            return RedirectToAction(nameof(Index));
        }
	}
}
