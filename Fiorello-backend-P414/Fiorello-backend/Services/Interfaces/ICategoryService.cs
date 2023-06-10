using Fiorello_backend.Models;

namespace Fiorello_backend.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<List<Category>> GetAll();
    }
}
