#nullable disable
using Business;
using Business.Models;
using DataAccess.Results.Bases;
using Business.Services;
using DataAccess.Enums;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;
using MVC.Controllers.Bases;

namespace MVC.Controllers
{
    public class UsersController : MvcControllerBase
    {
        #region User and Role Service Constructor Injections
        private readonly IUserService _userService;
        private readonly IRoleService _roleService;

		public UsersController(IUserService userService, IRoleService roleService)
		{
			_userService = userService;
			_roleService = roleService;
		}
        #endregion

        [Authorize]
        public IActionResult GetList()
        {
            List<UserModel> userList = _userService.Query().ToList();


            return View("List", userList);
        }

        [Authorize(Roles = "admin")]
        public JsonResult GetListJson()
        {
            var userList = _userService.Query().ToList();
            return Json(userList);
        }

        [Authorize(Roles = "admin")]
        public IActionResult Details(int id)
        {
            UserModel user = _userService.Query().SingleOrDefault(u => u.Id == id);

            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public IActionResult Create()
        {
            ViewBag.Roles = new SelectList(_roleService.Query().ToList(), "Id", "Name");

			return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public IActionResult Create(UserModel user)
        {
            if (ModelState.IsValid)
            {
                Result result = _userService.Add(user);
                if (result.IsSuccessful)
                {
                    TempData["Message"] = result.Message;
                    return RedirectToAction(nameof(GetList));
                }

				ModelState.AddModelError("", result.Message); 

            }

			ViewBag.Roles = new SelectList(_roleService.Query().ToList(), "Id", "Name");
			return View(user); 
        }

        [Authorize(Roles = "admin")]
        public IActionResult Edit(int id)
        {
            UserModel user = _userService.Query().SingleOrDefault(u => u.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            ViewBag.RoleId = new SelectList(_roleService.Query().ToList(), "Id", "Name");
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public IActionResult Edit(UserModel user)
        {
            if (ModelState.IsValid)
            {
                var result = _userService.Update(user);
                if (result.IsSuccessful)
                {
                    TempData["Message"] = result.Message;
                    return RedirectToAction(nameof(GetList));
                }
                ModelState.AddModelError("", result.Message);
            }
            
            ViewBag.RoleId = new SelectList(_roleService.Query().ToList(), "Id", "Name");
            return View(user);
        }

        [Authorize(Roles = "admin")]
        public IActionResult Delete(int id)
        {
            UserModel user = _userService.Query().SingleOrDefault(u => u.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

		[HttpPost, ActionName("Delete"), ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public IActionResult DeleteConfirmed(int id)
        {
            var result = _userService.DeleteUser(id);
			
            TempData["Message"] = result.Message;
			 
            return RedirectToAction(nameof(GetList));
        }
    }
}
