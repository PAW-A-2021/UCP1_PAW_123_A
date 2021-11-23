using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UCP1_PAW_123_A.Models;

namespace UCP1_PAW_123_A.Controllers
{
    public class TblBarangsController : Controller
    {
        private readonly db_penjualanContext _context;

        public TblBarangsController(db_penjualanContext context)
        {
            _context = context;
        }

        // GET: TblBarangs
        public async Task<IActionResult> Index()
        {
            return View(await _context.TblBarangs.ToListAsync());
        }

        // GET: TblBarangs/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblBarang = await _context.TblBarangs
                .FirstOrDefaultAsync(m => m.KodeBarang == id);
            if (tblBarang == null)
            {
                return NotFound();
            }

            return View(tblBarang);
        }

        // GET: TblBarangs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TblBarangs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("KodeBarang,NamaBarang,Harga,Stok,Satuan")] TblBarang tblBarang)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblBarang);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblBarang);
        }

        // GET: TblBarangs/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblBarang = await _context.TblBarangs.FindAsync(id);
            if (tblBarang == null)
            {
                return NotFound();
            }
            return View(tblBarang);
        }

        // POST: TblBarangs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("KodeBarang,NamaBarang,Harga,Stok,Satuan")] TblBarang tblBarang)
        {
            if (id != tblBarang.KodeBarang)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblBarang);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblBarangExists(tblBarang.KodeBarang))
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
            return View(tblBarang);
        }

        // GET: TblBarangs/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblBarang = await _context.TblBarangs
                .FirstOrDefaultAsync(m => m.KodeBarang == id);
            if (tblBarang == null)
            {
                return NotFound();
            }

            return View(tblBarang);
        }

        // POST: TblBarangs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var tblBarang = await _context.TblBarangs.FindAsync(id);
            _context.TblBarangs.Remove(tblBarang);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblBarangExists(string id)
        {
            return _context.TblBarangs.Any(e => e.KodeBarang == id);
        }
    }
}
