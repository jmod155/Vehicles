using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vehicles.Api.Data;
using Vehicles.Api.Data.Entities;

namespace Vehicles.Api.Controllers
{
   
    [Authorize(Roles = "Admin")]
    public class ProceduresController : Controller
    {
        private readonly DataContext _context;
        public ProceduresController(DataContext context)
        {
            _context = context;

        }


        public async Task<IActionResult> Index()
        {
            return View(await _context.Procedures.ToListAsync());
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
        public async Task<IActionResult> Create(Procedure procedure)//[Bind("Id,Description")]  se puede quitar
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Add(procedure);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException dbUpdateException)
                {   //validacion en caso de un duplicado
                    if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                    {
                        ModelState.AddModelError(string.Empty, "Ya exixte este tipo de procedimiento");
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
            return View(procedure);
        }

        // GET: VehiclesTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Procedure procedure = await _context.Procedures.FindAsync(id);
            if (procedure == null)
            {
                return NotFound();
            }
            return View(procedure);
        }

        // POST: VehiclesTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Procedure procedure)//se quita [Bind("Id,Description")] 
        {
            if (id != procedure.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(procedure);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException dbUpdateException)
                {   //validacion en caso de un duplicado
                    if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                    {
                        ModelState.AddModelError(string.Empty, "Ya exixte este procedimiento");
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
            return View(procedure);
        }

        // GET: VehiclesTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Procedure procedure = await _context.Procedures
                .FirstOrDefaultAsync(m => m.Id == id);
            if (procedure == null)
            {
                return NotFound();
            }

            _context.Procedures.Remove(procedure);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}

