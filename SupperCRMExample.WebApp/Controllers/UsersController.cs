using Microsoft.AspNetCore.Mvc;
using SupperCRMExample.Entities;
using SupperCRMExample.Models;
using SupperCRMExample.Services;
using System;
using System.Collections.Generic;

namespace SupperCRMExample.WebApp.Controllers
{
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }


        // GET: Users
        public ActionResult Index(string search = "")
        {
            List<User> users = null;

            if (string.IsNullOrEmpty(search) || string.IsNullOrWhiteSpace(search))
            {
                users = _userService.List();
            }
            else
            {
                users = _userService.ListBySearch(search);
                ViewData["search"] = search;
            }

            return View(users);
        }

        // GET: Users/Details/5
        public ActionResult Details(int id)
        {
            var user = _userService.GetById(id);
            return Json(new AjaxResponseModel<User> { Data = user });
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        [HttpPost]
        public ActionResult Create(CreateUserModel model)
        {
            AjaxResponseModel<string> response = new AjaxResponseModel<string>();

            if (ModelState.IsValid)
            {
                try
                {
                    _userService.Create(model);

                    response.Success = "Kullanıcı eklendi.";
                    return Json(response);
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(nameof(model.Username), ex.Message);
                }
            }

            AddModelStateErrorsToAjaxResponse(response);

            return Json(response);
        }

        // GET: Users/Edit/5
        public ActionResult Edit(int id)
        {
            var user = _userService.GetById(id);
            return Json(new AjaxResponseModel<User> { Data = user });
        }

        // POST: Customers/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, EditUserModel model)
        {
            AjaxResponseModel<string> response = new AjaxResponseModel<string>();

            if (ModelState.IsValid)
            {
                _userService.Update(id, model);

                response.Success = "Kullanıcı güncellendi.";
                return Json(response);
            }

            AddModelStateErrorsToAjaxResponse(response);

            return Json(response);
        }

        // POST: Customers/ChangeUsername/5
        [HttpPost]
        public ActionResult ChangeUsername(int id, ChangeUsernameModel model)
        {
            AjaxResponseModel<string> response = new AjaxResponseModel<string>();

            if (ModelState.IsValid)
            {
                try
                {
                    _userService.ChangeUsername(id, model);

                    response.Success = "Kullanıcı adı değişitirildi.";
                    return Json(response);
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(nameof(model.Username), ex.Message);
                }
            }

            AddModelStateErrorsToAjaxResponse(response);

            return Json(response);
        }

        // POST: Customers/ChangePassword/5
        [HttpPost]
        public ActionResult ChangePassword(int id, ChangePasswordModel model)
        {
            AjaxResponseModel<string> response = new AjaxResponseModel<string>();

            if (ModelState.IsValid)
            {
                _userService.ChangePassword(id, model);

                response.Success = "Kullanıcı şifre değiştirildi.";
                return Json(response);
            }

            AddModelStateErrorsToAjaxResponse(response);

            return Json(response);
        }

        // POST: Users/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            AjaxResponseModel<string> response = new AjaxResponseModel<string>();

            try
            {
                _userService.Delete(id);
                response.Success = "Kullanıcı silindi.";
            }
            catch (Exception ex)
            {
                response.AddError("ex", ex.Message);
            }

            return Json(response);
        }
    }
}
