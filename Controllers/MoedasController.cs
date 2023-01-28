using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcMoeda.Models;

namespace projeto_inoa.Controllers
{
    public class MoedasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MoedasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Moedas
        public async Task<IActionResult> Index()
        {
              return _context.Moeda != null ? 
                          View(await _context.Moeda.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Moeda'  is null.");
        }

        // GET: Moedas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Moeda == null)
            {
                return NotFound();
            }

            var moeda = await _context.Moeda
                .FirstOrDefaultAsync(m => m.Id == id);
            if (moeda == null)
            {
                return NotFound();
            }

            return View(moeda);
        }

        // GET: Moedas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Moedas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome")] Moeda moeda)
        {
            if (ModelState.IsValid)
            {
                _context.Add(moeda);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(moeda);
        }

        // GET: Moedas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Moeda == null)
            {
                return NotFound();
            }

            var moeda = await _context.Moeda.FindAsync(id);
            if (moeda == null)
            {
                return NotFound();
            }
            return View(moeda);
        }

        // POST: Moedas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome")] Moeda moeda)
        {
            if (id != moeda.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(moeda);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MoedaExists(moeda.Id))
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
            return View(moeda);
        }

        // GET: Moedas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Moeda == null)
            {
                return NotFound();
            }

            var moeda = await _context.Moeda
                .FirstOrDefaultAsync(m => m.Id == id);
            if (moeda == null)
            {
                return NotFound();
            }

            return View(moeda);
        }

        // POST: Moedas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Moeda == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Moeda'  is null.");
            }
            var moeda = await _context.Moeda.FindAsync(id);
            if (moeda != null)
            {
                _context.Moeda.Remove(moeda);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MoedaExists(int id)
        {
          return (_context.Moeda?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
