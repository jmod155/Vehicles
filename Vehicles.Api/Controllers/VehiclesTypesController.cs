using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
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
        public async Task<IActionResult> Create(VehiclesType vehiclesType)//[Bind("Id,Description")]  se puede quitar
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Add(vehiclesType);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException dbUpdateException)
                {   //validacion en caso de un duplicado
                    if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                    {
                        ModelState.AddModelError(string.Empty, "Ya exixte este tipo de vehiculo");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, dbUpdateException.InnerException.Message);
                    }
                }
                catch (Exception Exception)
                {
                    ModelState.AddModelError(string.Empty, Exception.Message);
                }
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

            VehiclesType vehiclesType = await _context.VehiclesType.FindAsync(id);
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
        public async Task<IActionResult> Edit(int id, VehiclesType vehiclesType)//se quita [Bind("Id,Description")] 
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
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException dbUpdateException)
                {   //validacion en caso de un duplicado
                    if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                    {
                        ModelState.AddModelError(string.Empty, "Ya exixte este tipo de vehiculo");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, dbUpdateException.InnerException.Message);
                    }
                }
                catch (Exception Exception)
                {
                    ModelState.AddModelError(string.Empty, Exception.Message);
                }

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

            VehiclesType vehiclesType = await _context.VehiclesType
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vehiclesType == null)
            {
                return NotFound();
            }

            _context.VehiclesType.Remove(vehiclesType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}
