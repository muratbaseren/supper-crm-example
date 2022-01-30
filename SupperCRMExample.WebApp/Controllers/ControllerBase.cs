using Microsoft.AspNetCore.Mvc;
using SupperCRMExample.Models;
using System.Collections.Generic;
using System.Linq;

namespace SupperCRMExample.WebApp.Controllers
{
    public class ControllerBase : Controller
    {
        protected void AddModelStateErrorsToAjaxResponse(AjaxResponseModel<string> response)
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
    }
}
