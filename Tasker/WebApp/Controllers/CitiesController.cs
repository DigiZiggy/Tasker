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
    public class CitiesController : Controller
    {
        private readonly IAppUnitOfWork _uow;

        public CitiesController(IAppUnitOfWork uow)
        {
            _uow = uow;
        }
        // GET: Cities
        public async Task<IActionResult> Index()
        {
            var cities = await _uow.Cities.AllAsync();

            return View(cities);
        }

        // GET: Cities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var city = await _uow.Cities.FindAsync(id);

            if (city == null)
            {
                return NotFound();
            }

            return View(city);
        }

        // GET: Cities/Create
        public async Task<IActionResult> Create()
        {
            var vm = new CityCreateViewModel()
            {
                CountrySelectList = new SelectList(await _uow.BaseRepositoryAsync<Country>().AllAsync(), "Id", "Id"),
            };

            return View(vm);
        }

        // POST: Cities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CityCreateViewModel vm)
        {
            if (ModelState.IsValid)
            {
                await _uow.Cities.AddAsync(vm.City);
                await _uow.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            
            vm.CountrySelectList = new SelectList(await _uow.BaseRepositoryAsync<Country>().AllAsync(), "Id", "Id", vm.City.CountryId);

            return View(vm);
        }

        // GET: Cities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var city = await _uow.Cities.FindAsync(id);
            if (city == null)
            {
                return NotFound();
            }
            var vm = new CityEditViewModel()
            {
                CountrySelectList = new SelectList(await _uow.BaseRepositoryAsync<Country>().AllAsync(), "Id", "Id", city.CountryId),
            };
            
            return View(vm);
        }

        // POST: Cities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CityEditViewModel vm)
        {
            if (id != vm.City.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _uow.Cities.Update(vm.City);
                await _uow.SaveChangesAsync();
                    
                return RedirectToAction(nameof(Index));
            }
            
            vm.CountrySelectList = new SelectList(await _uow.BaseRepositoryAsync<Country>().AllAsync(), "Id", "Id", vm.City.CountryId);
            return View(vm);
        }

        // GET: Cities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var city = await _uow.Cities.FindAsync(id);
            if (city == null)
            {
                return NotFound();
            }

            return View(city);
        }

        // POST: Cities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            _uow.Cities.Remove(id);
            await _uow.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
