using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BariiLi.Data;
using BariiLi.Models;

namespace BariiLi.Controllers
{
    public class AppointmentSystemsController : Controller
    {
        private readonly BariiLiContext _context;

        public AppointmentSystemsController(BariiLiContext context)
        {
            _context = context;
        }

        // GET: AppointmentSystems
        public async Task<IActionResult> Index()
        {
            return View(await _context.AppointmentSystems.ToListAsync());
        }

        // GET: AppointmentSystems/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointmentSystems = await _context.AppointmentSystems
                .FirstOrDefaultAsync(m => m.typeOfPain == id);
            if (appointmentSystems == null)
            {
                return NotFound();
            }

            return View(appointmentSystems);
        }

        // GET: AppointmentSystems/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AppointmentSystems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("typeOfPain,MTId,patientId,availabilityQueues")] AppointmentSystems appointmentSystems)
        {
            if (ModelState.IsValid)
            {
                _context.Add(appointmentSystems);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(appointmentSystems);
        }

        // GET: AppointmentSystems/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointmentSystems = await _context.AppointmentSystems.FindAsync(id);
            if (appointmentSystems == null)
            {
                return NotFound();
            }
            return View(appointmentSystems);
        }

        // POST: AppointmentSystems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("typeOfPain,MTId,patientId,availabilityQueues")] AppointmentSystems appointmentSystems)
        {
            if (id != appointmentSystems.typeOfPain)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(appointmentSystems);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AppointmentSystemsExists(appointmentSystems.typeOfPain))
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
            return View(appointmentSystems);
        }

        // GET: AppointmentSystems/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointmentSystems = await _context.AppointmentSystems
                .FirstOrDefaultAsync(m => m.typeOfPain == id);
            if (appointmentSystems == null)
            {
                return NotFound();
            }

            return View(appointmentSystems);
        }

        // POST: AppointmentSystems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var appointmentSystems = await _context.AppointmentSystems.FindAsync(id);
            _context.AppointmentSystems.Remove(appointmentSystems);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AppointmentSystemsExists(string id)
        {
            return _context.AppointmentSystems.Any(e => e.typeOfPain == id);
        }
    }
}
