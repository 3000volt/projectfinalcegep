using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using testactualisation.Appdata;

namespace testactualisation.Controllers
{
    public class FamillecompetencesController : Controller
    {
        private readonly ActualisationContext _context;

        public FamillecompetencesController(ActualisationContext context)
        {
            _context = context;
        }

        // GET: Famillecompetences
        public async Task<IActionResult> Index()
        {
            return View(await _context.Famillecompetence.ToListAsync());
        }

        // GET: Famillecompetences/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var famillecompetence = await _context.Famillecompetence
                .FirstOrDefaultAsync(m => m.Idfamille == id);
            if (famillecompetence == null)
            {
                return NotFound();
            }

            return View(famillecompetence);
        }

        // GET: Famillecompetences/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Famillecompetences/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NomFamille,Idfamille")] Famillecompetence famillecompetence)
        {
            if (ModelState.IsValid)
            {
                _context.Add(famillecompetence);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(famillecompetence);
        }

        // GET: Famillecompetences/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var famillecompetence = await _context.Famillecompetence.FindAsync(id);
            if (famillecompetence == null)
            {
                return NotFound();
            }
            return View(famillecompetence);
        }

        // POST: Famillecompetences/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("NomFamille,Idfamille")] Famillecompetence famillecompetence)
        {
            if (id != famillecompetence.Idfamille)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(famillecompetence);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FamillecompetenceExists(famillecompetence.Idfamille))
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
            return View(famillecompetence);
        }

        // GET: Famillecompetences/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var famillecompetence = await _context.Famillecompetence
                .FirstOrDefaultAsync(m => m.Idfamille == id);
            if (famillecompetence == null)
            {
                return NotFound();
            }

            return View(famillecompetence);
        }

        // POST: Famillecompetences/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var famillecompetence = await _context.Famillecompetence.FindAsync(id);
            _context.Famillecompetence.Remove(famillecompetence);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FamillecompetenceExists(int id)
        {
            return _context.Famillecompetence.Any(e => e.Idfamille == id);
        }
    }
}
