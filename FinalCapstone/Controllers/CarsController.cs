 using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FinalCapstone.Services;
using Microsoft.AspNetCore.Http;

namespace FinalCapstone.Models
{
    public class CarsController : Controller
    {
        private readonly ICarsService _service;


        public CarsController(ICarsService service)
        {
            _service = service;
        }


        public async Task<IActionResult> Index()
        {
            var model = await _service.GetAll();
            return View(model);
        }


        public async Task<ActionResult> Details(int id)
        {
            var model = await _service.Get(id);

            return View(model);
        }

   
        public ActionResult Search()
        {
            return View();
        }

        public async Task<ActionResult> SearchResults([Bind("Make, Model, Year, Color")] Car car)
        {
            if (ModelState.IsValid)
            {
                var model = await _service.Search(car);
                return View(model); 

            }

            return RedirectToAction(nameof(Search));

        }
       

        public ActionResult Create()
        {
            return View();
        }
 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind("Make, Model, Year, Color")] Car car)
        {
            if (ModelState.IsValid)
            {
                await _service.Create(car);
                return RedirectToAction(nameof(Index));
            }

            return View();
        }

  
        public async Task<ActionResult> Edit(int id)
        {
            var model = await _service.Get(id);
            return View(model);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Car car)
        {
            if (ModelState.IsValid)
            {
                await _service.Edit(id, car);
                return RedirectToAction(nameof(Index));
            }

            return View();

        }


        public async Task<ActionResult> Delete(int id)
        {
            var model = await _service.Get(id);
            return View(model);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, IFormCollection collection)
        {
            try
            {
                await _service.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }


}





