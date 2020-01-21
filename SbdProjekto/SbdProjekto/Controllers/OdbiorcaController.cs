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
    public class OdbiorcaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OdbiorcaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Odbiorca
        public async Task<IActionResult> Index()
        {
            return View(await _context.Odbiorcy.ToListAsync());
        }

        // GET: Odbiorca/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var odbiorca = await _context.Odbiorcy
                .FirstOrDefaultAsync(m => m.OdbiorcaId == id);
            if (odbiorca == null)
            {
                return NotFound();
            }

            return View(odbiorca);
        }

        public async Task<IActionResult> Order(int id)
        {
            var recipientOrders = _context.Zamowienia.Where(m => m.OdbiorcaId.Equals(id))
                .Include(m => m.Kurier)
                .Include(m => m.Odbiorca)
                .Include(m => m.Nadawca).ToListAsync();
            return View(await recipientOrders);
        }

        // GET: Odbiorca/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Odbiorca/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OdbiorcaId,Imie,Nazwisko,Ulica,Miasto,KodPocztowy")] Odbiorca odbiorca)
        {
            if (ModelState.IsValid)
            {
                _context.Add(odbiorca);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(odbiorca);
        }

        // GET: Odbiorca/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var odbiorca = await _context.Odbiorcy.FindAsync(id);
            if (odbiorca == null)
            {
                return NotFound();
            }
            return View(odbiorca);
        }

        // POST: Odbiorca/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OdbiorcaId,Imie,Nazwisko,Ulica,Miasto,KodPocztowy")] Odbiorca odbiorca)
        {
            if (id != odbiorca.OdbiorcaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(odbiorca);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OdbiorcaExists(odbiorca.OdbiorcaId))
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
            return View(odbiorca);
        }

        // GET: Odbiorca/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var odbiorca = await _context.Odbiorcy
                .FirstOrDefaultAsync(m => m.OdbiorcaId == id);
            if (odbiorca == null)
            {
                return NotFound();
            }

            return View(odbiorca);
        }

        // POST: Odbiorca/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var odbiorca = await _context.Odbiorcy.FindAsync(id);
            _context.Odbiorcy.Remove(odbiorca);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OdbiorcaExists(int id)
        {
            return _context.Odbiorcy.Any(e => e.OdbiorcaId == id);
        }
    }
}
