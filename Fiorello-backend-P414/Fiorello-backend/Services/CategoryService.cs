using Fiorello_backend.Data;
using Fiorello_backend.Models;
using Fiorello_backend.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Fiorello_backend.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly AppDbContext _context;

        public CategoryService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Category>> GetAll()
        {
            return await _context.Categories.ToListAsync();
        }
    }
}
