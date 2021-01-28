using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NETCore.Models;

namespace NETCore.Controllers
{
    public class ObuwiesController : Controller
    {
        private readonly DBContext _context;

        public ObuwiesController(DBContext context)
        {
            _context = context;
        }

        // GET: Obuwies
        public async Task<IActionResult> Index()
        {
            return View(await _context.Obuwie.ToListAsync());
        }

        public async Task<IActionResult> Polbuty()
        {
            return View(await _context.Obuwie.ToListAsync());
        }
        public async Task<IActionResult> Pozostale()
        {
            return View(await _context.Obuwie.ToListAsync());
        }
        public async Task<IActionResult> Robocze()
        {
            return View(await _context.Obuwie.ToListAsync());
        }
        public async Task<IActionResult> Sandaly()
        {
            return View(await _context.Obuwie.ToListAsync());

        }
        public async Task<IActionResult> Sportowe()
        {
            return View(await _context.Obuwie.ToListAsync());
        }
        public async Task<IActionResult> Zimowe()
        {
            return View(await _context.Obuwie.ToListAsync());
        }
        public async Task<IActionResult> Wizytowe()
        {
            return View(await _context.Obuwie.ToListAsync());
        }

        // GET: Obuwies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obuwie = await _context.Obuwie
                .FirstOrDefaultAsync(m => m.Id == id);
            if (obuwie == null)
            {
                return NotFound();
            }

            return View(obuwie);
        }

        // GET: Obuwies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Obuwies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nazwa,Rodzaj,Rozmiar,ManorWomen,Cena")] Obuwie obuwie)
        {
            if (ModelState.IsValid)
            {
                _context.Add(obuwie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(obuwie);
        }

        // GET: Obuwies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obuwie = await _context.Obuwie.FindAsync(id);
            if (obuwie == null)
            {
                return NotFound();
            }
            return View(obuwie);
        }

        // POST: Obuwies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nazwa,Rodzaj,Rozmiar,ManorWomen,Cena")] Obuwie obuwie)
        {
            if (id != obuwie.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(obuwie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ObuwieExists(obuwie.Id))
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
            return View(obuwie);
        }

        // GET: Obuwies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obuwie = await _context.Obuwie
                .FirstOrDefaultAsync(m => m.Id == id);
            if (obuwie == null)
            {
                return NotFound();
            }

            return View(obuwie);
        }

        // POST: Obuwies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var obuwie = await _context.Obuwie.FindAsync(id);
            _context.Obuwie.Remove(obuwie);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ObuwieExists(int id)
        {
            return _context.Obuwie.Any(e => e.Id == id);
        }
    }
}
