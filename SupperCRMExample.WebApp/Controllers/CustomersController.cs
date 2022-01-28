using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SupperCRMExample.Entities;
using SupperCRMExample.Models;
using SupperCRMExample.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SupperCRMExample.WebApp.Controllers
{
    public class CustomersController : Controller
    {
        private readonly IClientService _clientService;

        public CustomersController(IClientService clientService)
        {
            _clientService = clientService;
        }


        // GET: CustomersController
        public ActionResult Index()
        {
            var clients = _clientService.List();
            return View(clients);
        }

        // GET: CustomersController/Details/5
        public ActionResult Details(int id)
        {
            var client = _clientService.GetById(id);
            return Json(new AjaxResponseModel<Client> { Data = client });
        }

        // GET: CustomersController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CustomersController/Create
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Create(CreateCustomerModel model)
        {
            AjaxResponseModel<string> response = new AjaxResponseModel<string>();

            if (ModelState.IsValid)
            {
                _clientService.Create(model);

                response.Success = "Müşteri eklendi.";
                return Json(response);
            }

            AddModelStateErrorsToAjaxResponse(response);

            return Json(response);
        }

        private void AddModelStateErrorsToAjaxResponse(AjaxResponseModel<string> response)
        {
            foreach (var key in ModelState.Keys)
            {
                var item = ModelState.GetValueOrDefault(key);

                if (item != null && item.Errors.Count > 0)
                {
                    item.Errors.ToList().ForEach(err => response.AddError(key, err.ErrorMessage));
                }
            }
        }

        // GET: CustomersController/Edit/5
        public ActionResult Edit(int id)
        {
            var client = _clientService.GetById(id);
            return Json(new AjaxResponseModel<Client> { Data = client });
        }

        // POST: Customers/Edit/5
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Edit(int id, EditCustomerModel model)
        {
            AjaxResponseModel<string> response = new AjaxResponseModel<string>();

            if (ModelState.IsValid)
            {
                _clientService.Update(id, model);

                response.Success = "Müşteri güncellendi.";
                return Json(response);
            }

            AddModelStateErrorsToAjaxResponse(response);

            return Json(response);
        }

        // GET: CustomersController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CustomersController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
