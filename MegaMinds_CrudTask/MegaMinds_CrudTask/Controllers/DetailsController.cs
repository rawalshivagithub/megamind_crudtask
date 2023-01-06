using MegaMinds_CrudTask.Models;
using MegaMinds_CrudTask.Service.IDetailsInterface;
using Microsoft.AspNetCore.Mvc;

namespace MegaMinds_CrudTask.Controllers
{
    public class DetailsController : Controller
    {
        private readonly IDetailsService _detailsService;

        public DetailsController(IDetailsService detailsService)
        {
            _detailsService = detailsService;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _detailsService.GetDetailsList();
            return View(data);
        }

        [HttpGet]
        public async Task<IActionResult> Create(int Id, Details details)
        {
            var data = await _detailsService.GetDetailsById(Id, details);
            return View(data);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Details details)
        {
           await _detailsService.AddDetails(details);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Update(int Id, Details details)
        {
            var data =  await _detailsService.GetDetailsById(Id, details);
            return View(data);
        }

        [HttpPost]
        public async Task<IActionResult> Update(Details details)
        {
            var data = await _detailsService.UpdateDetails(details);
            return RedirectToAction("Index", data);
        }

        public async Task<IActionResult> Delete(int Id)
        {
            var data = await _detailsService.DeleteDetails(Id);
            return RedirectToAction("Index", data);
        }

    }
}
