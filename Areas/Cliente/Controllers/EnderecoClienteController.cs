using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebAppPedido.Areas.Cliente.Models;
using WebAppPedido.Data;

namespace WebAppPedido.Areas.Cliente.Controllers
{
    [Area("Cliente")]
    public class EnderecoClienteController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EnderecoClienteController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Cliente/EnderecoCliente
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.EnderecoCliente.Include(e => e.Cliente);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Cliente/EnderecoCliente/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.EnderecoCliente == null)
            {
                return NotFound();
            }

            var enderecoCliente = await _context.EnderecoCliente
                .Include(e => e.Cliente)
                .FirstOrDefaultAsync(m => m.EnderecoClienteID == id);
            if (enderecoCliente == null)
            {
                return NotFound();
            }

            return View(enderecoCliente);
        }

        // GET: Cliente/EnderecoCliente/Create
        public IActionResult Create()
        {
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "ClienteId", "ClienteId");
            return View();
        }

        // POST: Cliente/EnderecoCliente/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EnderecoClienteID,Denominacao,Logradouro,Numero,Complemento,Principal,ClienteId")] EnderecoCliente enderecoCliente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(enderecoCliente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "ClienteId", "ClienteId", enderecoCliente.ClienteId);
            return View(enderecoCliente);
        }

        // GET: Cliente/EnderecoCliente/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.EnderecoCliente == null)
            {
                return NotFound();
            }

            var enderecoCliente = await _context.EnderecoCliente.FindAsync(id);
            if (enderecoCliente == null)
            {
                return NotFound();
            }
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "ClienteId", "ClienteId", enderecoCliente.ClienteId);
            return View(enderecoCliente);
        }

        // POST: Cliente/EnderecoCliente/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EnderecoClienteID,Denominacao,Logradouro,Numero,Complemento,Principal,ClienteId")] EnderecoCliente enderecoCliente)
        {
            if (id != enderecoCliente.EnderecoClienteID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(enderecoCliente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EnderecoClienteExists(enderecoCliente.EnderecoClienteID))
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
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "ClienteId", "ClienteId", enderecoCliente.ClienteId);
            return View(enderecoCliente);
        }

        // GET: Cliente/EnderecoCliente/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.EnderecoCliente == null)
            {
                return NotFound();
            }

            var enderecoCliente = await _context.EnderecoCliente
                .Include(e => e.Cliente)
                .FirstOrDefaultAsync(m => m.EnderecoClienteID == id);
            if (enderecoCliente == null)
            {
                return NotFound();
            }

            return View(enderecoCliente);
        }

        // POST: Cliente/EnderecoCliente/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.EnderecoCliente == null)
            {
                return Problem("Entity set 'ApplicationDbContext.EnderecoCliente'  is null.");
            }
            var enderecoCliente = await _context.EnderecoCliente.FindAsync(id);
            if (enderecoCliente != null)
            {
                _context.EnderecoCliente.Remove(enderecoCliente);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EnderecoClienteExists(int id)
        {
            return (_context.EnderecoCliente?.Any(e => e.EnderecoClienteID == id)).GetValueOrDefault();
        }
    }
}
