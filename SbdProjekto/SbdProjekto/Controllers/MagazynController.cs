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
    public class MagazynController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MagazynController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Magazyn
        public async Task<IActionResult> Index(string searchString)
        {
            
            List<Magazyn> magazines;

            if(!String.IsNullOrEmpty(searchString))
            {
                magazines = await _context.Magazyny.Where(m => m.Nazwa.Contains(searchString)).ToListAsync();
                ViewBag.Filter = searchString;
            }
            else
            {
                magazines = await _context.Magazyny.ToListAsync();
            }
            return View(magazines);
        }

        // GET: Magazyn/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var magazyn = await _context.Magazyny
                .FirstOrDefaultAsync(m => m.MagazynId == id);
            if (magazyn == null)
            {
                return NotFound();
            }

            return View(magazyn);
        }

        // GET: Magazyn/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Magazyn/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MagazynId,Nazwa,Ulica,Miasto,KodPocztowy")] Magazyn magazyn)
        {
            if (ModelState.IsValid)
            {
                _context.Add(magazyn);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(magazyn);
        }

        // GET: Magazyn/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var magazyn = await _context.Magazyny.FindAsync(id);
            if (magazyn == null)
            {
                return NotFound();
            }
            return View(magazyn);
        }

        // POST: Magazyn/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MagazynId,Nazwa,Ulica,Miasto,KodPocztowy")] Magazyn magazyn)
        {
            if (id != magazyn.MagazynId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(magazyn);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MagazynExists(magazyn.MagazynId))
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
            return View(magazyn);
        }

        // GET: Magazyn/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var magazyn = await _context.Magazyny
                .FirstOrDefaultAsync(m => m.MagazynId == id);
            if (magazyn == null)
            {
                return NotFound();
            }

            return View(magazyn);
        }

        // POST: Magazyn/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var magazyn = await _context.Magazyny.FindAsync(id);
            _context.Magazyny.Remove(magazyn);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MagazynExists(int id)
        {
            return _context.Magazyny.Any(e => e.MagazynId == id);
        }
    }
}
