using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SbdProjekto.Models;

namespace SbdProjekto.Controllers
{
    public class RodzajPrzesylkiController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RodzajPrzesylkiController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: RodzajPrzesylki
        public async Task<IActionResult> Index()
        {
            return View(await _context.RodzajePrzesylek.ToListAsync());
        }

        // GET: RodzajPrzesylki/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rodzajPrzesylki = await _context.RodzajePrzesylek
                .FirstOrDefaultAsync(m => m.RodzajPrzesylkiId == id);
            if (rodzajPrzesylki == null)
            {
                return NotFound();
            }

            return View(rodzajPrzesylki);
        }

        // GET: RodzajPrzesylki/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RodzajPrzesylki/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RodzajPrzesylkiId,Typ,Cena")] RodzajPrzesylki rodzajPrzesylki)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rodzajPrzesylki);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(rodzajPrzesylki);
        }

        // GET: RodzajPrzesylki/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rodzajPrzesylki = await _context.RodzajePrzesylek.FindAsync(id);
            if (rodzajPrzesylki == null)
            {
                return NotFound();
            }
            return View(rodzajPrzesylki);
        }

        // POST: RodzajPrzesylki/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RodzajPrzesylkiId,Typ,Cena")] RodzajPrzesylki rodzajPrzesylki)
        {
            if (id != rodzajPrzesylki.RodzajPrzesylkiId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rodzajPrzesylki);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RodzajPrzesylkiExists(rodzajPrzesylki.RodzajPrzesylkiId))
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
            return View(rodzajPrzesylki);
        }

        // GET: RodzajPrzesylki/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rodzajPrzesylki = await _context.RodzajePrzesylek
                .FirstOrDefaultAsync(m => m.RodzajPrzesylkiId == id);
            if (rodzajPrzesylki == null)
            {
                return NotFound();
            }

            return View(rodzajPrzesylki);
        }

        // POST: RodzajPrzesylki/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rodzajPrzesylki = await _context.RodzajePrzesylek.FindAsync(id);
            _context.RodzajePrzesylek.Remove(rodzajPrzesylki);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RodzajPrzesylkiExists(int id)
        {
            return _context.RodzajePrzesylek.Any(e => e.RodzajPrzesylkiId == id);
        }
    }
}
