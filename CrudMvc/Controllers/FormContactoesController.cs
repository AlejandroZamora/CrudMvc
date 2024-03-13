using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CrudMvc.Models;

namespace CrudMvc.Controllers
{
    public class FormContactoesController : Controller
    {
        private readonly FormContactoDbContext _context;

        public FormContactoesController(FormContactoDbContext context)
        {
            _context = context;
        }

        // GET: FormContactoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.FormContactos.ToListAsync());
        }

        // GET: FormContactoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var formContacto = await _context.FormContactos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (formContacto == null)
            {
                return NotFound();
            }

            return View(formContacto);
        }

        // GET: FormContactoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FormContactoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Correo,Mensaje")] FormContacto formContacto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(formContacto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(formContacto);
        }

        // GET: FormContactoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var formContacto = await _context.FormContactos.FindAsync(id);
            if (formContacto == null)
            {
                return NotFound();
            }
            return View(formContacto);
        }

        // POST: FormContactoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Correo,Mensaje")] FormContacto formContacto)
        {
            if (id != formContacto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(formContacto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FormContactoExists(formContacto.Id))
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
            return View(formContacto);
        }

        // GET: FormContactoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var formContacto = await _context.FormContactos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (formContacto == null)
            {
                return NotFound();
            }

            return View(formContacto);
        }

        // POST: FormContactoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var formContacto = await _context.FormContactos.FindAsync(id);
            if (formContacto != null)
            {
                _context.FormContactos.Remove(formContacto);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FormContactoExists(int id)
        {
            return _context.FormContactos.Any(e => e.Id == id);
        }
    }
}
