using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using _1_praktiskais.Data;
using _1_praktiskais.Models;

namespace praktiskaisss_3.Controllers
{
    public class LietotajsController : Controller
    {
        private readonly Praktiskais1Context _context;

        public LietotajsController(Praktiskais1Context context)
        {
            _context = context;
        }

        // GET: Lietotajs
        public async Task<IActionResult> Index()
        {
            return View(await _context.Lietotajs.ToListAsync());
        }

        // GET: Lietotajs/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lietotaj = await _context.Lietotajs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lietotaj == null)
            {
                return NotFound();
            }

            return View(lietotaj);
        }

        // GET: Lietotajs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Lietotajs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Vards,Uzvards")] Lietotaj lietotaj)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lietotaj);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(lietotaj);
        }

        // GET: Lietotajs/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lietotaj = await _context.Lietotajs.FindAsync(id);
            if (lietotaj == null)
            {
                return NotFound();
            }
            return View(lietotaj);
        }

        // POST: Lietotajs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,Vards,Uzvards")] Lietotaj lietotaj)
        {
            if (id != lietotaj.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lietotaj);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LietotajExists(lietotaj.Id))
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
            return View(lietotaj);
        }

        // GET: Lietotajs/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lietotaj = await _context.Lietotajs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lietotaj == null)
            {
                return NotFound();
            }

            return View(lietotaj);
        }

        // POST: Lietotajs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var lietotaj = await _context.Lietotajs.FindAsync(id);
            if (lietotaj != null)
            {
                _context.Lietotajs.Remove(lietotaj);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LietotajExists(string id)
        {
            return _context.Lietotajs.Any(e => e.Id == id);
        }
        // GET: Lietotajs/Search
        public ActionResult Search()
        {
            return View();
        }

        // POST: Lietotajs/Search
        [HttpPost]
        public ActionResult Search(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
            {
                return View();
            }

            var lietotaji = _context.Lietotajs
                .Where(l =>
                    l.Id.Contains(query) ||
                    l.Vards.Contains(query) ||
                    l.Uzvards.Contains(query))
                .ToList();

            return View(lietotaji);
        }

    }
}
