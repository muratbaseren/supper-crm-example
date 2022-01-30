using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SupperCRMExample.Entities;
using SupperCRMExample.Models;
using SupperCRMExample.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SupperCRMExample.WebApp.Controllers
{
    public class CustomersController : ControllerBase
    {
        private readonly IClientService _clientService;

        public CustomersController(IClientService clientService)
        {
            _clientService = clientService;
        }


        // GET: CustomersController
        public ActionResult Index(string search = "")
        {
            List<Client> clients = null;

            if (string.IsNullOrEmpty(search) || string.IsNullOrWhiteSpace(search))
            {
                clients = _clientService.List();
            }
            else
            {
                clients = _clientService.ListBySearch(search);
                ViewData["search"] = search;
            }

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

        // POST: CustomersController/Delete/5
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            AjaxResponseModel<string> response = new AjaxResponseModel<string>();

            try
            {
                _clientService.Delete(id);
                response.Success = "Müşteri silindi.";
            }
            catch (Exception ex)
            {
                response.AddError("ex", ex.Message);
            }

            return Json(response);
        }
    }
}
