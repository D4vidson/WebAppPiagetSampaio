using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebAppPiagetSampaio.Data;
using WebAppPiagetSampaio.Models;

namespace WebAppPiagetSampaio.Controllers
{
    public class ProfessorController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProfessorController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Professor
        public async Task<IActionResult> Index()
        {
            return View(await _context.Professor.ToListAsync());
        }

        // GET: Professor/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var professor = await _context.Professor
                .FirstOrDefaultAsync(m => m.id == id);
            if (professor == null)
            {
                return NotFound();
            }

            return View(professor);
        }

        // GET: Professor/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Professor/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("nome,email,telefone,id")] Professor professor)
        {
            if (ModelState.IsValid)
            {
                professor.id = Guid.NewGuid();
                _context.Add(professor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(professor);
        }

        // GET: Professor/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var professor = await _context.Professor.FindAsync(id);
            if (professor == null)
            {
                return NotFound();
            }
            return View(professor);
        }

        // POST: Professor/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("nome,email,telefone,id")] Professor professor)
        {
            if (id != professor.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(professor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProfessorExists(professor.id))
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
            return View(professor);
        }

        // GET: Professor/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var professor = await _context.Professor
                .FirstOrDefaultAsync(m => m.id == id);
            if (professor == null)
            {
                return NotFound();
            }

            return View(professor);
        }

        // POST: Professor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var professor = await _context.Professor.FindAsync(id);
            if (professor != null)
            {
                _context.Professor.Remove(professor);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProfessorExists(Guid id)
        {
            return _context.Professor.Any(e => e.id == id);
        }
    }
}
