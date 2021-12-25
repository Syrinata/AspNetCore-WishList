using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WishList.Data;
using WishList.Models;

namespace WishList.Controllers
{
    public class ItemController : Controller
    {
        private readonly ApplicationDbContext _context;
        public IActionResult Index()
        {
            List<Item> items = new List<Item>();
            items.AddRange(_context.Items);
            return View("Index",items );
        }
        public ItemController(ApplicationDbContext context)
        {
            _context = context; 

        }

        [HttpGet]
        public IActionResult Create()
        {
            return View("Create");
        }
        [HttpPost]
        public IActionResult Create(Item item)
        {
            _context.Items.Add(item);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
