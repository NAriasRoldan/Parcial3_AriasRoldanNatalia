using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Parcial3_AriasRoldanNatalia.DAL;
using Parcial3_AriasRoldanNatalia.DAL.Entities;
using Parcial3_AriasRoldanNatalia.Helpers;
using Parcial3_AriasRoldanNatalia.Models;

namespace Parcial3_AriasRoldanNatalia.Controllers
{
    public class VehiclesController : Controller
    {
        private readonly DataBaseContext _context;
        private readonly IDropDownListHelper _ddlHelper;
        public VehiclesController(DataBaseContext context, IDropDownListHelper dropDownListHelper)
        {
            _context = context;
            _ddlHelper = dropDownListHelper;
        }

        // GET: Vehicles
        public async Task<IActionResult> Index()
        {
            return _context.VehiculesDetails != null ?
                        View(await _context.VehiculesDetails.Include(c => c.Vehicles).ToListAsync()) :
                        Problem("Entity set 'DataBaseContext.Vehicules'  is null.");
        }

        // GET: Vehicles/Details/5
        public async Task<IActionResult> Details()
        {
            if (_context.Vehicules == null)
            {
                return NotFound();
            }

            ICollection< VehicleDetails> VehiculesDetails = await _context.VehiculesDetails.Include(c => c.Vehicles).Include(c=> c.Vehicles.Services).ToListAsync();
            if (VehiculesDetails.IsNullOrEmpty())
            {
                return NotFound();
            }

            ICollection<EstateServiceView> estateServiceViews = new List<EstateServiceView>();

            foreach (var item in VehiculesDetails)
            {
                estateServiceViews.Add(new EstateServiceView {
                    NameService = item.Vehicles.Services.Name,
                    CreateDate = item.CreatedDate,
                    DeliveryDate = item.DeliveryDate,
                    PriceService = item.Vehicles.Services.Price,
                    VehiclePlateumber = item.Vehicles.NumberPlate,
                });   
            }

            return View(estateServiceViews);
        }

        // GET: Vehicles/Create
        public async Task<IActionResult> Create()
        {
            VehicleServiceViewModel vehicleServiceViewModel = new()
            {
                Id = new Guid(),
                CreatedDate = DateTime.Now,
                Owner = "Natalia",
                listServices = await _ddlHelper.GetDDLServicesAsync(),
            };
            return View(vehicleServiceViewModel);
        }

        // POST: Vehicles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(VehicleServiceViewModel vehicleServiceViewModel)
        {
            if (ModelState.IsValid)
            {
                Vehicles vehicle = new()
                {
                    Id = new Guid(),
                    CreatedDate = DateTime.Now,
                    NumberPlate = vehicleServiceViewModel.NumberPlate,
                    Owner = vehicleServiceViewModel.Owner,
                    Services = await _context.Servicies.FirstOrDefaultAsync(m => m.Id == vehicleServiceViewModel.ServiceId),
                };
                VehicleDetails vehicleDetails = new()
                {
                    Id = new Guid(),
                    Vehicles = vehicle,
                    CreatedDate = DateTime.Now,
                };
                _context.Add(vehicle);
                _context.Add(vehicleDetails);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: Vehicles/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.VehiculesDetails == null)
            {
                return NotFound();
            }

            VehicleDetails vehiclesDetails = await _context.
                VehiculesDetails.Include(c => c.Vehicles)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vehiclesDetails == null)
            {
                return NotFound();
            }

            EditDetailsVehicleView editDetailsVehicleView = new()
            {
                CreatedDate = vehiclesDetails.CreatedDate,
                Id = vehiclesDetails.Id,
                VehiclesId = vehiclesDetails.Vehicles.Id
            };
            return View(editDetailsVehicleView);
        }

        // POST: Vehicles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, EditDetailsVehicleView editDetailsVehicleView)
        {
            if (id != editDetailsVehicleView.Id)
            {
                return NotFound();
            }


            VehicleDetails vehicleDetails = new()
            {
                Id = id,
                DeliveryDate = editDetailsVehicleView.DeliveryDate,
                CreatedDate = editDetailsVehicleView.CreatedDate,
                Vehicles = await _context.Vehicules.FirstOrDefaultAsync(m => m.Id == editDetailsVehicleView.VehiclesId)
            };

            try
            {
                _context.Update(vehicleDetails);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VehiclesExists(vehicleDetails.Id))
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
