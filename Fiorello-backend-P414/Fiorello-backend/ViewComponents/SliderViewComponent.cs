using Fiorello_backend.Data;
using Fiorello_backend.Models;
using Fiorello_backend.Services.Interfaces;
using Fiorello_backend.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Fiorello_backend.ViewComponents
{
    public class SliderViewComponent : ViewComponent
    {
        private readonly AppDbContext _context;
        private readonly ISliderService _sliderService;

        public SliderViewComponent(AppDbContext context, ISliderService sliderService)
        {
            _context = context;
            _sliderService = sliderService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            IEnumerable<Slider> sliders = await _sliderService.GetAllByStatusAsync();
            SliderInfo sliderInfo = await _context.SliderInfos.Where(m => !m.SoftDelete).FirstOrDefaultAsync();
            SliderVM model = new()
            {
                Sliders = sliders,
                SliderInfo = sliderInfo
            };

            return await Task.FromResult(View(model));
        }
    }
}
