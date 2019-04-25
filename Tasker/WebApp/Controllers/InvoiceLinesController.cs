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
using WebApp.ViewModels;

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
            
            return View(invoiceLines);
        }

        // GET: InvoiceLines/Details/5
        public async Task<IActionResult> Details(int? id)
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

        // GET: InvoiceLines/Create
        public async Task<IActionResult> Create()
        {
            var vm = new InvoiceLinesCreateViewModel()
            {
                InvoiceSelectList = new SelectList(await _uow.BaseRepositoryAsync<Invoice>().AllAsync(), "Id", "Id"),
                TaskSelectList = new SelectList(await _uow.BaseRepositoryAsync<Domain.Task>().AllAsync(), "Id", "Id"),
            };
            
            return View(vm);
        }

        // POST: InvoiceLines/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(InvoiceLinesCreateViewModel vm)
        {
            if (ModelState.IsValid)
            {
                await _uow.InvoiceLines.AddAsync(vm.InvoiceLine);
                await _uow.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
                                 
            vm.InvoiceSelectList = new SelectList(await _uow.BaseRepositoryAsync<Invoice>().AllAsync(), "Id",
                "Id", vm.InvoiceLine.InvoiceId);
            vm.TaskSelectList = new SelectList(await _uow.BaseRepositoryAsync<Domain.Task>().AllAsync(), "Id",
                "Id", vm.InvoiceLine.TaskId);
            
            return View(vm);
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
            
            var vm = new InvoiceLinesEditViewModel()
            {
                InvoiceSelectList = new SelectList(await _uow.BaseRepositoryAsync<Invoice>().AllAsync(), "Id", "Id", invoiceLine.InvoiceId),
                TaskSelectList = new SelectList(await _uow.BaseRepositoryAsync<Domain.Task>().AllAsync(), "Id", "Id", invoiceLine.TaskId),
            };
            
            return View(vm);
        }

        // POST: InvoiceLines/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, InvoiceLinesEditViewModel vm)
        {
            if (id != vm.InvoiceLine.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _uow.InvoiceLines.Update(vm.InvoiceLine);
                await _uow.SaveChangesAsync();
                    
                return RedirectToAction(nameof(Index));
            }
            
            vm.InvoiceSelectList = new SelectList(await _uow.BaseRepositoryAsync<Invoice>().AllAsync(), "Id",
                "Id", vm.InvoiceLine.InvoiceId);
            vm.TaskSelectList = new SelectList(await _uow.BaseRepositoryAsync<Domain.Task>().AllAsync(), "Id",
                "Id", vm.InvoiceLine.TaskId);

            return View(vm);
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
