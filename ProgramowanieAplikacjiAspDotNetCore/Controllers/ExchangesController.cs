using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProgramowanieAplikacjiAspDotNetCore.Models;

namespace ProgramowanieAplikacjiAspDotNetCore.Controllers
{
    public class ExchangesController : Controller
    {
        public IActionResult Show()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(ItemModel itemModel)
        {

            var viewModel = new AddNewItemConfirmationModel
            {
                Id = 1,
                Name = itemModel.Name
            };
            return RedirectToAction("AddConfirmation");
        }

        public IActionResult AddConfirmation()
        {
            return View();
        }
    }
}
