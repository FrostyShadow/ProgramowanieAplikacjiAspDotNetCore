using AspDotNetAppsProgramming.Entities;
using AspDotNetAppsProgramming.Models;
using Microsoft.AspNetCore.Mvc;

namespace AspDotNetAppsProgramming.Controllers
{
    public class ExchangesController : Controller
    {
        private readonly ExchangesDbContext _context;

        public ExchangesController(ExchangesDbContext context)
        {
            _context = context;
        }


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

            var entity = new ItemEntity
            {
                Name = itemModel.Name,
                Description = itemModel.Description,
                IsVisible = itemModel.IsVisible
            };
            _context.Items.Add(entity);
            _context.SaveChanges();

            return RedirectToAction("AddConfirmation", new { itemId = entity.Id });
        }

        [HttpGet]
        public IActionResult AddConfirmation(int itemId)
        {
            return View(itemId);
        }
    }
}
