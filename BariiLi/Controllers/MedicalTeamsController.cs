﻿using System;
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
    public class MedicalTeamsController : Controller
    {
        private readonly BariiLiContext _context;

        public MedicalTeamsController(BariiLiContext context)
        {
            _context = context;
        }

        // GET: MedicalTeams
        public async Task<IActionResult> Index()
        {
            return View(await _context.MedicalTeam.ToListAsync());
        }

        // GET: MedicalTeams/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medicalTeam = await _context.MedicalTeam
                .FirstOrDefaultAsync(m => m.MTId == id);
            if (medicalTeam == null)
            {
                return NotFound();
            }

            return View(medicalTeam);
        }

        // GET: MedicalTeams/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MedicalTeams/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MTId,fullName,gender,specialization,availability,location,previousExprience")] MedicalTeam medicalTeam)
        {
            if (ModelState.IsValid)
            {
                _context.Add(medicalTeam);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(medicalTeam);
        }

        // GET: MedicalTeams/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medicalTeam = await _context.MedicalTeam.FindAsync(id);
            if (medicalTeam == null)
            {
                return NotFound();
            }
            return View(medicalTeam);
        }

        // POST: MedicalTeams/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("MTId,fullName,gender,specialization,availability,location,previousExprience")] MedicalTeam medicalTeam)
        {
            if (id != medicalTeam.MTId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(medicalTeam);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MedicalTeamExists(medicalTeam.MTId))
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
            return View(medicalTeam);
        }

        // GET: MedicalTeams/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medicalTeam = await _context.MedicalTeam
                .FirstOrDefaultAsync(m => m.MTId == id);
            if (medicalTeam == null)
            {
                return NotFound();
            }

            return View(medicalTeam);
        }

        // POST: MedicalTeams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var medicalTeam = await _context.MedicalTeam.FindAsync(id);
            _context.MedicalTeam.Remove(medicalTeam);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MedicalTeamExists(string id)
        {
            return _context.MedicalTeam.Any(e => e.MTId == id);
        }
    }
}
