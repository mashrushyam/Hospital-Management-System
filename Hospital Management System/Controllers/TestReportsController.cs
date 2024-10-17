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
    public class TestReportsController : Controller
    {
        private readonly ApplicationDBContext _context;

        public TestReportsController(ApplicationDBContext context)
        {
            _context = context;
        }

        // GET: TestReports
        public async Task<IActionResult> Index()
        {
            var applicationDBContext = _context.TestReports.Include(t => t.MedicalRecords);
            return View(await applicationDBContext.ToListAsync());
        }

        // GET: TestReports/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var testReports = await _context.TestReports
                .Include(t => t.MedicalRecords)
                .FirstOrDefaultAsync(m => m.ReportId == id);
            if (testReports == null)
            {
                return NotFound();
            }

            return View(testReports);
        }

        // GET: TestReports/Create
        public IActionResult Create()
        {
            ViewData["RecordId"] = new SelectList(_context.MedicalRecords, "RecordId", "RecordId");
            return View();
        }

        // POST: TestReports/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ReportId,RecordId,ReportType,ReportDetails,TestDate,TestResult")] TestReports testReports)
        {
            if (ModelState.IsValid)
            {
                _context.Add(testReports);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RecordId"] = new SelectList(_context.MedicalRecords, "RecordId", "RecordId", testReports.RecordId);
            return View(testReports);
        }

        // GET: TestReports/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var testReports = await _context.TestReports.FindAsync(id);
            if (testReports == null)
            {
                return NotFound();
            }
            ViewData["RecordId"] = new SelectList(_context.MedicalRecords, "RecordId", "RecordId", testReports.RecordId);
            return View(testReports);
        }

        // POST: TestReports/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ReportId,RecordId,ReportType,ReportDetails,TestDate,TestResult")] TestReports testReports)
        {
            if (id != testReports.ReportId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(testReports);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TestReportsExists(testReports.ReportId))
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
            ViewData["RecordId"] = new SelectList(_context.MedicalRecords, "RecordId", "RecordId", testReports.RecordId);
            return View(testReports);
        }

        // GET: TestReports/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var testReports = await _context.TestReports
                .Include(t => t.MedicalRecords)
                .FirstOrDefaultAsync(m => m.ReportId == id);
            if (testReports == null)
            {
                return NotFound();
            }

            return View(testReports);
        }

        // POST: TestReports/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var testReports = await _context.TestReports.FindAsync(id);
            if (testReports != null)
            {
                _context.TestReports.Remove(testReports);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TestReportsExists(int id)
        {
            return _context.TestReports.Any(e => e.ReportId == id);
        }
    }
}
