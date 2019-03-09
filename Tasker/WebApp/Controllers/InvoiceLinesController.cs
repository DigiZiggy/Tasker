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
    public class InvoiceLinesController : Controller
    {
        private readonly AppDbContext _context;

        public InvoiceLinesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: InvoiceLines
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.InvoiceLines.Include(i => i.Invoice).Include(i => i.Task);
            return View(await appDbContext.ToListAsync());
        }

        // GET: InvoiceLines/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invoiceLine = await _context.InvoiceLines
                .Include(i => i.Invoice)
                .Include(i => i.Task)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (invoiceLine == null)
            {
                return NotFound();
            }

            return View(invoiceLine);
        }

        // GET: InvoiceLines/Create
        public IActionResult Create()
        {
            ViewData["InvoiceId"] = new SelectList(_context.Invoices, "Id", "Id");
            ViewData["TaskId"] = new SelectList(_context.Tasks, "Id", "Address");
            return View();
        }

        // POST: InvoiceLines/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Price,Amount,VATpercentage,VAT,TotalWithoutVAT,Total,Comment,InvoiceId,TaskId,Id")] InvoiceLine invoiceLine)
        {
            if (ModelState.IsValid)
            {
                _context.Add(invoiceLine);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["InvoiceId"] = new SelectList(_context.Invoices, "Id", "Id", invoiceLine.InvoiceId);
            ViewData["TaskId"] = new SelectList(_context.Tasks, "Id", "Address", invoiceLine.TaskId);
            return View(invoiceLine);
        }

        // GET: InvoiceLines/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invoiceLine = await _context.InvoiceLines.FindAsync(id);
            if (invoiceLine == null)
            {
                return NotFound();
            }
            ViewData["InvoiceId"] = new SelectList(_context.Invoices, "Id", "Id", invoiceLine.InvoiceId);
            ViewData["TaskId"] = new SelectList(_context.Tasks, "Id", "Address", invoiceLine.TaskId);
            return View(invoiceLine);
        }

        // POST: InvoiceLines/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Price,Amount,VATpercentage,VAT,TotalWithoutVAT,Total,Comment,InvoiceId,TaskId,Id")] InvoiceLine invoiceLine)
        {
            if (id != invoiceLine.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(invoiceLine);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InvoiceLineExists(invoiceLine.Id))
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
            ViewData["InvoiceId"] = new SelectList(_context.Invoices, "Id", "Id", invoiceLine.InvoiceId);
            ViewData["TaskId"] = new SelectList(_context.Tasks, "Id", "Address", invoiceLine.TaskId);
            return View(invoiceLine);
        }

        // GET: InvoiceLines/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invoiceLine = await _context.InvoiceLines
                .Include(i => i.Invoice)
                .Include(i => i.Task)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (invoiceLine == null)
            {
                return NotFound();
            }

            return View(invoiceLine);
        }

        // POST: InvoiceLines/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var invoiceLine = await _context.InvoiceLines.FindAsync(id);
            _context.InvoiceLines.Remove(invoiceLine);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InvoiceLineExists(int id)
        {
            return _context.InvoiceLines.Any(e => e.Id == id);
        }
    }
}
