using Fiorello2.DAL;
using Fiorello2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiorello2.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoriesController : Controller
    {


        private readonly AppDbContext _db;
        public CategoriesController(AppDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<Category> categories = _db.Categories.Where(x => x.IsDeactive == false).Include(x => x.Products).ToList();
            return View(categories);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Category category)
        {
            bool IsExist = _db.Categories.Any(x => x.Name == category.Name);
            if (IsExist == true)
            {
                ModelState.AddModelError("Name", "This Category is already is exist!");
                return View();
            }
            await _db.Categories.AddAsync(category);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Update(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Category category = await _db.Categories.FirstOrDefaultAsync(x => x.Id == id);
            if (category == null)
            {
                return BadRequest();
            }
            return View(category);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, Category changedCategory)
        {
            if (id == null)
            {
                return NotFound();
            }
            Category dbCategory = await _db.Categories.FirstOrDefaultAsync(x => x.Id == id);
            if (dbCategory == null)
            {
                return BadRequest();
            }
            bool IsExist = _db.Categories.Any(x => x.Name == changedCategory.Name&&x.Id!=id );
            if (IsExist == true)
            {
                ModelState.AddModelError("Name", "This Category is already is exist!");
                return View();
            }
            dbCategory.Name = changedCategory.Name;
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
            
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Category category = await _db.Categories.FirstOrDefaultAsync(x => x.Id == id);
            if (category == null)
            {
                return BadRequest();
            }
            return View(category);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public async Task<IActionResult> DeletePost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Category category = await _db.Categories.Include(x=>x.Products).FirstOrDefaultAsync(x => x.Id == id);
            if (category == null)
            {
                return BadRequest();
            }
            foreach (Product product in category.Products)
            {
                product.IsDeactive = true;
            }
            category.IsDeactive = true;
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> ReturnAllProducts()
        {
            List<Category> categories = await _db.Categories.Where(x=>x.IsDeactive==true).Include(x => x.Products).ToListAsync();
            foreach (Category cat in categories)
            {
                cat.IsDeactive = false;
                foreach (Product product in cat.Products)
                {
                    product.IsDeactive = false;
                    
                }
            }
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
