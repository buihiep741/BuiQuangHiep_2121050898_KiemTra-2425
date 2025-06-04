using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcMovie.Data;
using MvcMovie.Models;

namespace MvcMovie.Controllers
{
    public class ca2Controller : Controller
    {
        private readonly ApplicationDbContext _context;

        public ca2Controller(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ca2
        public async Task<IActionResult> Index()
        {
            return View(await _context.ca2.ToListAsync());
        }

        // GET: ca2/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ca2 = await _context.ca2
                .FirstOrDefaultAsync(m => m.ten == id);
            if (ca2 == null)
            {
                return NotFound();
            }

            return View(ca2);
        }

        // GET: ca2/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ca2/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int tuoi)
        {
            string output;
            if (tuoi >= 18)
                output = "trưởng thành";
            else
                output = "chưa trưởng thành";
        ViewBag.tuoi = tuoi;
        ViewBag.Message = output;
        return View();
        }

        // GET: ca2/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ca2 = await _context.ca2.FindAsync(id);
            if (ca2 == null)
            {
                return NotFound();
            }
            return View(ca2);
        }
        // POST: ca2/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("ten,diachi,tuoi")] ca2 ca2)
        {
            if (id != ca2.ten)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ca2);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ca2Exists(ca2.ten))
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
            return View(ca2);
        }

        // GET: ca2/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ca2 = await _context.ca2
                .FirstOrDefaultAsync(m => m.ten == id);
            if (ca2 == null)
            {
                return NotFound();
            }

            return View(ca2);
        }

        // POST: ca2/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var ca2 = await _context.ca2.FindAsync(id);
            if (ca2 != null)
            {
                _context.ca2.Remove(ca2);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ca2Exists(string id)
        {
            return _context.ca2.Any(e => e.ten == id);
        }
    }
}
