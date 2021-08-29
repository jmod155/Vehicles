using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Vehicles.Api.Data;
using Vehicles.Api.Data.Entities;

namespace Vehicles.Api.Controllers
{
    public class VehiclesTypesController : Controller
    {
        private readonly DataContext _context;

        public VehiclesTypesController(DataContext context)
        {
            _context = context;
        }

        // GET: VehiclesTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.VehiclesType.ToListAsync());
        }

        // GET: VehiclesTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehiclesType = await _context.VehiclesType
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vehiclesType == null)
            {
                return NotFound();
            }

            return View(vehiclesType);
        }

        // GET: VehiclesTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: VehiclesTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Description")] VehiclesType vehiclesType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vehiclesType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vehiclesType);
        }

        // GET: VehiclesTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehiclesType = await _context.VehiclesType.FindAsync(id);
            if (vehiclesType == null)
            {
                return NotFound();
            }
            return View(vehiclesType);
        }

        // POST: VehiclesTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Description")] VehiclesType vehiclesType)
        {
            if (id != vehiclesType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vehiclesType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VehiclesTypeExists(vehiclesType.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(vehiclesType);
        }

        // GET: VehiclesTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehiclesType = await _context.VehiclesType
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vehiclesType == null)
            {
                return NotFound();
            }

            return View(vehiclesType);
        }

        // POST: VehiclesTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vehiclesType = await _context.VehiclesType.FindAsync(id);
            _context.VehiclesType.Remove(vehiclesType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VehiclesTypeExists(int id)
        {
            return _context.VehiclesType.Any(e => e.Id == id);
        }
    }
}
