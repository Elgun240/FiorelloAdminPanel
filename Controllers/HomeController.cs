using Fiorello2.DAL;
using Fiorello2.Models;
using Fiorello2.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Fiorello2.Controllers
{
    public class HomeController : Controller
    {

        private readonly AppDbContext _db;
        public HomeController(AppDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            HomeVM homeVM = new HomeVM {

                Sliders = _db.Sliders.FirstOrDefault(),
                Experts=_db.Experts.ToList(),
                SliderImages=_db.SliderImages.Where(x=>x.IsDeactive==false).ToList(),
                Products=_db.Prodcuts.OrderByDescending(x=>x).Take(8).ToList(),
                Categories=_db.Categories.Where(x => x.IsDeactive == false).ToList(),
                Blogs=_db.Blogs.ToList(),

            };
            

            return View(homeVM);
            
        }

        

        
        public IActionResult Error()
        {
            return View();
        }
    }
}
