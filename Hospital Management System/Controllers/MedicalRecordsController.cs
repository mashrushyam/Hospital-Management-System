using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Hospital_Management_System.Data;
using Hospital_Management_System.Models;

namespace Hospital_Management_System.Controllers
{
    public class MedicalRecordsController : Controller
    {
        private readonly ApplicationDBContext _context;

        public MedicalRecordsController(ApplicationDBContext context)
        {
            _context = context;
        }

        // GET: MedicalRecords
        public async Task<IActionResult> Index()
        {
            var applicationDBContext = _context.MedicalRecords.Include(m => m.Doctors).Include(m => m.Patient);
            return View(await applicationDBContext.ToListAsync());
        }

        // GET: MedicalRecords/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medicalRecords = await _context.MedicalRecords
                .Include(m => m.Doctors)
                .Include(m => m.Patient)
                .FirstOrDefaultAsync(m => m.RecordId == id);
            if (medicalRecords == null)
            {
                return NotFound();
            }

            return View(medicalRecords);
        }

        // GET: MedicalRecords/Create
        public IActionResult Create()
        {
            ViewData["DoctorId"] = new SelectList(_context.Doctors, "DoctorId", "DoctorId");
            ViewData["PatientId"] = new SelectList(_context.Patients, "PatientId", "PatientId");
            return View();
        }

        // POST: MedicalRecords/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RecordId,PatientId,DoctorId,Diagnosis,Prescription,TreatmentDetails,TestResult,RecordDate")] MedicalRecords medicalRecords)
        {
            if (ModelState.IsValid)
            {
                _context.Add(medicalRecords);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DoctorId"] = new SelectList(_context.Doctors, "DoctorId", "DoctorId", medicalRecords.DoctorId);
            ViewData["PatientId"] = new SelectList(_context.Patients, "PatientId", "PatientId", medicalRecords.PatientId);
            return View(medicalRecords);
        }

        // GET: MedicalRecords/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medicalRecords = await _context.MedicalRecords.FindAsync(id);
            if (medicalRecords == null)
            {
                return NotFound();
            }
            ViewData["DoctorId"] = new SelectList(_context.Doctors, "DoctorId", "DoctorId", medicalRecords.DoctorId);
            ViewData["PatientId"] = new SelectList(_context.Patients, "PatientId", "PatientId", medicalRecords.PatientId);
            return View(medicalRecords);
        }

        // POST: MedicalRecords/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RecordId,PatientId,DoctorId,Diagnosis,Prescription,TreatmentDetails,TestResult,RecordDate")] MedicalRecords medicalRecords)
        {
            if (id != medicalRecords.RecordId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(medicalRecords);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MedicalRecordsExists(medicalRecords.RecordId))
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
            ViewData["DoctorId"] = new SelectList(_context.Doctors, "DoctorId", "DoctorId", medicalRecords.DoctorId);
            ViewData["PatientId"] = new SelectList(_context.Patients, "PatientId", "PatientId", medicalRecords.PatientId);
            return View(medicalRecords);
        }

        // GET: MedicalRecords/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medicalRecords = await _context.MedicalRecords
                .Include(m => m.Doctors)
                .Include(m => m.Patient)
                .FirstOrDefaultAsync(m => m.RecordId == id);
            if (medicalRecords == null)
            {
                return NotFound();
            }

            return View(medicalRecords);
        }

        // POST: MedicalRecords/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var medicalRecords = await _context.MedicalRecords.FindAsync(id);
            if (medicalRecords != null)
            {
                _context.MedicalRecords.Remove(medicalRecords);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MedicalRecordsExists(int id)
        {
            return _context.MedicalRecords.Any(e => e.RecordId == id);
        }
    }
}
