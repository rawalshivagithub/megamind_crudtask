using MegaMinds_CrudTask.DataContext;
using MegaMinds_CrudTask.Models;
using MegaMinds_CrudTask.Service.IDetailsInterface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace MegaMinds_CrudTask.Controllers
{
    public class DetailsController : Controller
    {
        private readonly IDetailsService _detailsService;
        private readonly DataContextClass _dataContext;

        public DetailsController(IDetailsService detailsService, DataContextClass dataContext)
        {
            _detailsService = detailsService;
            _dataContext = dataContext;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _detailsService.GetDetailsList();
            return View(data);
        }

        [HttpGet]
        public async Task<IActionResult> Create(int Id, Details details)
        {

            ViewBag.states = (from u in _dataContext.State select new SelectListItem { Value = u.StateId.ToString(), Text = u.StateName }).ToList();

            ViewBag.cities = (from t in _dataContext.City select new SelectListItem { Value = t.CityId.ToString(), Text = t.CityName }).ToList();

            var model = await _detailsService.GetDetailsById(Id, details);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Details details)
        {
            await _detailsService.AddDetails(details);
            return RedirectToAction("Index", details);
        }

        [HttpGet]
        public async Task<IActionResult> Update(int Id, Details details)
        {
            var data = await _detailsService.GetDetailsById(Id, details);
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
