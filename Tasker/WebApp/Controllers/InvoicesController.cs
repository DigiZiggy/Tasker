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
    public class InvoicesController : Controller
    {
        private readonly IAppUnitOfWork _uow;

        public InvoicesController(IAppUnitOfWork uow)
        {
            _uow = uow;
        }
        // GET: Invoices
        public async Task<IActionResult> Index()
        {
            var invoices = await _uow.Invoices.AllAsync();

            return View(invoices);
        }

        // GET: Invoices/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invoice = await _uow.Invoices.FindAsync(id);

            if (invoice == null)
            {
                return NotFound();
            }

            return View(invoice);
        }

        // GET: Invoices/Create
        public async Task<IActionResult> Create()
        {
            var vm = new InvoiceCreateViewModel()
            {
                UserSelectList = new SelectList(await _uow.BaseRepositoryAsync<User>().AllAsync(), "Id", "Id"),

            };
            
            return View(vm);
        }

        // POST: Invoices/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(InvoiceCreateViewModel vm)
        {
            if (ModelState.IsValid)
            {
                await _uow.Invoices.AddAsync(vm.Invoice);
                await _uow.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            
            vm.UserSelectList = new SelectList(await _uow.BaseRepositoryAsync<User>().AllAsync(), "Id",
                "Id", vm.Invoice.UserId);

            return View(vm);
        }

        // GET: Invoices/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invoice = await _uow.Invoices.FindAsync(id);
            if (invoice == null)
            {
                return NotFound();
            }
            
            var vm = new InvoiceEditViewModel()
            {
                UserSelectList = new SelectList(await _uow.BaseRepositoryAsync<User>().AllAsync(), "Id", "Id", invoice.UserId),

            };
            
            return View(vm);
        }

        // POST: Invoices/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, InvoiceEditViewModel vm)
        {
            if (id != vm.Invoice.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _uow.Invoices.Update(vm.Invoice);
                await _uow.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            vm.UserSelectList = new SelectList(await _uow.BaseRepositoryAsync<User>().AllAsync(), "Id",
                "Id", vm.Invoice.UserId);
            
            return View(vm);
        }

        // GET: Invoices/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invoice = await _uow.Invoices.FindAsync(id);
            if (invoice == null)
            {
                return NotFound();
            }

            return View(invoice);
        }

        // POST: Invoices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            _uow.Invoices.Remove(id);
            await _uow.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
