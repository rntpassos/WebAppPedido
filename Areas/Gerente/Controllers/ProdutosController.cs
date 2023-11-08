using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebAppPedido.Areas.Gerente.Models;
using WebAppPedido.Data;

namespace WebAppPedido.Areas.Gerente.Controllers
{
    [Area("Gerente")]
    [Authorize(Roles = "Admin,Gerente")]
    public class ProdutosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProdutosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Gerente/Produtos
        public async Task<IActionResult> Index()
        {
              return _context.Produtos != null ? 
                          View(await _context.Produtos.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Produtos'  is null.");
        }

        // GET: Gerente/Produtos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Produtos == null)
            {
                return NotFound();
            }

            var produto = await _context.Produtos
                .FirstOrDefaultAsync(m => m.ProdutoId == id);
            if (produto == null)
            {
                return NotFound();
            }

            return PartialView("_DetalhesProduto", produto);
        }

        // GET: Gerente/Produtos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Gerente/Produtos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Descricao,Valor,Quantidade")] Produto produto)
        {
            Produto novoProduto = new Produto(produto.Descricao, produto.Valor, produto.Quantidade, HttpContext.User.Identity.Name);
            if (ModelState.IsValid)
            {
                _context.Add(novoProduto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(novoProduto);
        }

        // GET: Gerente/Produtos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Produtos == null)
            {
                return NotFound();
            }

            var produto = await _context.Produtos.FindAsync(id);
            if (produto == null)
            {
                return NotFound();
            }
            return PartialView("_EditarProduto", produto);
        }

        // POST: Gerente/Produtos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProdutoId,Descricao,Valor,Quantidade,RegistroAtivo")] Produto produto)
        {
            if (id != produto.ProdutoId)
            {
                //return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    produto.DataAlteracao = DateTime.Now;
                    produto.UsuarioAlteracao = HttpContext.User.Identity.Name;
                    _context.Update(produto);
                    _context.Entry(produto).Property(p => p.UsuarioCriacao).IsModified = false;
                    _context.Entry(produto).Property(p => p.DataCriacao).IsModified = false;

                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProdutoExists(produto.ProdutoId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(produto);
        }

        // GET: Gerente/Produtos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Produtos == null)
            {
                return NotFound();
            }

            var produto = await _context.Produtos
                .FirstOrDefaultAsync(m => m.ProdutoId == id);
            if (produto == null)
            {
                return NotFound();
            }

            return PartialView("_ConfirmaCancelamento", produto);
        }

        // POST: Gerente/Produtos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int ProdutoId)
        {
            if (_context.Produtos == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Produtos'  is null.");
            }
            var produto = await _context.Produtos.FindAsync(ProdutoId);
            if (produto != null)
            {
                _context.Produtos.Remove(produto);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProdutoExists(int id)
        {
          return (_context.Produtos?.Any(e => e.ProdutoId == id)).GetValueOrDefault();
        }
    }
}
