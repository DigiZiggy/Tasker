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
    public class PricesController : Controller
    {
        private readonly IAppUnitOfWork _uow;

        public PricesController(IAppUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: Prices
        public async Task<IActionResult> Index()
        {
            var prices = await _uow.Prices.AllAsync();

            return View(prices);
        }

        // GET: Prices/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var price = await _uow.Prices.FindAsync(id);

            if (price == null)
            {
                return NotFound();
            }

            return View(price);
        }

        // GET: Prices/Create
        public async Task<IActionResult> Create()
        {
            var vm = new PriceCreateViewModel()
            {
                PriceListSelectList = new SelectList(await _uow.BaseRepository<PriceList>().AllAsync(), "Id", "FirstName"),

            };

            return View(vm);
        }

        // POST: Prices/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PriceCreateViewModel vm)
        {
            if (ModelState.IsValid)
            {
                await _uow.Prices.AddAsync(vm.Price);
                await _uow.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            
            vm.PriceListSelectList = new SelectList(await _uow.BaseRepository<PriceList>().AllAsync(), "Id",
                "Id", vm.Price.PriceListId);

            return View(vm);
        }

        // GET: Prices/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var price = await _uow.Prices.FindAsync(id);
            if (price == null)
            {
                return NotFound();
            }
            
            var vm = new PriceEditViewModel()
            {
                PriceListSelectList = new SelectList(await _uow.BaseRepository<PriceList>().AllAsync(), "Id", "FirstName", price.PriceListId),

            };

            return View(vm);
        }

        // POST: Prices/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, PriceEditViewModel vm)
        {
            if (id != vm.Price.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _uow.Prices.Update(vm.Price);
                await _uow.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            
            vm.PriceListSelectList = new SelectList(await _uow.BaseRepository<PriceList>().AllAsync(), "Id",
                "Id", vm.Price.PriceListId);

            return View(vm);
        }

        // GET: Prices/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var price = await _uow.Prices.FindAsync(id);
            if (price == null)
            {
                return NotFound();
            }

            return View(price);
        }

        // POST: Prices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            _uow.Prices.Remove(id);
            await _uow.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
