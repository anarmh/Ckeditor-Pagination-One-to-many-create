using Fiorello_backend.Models;
using Fiorello_backend.Responses;
using Fiorello_backend.ViewModels;

namespace Fiorello_backend.Services.Interfaces
{
    public interface IBasketService
    {
        List<BasketVM> GetAll();
        void AddProduct(List<BasketVM> basket, Product product);
        Task<BasketDeleteResponse> DeleteProduct(int? id);
        int GetCount();
    }
}
