using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Parcial3_AriasRoldanNatalia.DAL;
using Parcial3_AriasRoldanNatalia.DAL.Entities;

namespace Parcial3_AriasRoldanNatalia.Controllers
{
    public class VehiclesController : Controller
    {
        private readonly DataBaseContext _context;

        public VehiclesController(DataBaseContext context)
        {
            _context = context;
        }

        // GET: Vehicles
        public async Task<IActionResult> Index()
        {
              return _context.Vehicules != null ? 
                          View(await _context.Vehicules.ToListAsync()) :
                          Problem("Entity set 'DataBaseContext.Vehicules'  is null.");
        }

        // GET: Vehicles/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.Vehicules == null)
            {
                return NotFound();
            }

            var vehicles = await _context.Vehicules
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vehicles == null)
            {
                return NotFound();
            }

            return View(vehicles);
        }

        // GET: Vehicles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Vehicles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Owner,NumberPlate,Id,CreatedDate")] Vehicles vehicles)
        {
            if (ModelState.IsValid)
            {
                vehicles.Id = Guid.NewGuid();
                _context.Add(vehicles);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vehicles);
        }

        // GET: Vehicles/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.Vehicules == null)
            {
                return NotFound();
            }

            var vehicles = await _context.Vehicules.FindAsync(id);
            if (vehicles == null)
            {
                return NotFound();
            }
            return View(vehicles);
        }

        // POST: Vehicles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Owner,NumberPlate,Id,CreatedDate")] Vehicles vehicles)
        {
            if (id != vehicles.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vehicles);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VehiclesExists(vehicles.Id))
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
            return View(vehicles);
        }

        // GET: Vehicles/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.Vehicules == null)
            {
                return NotFound();
            }

            var vehicles = await _context.Vehicules
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vehicles == null)
            {
                return NotFound();
            }

            return View(vehicles);
        }

        // POST: Vehicles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.Vehicules == null)
            {
                return Problem("Entity set 'DataBaseContext.Vehicules'  is null.");
            }
            var vehicles = await _context.Vehicules.FindAsync(id);
            if (vehicles != null)
            {
                _context.Vehicules.Remove(vehicles);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VehiclesExists(Guid id)
        {
          return (_context.Vehicules?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
