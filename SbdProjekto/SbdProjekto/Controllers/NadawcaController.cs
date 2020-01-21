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
    public class NadawcaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public NadawcaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Nadawca
        public async Task<IActionResult> Index()
        {
            return View(await _context.Nadawcy.ToListAsync());
        }

        // GET: Nadawca/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nadawca = await _context.Nadawcy
                .FirstOrDefaultAsync(m => m.NadawcaId == id);
            if (nadawca == null)
            {
                return NotFound();
            }

            return View(nadawca);
        }

        public async Task<IActionResult> Order(int id)
        {
            var senderOrders = _context.Zamowienia.Where(m => m.NadawcaId.Equals(id))
                .Include(m => m.Kurier)
                .Include(m => m.Odbiorca)
                .Include(m => m.Nadawca).ToListAsync();
            return View(await senderOrders);
        }

        // GET: Nadawca/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Nadawca/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NadawcaId,Imie,Nazwisko,Ulica,Miasto,KodPocztowy")] Nadawca nadawca)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nadawca);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(nadawca);
        }

        // GET: Nadawca/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nadawca = await _context.Nadawcy.FindAsync(id);
            if (nadawca == null)
            {
                return NotFound();
            }
            return View(nadawca);
        }

        // POST: Nadawca/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("NadawcaId,Imie,Nazwisko,Ulica,Miasto,KodPocztowy")] Nadawca nadawca)
        {
            if (id != nadawca.NadawcaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nadawca);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NadawcaExists(nadawca.NadawcaId))
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
            return View(nadawca);
        }

        // GET: Nadawca/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nadawca = await _context.Nadawcy
                .FirstOrDefaultAsync(m => m.NadawcaId == id);
            if (nadawca == null)
            {
                return NotFound();
            }

            return View(nadawca);
        }

        // POST: Nadawca/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var nadawca = await _context.Nadawcy.FindAsync(id);
            _context.Nadawcy.Remove(nadawca);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NadawcaExists(int id)
        {
            return _context.Nadawcy.Any(e => e.NadawcaId == id);
        }
    }
}
