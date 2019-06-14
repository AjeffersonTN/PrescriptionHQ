using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PrescriptionHQ.Data;
using PrescriptionHQ.Models;

namespace PrescriptionHQ.Controllers
{
    public class PrescriptionsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;
        private readonly object p;

        public PrescriptionsController(ApplicationDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        private Task<User> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

        [Authorize(Roles = "Pharmacy,Doctor")]
        
        // GET: Prescriptions
        public async Task<IActionResult> Index()
        {
            return View(await _context.Prescription.ToListAsync());
        }
        [Authorize(Roles = "Pharmacy,Doctor,Member")]
        // GET: Prescriptions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prescription = await _context.Prescription
                .FirstOrDefaultAsync(m => m.PrescriptionId == id);
            if (prescription == null)
            {
                return NotFound();
            }

            return View(prescription);
        }
        [Authorize(Roles = "Pharmacy,Doctor")]
        // GET: Prescriptions/Create
        public IActionResult Create()
        {
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        //Get: Prescriptions for the member view
        
        [Authorize]
        public async Task<IActionResult> GetActivePrescriptions()
        {

            var user = await GetCurrentUserAsync();
            //var applicationDbContext = _context.Prescription
                    //.Include(p => p.Drug)
                    //.Include(p => p.Dosage)
                    //.Include(p => p.Quantity)
                    //.Include(p => p.Frequency)
                    //.Include(p => p.Refills)
                    //.Include(p => p.DateFilled)
                    //.Include(p => p.DatePrescribed)
                    //.Include(p => p.SpecialInstructions)
                    //.Where(p => p.UserId == user.Id);

            return View(await _context.Prescription.Where(p => p.UserId == user.Id).ToListAsync());
            //return View(await applicationDbContext.ToListAsync());
        }


        // POST: Prescriptions/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PrescriptionId,Drug,Dosage,Quantity,Frequency,DatePrescribed,DateFilled,SpecialInstructions,Refills, UserId")] Prescription prescription)
        {
            if (ModelState.IsValid)
            {
                _context.Add(prescription);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", prescription.UserId);
            return View(prescription);
        }
        [Authorize(Roles = "Pharmacy,Doctor")]
        // GET: Prescriptions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prescription = await _context.Prescription.FindAsync(id);
            if (prescription == null)
            {
                return NotFound();
            }

            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id");

            return View(prescription);
        }

        // POST: Prescriptions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PrescriptionId,Drug,Dosage,Quantity,Frequency,DatePrescribed,DateFilled,SpecialInstructions,Refills, UserId")] Prescription prescription)
        {
            if (id != prescription.PrescriptionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(prescription);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PrescriptionExists(prescription.PrescriptionId))
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
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", prescription.UserId);
            return View(prescription);
        }
        [Authorize(Roles = "Pharmacy,Doctor")]
        // GET: Prescriptions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prescription = await _context.Prescription
                .FirstOrDefaultAsync(m => m.PrescriptionId == id);
            if (prescription == null)
            {
                return NotFound();
            }

            return View(prescription);
        }

        // POST: Prescriptions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var prescription = await _context.Prescription.FindAsync(id);
            _context.Prescription.Remove(prescription);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PrescriptionExists(int id)
        {
            return _context.Prescription.Any(e => e.PrescriptionId == id);
        }
    }
}
