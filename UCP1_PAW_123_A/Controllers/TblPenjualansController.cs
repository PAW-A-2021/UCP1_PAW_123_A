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
    public class TblPenjualansController : Controller
    {
        private readonly db_penjualanContext _context;

        public TblPenjualansController(db_penjualanContext context)
        {
            _context = context;
        }

        // GET: TblPenjualans
        public async Task<IActionResult> Index()
        {
            var db_penjualanContext = _context.TblPenjualans.Include(t => t.IdPelangganNavigation);
            return View(await db_penjualanContext.ToListAsync());
        }

        // GET: TblPenjualans/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblPenjualan = await _context.TblPenjualans
                .Include(t => t.IdPelangganNavigation)
                .FirstOrDefaultAsync(m => m.NoKwitansi == id);
            if (tblPenjualan == null)
            {
                return NotFound();
            }

            return View(tblPenjualan);
        }

        // GET: TblPenjualans/Create
        public IActionResult Create()
        {
            ViewData["IdPelanggan"] = new SelectList(_context.TblPelanggans, "IdPelanggan", "IdPelanggan");
            return View();
        }

        // POST: TblPenjualans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NoKwitansi,TglKwitansi,IdPelanggan")] TblPenjualan tblPenjualan)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblPenjualan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdPelanggan"] = new SelectList(_context.TblPelanggans, "IdPelanggan", "IdPelanggan", tblPenjualan.IdPelanggan);
            return View(tblPenjualan);
        }

        // GET: TblPenjualans/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblPenjualan = await _context.TblPenjualans.FindAsync(id);
            if (tblPenjualan == null)
            {
                return NotFound();
            }
            ViewData["IdPelanggan"] = new SelectList(_context.TblPelanggans, "IdPelanggan", "IdPelanggan", tblPenjualan.IdPelanggan);
            return View(tblPenjualan);
        }

        // POST: TblPenjualans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("NoKwitansi,TglKwitansi,IdPelanggan")] TblPenjualan tblPenjualan)
        {
            if (id != tblPenjualan.NoKwitansi)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblPenjualan);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblPenjualanExists(tblPenjualan.NoKwitansi))
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
            ViewData["IdPelanggan"] = new SelectList(_context.TblPelanggans, "IdPelanggan", "IdPelanggan", tblPenjualan.IdPelanggan);
            return View(tblPenjualan);
        }

        // GET: TblPenjualans/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblPenjualan = await _context.TblPenjualans
                .Include(t => t.IdPelangganNavigation)
                .FirstOrDefaultAsync(m => m.NoKwitansi == id);
            if (tblPenjualan == null)
            {
                return NotFound();
            }

            return View(tblPenjualan);
        }

        // POST: TblPenjualans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var tblPenjualan = await _context.TblPenjualans.FindAsync(id);
            _context.TblPenjualans.Remove(tblPenjualan);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblPenjualanExists(string id)
        {
            return _context.TblPenjualans.Any(e => e.NoKwitansi == id);
        }
    }
}
