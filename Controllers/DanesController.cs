using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Etui.Infrastructure;
using Etui.Models;
using Microsoft.AspNetCore.Mvc.Razor.Compilation;

namespace Etui.Controllers
{
    public class DanesController : Controller
    {
        private readonly DataContext _context;

        public DanesController(DataContext context)
        {
            _context = context;
        }

        // GET: Danes
        public async Task<IActionResult> Index2()
        {
              return View(await _context.Dane_1.ToListAsync());
        }

        // GET: Danes/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.Dane_1 == null)
            {
                return NotFound();
            }

            var Dane = await _context.Dane_1
                .FirstOrDefaultAsync(m => m.Id == id);
            if (Dane == null)
            {
                return NotFound();
            }

            return View(Dane);
        }

        public IActionResult Twojedane()
        {
            return View();
        }

        // POST: Danes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Twojedane([Bind("Id,imie,nazwisko,email,ulica,nrdomu,nrlokalu,kodpocztowy,miejscowosc,nrtelefonu")] Dane dane)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dane);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index2));
            }
            return View(dane);
        }

      

        // GET: Danes/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.Dane_1 == null)
            {
                return NotFound();
            }

            var dane = await _context.Dane_1.FindAsync(id);
            if (dane == null)
            {
                return NotFound();
            }
            return View(dane);
        }

        // POST: Danes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,imie,nazwisko,email,ulica,nrdomu,nrlokalu,kodpocztowy,miejscowosc,nrtelefonu")] Dane dane)
        {
            if (id != dane.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dane);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DaneExists(dane.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index2));
            }
            return View(dane);
        }

        // GET: Danes/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.Dane_1 == null)
            {
                return NotFound();
            }

            var dane = await _context.Dane_1
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dane == null)
            {
                return NotFound();
            }

            return View(dane);
        }

        // POST: Danes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_context.Dane_1 == null)
            {
                return Problem("Entity set 'DataContext.Dane_1'  is null.");
            }
            var dane = await _context.Dane_1.FindAsync(id);
            if (dane != null)
            {
                _context.Dane_1.Remove(dane);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index2));
        }

        private bool DaneExists(long id)
        {
          return _context.Dane_1.Any(e => e.Id == id);
        }
    }
}
