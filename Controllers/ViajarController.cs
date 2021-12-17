using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Viagem.Database;
using Viagem.Models;

namespace Viagem.Controllers
{
    public class ViajarController : Controller
    {
        private readonly ViagensContext _context;

        public ViajarController(ViagensContext context)
        {
            _context = context;
        }

        // GET: Viajar
        public async Task<IActionResult> Index()
        {
            return View(await _context.Viajar.ToListAsync());
        }

        // GET: Viajar/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var viajar = await _context.Viajar
                .FirstOrDefaultAsync(m => m.Id == id);
            if (viajar == null)
            {
                return NotFound();
            }

            return View(viajar);
        }

        // GET: Viajar/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Viajar/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Partida,Destino,dataIda,dataVolta,PassageiroId_passageiro,PagamentoId_pagamento")] Viajar viajar)
        {
            if (ModelState.IsValid)
            {
                _context.Add(viajar);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(viajar);
        }

        // GET: Viajar/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var viajar = await _context.Viajar.FindAsync(id);
            if (viajar == null)
            {
                return NotFound();
            }
            return View(viajar);
        }

        // POST: Viajar/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Partida,Destino,dataIda,dataVolta,PassageiroId_passageiro,PagamentoId_pagamento")] Viajar viajar)
        {
            if (id != viajar.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(viajar);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ViajarExists(viajar.Id))
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
            return View(viajar);
        }

        // GET: Viajar/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var viajar = await _context.Viajar
                .FirstOrDefaultAsync(m => m.Id == id);
            if (viajar == null)
            {
                return NotFound();
            }

            return View(viajar);
        }

        // POST: Viajar/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var viajar = await _context.Viajar.FindAsync(id);
            _context.Viajar.Remove(viajar);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ViajarExists(int id)
        {
            return _context.Viajar.Any(e => e.Id == id);
        }
    }
}
