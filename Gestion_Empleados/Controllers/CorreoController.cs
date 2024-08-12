using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Gestion_Empleados.Data;
using Gestion_Empleados.Models;

namespace Gestion_Empleados.Controllers
{
    public class CorreoController : Controller
    {
        private readonly Contexto _context;

        public CorreoController(Contexto context)
        {
            _context = context;
        }

        // GET: Correo
        public async Task<IActionResult> Index()
        {
            var contexto = _context.Correos.Include(c => c.Destinatario).Include(c => c.Remitente);
            return View(await contexto.ToListAsync());
        }

        // GET: Correo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var correo = await _context.Correos
                .Include(c => c.Destinatario)
                .Include(c => c.Remitente)
                .FirstOrDefaultAsync(m => m.CorreoId == id);
            if (correo == null)
            {
                return NotFound();
            }

            return View(correo);
        }

        // GET: Correo/Create
        public IActionResult Create()
        {
            ViewData["DestinatarioId"] = new SelectList(_context.Empleados, "EmpleadoId", "Apellidos");
            ViewData["RemitenteId"] = new SelectList(_context.Empleados, "EmpleadoId", "Apellidos");
            return View();
        }

        // POST: Correo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CorreoId,RemitenteId,DestinatarioId,Asunto,Texto,Fecha")] Correo correo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(correo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DestinatarioId"] = new SelectList(_context.Empleados, "EmpleadoId", "Apellidos", correo.DestinatarioId);
            ViewData["RemitenteId"] = new SelectList(_context.Empleados, "EmpleadoId", "Apellidos", correo.RemitenteId);
            return View(correo);
        }

        // GET: Correo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var correo = await _context.Correos.FindAsync(id);
            if (correo == null)
            {
                return NotFound();
            }
            ViewData["DestinatarioId"] = new SelectList(_context.Empleados, "EmpleadoId", "Apellidos", correo.DestinatarioId);
            ViewData["RemitenteId"] = new SelectList(_context.Empleados, "EmpleadoId", "Apellidos", correo.RemitenteId);
            return View(correo);
        }

        // POST: Correo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CorreoId,RemitenteId,DestinatarioId,Asunto,Texto,Fecha")] Correo correo)
        {
            if (id != correo.CorreoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(correo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CorreoExists(correo.CorreoId))
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
            ViewData["DestinatarioId"] = new SelectList(_context.Empleados, "EmpleadoId", "Apellidos", correo.DestinatarioId);
            ViewData["RemitenteId"] = new SelectList(_context.Empleados, "EmpleadoId", "Apellidos", correo.RemitenteId);
            return View(correo);
        }

        // GET: Correo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var correo = await _context.Correos
                .Include(c => c.Destinatario)
                .Include(c => c.Remitente)
                .FirstOrDefaultAsync(m => m.CorreoId == id);
            if (correo == null)
            {
                return NotFound();
            }

            return View(correo);
        }

        // POST: Correo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var correo = await _context.Correos.FindAsync(id);
            if (correo != null)
            {
                _context.Correos.Remove(correo);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CorreoExists(int id)
        {
            return _context.Correos.Any(e => e.CorreoId == id);
        }
    }
}
