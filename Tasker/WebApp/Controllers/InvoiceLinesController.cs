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
    public class InvoiceLinesController : Controller
    {
        private readonly IAppUnitOfWork _uow;

        public InvoiceLinesController(IAppUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: InvoiceLines
        public async Task<IActionResult> Index()
        {
            
            var invoiceLines = await _uow.InvoiceLines.AllAsync();

//            var appDbContext = _context.InvoiceLines
//                .Include(i => i.Invoice)
//                .Include(i => i.Task);
            
            return View(invoiceLines);
        }

        // GET: InvoiceLines/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

//            var invoiceLine = await _context.InvoiceLines
//                .Include(i => i.Invoice)
//                .Include(i => i.Task)
//                .FirstOrDefaultAsync(m => m.Id == id);

            var invoiceLine = await _uow.InvoiceLines.FindAsync(id);

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
            ViewData["TaskId"] = new SelectList(_context.Tasks, "Id", "Id");
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
                await _uow.InvoiceLines.AddAsync(invoiceLine);
                await _uow.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["InvoiceId"] = new SelectList(_context.Invoices, "Id", "Id", invoiceLine.InvoiceId);
            ViewData["TaskId"] = new SelectList(_context.Tasks, "Id", "Id", invoiceLine.TaskId);
            return View(invoiceLine);
        }

        // GET: InvoiceLines/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invoiceLine = await _uow.InvoiceLines.FindAsync(id);
            if (invoiceLine == null)
            {
                return NotFound();
            }
            ViewData["InvoiceId"] = new SelectList(_context.Invoices, "Id", "Id", invoiceLine.InvoiceId);
            ViewData["TaskId"] = new SelectList(_context.Tasks, "Id", "Id", invoiceLine.TaskId);
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
                _uow.InvoiceLines.Update(invoiceLine);
                await _uow.SaveChangesAsync();
                    
                return RedirectToAction(nameof(Index));
            }
            ViewData["InvoiceId"] = new SelectList(_context.Invoices, "Id", "Id", invoiceLine.InvoiceId);
            ViewData["TaskId"] = new SelectList(_context.Tasks, "Id", "Id", invoiceLine.TaskId);
            return View(invoiceLine);
        }

        // GET: InvoiceLines/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invoiceLine = await _uow.InvoiceLines.FindAsync(id);
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
            _uow.InvoiceLines.Remove(id);
            await _uow.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
