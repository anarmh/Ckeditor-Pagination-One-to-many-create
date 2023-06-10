using Fiorello_backend.Areas.Admin.ViewModels.Slider;
using Fiorello_backend.Data;
using Fiorello_backend.Helpers;
using Fiorello_backend.Models;
using Fiorello_backend.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using System.IO;

namespace Fiorello_backend.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SliderController : Controller
    {
        private readonly IWebHostEnvironment _env;
        private readonly ISliderService _sliderService;

        public SliderController(IWebHostEnvironment env, ISliderService sliderService)
        {
            _env = env;
            _sliderService = sliderService;
        }

        [HttpGet]
        public async Task<IActionResult> Index() => View(await _sliderService.GetAllMappedDatasAsync());

        [HttpGet]
        public async Task<IActionResult> Detail(int? id)
        {
            if (id is null) return BadRequest();

            Slider dbSlider = await _sliderService.GetByIdAsync((int)id);

            if (dbSlider is null) return NotFound();

            return View(_sliderService.GetMappedData(dbSlider));
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SliderCreateVM request)
        {
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

            await _sliderService.CreateAsync(request.Images);

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await _sliderService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id is null) return BadRequest();

            Slider dbSlider = await _sliderService.GetByIdAsync((int)id);

            if (dbSlider is null) return NotFound();

            return View(new SliderEditVM { Image = dbSlider.Image });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, SliderEditVM request)
        {
            if (id is null) return BadRequest();

            Slider dbSlider = await _sliderService.GetByIdAsync((int)id);

            if (dbSlider is null) return NotFound();

            if(request.NewImage is null) return RedirectToAction(nameof(Index));

            if (!request.NewImage.CheckFileType("image/"))
            {
                ModelState.AddModelError("NewImage", "Please select only image file");
                request.Image = dbSlider.Image;
                return View(request);
            }


            if (request.NewImage.CheckFileSize(200))
            {
                ModelState.AddModelError("NewImage", "Image size must be max 200 KB");
                request.Image = dbSlider.Image;
                return View(request);
            }

            await _sliderService.EditAsync(dbSlider, request.NewImage);

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> ChangeStatus(int? id)
        {
            if (id == null) return BadRequest();

            Slider slider = await _sliderService.GetByIdAsync((int)id);

            if(slider is null) return NotFound();
           
            return Ok(await _sliderService.ChangeStatusAsync(slider));
        }
    }
}
