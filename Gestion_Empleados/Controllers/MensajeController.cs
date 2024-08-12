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
    public class MensajeController : Controller
    {
        private readonly Contexto _context;

        public MensajeController(Contexto context)
        {
            _context = context;
        }

        // GET: Mensaje
        public async Task<IActionResult> Index()
        {
            var contexto = _context.Mensajes.Include(m => m.Remitente);
            return View(await contexto.ToListAsync());
        }

        // GET: Mensaje/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mensaje = await _context.Mensajes
                .Include(m => m.Remitente)
                .FirstOrDefaultAsync(m => m.MensajeId == id);
            if (mensaje == null)
            {
                return NotFound();
            }

            return View(mensaje);
        }

        // GET: Mensaje/Create
        public IActionResult Create()
        {
            ViewData["RemitenteId"] = new SelectList(_context.Empleados, "EmpleadoId", "Apellidos");
            return View();
        }

        // POST: Mensaje/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MensajeId,RemitenteId,Asunto,Texto,Fecha")] Mensaje mensaje)
        {
            var userIdClaim = User.FindFirst("UserId");
            if (userIdClaim != null)
            {
                int userId = int.Parse(userIdClaim.Value);
                mensaje.RemitenteId = userId;

                var empleado = await _context.Empleados.FindAsync(userId);
                mensaje.Remitente = empleado;

                if (empleado!=null && mensaje!=null)
                {
                    _context.Add(mensaje);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index", "Home");
                }
            }
            
            ViewData["RemitenteId"] = new SelectList(_context.Empleados, "EmpleadoId", "Apellidos", mensaje.RemitenteId);
            return View(mensaje);
        }

        // GET: Mensaje/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mensaje = await _context.Mensajes
                .Include(m => m.Remitente) 
                .FirstOrDefaultAsync(m => m.MensajeId == id);

            
            
            //ViewBag.Empleado = empleado;

            if (mensaje == null)
            {
                return NotFound();
            }
            ViewData["RemitenteId"] = new SelectList(_context.Empleados, "EmpleadoId", "Apellidos", mensaje.RemitenteId);
            return View(mensaje);
        }

        // POST: Mensaje/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MensajeId,RemitenteId,Remitente,Asunto,Texto,Fecha")] Mensaje mensaje)
        {
            if (id != mensaje.MensajeId)
            {
                return NotFound();
            }

            int empId = mensaje.RemitenteId;

            var empleado = await _context.Empleados.FindAsync(empId);

            mensaje.Remitente = empleado;

            if (mensaje!=null&&empleado!=null)
            {
                try
                {
                    _context.Update(mensaje);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MensajeExists(mensaje.MensajeId))
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
            ViewData["RemitenteId"] = new SelectList(_context.Empleados, "EmpleadoId", "Apellidos", mensaje.RemitenteId);
            return View(mensaje);
        }

        // GET: Mensaje/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mensaje = await _context.Mensajes
                .Include(m => m.Remitente)
                .FirstOrDefaultAsync(m => m.MensajeId == id);
            if (mensaje == null)
            {
                return NotFound();
            }

            return View(mensaje);
        }

        // POST: Mensaje/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mensaje = await _context.Mensajes.FindAsync(id);
            if (mensaje != null)
            {
                _context.Mensajes.Remove(mensaje);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MensajeExists(int id)
        {
            return _context.Mensajes.Any(e => e.MensajeId == id);
        }
    }
}
