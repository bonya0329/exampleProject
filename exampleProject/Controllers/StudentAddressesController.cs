using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using exampleProject.Data;
using exampleProject.Models;

namespace exampleProject.Controllers
{
    public class StudentAddressesController : Controller
    {
        private readonly MyDBContext _context;

        public StudentAddressesController(MyDBContext context)
        {
            _context = context;
        }

        // GET: StudentAddresses
        public async Task<IActionResult> Index()
        {
            var myDBContext = _context.StudentAddress.Include(s => s.Student);
            return View(await myDBContext.ToListAsync());
        }

        // GET: StudentAddresses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentAddress = await _context.StudentAddress
                .Include(s => s.Student)
                .FirstOrDefaultAsync(m => m.StudentID == id);
            if (studentAddress == null)
            {
                return NotFound();
            }

            return View(studentAddress);
        }

        // GET: StudentAddresses/Create
        public IActionResult Create()
        {
            ViewData["StudentID"] = new SelectList(_context.Student, "StudentID", "StudentID");
            return View();
        }

        // POST: StudentAddresses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StudentID,Address,City,Country")] StudentAddress studentAddress)
        {
            if (ModelState.IsValid)
            {
                _context.Add(studentAddress);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["StudentID"] = new SelectList(_context.Student, "StudentID", "StudentID", studentAddress.StudentID);
            return View(studentAddress);
        }

        // GET: StudentAddresses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentAddress = await _context.StudentAddress.FindAsync(id);
            if (studentAddress == null)
            {
                return NotFound();
            }
            ViewData["StudentID"] = new SelectList(_context.Student, "StudentID", "StudentID", studentAddress.StudentID);
            return View(studentAddress);
        }

        // POST: StudentAddresses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StudentID,Address,City,Country")] StudentAddress studentAddress)
        {
            if (id != studentAddress.StudentID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(studentAddress);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentAddressExists(studentAddress.StudentID))
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
            ViewData["StudentID"] = new SelectList(_context.Student, "StudentID", "StudentID", studentAddress.StudentID);
            return View(studentAddress);
        }

        // GET: StudentAddresses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentAddress = await _context.StudentAddress
                .Include(s => s.Student)
                .FirstOrDefaultAsync(m => m.StudentID == id);
            if (studentAddress == null)
            {
                return NotFound();
            }

            return View(studentAddress);
        }

        // POST: StudentAddresses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var studentAddress = await _context.StudentAddress.FindAsync(id);
            _context.StudentAddress.Remove(studentAddress);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentAddressExists(int id)
        {
            return _context.StudentAddress.Any(e => e.StudentID == id);
        }
    }
}
