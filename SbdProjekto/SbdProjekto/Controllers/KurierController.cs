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
    public class KurierController : Controller
    {
        private readonly ApplicationDbContext _context;

        public KurierController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Kurier
        public async Task<IActionResult> Index()
        {
            var applicationDbContext =_context.Kurierzy.Include(k => k.Rejon);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Kurier/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kurier = await _context.Kurierzy
                .Include(k => k.Rejon)
                .FirstOrDefaultAsync(m => m.KurierId == id);
            if (kurier == null)
            {
                return NotFound();
            }

            return View(kurier);
        }
        public async Task<IActionResult> Order(int id)
        {
            var courierOrders = _context.Zamowienia.Where(m => m.KurierId.Equals(id))
                .Include(m=>m.Kurier)
                .Include(m=>m.Odbiorca)
                .Include(m=>m.Nadawca).ToListAsync();
            return View(await courierOrders);
        }

        // GET: Kurier/Create
        public IActionResult Create()
        {
            ViewData["RejonId"] = new SelectList(_context.Rejony, "RejonId", "Nazwa","xczcxcz");
            return View();
        }

        // POST: Kurier/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("KurierId,Imie,Nazwisko,Pesel,Telefon,RejonId")] Kurier kurier)
        {
            if (ModelState.IsValid)
            {
                _context.Add(kurier);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RejonId"] = new SelectList(_context.Rejony, "RejonId", "RejonId", kurier.RejonId);
            return View(kurier);
        }

        // GET: Kurier/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kurier = await _context.Kurierzy.FindAsync(id);
            if (kurier == null)
            {
                return NotFound();
            }
            ViewData["RejonId"] = new SelectList(_context.Rejony, "RejonId", "RejonId", kurier.RejonId);
            return View(kurier);
        }

        // POST: Kurier/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("KurierId,Imie,Nazwisko,Pesel,Telefon,RejonId")] Kurier kurier)
        {
            if (id != kurier.KurierId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(kurier);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KurierExists(kurier.KurierId))
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
            ViewData["RejonId"] = new SelectList(_context.Rejony, "RejonId", "RejonId", kurier.RejonId);
            return View(kurier);
        }

        // GET: Kurier/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kurier = await _context.Kurierzy
                .Include(k => k.Rejon)
                .FirstOrDefaultAsync(m => m.KurierId == id);
            if (kurier == null)
            {
                return NotFound();
            }

            return View(kurier);
        }

        // POST: Kurier/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var kurier = await _context.Kurierzy.FindAsync(id);
            _context.Kurierzy.Remove(kurier);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KurierExists(int id)
        {
            return _context.Kurierzy.Any(e => e.KurierId == id);
        }
    }
}
