using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Viagem.Data;
using Viagem.Models;

namespace Viagem.Controllers
{
    public class ViagemController : Controller
    {
        private readonly ViagemContext _context;

        public ViagemController(ViagemContext context)
        {
            _context = context;
        }

        // GET: Viagem
        public async Task<IActionResult> Index()
        {
            return View(await _context.Viagens.ToListAsync());
        }

        // GET: Viagem/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var viajar = await _context.Viagens
                .FirstOrDefaultAsync(m => m.Id == id);
            if (viajar == null)
            {
                return NotFound();
            }

            return View(viajar);
        }

        // GET: Viagem/Create
        public IActionResult Create()
        {
            ViewData["PagamentoId_pagamento"] = new SelectList(_context.Pagamentos, "Id_Pagamento", "Pagar");
            ViewData["PassageiroId_passageiro"] = new SelectList(_context.Passageiros, "Id_Passageiro", "Nome");
            return View();
        }

        // POST: Viagem/Create
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

        // GET: Viagem/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var viajar = await _context.Viagens.FindAsync(id);
            if (viajar == null)
            {
                return NotFound();
            }
            return View(viajar);
        }

        // POST: Viagem/Edit/5
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

        // GET: Viagem/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var viajar = await _context.Viagens
                .FirstOrDefaultAsync(m => m.Id == id);
            if (viajar == null)
            {
                return NotFound();
            }

            return View(viajar);
        }

        // POST: Viagem/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var viajar = await _context.Viagens.FindAsync(id);
            _context.Viagens.Remove(viajar);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ViajarExists(int id)
        {
            return _context.Viagens.Any(e => e.Id == id);
        }
    }
}
