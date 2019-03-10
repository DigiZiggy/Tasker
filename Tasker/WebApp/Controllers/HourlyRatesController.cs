using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DAL.App.EF;
using Domain;

namespace WebApp.Controllers
{
    public class HourlyRatesController : Controller
    {
        private readonly AppDbContext _context;

        public HourlyRatesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: HourlyRates
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.HourlyRates.Include(h => h.PriceList);
            return View(await appDbContext.ToListAsync());
        }

        // GET: HourlyRates/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hourlyRate = await _context.HourlyRates
                .Include(h => h.PriceList)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hourlyRate == null)
            {
                return NotFound();
            }

            return View(hourlyRate);
        }

        // GET: HourlyRates/Create
        public IActionResult Create()
        {
            ViewData["PriceListId"] = new SelectList(_context.PriceLists, "Id", "Name");
            return View();
        }

        // POST: HourlyRates/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HourRate,Start,End,PriceListId,Id")] HourlyRate hourlyRate)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hourlyRate);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PriceListId"] = new SelectList(_context.PriceLists, "Id", "Name", hourlyRate.PriceListId);
            return View(hourlyRate);
        }

        // GET: HourlyRates/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hourlyRate = await _context.HourlyRates.FindAsync(id);
            if (hourlyRate == null)
            {
                return NotFound();
            }
            ViewData["PriceListId"] = new SelectList(_context.PriceLists, "Id", "Name", hourlyRate.PriceListId);
            return View(hourlyRate);
        }

        // POST: HourlyRates/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("HourRate,Start,End,PriceListId,Id")] HourlyRate hourlyRate)
        {
            if (id != hourlyRate.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hourlyRate);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HourlyRateExists(hourlyRate.Id))
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
            ViewData["PriceListId"] = new SelectList(_context.PriceLists, "Id", "Name", hourlyRate.PriceListId);
            return View(hourlyRate);
        }

        // GET: HourlyRates/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hourlyRate = await _context.HourlyRates
                .Include(h => h.PriceList)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hourlyRate == null)
            {
                return NotFound();
            }

            return View(hourlyRate);
        }

        // POST: HourlyRates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hourlyRate = await _context.HourlyRates.FindAsync(id);
            _context.HourlyRates.Remove(hourlyRate);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HourlyRateExists(int id)
        {
            return _context.HourlyRates.Any(e => e.Id == id);
        }
    }
}
