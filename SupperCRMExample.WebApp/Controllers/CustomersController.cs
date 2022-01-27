using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
            return View();
        }

        // GET: CustomersController/Create
        public ActionResult Create()
        {
            return View();
        }

        // GET: CustomersController/FakeInsert
        public ActionResult FakeInsert()
        {
            CreateCustomerModel model = new CreateCustomerModel
            {
                Name = "John Doe",
                IsCorporate = false,
                Email  = "john@doe.com",
                Phone = "5556667788",
                Description = "Lorem ipsum dolor sit a met."
            };

            _clientService.Create(model);
            return RedirectToAction(nameof(Index));
        }

        // POST: CustomersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateCustomerModel model)
        {
            if (ModelState.IsValid)
            {
                _clientService.Create(model);
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        // GET: CustomersController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CustomersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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
