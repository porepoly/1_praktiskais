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
    public class BmisController : Controller
    {
        private readonly Praktiskais1Context _context;

        public BmisController(Praktiskais1Context context)
        {
            _context = context;
        }

        // GET: Bmis
        public async Task<IActionResult> Index()
        {
            return View(await _context.Bmis.ToListAsync());
        }

        // GET: Bmis/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bmi = await _context.Bmis
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bmi == null)
            {
                return NotFound();
            }

            return View(bmi);
        }

        // GET: Bmis/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Bmis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Augums,Svars")] Bmi bmi)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bmi);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bmi);
        }

        // GET: Bmis/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bmi = await _context.Bmis.FindAsync(id);
            if (bmi == null)
            {
                return NotFound();
            }
            return View(bmi);
        }

        // POST: Bmis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,Augums,Svars")] Bmi bmi)
        {
            if (id != bmi.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bmi);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BmiExists(bmi.Id))
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
            return View(bmi);
        }

        // GET: Bmis/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bmi = await _context.Bmis
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bmi == null)
            {
                return NotFound();
            }

            return View(bmi);
        }

        // POST: Bmis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var bmi = await _context.Bmis.FindAsync(id);
            if (bmi != null)
            {
                _context.Bmis.Remove(bmi);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BmiExists(string id)
        {
            return _context.Bmis.Any(e => e.Id == id);
        }

        // GET: Bmis/Search
        public ActionResult Search()
        {
            return View();
        }

        // POST: Bmis/Search
        [HttpPost]
        public ActionResult Search(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
            {
                return View();
            }

            var bmis = _context.Bmis
                .Where(b =>
                    b.Id.Contains(query) ||
                    b.Augums.ToString().Contains(query) ||
                    b.Svars.ToString().Contains(query))
                .ToList();

            return View(bmis);
        }


    }
}
