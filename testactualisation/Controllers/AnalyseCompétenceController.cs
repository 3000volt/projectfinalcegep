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
    public class AnalyseCompétenceController : Controller
    {
        private readonly ActualisationContext _context;

        public AnalyseCompétenceController(ActualisationContext context)
        {
            _context = context;
        }

        // GET: AnalyseCompétence
        public async Task<IActionResult> Index()
        {
            var actualisationContext = _context.AnalyseCompétence.Include(a => a.AdresseCourrielNavigation).Include(a => a.CodeCompetenceNavigation);
            return View(await actualisationContext.ToListAsync());
        }

        // GET: AnalyseCompétence/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var analyseCompétence = await _context.AnalyseCompétence
                .Include(a => a.AdresseCourrielNavigation)
                .Include(a => a.CodeCompetenceNavigation)
                .FirstOrDefaultAsync(m => m.IdAnalyseAc == id);
            if (analyseCompétence == null)
            {
                return NotFound();
            }

            return View(analyseCompétence);
        }

        // GET: AnalyseCompétence/Create
        public IActionResult Create()
        {
            ViewData["AdresseCourriel"] = new SelectList(_context.Utilisateur, "AdresseCourriel", "AdresseCourriel");
            ViewData["CodeCompetence"] = new SelectList(_context.Competences, "CodeCompetence", "CodeCompetence");
            return View();
        }

        // POST: AnalyseCompétence/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Obligatoire,NiveauTaxonomique,Reformulation,Context,SavoirFaireProgramme,SavoirEtreProgramme,ValidationApprouve,IdAnalyseAc,AdresseCourriel,CodeCompetence")] AnalyseCompétence analyseCompétence)
        {
            if (ModelState.IsValid)
            {
                _context.Add(analyseCompétence);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AdresseCourriel"] = new SelectList(_context.Utilisateur, "AdresseCourriel", "AdresseCourriel", analyseCompétence.AdresseCourriel);
            ViewData["CodeCompetence"] = new SelectList(_context.Competences, "CodeCompetence", "CodeCompetence", analyseCompétence.CodeCompetence);
            return View(analyseCompétence);
        }

        // GET: AnalyseCompétence/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var analyseCompétence = await _context.AnalyseCompétence.FindAsync(id);
            if (analyseCompétence == null)
            {
                return NotFound();
            }
            ViewData["AdresseCourriel"] = new SelectList(_context.Utilisateur, "AdresseCourriel", "AdresseCourriel", analyseCompétence.AdresseCourriel);
            ViewData["CodeCompetence"] = new SelectList(_context.Competences, "CodeCompetence", "CodeCompetence", analyseCompétence.CodeCompetence);
            return View(analyseCompétence);
        }

        // POST: AnalyseCompétence/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Obligatoire,NiveauTaxonomique,Reformulation,Context,SavoirFaireProgramme,SavoirEtreProgramme,ValidationApprouve,IdAnalyseAc,AdresseCourriel,CodeCompetence")] AnalyseCompétence analyseCompétence)
        {
            if (id != analyseCompétence.IdAnalyseAc)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(analyseCompétence);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AnalyseCompétenceExists(analyseCompétence.IdAnalyseAc))
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
            ViewData["AdresseCourriel"] = new SelectList(_context.Utilisateur, "AdresseCourriel", "AdresseCourriel", analyseCompétence.AdresseCourriel);
            ViewData["CodeCompetence"] = new SelectList(_context.Competences, "CodeCompetence", "CodeCompetence", analyseCompétence.CodeCompetence);
            return View(analyseCompétence);
        }

        // GET: AnalyseCompétence/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var analyseCompétence = await _context.AnalyseCompétence
                .Include(a => a.AdresseCourrielNavigation)
                .Include(a => a.CodeCompetenceNavigation)
                .FirstOrDefaultAsync(m => m.IdAnalyseAc == id);
            if (analyseCompétence == null)
            {
                return NotFound();
            }

            return View(analyseCompétence);
        }

        // POST: AnalyseCompétence/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var analyseCompétence = await _context.AnalyseCompétence.FindAsync(id);
            _context.AnalyseCompétence.Remove(analyseCompétence);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AnalyseCompétenceExists(int id)
        {
            return _context.AnalyseCompétence.Any(e => e.IdAnalyseAc == id);
        }
    }
}
