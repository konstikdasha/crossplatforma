using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcValue.Data;
using MvcValue.Models;

namespace MvcValue.Controllers
{
    public class ValuesController : Controller
    {
        private readonly MvcValueContext _context;

        public ValuesController(MvcValueContext context)
        {
            _context = context;
        }

        // GET: Values
        public async Task<IActionResult> Index()
        {
            return View(await _context.Value.ToListAsync());
        }

        // GET: Values/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var value = await _context.Value
                .FirstOrDefaultAsync(m => m.Id == id);
            if (value == null)
            {
                return NotFound();
            }

            return View(value);
        }

        // GET: Values/Create
        public IActionResult Create()
        {
            return View(new Value
            {
                Title = "Daria",
                Category = "Student",
                Price = 1.99M
            }
            );
        }

        // POST: Values/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Category,Price")] Value value)
        {
            if (ModelState.IsValid)
            {
                _context.Add(value);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(value);
        }

        // GET: Values/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var value = await _context.Value.FindAsync(id);
            if (value == null)
            {
                return NotFound();
            }
            return View(value);
        }

        // POST: Values/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Category,Price")] Value value)
        {
            if (id != value.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(value);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ValueExists(value.Id))
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
            return View(value);
        }

        // GET: Values/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var value = await _context.Value
                .FirstOrDefaultAsync(m => m.Id == id);
            if (value == null)
            {
                return NotFound();
            }

            return View(value);
        }

        // POST: Values/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var value = await _context.Value.FindAsync(id);
            _context.Value.Remove(value);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ValueExists(int id)
        {
            return _context.Value.Any(e => e.Id == id);
        }
    }
}
