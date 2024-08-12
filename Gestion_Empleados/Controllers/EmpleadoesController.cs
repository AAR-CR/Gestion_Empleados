using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Gestion_Empleados.Data;
using Gestion_Empleados.Models;

namespace Gestion_Empleados.Controllers
{
    public class EmpleadoesController : Controller
    {
        private readonly Contexto _context;

        public EmpleadoesController(Contexto context)
        {
            _context = context;
        }

        // GET: Empleadoes
        public async Task<IActionResult> Index()
        {
            var empleados = _context.Empleados.Include(e => e.Jornada);
            return View(await empleados.ToListAsync());
        }

        // GET: Empleadoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empleado = await _context.Empleados
                .Include(e => e.Jornada)
                .FirstOrDefaultAsync(m => m.EmpleadoId == id);
            if (empleado == null)
            {
                return NotFound();
            }

            return View(empleado);
        }

        // GET: Empleadoes/Create
        public IActionResult Create()
        {
            ViewData["JornadaId"] = new SelectList(_context.Jornadas, "JornadaId", "Nombre");
            return View();
        }

        // POST: Empleadoes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmpleadoId,Nombre,Apellidos,Direccion,Telefono,Correo,FechaNacimiento,Puesto,FechaContratacion,Rol,JornadaId")] Empleado empleado)
        {
            var jornada = await _context.Jornadas.FindAsync(empleado.JornadaId);
            empleado.Jornada = jornada;

            bool correoExiste = await _context.Empleados.AnyAsync(e => e.Correo == empleado.Correo);

            if (correoExiste)
            {
                ModelState.AddModelError("Correo", "El correo electrónico ya está registrado.");
            }

            if (ModelState.IsValid)
            {
                _context.Add(empleado);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["JornadaId"] = new SelectList(_context.Jornadas, "JornadaId", "Nombre", empleado.JornadaId);
            return View(empleado);
        }

        // GET: Empleadoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empleado = await _context.Empleados.FindAsync(id);
            if (empleado == null)
            {
                return NotFound();
            }
            ViewData["JornadaId"] = new SelectList(_context.Jornadas, "JornadaId", "Nombre", empleado.JornadaId);
            return View(empleado);
        }

        // POST: Empleadoes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EmpleadoId,Nombre,Apellidos,Direccion,Telefono,Correo,FechaNacimiento,Puesto,FechaContratacion,Rol,JornadaId")] Empleado empleado)
        {
            if (id != empleado.EmpleadoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(empleado);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmpleadoExists(empleado.EmpleadoId))
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
            ViewData["JornadaId"] = new SelectList(_context.Jornadas, "JornadaId", "Nombre", empleado.JornadaId);
            return View(empleado);
        }

        // GET: Empleadoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empleado = await _context.Empleados
                .Include(e => e.Jornada)
                .FirstOrDefaultAsync(m => m.EmpleadoId == id);
            if (empleado == null)
            {
                return NotFound();
            }

            return View(empleado);
        }

        // POST: Empleadoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var empleado = await _context.Empleados.FindAsync(id);
            if (empleado != null)
            {
                _context.Empleados.Remove(empleado);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmpleadoExists(int id)
        {
            return _context.Empleados.Any(e => e.EmpleadoId == id);
        }

        public IActionResult JornadasChart()
        {
          
            var data = _context.Empleados
                .GroupBy(e => e.Jornada.Nombre)
                .Select(g => new { Jornada = g.Key, Count = g.Count() })
                .ToList();

            ViewBag.Labels = data.Select(d => d.Jornada).ToList();
            ViewBag.Values = data.Select(d => d.Count).ToList();

            return View();
        }
    }
}
