using Gestion_Empleados.Data;
using Gestion_Empleados.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Gestion_Empleados.Controllers
{
    public class JornadaController : Controller
    {
        private readonly Contexto _context;

        public JornadaController(Contexto context)
        {
            _context = context;
        }

        // GET: Jornada
        public async Task<IActionResult> Index()
        {
            return View(await _context.Jornadas.ToListAsync());
        }

        // GET: Jornada/Create
        [Authorize(Policy = "RequireAdminRole")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Jornada/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("JornadaId,Nombre,HoraInicio,HoraFin")] Jornada jornada)
        {
            if (ModelState.IsValid)
            {
                _context.Add(jornada);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(jornada);
        }

        // GET: Jornada/Edit/5
        [Authorize(Policy = "RequireAdminRole")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jornada = await _context.Jornadas.FindAsync(id);
            if (jornada == null)
            {
                return NotFound();
            }
            return View(jornada);
        }

        // POST: Jornada/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("JornadaId,Nombre,HoraInicio,HoraFin")] Jornada jornada)
        {
            if (id != jornada.JornadaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(jornada);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JornadaExists(jornada.JornadaId))
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
            return View(jornada);
        }

        // GET: Jornada/Delete/5
        [Authorize(Policy = "RequireAdminRole")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jornada = await _context.Jornadas
                .FirstOrDefaultAsync(m => m.JornadaId == id);
            if (jornada == null)
            {
                return NotFound();
            }

            return View(jornada);
        }

        // POST: Jornada/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var jornada = await _context.Jornadas.FindAsync(id);
            _context.Jornadas.Remove(jornada);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JornadaExists(int id)
        {
            return _context.Jornadas.Any(e => e.JornadaId == id);
        }

    }
}
