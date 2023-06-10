using System.ComponentModel.DataAnnotations;

namespace Fiorello_backend.Areas.Admin.ViewModels.Slider
{
    public class SliderCreateVM
    {
        [Required]
        public List<IFormFile> Images { get; set; }
    }
}
