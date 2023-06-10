using Fiorello_backend.Areas.Admin.ViewModels.Product;
using Fiorello_backend.Areas.Admin.ViewModels.Slider;
using Fiorello_backend.Helpers;
using Fiorello_backend.Models;
using Fiorello_backend.Services;
using Fiorello_backend.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Fiorello_backend.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ISettingService _settingService;
        private readonly IDiscountService _discountService;
        private readonly ICategoryService _categoryService;
     

        public ProductController(IProductService productService,
                                 ISettingService settingService,
                                 IDiscountService discountService,
                                 ICategoryService categoryService)
        {
            _productService = productService;
            _settingService = settingService;
            _discountService = discountService;
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int page = 1)
        {
            var settingDatas = _settingService.GetAll();
            int take =int.Parse(settingDatas["AdminProductPaginateTake"]);
            var paginatedDatas = await _productService.GetPaginatedDatasAsync(page, take);

            int pageCount = await GetCountAsync(take);

            if(page > pageCount)
            {
                return NotFound();
            }

            List<ProductVM> mappedDatas = _productService.GetMappedDatas(paginatedDatas);

            Paginate<ProductVM> result = new(mappedDatas,page, pageCount);

            return View(result);
        }

        private async Task<int> GetCountAsync(int take)
        {
            int count = await _productService.GetCountAsync();
            
            decimal result = Math.Ceiling((decimal)count / take);

            return (int)result;

        }

        [HttpGet]
        public async Task<IActionResult> Detail(int? id)
        {
            if (id is null) return BadRequest();

            Product product = await _productService.GetWithIncludesAsync((int)id);

            if (product is null) return NotFound();

            return View(_productService.GetMappedData(product));
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            await GetCategoriesAndDiscounts();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductCreateVM request)
        {
            await GetCategoriesAndDiscounts();

            if (!ModelState.IsValid)
            {
                return View();
            }

            foreach (var item in request.Images)
            {
                if (!item.CheckFileType("image/"))
                {
                    ModelState.AddModelError("Image", "Please select only image file");
                    return View();
                }


                if (item.CheckFileSize(200))
                {
                    ModelState.AddModelError("Image", "Image size must be max 200 KB");
                    return View();
                }
            }

            await _productService.CreateAsync(request);
            return RedirectToAction(nameof(Index));
        }


        private async Task GetCategoriesAndDiscounts()
        {
            ViewBag.categories = await GetCategories();
            ViewBag.discounts = await GetDiscounts();
        }




        private async Task<SelectList> GetCategories()
        {
            List<Category> categories = await _categoryService.GetAll();
            return new SelectList(categories, "Id", "Name");
        }


        private async Task<SelectList> GetDiscounts()
        {
            List<Discount> discounts = await _discountService.GetAll();
            return new SelectList(discounts, "Id", "Name");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            await _productService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
