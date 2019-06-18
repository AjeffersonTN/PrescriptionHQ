﻿using System;
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
            var customerList = _context.Prescription
              .Include(p => p.User)
              .Where(p => p.UserId != null);

            return View(await customerList.ToListAsync());
            //return View(await _context.Prescription.ToListAsync());
        }


        // GET: Prescriptions
        [Authorize(Roles = "Pharmacy,Doctor")]
        public async Task<IActionResult> PharmacyRequest()
        {
            var customerList = _context.Prescription
               .Include(p => p.User)
               .Where(p => p.UserId != null);

            return View(await customerList.ToListAsync());
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
             .Include(p => p.User)
             .Where(p => p.UserId != null)
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
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "FullName");

            return View();
        }

        //Get: Prescriptions for the member view 
        
        [Authorize]
        public async Task<IActionResult> GetActivePrescriptions()
        {

            var user = await GetCurrentUserAsync();      
            

            return View(await _context.Prescription.Where(p => p.UserId == user.Id).ToListAsync());
           
        }


        //Get: Pharmacy vault get customer list and prescriptions 
        [Authorize]
        public async Task<IActionResult> PharmacyVault()
        {
            var customerList = _context.Prescription
                .Include(p => p.User)                
                .Where(p => p.UserId != null);

            return View(await customerList.ToListAsync());

        }


        // POST: Prescriptions/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PrescriptionId,Drug,Dosage,Quantity,Frequency,DatePrescribed,DateFilled,SpecialInstructions,Refills,UserId,PatientName,RefillRequested")] Prescription prescription)
        {
            if (ModelState.IsValid)
            {
                _context.Add(prescription);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "FullName", prescription.UserId);
            return View(prescription);
        }

 
         // GET: Prescriptions/Create
        [Authorize(Roles = "Pharmacy,Doctor")]
        public IActionResult CreateRequest()
        {
            ViewData["PatientName"] = new SelectList(_context.Users, "FullName", "FullName");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateRequest([Bind("PrescriptionId,Drug,Dosage,Quantity,Frequency,DatePrescribed,DateFilled,SpecialInstructions,Refills,UserId,RoleId,PatientName,RefillRequested")] Prescription prescription)
        {
            if (ModelState.IsValid)
            {
                _context.Add(prescription);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["UserId"] = new SelectList(_context.Users, "Id", "FullName", prescription.User);
            return View(prescription);
        }
        //Capture current user refill request information and send to list

        public async Task<IActionResult> RefillStatus(int? id)
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

            ViewData["UserId"] = new SelectList(_context.Users, "Id", "FullName");

            return View(prescription);

        }
        //post user changes
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RefillStatus(int id, [Bind("PrescriptionId,Drug,Dosage,Quantity,Frequency,DatePrescribed,DateFilled,SpecialInstructions,Refills,UserId,PatientName,RefillRequested")] Prescription prescription)
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
                return RedirectToAction(nameof(GetActivePrescriptions));
            }
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "FullName", prescription.UserId);
            return View(prescription);
        }


        //[Authorize(Roles = "Pharmacy,Doctor")]
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

            ViewData["UserId"] = new SelectList(_context.Users, "Id", "FullName");

            return View(prescription);
        }

        // POST: Prescriptions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PrescriptionId,Drug,Dosage,Quantity,Frequency,DatePrescribed,DateFilled,SpecialInstructions,Refills,UserId,PatientName")] Prescription prescription)
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
                return RedirectToAction(nameof(PharmacyRequest));
            }
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "FullName", prescription.UserId);
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
