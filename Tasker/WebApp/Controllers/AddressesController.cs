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
    public class AddressesController : Controller
    {
        private readonly IAppUnitOfWork _uow;

        public AddressesController(IAppUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: Addresses
        public async Task<IActionResult> Index()
        {
            var addresses = await _uow.Addresses.AllAsync();

            return View(addresses);
        }

        // GET: Addresses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var address = await _uow.Addresses.FindAsync(id);
            
            if (address == null)
            {
                return NotFound();
            }

            return View(address);
        }

        // GET: Addresses/Create
        public IActionResult Create()
        {
            var vm = new AddressCreateViewModel()
            {
                CitySelectList = new SelectList(_uow.BaseRepository<City>().All(), "Id", "Id"),
            };
            return View(vm);
        }

        // POST: Addresses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AddressCreateViewModel vm)
        {
            if (ModelState.IsValid)
            {
                await _uow.Addresses.AddAsync(vm.Address);
                await _uow.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            
            vm.CitySelectList = new SelectList(await _uow.BaseRepository<City>().AllAsync(), "Id", "Id", vm.Address.CityId);

            return View(vm);
        }

        // GET: Addresses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var address = await _uow.Addresses.FindAsync(id);
            if (address == null)
            {
                return NotFound();
            }
            
            var vm = new AddressEditViewModel()
            {
                CitySelectList = new SelectList(_uow.BaseRepository<City>().All(), "Id", "Id", address.CityId),
            };
            
            return View(vm);
        }

        // POST: Addresses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, AddressEditViewModel vm)
        {
            if (id != vm.Address.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _uow.Addresses.Update(vm.Address);
                await _uow.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            
            vm.CitySelectList = new SelectList(await _uow.BaseRepository<City>().AllAsync(), "Id", "Id", vm.Address.CityId);
            return View(vm);
        }

        // GET: Addresses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var address = await _uow.Addresses.FindAsync(id);
            if (address == null)
            {
                return NotFound();
            }

            return View(address);
        }

        // POST: Addresses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            _uow.Addresses.Remove(id);
            await _uow.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
