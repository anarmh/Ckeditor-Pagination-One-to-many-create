using Fiorello_backend.Areas.Admin.ViewModels.Slider;
using Fiorello_backend.Models;

namespace Fiorello_backend.Services.Interfaces
{
    public interface ISliderService
    {
        Task<List<Slider>> GetAllAsync();
        Task<Slider> GetByIdAsync(int id);
        Task<List<SliderVM>> GetAllMappedDatasAsync();
        SliderDetailVM GetMappedData(Slider slider);
        Task CreateAsync(List<IFormFile> images);
        Task DeleteAsync(int id);
        Task EditAsync(Slider slider, IFormFile newImage);
        Task<List<Slider>> GetAllByStatusAsync();
        Task<int> GetCountAsync();
        Task<bool> ChangeStatusAsync(Slider slider);
    }
}
