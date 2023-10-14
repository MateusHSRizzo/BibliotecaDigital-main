using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BibliotecaDigital.Models;

namespace BibliotecaDigital.Controllers
{
    public class LivroController : Controller
    {
        private readonly Context _context;

        public LivroController(Context context)
        {
            _context = context;
        }

        // GET: Livro
        public async Task<IActionResult> Index()
        {
            var context = _context.Livro.Include(l => l.Autor).Include(l => l.Cliente).Include(l => l.Editora).Include(l => l.Genero);
            return View(await context.ToListAsync());
        }

        // GET: Livro/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Livro == null)
            {
                return NotFound();
            }

            var livro = await _context.Livro
                .Include(l => l.Autor)
                .Include(l => l.Cliente)
                .Include(l => l.Editora)
                .Include(l => l.Genero)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (livro == null)
            {
                return NotFound();
            }

            return View(livro);
        }

        // GET: Livro/Create
        public IActionResult Create()
        {
            ViewData["AutorId"] = new SelectList(_context.Autor, "Id", "Nome");
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "Id", "Endereco");
            ViewData["EditoraId"] = new SelectList(_context.Editora, "Id", "Nome");
            ViewData["GeneroId"] = new SelectList(_context.Genero, "Id", "Descricao");
            return View();
        }

        // POST: Livro/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,EditoraId,AutorId,GeneroId,ClienteId")] Livro livro)
        {
            if (ModelState.IsValid)
            {
                _context.Add(livro);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AutorId"] = new SelectList(_context.Autor, "Id", "Nome", livro.AutorId);
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "Id", "Endereco", livro.ClienteId);
            ViewData["EditoraId"] = new SelectList(_context.Editora, "Id", "Nome", livro.EditoraId);
            ViewData["GeneroId"] = new SelectList(_context.Genero, "Id", "Descricao", livro.GeneroId);
            return View(livro);
        }

        // GET: Livro/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Livro == null)
            {
                return NotFound();
            }

            var livro = await _context.Livro.FindAsync(id);
            if (livro == null)
            {
                return NotFound();
            }
            ViewData["AutorId"] = new SelectList(_context.Autor, "Id", "Nome", livro.AutorId);
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "Id", "Endereco", livro.ClienteId);
            ViewData["EditoraId"] = new SelectList(_context.Editora, "Id", "Nome", livro.EditoraId);
            ViewData["GeneroId"] = new SelectList(_context.Genero, "Id", "Descricao", livro.GeneroId);
            return View(livro);
        }

        // POST: Livro/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,EditoraId,AutorId,GeneroId,ClienteId")] Livro livro)
        {
            if (id != livro.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(livro);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LivroExists(livro.Id))
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
            ViewData["AutorId"] = new SelectList(_context.Autor, "Id", "Nome", livro.AutorId);
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "Id", "Endereco", livro.ClienteId);
            ViewData["EditoraId"] = new SelectList(_context.Editora, "Id", "Nome", livro.EditoraId);
            ViewData["GeneroId"] = new SelectList(_context.Genero, "Id", "Descricao", livro.GeneroId);
            return View(livro);
        }

        // GET: Livro/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Livro == null)
            {
                return NotFound();
            }

            var livro = await _context.Livro
                .Include(l => l.Autor)
                .Include(l => l.Cliente)
                .Include(l => l.Editora)
                .Include(l => l.Genero)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (livro == null)
            {
                return NotFound();
            }

            return View(livro);
        }

        // POST: Livro/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Livro == null)
            {
                return Problem("Entity set 'Context.Livro'  is null.");
            }
            var livro = await _context.Livro.FindAsync(id);
            if (livro != null)
            {
                _context.Livro.Remove(livro);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LivroExists(int id)
        {
          return _context.Livro.Any(e => e.Id == id);
        }
    }
}
