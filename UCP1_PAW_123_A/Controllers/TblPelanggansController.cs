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
    public class TblPelanggansController : Controller
    {
        private readonly db_penjualanContext _context;

        public TblPelanggansController(db_penjualanContext context)
        {
            _context = context;
        }

        // GET: TblPelanggans
        public async Task<IActionResult> Index()
        {
            return View(await _context.TblPelanggans.ToListAsync());
        }

        // GET: TblPelanggans/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblPelanggan = await _context.TblPelanggans
                .FirstOrDefaultAsync(m => m.IdPelanggan == id);
            if (tblPelanggan == null)
            {
                return NotFound();
            }

            return View(tblPelanggan);
        }

        // GET: TblPelanggans/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TblPelanggans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPelanggan,NamaPelanggan,Alamat,NoTelepon")] TblPelanggan tblPelanggan)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblPelanggan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblPelanggan);
        }

        // GET: TblPelanggans/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblPelanggan = await _context.TblPelanggans.FindAsync(id);
            if (tblPelanggan == null)
            {
                return NotFound();
            }
            return View(tblPelanggan);
        }

        // POST: TblPelanggans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("IdPelanggan,NamaPelanggan,Alamat,NoTelepon")] TblPelanggan tblPelanggan)
        {
            if (id != tblPelanggan.IdPelanggan)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblPelanggan);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblPelangganExists(tblPelanggan.IdPelanggan))
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
            return View(tblPelanggan);
        }

        // GET: TblPelanggans/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblPelanggan = await _context.TblPelanggans
                .FirstOrDefaultAsync(m => m.IdPelanggan == id);
            if (tblPelanggan == null)
            {
                return NotFound();
            }

            return View(tblPelanggan);
        }

        // POST: TblPelanggans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var tblPelanggan = await _context.TblPelanggans.FindAsync(id);
            _context.TblPelanggans.Remove(tblPelanggan);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblPelangganExists(string id)
        {
            return _context.TblPelanggans.Any(e => e.IdPelanggan == id);
        }
    }
}
