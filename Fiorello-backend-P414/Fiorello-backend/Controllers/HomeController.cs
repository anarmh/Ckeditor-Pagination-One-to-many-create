using Fiorello_backend.Data;
using Fiorello_backend.Models;
using Fiorello_backend.Services.Interfaces;
using Fiorello_backend.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Fiorello_backend.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IProductService _productService;

        public HomeController(AppDbContext context, IProductService productService)
        {
            _context = context;
            _productService = productService;
        }


        public async Task<IActionResult> Index()
        {
           
            IEnumerable<Blog> blogs = await _context.Blogs.Where(m => !m.SoftDelete).ToListAsync();

            IEnumerable<Category> categories = await _context.Categories.Where(m => !m.SoftDelete).ToListAsync();

            IEnumerable<Product> products = await _productService.GetAllAsync();

            IEnumerable<Expert> experts = await _context.Experts.Include(m => m.Position).Where(m => !m.SoftDelete).ToListAsync();

            HomeVM model = new()
            {
                Blogs = blogs,
                Categories = categories,
                Products = products,
                Experts = experts
            };

            return View(model);
        }

    }
}