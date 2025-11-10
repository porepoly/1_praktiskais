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
    public class HobijisController : Controller
    {
        private readonly Praktiskais1Context _context;

        public HobijisController(Praktiskais1Context context)
        {
            _context = context;
        }

        // GET: Hobijis
        public async Task<IActionResult> Index()
        {
            return View(await _context.Hobijis.ToListAsync());
        }

        // GET: Hobijis/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hobiji = await _context.Hobijis
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hobiji == null)
            {
                return NotFound();
            }

            return View(hobiji);
        }

        // GET: Hobijis/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Hobijis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Hobijs,Skola")] Hobiji hobiji)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hobiji);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hobiji);
        }

        // GET: Hobijis/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hobiji = await _context.Hobijis.FindAsync(id);
            if (hobiji == null)
            {
                return NotFound();
            }
            return View(hobiji);
        }

        // POST: Hobijis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,Hobijs,Skola")] Hobiji hobiji)
        {
            if (id != hobiji.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hobiji);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HobijiExists(hobiji.Id))
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
            return View(hobiji);
        }

        // GET: Hobijis/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hobiji = await _context.Hobijis
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hobiji == null)
            {
                return NotFound();
            }

            return View(hobiji);
        }

        // POST: Hobijis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var hobiji = await _context.Hobijis.FindAsync(id);
            if (hobiji != null)
            {
                _context.Hobijis.Remove(hobiji);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HobijiExists(string id)
        {
            return _context.Hobijis.Any(e => e.Id == id);
        }

        // GET: Hobijis/Search
        public ActionResult Search()
        {
            return View();
        }

        // POST: Hobijis/Search
        [HttpPost]
        public ActionResult Search(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
            {
                return View();
            }

            var hobiji = _context.Hobijis
                .Where(h =>
                    h.Id.Contains(query) ||
                    h.Hobijs.Contains(query) ||
                    h.Skola.Contains(query))
                .ToList();

            return View(hobiji);
        }


    }

}
