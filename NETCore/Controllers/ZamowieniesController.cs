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
    public class ZamowieniesController : Controller
    {
        private readonly DBContext _context;

        public ZamowieniesController(DBContext context)
        {
            _context = context;
        }

        // GET: Zamowienies
        public async Task<IActionResult> Index()
        {
            var dBContext = _context.Zamowienie.Include(z => z.Klient).Include(z => z.Obuwie);
            return View(await dBContext.ToListAsync());
        }

        // GET: Zamowienies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zamowienie = await _context.Zamowienie
                .Include(z => z.Klient)
                .Include(z => z.Obuwie)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (zamowienie == null)
            {
                return NotFound();
            }

            return View(zamowienie);
        }

        // GET: Zamowienies/Create
        public IActionResult Create()
        {
            ViewData["KlientId"] = new SelectList(_context.Klient, "Id", "Nazwisko");
            ViewData["ObuwieId"] = new SelectList(_context.Obuwie, "Id", "Nazwa");
            return View();
        }

        // POST: Zamowienies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ObuwieId,KlientId,Data")] Zamowienie zamowienie)
        {
            if (ModelState.IsValid)
            {
                _context.Add(zamowienie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["KlientId"] = new SelectList(_context.Klient, "Id", "Nazwisko", zamowienie.KlientId);
            ViewData["ObuwieId"] = new SelectList(_context.Obuwie, "Id", "Nazwa", zamowienie.ObuwieId);
            return View(zamowienie);
        }

        // GET: Zamowienies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zamowienie = await _context.Zamowienie.FindAsync(id);
            if (zamowienie == null)
            {
                return NotFound();
            }
            ViewData["KlientId"] = new SelectList(_context.Klient, "Id", "Nazwisko", zamowienie.KlientId);
            ViewData["ObuwieId"] = new SelectList(_context.Obuwie, "Id", "Nazwa", zamowienie.ObuwieId);
            return View(zamowienie);
        }

        // POST: Zamowienies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ObuwieId,KlientId,Data")] Zamowienie zamowienie)
        {
            if (id != zamowienie.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(zamowienie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ZamowienieExists(zamowienie.Id))
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
            ViewData["KlientId"] = new SelectList(_context.Klient, "Id", "Nazwisko", zamowienie.KlientId);
            ViewData["ObuwieId"] = new SelectList(_context.Obuwie, "Id", "Nazwa", zamowienie.ObuwieId);
            return View(zamowienie);
        }

        // GET: Zamowienies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zamowienie = await _context.Zamowienie
                .Include(z => z.Klient)
                .Include(z => z.Obuwie)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (zamowienie == null)
            {
                return NotFound();
            }

            return View(zamowienie);
        }

        // POST: Zamowienies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var zamowienie = await _context.Zamowienie.FindAsync(id);
            _context.Zamowienie.Remove(zamowienie);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ZamowienieExists(int id)
        {
            return _context.Zamowienie.Any(e => e.Id == id);
        }
    }
}
