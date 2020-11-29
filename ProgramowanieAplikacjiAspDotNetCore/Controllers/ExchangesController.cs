using System.Linq;
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
            var items = _context.Items.ToList();
            return View(items);
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

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var item = _context.Items.FirstOrDefault(i => i.Id == id);

            if (item == null)
            {
                return NotFound();
            }

            _context.Items.Remove(item);
            _context.SaveChanges();

            return RedirectToAction("Show");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var item = _context.Items.FirstOrDefault(i => i.Id == id);

            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }

        [HttpPost]
        public IActionResult Edit(ItemEntity itemEntity)
        {
            _context.Items.Update(itemEntity);
            _context.SaveChanges();
            return RedirectToAction("Show");
        }
    }
}
