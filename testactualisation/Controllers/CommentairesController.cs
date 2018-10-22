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
    public class CommentairesController : Controller
    {
        private readonly ActualisationContext _context;

        public CommentairesController(ActualisationContext context)
        {
            _context = context;
        }

        // GET: Commentaires
        public async Task<IActionResult> Index()
        {
            var actualisationContext = _context.Commentaires.Include(c => c.AdresseCourrielNavigation);
            return View(await actualisationContext.ToListAsync());
        }

        // GET: Commentaires/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var commentaires = await _context.Commentaires
                .Include(c => c.AdresseCourrielNavigation)
                .FirstOrDefaultAsync(m => m.NumCom == id);
            if (commentaires == null)
            {
                return NotFound();
            }

            return View(commentaires);
        }

        // GET: Commentaires/Create
        public IActionResult Create()
        {
            ViewData["AdresseCourriel"] = new SelectList(_context.Utilisateur, "AdresseCourriel", "AdresseCourriel");
            return View();
        }

        // POST: Commentaires/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NumCom,TexteCom,Categorie,AdresseCourriel")] Commentaires commentaires)
        {
            if (ModelState.IsValid)
            {
                _context.Add(commentaires);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AdresseCourriel"] = new SelectList(_context.Utilisateur, "AdresseCourriel", "AdresseCourriel", commentaires.AdresseCourriel);
            return View(commentaires);
        }

        // GET: Commentaires/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var commentaires = await _context.Commentaires.FindAsync(id);
            if (commentaires == null)
            {
                return NotFound();
            }
            ViewData["AdresseCourriel"] = new SelectList(_context.Utilisateur, "AdresseCourriel", "AdresseCourriel", commentaires.AdresseCourriel);
            return View(commentaires);
        }

        // POST: Commentaires/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("NumCom,TexteCom,Categorie,AdresseCourriel")] Commentaires commentaires)
        {
            if (id != commentaires.NumCom)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(commentaires);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CommentairesExists(commentaires.NumCom))
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
            ViewData["AdresseCourriel"] = new SelectList(_context.Utilisateur, "AdresseCourriel", "AdresseCourriel", commentaires.AdresseCourriel);
            return View(commentaires);
        }

        // GET: Commentaires/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var commentaires = await _context.Commentaires
                .Include(c => c.AdresseCourrielNavigation)
                .FirstOrDefaultAsync(m => m.NumCom == id);
            if (commentaires == null)
            {
                return NotFound();
            }

            return View(commentaires);
        }

        // POST: Commentaires/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var commentaires = await _context.Commentaires.FindAsync(id);
            _context.Commentaires.Remove(commentaires);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CommentairesExists(int id)
        {
            return _context.Commentaires.Any(e => e.NumCom == id);
        }
    }
}
