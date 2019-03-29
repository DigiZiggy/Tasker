using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.DAL.App;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DAL.App.EF;
using Domain;

namespace WebApp.Controllers
{
    public class HourlyRatesController : Controller
    {
        private readonly IAppUnitOfWork _uow;

        public HourlyRatesController(IAppUnitOfWork uow)
        {
            _uow = uow;
        }
        // GET: HourlyRates
        public async Task<IActionResult> Index()
        {
            var hourlyRates = await _uow.HourlyRates.AllAsync();

//            var appDbContext = _context.HourlyRates.Include(h => h.PriceList);
            return View(hourlyRates);
        }

        // GET: HourlyRates/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

//            var hourlyRate = await _context.HourlyRates
//                .Include(h => h.PriceList)
//                .FirstOrDefaultAsync(m => m.Id == id);

            var hourlyRate = await _uow.HourlyRates.FindAsync(id);

            if (hourlyRate == null)
            {
                return NotFound();
            }

            return View(hourlyRate);
        }

        // GET: HourlyRates/Create
        public IActionResult Create()
        {
            ViewData["PriceListId"] = new SelectList(_context.PriceLists, "Id", "Id");
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
                await _uow.HourlyRates.AddAsync(hourlyRate);
                await _uow.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PriceListId"] = new SelectList(_context.PriceLists, "Id", "Id", hourlyRate.PriceListId);
            return View(hourlyRate);
        }

        // GET: HourlyRates/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hourlyRate = await _uow.HourlyRates.FindAsync(id);
            if (hourlyRate == null)
            {
                return NotFound();
            }
            ViewData["PriceListId"] = new SelectList(_context.PriceLists, "Id", "Id", hourlyRate.PriceListId);
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
                _uow.HourlyRates.Update(hourlyRate);
                await _uow.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            ViewData["PriceListId"] = new SelectList(_context.PriceLists, "Id", "Id", hourlyRate.PriceListId);
            return View(hourlyRate);
        }

        // GET: HourlyRates/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hourlyRate = await _uow.HourlyRates.FindAsync(id);
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
            _uow.HourlyRates.Remove(id);
            await _uow.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
