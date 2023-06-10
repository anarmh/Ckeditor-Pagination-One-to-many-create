using Fiorello_backend.Data;
using Fiorello_backend.Models;
using Fiorello_backend.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Fiorello_backend.Services
{
    public class DiscountService : IDiscountService
    {
        private readonly AppDbContext _context;

        public DiscountService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Discount>> GetAll()
        {
            return await _context.Discounts.ToListAsync();
        }
    }
}
