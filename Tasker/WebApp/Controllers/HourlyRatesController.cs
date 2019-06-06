using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.BLL.App;
using Contracts.DAL.App;
using DAL.App.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DAL.App.EF;
using Domain;

namespace WebApp.Controllers
{
    public class HourlyRatesController : Controller
    {
        private readonly IAppBLL _bll;

        public HourlyRatesController(IAppBLL bll)
        {
            _bll = bll;
        }

        // GET: HourlyRates
        public async Task<IActionResult> Index()
        {
            return View(await _bll.HourlyRates.AllAsync());
        }

        // GET: HourlyRates/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hourlyRate = await _bll.HourlyRates.FindAsync(id);

            if (hourlyRate == null)
            {
                return NotFound();
            }

            return View(hourlyRate);
        }

        // GET: HourlyRates/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: HourlyRates/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HourRate,Start,End,Id")] BLL.App.DTO.HourlyRate hourlyRate)
        {
            if (ModelState.IsValid)
            {
                _bll.HourlyRates.Add(hourlyRate);
                await _bll.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hourlyRate);
        }

        // GET: HourlyRates/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hourlyRate = await _bll.HourlyRates.FindAsync(id);
            if (hourlyRate == null)
            {
                return NotFound();
            }
            return View(hourlyRate);
        }

        // POST: HourlyRates/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("HourRate,Start,End,Id")] BLL.App.DTO.HourlyRate hourlyRate)
        {
            if (id != hourlyRate.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _bll.HourlyRates.Update(hourlyRate);
                await _bll.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            return View(hourlyRate);
        }

        // GET: HourlyRates/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hourlyRate = await _bll.HourlyRates.FindAsync(id);
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
            _bll.HourlyRates.Remove(id);
            await _bll.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
