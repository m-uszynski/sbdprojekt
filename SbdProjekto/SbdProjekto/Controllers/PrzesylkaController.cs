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
    public class PrzesylkaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PrzesylkaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Przesylka
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Przesylki.Include(p => p.Magazyn).Include(p => p.RodzajPrzesylki).Include(p => p.Zamowienie);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Przesylka/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var przesylka = await _context.Przesylki
                .Include(p => p.Magazyn)
                .Include(p => p.RodzajPrzesylki)
                .Include(p => p.Zamowienie)
                .FirstOrDefaultAsync(m => m.PrzesylkaId == id);
            if (przesylka == null)
            {
                return NotFound();
            }

            return View(przesylka);
        }

        // GET: Przesylka/Create
        public IActionResult Create()
        {
            //IEnumerable<SelectListItem> magazyny = _context.Magazyny.Select(x => new SelectListItem { Value = x.MagazynId.ToString(), Text = x.Nazwa });
            //IEnumerable<SelectListItem> rodzajePrzesylek = _context.RodzajePrzesylek.Select(x => new SelectListItem { Value = x.RodzajPrzesylkiId.ToString(), Text = x.Typ});
            
            ViewData["MagazynId"] = new SelectList(_context.Magazyny, "MagazynId", "Nazwa");
            ViewData["RodzajPrzesylkiId"] = new SelectList(_context.RodzajePrzesylek, "RodzajPrzesylkiId", "Typ");
            ViewData["ZamowienieId"] = new SelectList(_context.Zamowienia, "ZamowienieId", "ZamowienieId");
            return View();
        }

        // POST: Przesylka/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PrzesylkaId,Waga,Szerokosc,Wysokosc,Dlugosc,MagazynId,RodzajPrzesylkiId,ZamowienieId")] Przesylka przesylka)
        {
            if (ModelState.IsValid)
            {
                _context.Add(przesylka);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            IEnumerable<SelectListItem> magazyny = _context.Magazyny.Select(x => new SelectListItem { Value = x.MagazynId.ToString(), Text = x.Nazwa });
            IEnumerable<SelectListItem> rodzajePrzesylek = _context.RodzajePrzesylek.Select(x => new SelectListItem { Value = x.RodzajPrzesylkiId.ToString(), Text = x.Typ });

            ViewData["MagazynId"] = new SelectList(magazyny, "MagazynId", "Nazwa");
            ViewData["RodzajPrzesylkiId"] = new SelectList(rodzajePrzesylek, "Value", "Text");
            ViewData["ZamowienieId"] = new SelectList(_context.Zamowienia, "ZamowienieId", "ZamowienieId", przesylka.ZamowienieId);
            return View(przesylka);
        }

        // GET: Przesylka/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var przesylka = await _context.Przesylki.FindAsync(id);
            if (przesylka == null)
            {
                return NotFound();
            }
            IEnumerable<SelectListItem> magazyny = _context.Magazyny.Select(x => new SelectListItem { Value = x.MagazynId.ToString(), Text = x.Nazwa });
            IEnumerable<SelectListItem> rodzajePrzesylek = _context.RodzajePrzesylek.Select(x => new SelectListItem { Value = x.RodzajPrzesylkiId.ToString(), Text = x.Typ });

            ViewData["MagazynId"] = new SelectList(magazyny, "Value", "Text");
            ViewData["RodzajPrzesylkiId"] = new SelectList(rodzajePrzesylek, "Value", "Text");
            ViewData["ZamowienieId"] = new SelectList(_context.Zamowienia, "ZamowienieId", "ZamowienieId", przesylka.ZamowienieId);
            return View(przesylka);
        }

        // POST: Przesylka/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PrzesylkaId,Waga,Szerokosc,Wysokosc,Dlugosc,MagazynId,RodzajPrzesylkiId,ZamowienieId")] Przesylka przesylka)
        {
            if (id != przesylka.PrzesylkaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(przesylka);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PrzesylkaExists(przesylka.PrzesylkaId))
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
            IEnumerable<SelectListItem> magazyny = _context.Magazyny.Select(x => new SelectListItem { Value = x.MagazynId.ToString(), Text = x.Nazwa });
            IEnumerable<SelectListItem> rodzajePrzesylek = _context.RodzajePrzesylek.Select(x => new SelectListItem { Value = x.RodzajPrzesylkiId.ToString(), Text = x.Typ });

            ViewData["MagazynId"] = new SelectList(magazyny, "Value", "Text");
            ViewData["RodzajPrzesylkiId"] = new SelectList(rodzajePrzesylek, "Value", "Text");
            ViewData["ZamowienieId"] = new SelectList(_context.Zamowienia, "ZamowienieId", "ZamowienieId", przesylka.ZamowienieId);
            return View(przesylka);
        }

        // GET: Przesylka/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var przesylka = await _context.Przesylki
                .Include(p => p.Magazyn)
                .Include(p => p.RodzajPrzesylki)
                .Include(p => p.Zamowienie)
                .FirstOrDefaultAsync(m => m.PrzesylkaId == id);
            if (przesylka == null)
            {
                return NotFound();
            }

            return View(przesylka);
        }

        // POST: Przesylka/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var przesylka = await _context.Przesylki.FindAsync(id);
            _context.Przesylki.Remove(przesylka);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PrzesylkaExists(int id)
        {
            return _context.Przesylki.Any(e => e.PrzesylkaId == id);
        }
    }
}
