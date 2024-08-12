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
    public class EvaluacionDesempenoesController : Controller
    {
        private readonly Contexto _context;

        public EvaluacionDesempenoesController(Contexto context)
        {
            _context = context;
        }

        // GET: EvaluacionDesempenoes
        public async Task<IActionResult> Index()
        {
            var contexto = _context.EvaluacionesDesempeno.Include(e => e.Empleado);
            return View(await contexto.ToListAsync());
        }

        // GET: EvaluacionDesempenoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var evaluacionDesempeno = await _context.EvaluacionesDesempeno
                .Include(e => e.Empleado)
                .FirstOrDefaultAsync(m => m.EvaluacionDesempenoId == id);
            if (evaluacionDesempeno == null)
            {
                return NotFound();
            }

            return View(evaluacionDesempeno);
        }

        // GET: EvaluacionDesempenoes/Create
        public IActionResult Create()
        {
            ViewData["EmpleadoId"] = new SelectList(_context.Empleados, "EmpleadoId", "Apellidos");
            return View();
        }

        // POST: EvaluacionDesempenoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EvaluacionDesempenoId,EmpleadoId,FechaEvaluacion,Objetivos,Retroalimentacion")] EvaluacionDesempeno evaluacionDesempeno)
        {
            if (ModelState.IsValid)
            {
                _context.Add(evaluacionDesempeno);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmpleadoId"] = new SelectList(_context.Empleados, "EmpleadoId", "Apellidos", evaluacionDesempeno.EmpleadoId);
            return View(evaluacionDesempeno);
        }

        // GET: EvaluacionDesempenoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var evaluacionDesempeno = await _context.EvaluacionesDesempeno.FindAsync(id);
            if (evaluacionDesempeno == null)
            {
                return NotFound();
            }
            ViewData["EmpleadoId"] = new SelectList(_context.Empleados, "EmpleadoId", "Apellidos", evaluacionDesempeno.EmpleadoId);
            return View(evaluacionDesempeno);
        }

        // POST: EvaluacionDesempenoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EvaluacionDesempenoId,EmpleadoId,FechaEvaluacion,Objetivos,Retroalimentacion")] EvaluacionDesempeno evaluacionDesempeno)
        {
            if (id != evaluacionDesempeno.EvaluacionDesempenoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(evaluacionDesempeno);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EvaluacionDesempenoExists(evaluacionDesempeno.EvaluacionDesempenoId))
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
            ViewData["EmpleadoId"] = new SelectList(_context.Empleados, "EmpleadoId", "Apellidos", evaluacionDesempeno.EmpleadoId);
            return View(evaluacionDesempeno);
        }

        // GET: EvaluacionDesempenoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var evaluacionDesempeno = await _context.EvaluacionesDesempeno
                .Include(e => e.Empleado)
                .FirstOrDefaultAsync(m => m.EvaluacionDesempenoId == id);
            if (evaluacionDesempeno == null)
            {
                return NotFound();
            }

            return View(evaluacionDesempeno);
        }

        // POST: EvaluacionDesempenoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var evaluacionDesempeno = await _context.EvaluacionesDesempeno.FindAsync(id);
            if (evaluacionDesempeno != null)
            {
                _context.EvaluacionesDesempeno.Remove(evaluacionDesempeno);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EvaluacionDesempenoExists(int id)
        {
            return _context.EvaluacionesDesempeno.Any(e => e.EvaluacionDesempenoId == id);
        }
    }
}
