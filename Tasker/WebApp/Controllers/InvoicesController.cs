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
using Domain.Identity;
using WebApp.ViewModels;

namespace WebApp.Controllers
{
    public class InvoicesController : Controller
    {
        private readonly IAppBLL _bll;

        public InvoicesController(IAppBLL bll)
        {
            _bll = bll;
        }

        // GET: Invoices
        public async Task<IActionResult> Index()
        {
            return View(await _bll.Invoices.AllAsync());
        }

        // GET: Invoices/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invoice = await _bll.Invoices.FindAsync(id);

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
                AppUserSelectList = new SelectList(await _bll.AppUsers.AllAsync(), 
                    nameof(BLL.App.DTO.Identity.AppUser.Id), 
                    nameof(BLL.App.DTO.Identity.AppUser.Id))
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
                _bll.Invoices.Add(vm.Invoice);
                await _bll.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            vm.AppUserSelectList = new SelectList(await _bll.AppUsers.AllAsync(), 
                nameof(BLL.App.DTO.Identity.AppUser.Id),
                nameof(BLL.App.DTO.Identity.AppUser.Id), 
                vm.Invoice.AppUserId);

            return View(vm);

        }

        // GET: Invoices/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invoice = await _bll.Invoices.FindAsync(id);
            if (invoice == null)
            {
                return NotFound();
            }
            var vm = new InvoiceEditViewModel()
            {
                AppUserSelectList = new SelectList(await _bll.AppUsers.AllAsync(), 
                    nameof(BLL.App.DTO.Identity.AppUser.Id), 
                    nameof(BLL.App.DTO.Identity.AppUser.Id), 
                    invoice.AppUserId)
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
                _bll.Invoices.Update(vm.Invoice);
                await _bll.SaveChangesAsync();
  
                return RedirectToAction(nameof(Index));
            }
            vm.AppUserSelectList = new SelectList(await _bll.AppUsers.AllAsync(), 
                nameof(BLL.App.DTO.Identity.AppUser.Id),
                nameof(BLL.App.DTO.Identity.AppUser.Id), 
                vm.Invoice.AppUserId);
            
            return View(vm);

        }

        // GET: Invoices/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invoice = await _bll.Invoices.FindAsync(id);

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
            _bll.Invoices.Remove(id);
            await _bll.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
