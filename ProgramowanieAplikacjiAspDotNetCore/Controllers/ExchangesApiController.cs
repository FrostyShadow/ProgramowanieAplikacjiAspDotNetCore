using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspDotNetAppsProgramming.Models;

namespace AspDotNetAppsProgramming.Controllers
{
    [Route("api/exchanges")]
    [ApiController]
    public class ExchangesApiController : ControllerBase
    {
        private readonly ExchangesDbContext _context;

        public ExchangesApiController(ExchangesDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var items = _context.Items.ToList();
            return Ok(items);
        }

        [HttpPost]
        public IActionResult Add(ItemModel item)
        {
            var entity = _context.Items.Add(item.ToEntity());
            _context.SaveChanges();
            return CreatedAtAction(nameof(Add), entity.Entity);
        }

        [HttpPut]
        public IActionResult Edit(int id, [FromBody] ItemModel model)
        {
            var item = _context.Items.FirstOrDefault(i => i.Id == id);
            if (item == null) return NotFound();
            item.Name = model.Name;
            item.Description = model.Description;
            item.IsVisible = model.IsVisible;
            _context.SaveChanges();
            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var item = _context.Items.FirstOrDefault(i => i.Id == id);
            if (item == null) return NotFound();
            _context.Items.Remove(item);
            return Ok();
        }
    }
}
