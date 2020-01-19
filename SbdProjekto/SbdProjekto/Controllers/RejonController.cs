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
    public class RejonController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RejonController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Rejon
        public async Task<IActionResult> Index()
        {
            var rejony = from rej in _context.Rejony
                         select rej;
            return View(await rejony.ToListAsync());
        }

        // GET: Rejon/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rejon = await _context.Rejony
                .FirstOrDefaultAsync(m => m.RejonId == id);
            if (rejon == null)
            {
                return NotFound();
            }

            return View(rejon);
        }

        // GET: Rejon/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Rejon/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RejonId,Nazwa,Wojewodztwo")] Rejon rejon)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rejon);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(rejon);
        }

        // GET: Rejon/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rejon = await _context.Rejony.FindAsync(id);
            if (rejon == null)
            {
                return NotFound();
            }
            return View(rejon);
        }

        // POST: Rejon/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RejonId,Nazwa,Wojewodztwo")] Rejon rejon)
        {
            if (id != rejon.RejonId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rejon);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RejonExists(rejon.RejonId))
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
            return View(rejon);
        }

        // GET: Rejon/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rejon = await _context.Rejony
                .FirstOrDefaultAsync(m => m.RejonId == id);
            if (rejon == null)
            {
                return NotFound();
            }

            return View(rejon);
        }

        // POST: Rejon/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rejon = await _context.Rejony.FindAsync(id);
            _context.Rejony.Remove(rejon);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RejonExists(int id)
        {
            return _context.Rejony.Any(e => e.RejonId == id);
        }
    }
}
