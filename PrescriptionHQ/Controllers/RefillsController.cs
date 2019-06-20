using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PrescriptionHQ.Data;
using PrescriptionHQ.Models;

namespace PrescriptionHQ.Controllers
{
    public class RefillsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RefillsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Refills
        public async Task<IActionResult> Index()
        {
            return View(await _context.Refill.ToListAsync());
        }

        // GET: Refills/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var refill = await _context.Refill
                .FirstOrDefaultAsync(m => m.RefillId == id);
            if (refill == null)
            {
                return NotFound();
            }

            return View(refill);
        }

        // GET: Refills/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Refills/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RefillId,RequestDate,PickupStatus")] Refill refill)
        {
            //create a new prescription based off the information selected. send that object to the refills list and display message stating refill has ben sent
            if (ModelState.IsValid)
            {
                _context.Add(refill);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(refill);
        }

        // GET: Refills/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var refill = await _context.Refill.FindAsync(id);
            if (refill == null)
            {
                return NotFound();
            }
            return View(refill);
        }

        // POST: Refills/Edit/5
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
                    if (!RefillExists(prescription.PrescriptionId))
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
            return View(prescription);
        }

        // GET: Refills/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var refill = await _context.Refill
                .FirstOrDefaultAsync(m => m.RefillId == id);
            if (refill == null)
            {
                return NotFound();
            }

            return View(refill);
        }

        // POST: Refills/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var refill = await _context.Refill.FindAsync(id);
            _context.Refill.Remove(refill);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RefillExists(int id)
        {
            return _context.Refill.Any(e => e.RefillId == id);
        }
    }
}
