using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DAL;
using DAL.App.EF;
using Domain;

namespace WebApp.Controllers
{
    public class MeansOfPaymentsController : Controller
    {
        private readonly AppDbContext _context;

        public MeansOfPaymentsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: MeansOfPayments
        public async Task<IActionResult> Index()
        {
            return View(await _context.MeansOfPayments.ToListAsync());
        }

        // GET: MeansOfPayments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meansOfPayment = await _context.MeansOfPayments
                .FirstOrDefaultAsync(m => m.Id == id);
            if (meansOfPayment == null)
            {
                return NotFound();
            }

            return View(meansOfPayment);
        }

        // GET: MeansOfPayments/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MeansOfPayments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Comment,Id")] MeansOfPayment meansOfPayment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(meansOfPayment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(meansOfPayment);
        }

        // GET: MeansOfPayments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meansOfPayment = await _context.MeansOfPayments.FindAsync(id);
            if (meansOfPayment == null)
            {
                return NotFound();
            }
            return View(meansOfPayment);
        }

        // POST: MeansOfPayments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,Comment,Id")] MeansOfPayment meansOfPayment)
        {
            if (id != meansOfPayment.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(meansOfPayment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MeansOfPaymentExists(meansOfPayment.Id))
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
            return View(meansOfPayment);
        }

        // GET: MeansOfPayments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meansOfPayment = await _context.MeansOfPayments
                .FirstOrDefaultAsync(m => m.Id == id);
            if (meansOfPayment == null)
            {
                return NotFound();
            }

            return View(meansOfPayment);
        }

        // POST: MeansOfPayments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var meansOfPayment = await _context.MeansOfPayments.FindAsync(id);
            _context.MeansOfPayments.Remove(meansOfPayment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MeansOfPaymentExists(int id)
        {
            return _context.MeansOfPayments.Any(e => e.Id == id);
        }
    }
}
