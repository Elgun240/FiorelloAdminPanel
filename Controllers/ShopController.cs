using Fiorello2.DAL;
using Fiorello2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiorello2.Controllers
{
    public class ShopController : Controller
    {
        private readonly AppDbContext _db;
        public ShopController(AppDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            ViewBag.ProductCount = _db.Prodcuts.Count();
            List<Product> products = _db.Prodcuts.Where(x => x.IsDeactive == false).OrderByDescending(x=>x.Id).Take(8).ToList();
            return View(products);
        }
       
        public IActionResult LoadMore(int skip)
        {
            if (_db.Prodcuts.Count()<skip)
            {
                return Content("yeri redd ol!!");
            }
            List<Product> products = _db.Prodcuts.OrderByDescending(x => x.Id).Skip(skip).Take(8).ToList();
            return PartialView("_ProductsPartial", products);
        }
        public IActionResult Detail(int? id)
        {
            if (id == null)
            return RedirectToAction("Index");
            Product product = _db.Prodcuts.Include(x=>x.ProductDetail).FirstOrDefault(x=>x.Id==id);
            if (product == null)
                return BadRequest();
            return View(product);
        }
    }
}
