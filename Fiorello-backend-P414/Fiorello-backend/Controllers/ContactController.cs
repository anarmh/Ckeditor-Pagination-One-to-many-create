using Fiorello_backend.Data;
using Fiorello_backend.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Fiorello_backend.Controllers
{
    public class ContactController : Controller
    {
        private readonly AppDbContext _context;

        public ContactController(AppDbContext context)
        {
            _context = context;
        }


        public async Task<IActionResult> Index()
        {
            ContactVM contactVM = new()
            {
                Experts = await _context.Experts.Include(m => m.Position).Where(m => !m.SoftDelete).ToListAsync()
            };

            return View(contactVM);
        }

        public IActionResult Test()
        {
            return View();
        }
    }
}
