using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SupperCRMExample.Common;
using SupperCRMExample.Entities;
using SupperCRMExample.Models;
using SupperCRMExample.Services;
using System.Collections.Generic;

namespace SupperCRMExample.WebApp.Controllers
{
    public class NotifyController : ControllerBase
    {
        private readonly INotifyService _notifyService;

        public NotifyController(INotifyService notifyService)
        {
            _notifyService = notifyService;
        }

        // GET: Notify
        public ActionResult Index(string search = "")
        {
            List<Notify> notifies = null;

            int userid = HttpContext.Session.GetInt32(Constants.Session_Id).Value;

            if (string.IsNullOrEmpty(search) || string.IsNullOrWhiteSpace(search))
            {
                notifies = _notifyService.ListByUserId(userid, null);
            }
            else
            {
                notifies = _notifyService.ListBySearch(search, userid);
                ViewData["search"] = search;
            }

            return View(notifies);
        }

        // GET: Notify/Edit/5
        public ActionResult Edit(int id, bool read)
        {
            AjaxResponseModel<string> response = new AjaxResponseModel<string>();

            _notifyService.Update(id, read);

            response.Success = "Bildirim güncellendi.";
            return Json(response);
        }
    }
}
