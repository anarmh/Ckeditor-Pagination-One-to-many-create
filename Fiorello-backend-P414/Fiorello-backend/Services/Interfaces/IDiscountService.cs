using Fiorello_backend.Models;

namespace Fiorello_backend.Services.Interfaces
{
    public interface IDiscountService
    {
        Task<List<Discount>> GetAll();
    }
}
