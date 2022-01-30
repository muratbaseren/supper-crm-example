using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SupperCRMExample.Common;
using SupperCRMExample.Models;
using SupperCRMExample.Services;

namespace SupperCRMExample.WebApp.Controllers
{
    public class AccountController : ControllerBase
    {
        private readonly IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(AuthenticateModel model)
        {
            AjaxResponseModel<string> response = new AjaxResponseModel<string>();

            if (ModelState.IsValid)
            {
                var user = _userService.Authenticate(model);

                if (user != null)
                {
                    response.Success = "Giriş işlemi başarılı şekilde yapıldı.";

                    HttpContext.Session.SetString(Constants.Session_Name, user.Name);
                    HttpContext.Session.SetString(Constants.Session_Role, user.Role);
                    HttpContext.Session.SetInt32(Constants.Session_Id, user.Id);
                }
                else
                    response.AddError(nameof(model.Username), "Hatalı kullanıcı adı ya da şifre.");

                return Json(response);
            }

            AddModelStateErrorsToAjaxResponse(response);

            return Json(response);
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction(nameof(Login));
        }
        public IActionResult CreateFakeUser()
        {
            _userService.Create(new CreateUserModel
            {
                Name = "K. Murat Başeren",
                Email = "muratbaseren@gmail.com",
                Password = "123123",
                Locked = false,
                RePassword  ="123123",
                Role = "admin",
                Username = "muratbaseren"
            });

            return Json("ok");
        }
    }
}
