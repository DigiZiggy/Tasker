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
    public class PaymentsController : Controller
    {
        private readonly IAppUnitOfWork _uow;

        public PaymentsController(IAppUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: Payments
        public async Task<IActionResult> Index()
        {
            var payments = await _uow.Payments.AllAsync();

            return View(payments);
        }

        // GET: Payments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var payment = await _uow.Payments.FindAllIncludedAsync(id);

            if (payment == null)
            {
                return NotFound();
            }

            return View(payment);
        }

        // GET: Payments/Create
        public async Task<IActionResult> Create()
        {
            var vm = new PaymentCreateViewModel()
            {
                InvoiceSelectList = new SelectList(await _uow.BaseRepositoryAsync<Invoice>().AllAsync(), "Id", "Id"),

            };

            return View(vm);
        }

        // POST: Payments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PaymentCreateViewModel vm)
        {
            if (ModelState.IsValid)
            {
                await _uow.Payments.AddAsync(vm.Payment);
                await _uow.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            vm.InvoiceSelectList = new SelectList(await _uow.BaseRepositoryAsync<Invoice>().AllAsync(), "Id",
                "Id", vm.Payment.InvoiceId);

            return View(vm);

        }

        // GET: Payments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var payment = await _uow.Payments.FindAsync(id);
            if (payment == null)
            {
                return NotFound();
            }
            var vm = new PaymentEditViewModel()
            {
                InvoiceSelectList = new SelectList(await _uow.BaseRepositoryAsync<Invoice>().AllAsync(), "Id", "Id", payment.InvoiceId),

            };

            return View(vm);
        }

        // POST: Payments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, PaymentEditViewModel vm)
        {
            if (id != vm.Payment.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _uow.Payments.Update(vm.Payment);
                await _uow.SaveChangesAsync();
      
                return RedirectToAction(nameof(Index));
            }
                 
            vm.InvoiceSelectList = new SelectList(await _uow.BaseRepositoryAsync<Invoice>().AllAsync(), "Id",
                "Id", vm.Payment.InvoiceId);
            
            return View(vm);
        }

        // GET: Payments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var payment = await _uow.Payments.FindAllIncludedAsync(id);

            if (payment == null)
            {
                return NotFound();
            }

            return View(payment);
        }

        // POST: Payments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            _uow.Payments.Remove(id);
            await _uow.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
