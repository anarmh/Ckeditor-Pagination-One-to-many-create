using System.ComponentModel.DataAnnotations;

namespace Fiorello_backend.Areas.Admin.ViewModels.Category
{
    public class CategoryCreateVM
    {
        [Required]
        public string Name { get; set; }
    }
}
