using Fiorello_backend.Models;

namespace Fiorello_backend.ViewModels
{
    public class SliderVM
    {
        public IEnumerable<Slider> Sliders { get; set; }
        public SliderInfo SliderInfo { get; set; }
    }
}
