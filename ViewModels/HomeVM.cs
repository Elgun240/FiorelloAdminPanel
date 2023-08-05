using Fiorello2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiorello2.ViewModels
{
    public class HomeVM
    {
        public Slider Sliders { get; set; }
        public List<Expert> Experts { get; set; }
        public List<SliderImage> SliderImages { get; set; }
        public List<Category> Categories { get; set; }
        public List<Product> Products { get; set; }
        public List<Blog> Blogs { get; set; }
        
    }
}
