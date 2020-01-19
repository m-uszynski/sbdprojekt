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
    public class ZamowienieController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ZamowienieController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Zamowienie
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Zamowienia.Include(k => k.Kurier).Include(o => o.Odbiorca).Include(n => n.Nadawca);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Zamowienie/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zamowienie = await _context.Zamowienia
                .Include(z => z.Kurier)
                .Include(z => z.Nadawca)
                .Include(z => z.Odbiorca)
                .FirstOrDefaultAsync(m => m.ZamowienieId == id);
            if (zamowienie == null)
            {
                return NotFound();
            }

            return View(zamowienie);
        }

        // GET: Zamowienie/Create
        public IActionResult Create()
        {

            IEnumerable<SelectListItem> kurierzy = _context.Kurierzy.Select(x => new SelectListItem { Value = x.KurierId.ToString(), Text = x.Imie + " " + x.Nazwisko });
            IEnumerable<SelectListItem> nadawcy = _context.Nadawcy.Select(x => new SelectListItem { Value = x.NadawcaId.ToString(), Text = x.Imie + " " + x.Nazwisko});
            IEnumerable<SelectListItem> odbiorcy = _context.Odbiorcy.Select(x => new SelectListItem { Value = x.OdbiorcaId.ToString(), Text = x.Imie + " " + x.Nazwisko });

            ViewData["KurierId"] = new SelectList(kurierzy, "Value", "Text");
            ViewData["NadawcaId"] = new SelectList(nadawcy, "Value", "Text");
            ViewData["OdbiorcaId"] = new SelectList(odbiorcy, "Value", "Text");
            return View();
        }

        // POST: Zamowienie/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ZamowienieId,KurierId,NadawcaId,OdbiorcaId,DataNadania,DataOdbioru")] Zamowienie zamowienie)
        {
            if (ModelState.IsValid)
            {
                _context.Add(zamowienie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            IEnumerable<SelectListItem> kurierzy = _context.Kurierzy.Select(x => new SelectListItem { Value = x.KurierId.ToString(), Text = x.Imie + " " + x.Nazwisko });
            IEnumerable<SelectListItem> nadawcy = _context.Nadawcy.Select(x => new SelectListItem { Value = x.NadawcaId.ToString(), Text = x.Imie + " " + x.Nazwisko });
            IEnumerable<SelectListItem> odbiorcy = _context.Odbiorcy.Select(x => new SelectListItem { Value = x.OdbiorcaId.ToString(), Text = x.Imie + " " + x.Nazwisko });

            ViewData["KurierId"] = new SelectList(kurierzy, "Value", "Text");
            ViewData["NadawcaId"] = new SelectList(nadawcy, "Value", "Text");
            ViewData["OdbiorcaId"] = new SelectList(odbiorcy, "Value", "Text");
            return View(zamowienie);
        }

        // GET: Zamowienie/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zamowienie = await _context.Zamowienia.FindAsync(id);
            if (zamowienie == null)
            {
                return NotFound();
            }
            IEnumerable<SelectListItem> kurierzy = _context.Kurierzy.Select(x => new SelectListItem { Value = x.KurierId.ToString(), Text = x.Imie + " " + x.Nazwisko });
            IEnumerable<SelectListItem> nadawcy = _context.Nadawcy.Select(x => new SelectListItem { Value = x.NadawcaId.ToString(), Text = x.Imie + " " + x.Nazwisko });
            IEnumerable<SelectListItem> odbiorcy = _context.Odbiorcy.Select(x => new SelectListItem { Value = x.OdbiorcaId.ToString(), Text = x.Imie + " " + x.Nazwisko });

            ViewData["KurierId"] = new SelectList(kurierzy, "Value", "Text");
            ViewData["NadawcaId"] = new SelectList(nadawcy, "Value", "Text");
            ViewData["OdbiorcaId"] = new SelectList(odbiorcy, "Value", "Text");
            return View(zamowienie);
        }

        // POST: Zamowienie/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ZamowienieId,KurierId,NadawcaId,OdbiorcaId,DataNadania,DataOdbioru")] Zamowienie zamowienie)
        {
            if (id != zamowienie.ZamowienieId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(zamowienie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ZamowienieExists(zamowienie.ZamowienieId))
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
            IEnumerable<SelectListItem> kurierzy = _context.Kurierzy.Select(x => new SelectListItem { Value = x.KurierId.ToString(), Text = x.Imie + " " + x.Nazwisko });
            IEnumerable<SelectListItem> nadawcy = _context.Nadawcy.Select(x => new SelectListItem { Value = x.NadawcaId.ToString(), Text = x.Imie + " " + x.Nazwisko });
            IEnumerable<SelectListItem> odbiorcy = _context.Odbiorcy.Select(x => new SelectListItem { Value = x.OdbiorcaId.ToString(), Text = x.Imie + " " + x.Nazwisko });

            ViewData["KurierId"] = new SelectList(kurierzy, "Value", "Text");
            ViewData["NadawcaId"] = new SelectList(nadawcy, "Value", "Text");
            ViewData["OdbiorcaId"] = new SelectList(odbiorcy, "Value", "Text");
            return View(zamowienie);
        }

        // GET: Zamowienie/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zamowienie = await _context.Zamowienia
                .Include(z => z.Kurier)
                .Include(z => z.Nadawca)
                .Include(z => z.Odbiorca)
                .FirstOrDefaultAsync(m => m.ZamowienieId == id);
            if (zamowienie == null)
            {
                return NotFound();
            }

            return View(zamowienie);
        }

        // POST: Zamowienie/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var zamowienie = await _context.Zamowienia.FindAsync(id);
            _context.Zamowienia.Remove(zamowienie);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ZamowienieExists(int id)
        {
            return _context.Zamowienia.Any(e => e.ZamowienieId == id);
        }
    }
}
