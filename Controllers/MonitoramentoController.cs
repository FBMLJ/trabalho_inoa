using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcMonitoramento.Models;

namespace projeto_inoa.Controllers
{
    public class MonitoramentoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MonitoramentoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Monitoramento
        [Route("/")]
        public async Task<IActionResult> Index()
        {
            ViewBag.Moedas =  _context.Moeda.ToList();
            return _context.Monitoramento != null ? 
                          View(await _context.Monitoramento.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Monitoramento'  is null.");
        }

        // GET: Monitoramento/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Monitoramento == null)
            {
                return NotFound();
            }

            var monitoramento = await _context.Monitoramento
                .FirstOrDefaultAsync(m => m.Id == id);
            if (monitoramento == null)
            {
                return NotFound();
            }

            return View(monitoramento);
        }

        // GET: Monitoramento/Create
        public IActionResult Create()
        {
             ViewBag.Moedas =  _context.Moeda.ToList();
            return View();
        }

        // POST: Monitoramento/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        
        public async Task<IActionResult> Create([Bind("Id,Nome,MoedaOrigemId,MoedaAlvoId,ValorDeVenda,ValorDeCompra")] Monitoramento monitoramento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(monitoramento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(monitoramento);
        }

        // GET: Monitoramento/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Monitoramento == null)
            {
                return NotFound();
            }

            var monitoramento = await _context.Monitoramento.FindAsync(id);
            if (monitoramento == null)
            {
                return NotFound();
            }
            ViewBag.Moedas =  _context.Moeda.ToList();
            return View(monitoramento);
        }

        // POST: Monitoramento/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,MoedaOrigemId,MoedaAlvoId,ValorDeVenda,ValorDeCompra")] Monitoramento monitoramento)
        {
            if (id != monitoramento.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(monitoramento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MonitoramentoExists(monitoramento.Id))
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
            return View(monitoramento);
        }

        // GET: Monitoramento/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Monitoramento == null)
            {
                return NotFound();
            }

            var monitoramento = await _context.Monitoramento
                .FirstOrDefaultAsync(m => m.Id == id);
            if (monitoramento == null)
            {
                return NotFound();
            }

            return View(monitoramento);
        }

        // POST: Monitoramento/Delete/5
        [HttpPost, ActionName("Delete")]
        
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Monitoramento == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Monitoramento'  is null.");
            }
            var monitoramento = await _context.Monitoramento.FindAsync(id);
            if (monitoramento != null)
            {
                _context.Monitoramento.Remove(monitoramento);
            }
            
            await _context.SaveChangesAsync();
            return Ok(Json("Operação bem sucedida"));
        }

        private bool MonitoramentoExists(int id)
        {
          return (_context.Monitoramento?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
