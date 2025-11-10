using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Etui.Infrastructure;
using Etui.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;

namespace Etui.Controllers
{
    public class SupportsController : Controller
    {
        private readonly DataContext _context;

        public SupportsController(DataContext context)
        {
            _context = context;
        }

        // GET: Supports
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index()
        {
              return View(await _context.Support.ToListAsync());
        }
        public IActionResult Thankyou()
        {
            return View();
        }
        [Authorize(Roles ="Admin")]
        // GET: Supports/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.Support == null)
            {
                return NotFound();
            }

            var support = await _context.Support
                .FirstOrDefaultAsync(m => m.Id == id);
            if (support == null)
            {
                return NotFound();
            }

            return View(support);
        }

        // GET: Supports/Create

        public IActionResult Create()
        {
            return View();
        }

        // POST: Supports/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,nazwa,email,temat,wiadomosc")] Support support)
        {
            if (ModelState.IsValid)
            {
                _context.Add(support);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Thankyou));

            }
            return View(support);
        }

        // GET: Supports/Edit/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.Support == null)
            {
                return NotFound();
            }

            var support = await _context.Support.FindAsync(id);
            if (support == null)
            {
                return NotFound();
            }
            return View(support);
        }

        // POST: Supports/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(long id, [Bind("Id,nazwa,email,temat,wiadomosc")] Support support)
        {
            if (id != support.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(support);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SupportExists(support.Id))
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
            return View(support);
        }

        // GET: Supports/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.Support == null)
            {
                return NotFound();
            }

            var support = await _context.Support
                .FirstOrDefaultAsync(m => m.Id == id);
            if (support == null)
            {
                return NotFound();
            }

            return View(support);
        }

        // POST: Supports/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_context.Support == null)
            {
                return Problem("Entity set 'DataContext.Support'  is null.");
            }
            var support = await _context.Support.FindAsync(id);
            if (support != null)
            {
                _context.Support.Remove(support);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        private bool SupportExists(long id)
        {
          return _context.Support.Any(e => e.Id == id);
        }
    }
}
