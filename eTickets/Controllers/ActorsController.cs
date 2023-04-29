using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using eTickets.Data;
using eTickets.Models;
using eTickets.Data.Services;

namespace eTickets.Controllers
{
    public class ActorsController : Controller
    {
        private readonly IActorsService _service;

        public ActorsController(IActorsService service)
        {
            _service = service;
        }

        // GET: Actors
        public async Task<IActionResult> Index()
        {

            var data =await _service.GetAllAsync();
            return View(data);
        }
        //Get Actores/Create
      public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind("FullName,Profile,Bio")] Actor actor)
        {
            if (!ModelState.IsValid)
            {
                return View(actor);
            }
             await _service.AddAsync(actor);
            return RedirectToAction(nameof(Index));
        }
        // Get details
        public async Task<IActionResult> Details(int id)
        {
            var ac = await _service.GetByIdAsync(id);
            if (ac == null) return View("NotFound");
            return View(ac);
           
        }
        //Get:Actors

        public async Task< IActionResult> Edit(int id)
        {

            var ac = await _service.GetByIdAsync(id);
            if (ac == null) return View("NotFound");
            return View(ac);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FullName,Profile,Bio")] Actor actor)
        {
            if (!ModelState.IsValid)
            {
                return View(actor);
            }
            await _service.UpdateAsync(id,actor);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Delete(int id)
        {

            var ac = await _service.GetByIdAsync(id);
            if (ac == null) return View("NotFound");
            return View(ac);
        }
        [HttpPost,ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ac = await _service.GetByIdAsync(id);
            if (ac == null) return View("NotFound");
            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

    }
}