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
    public class IdentificationsController : Controller
    {
        private readonly IAppBLL _bll;

        public IdentificationsController(IAppBLL bll)
        {
            _bll = bll;
        }

        // GET: Identifications
        public async Task<IActionResult> Index()
        {
            var identifications = await _bll.Identifications.AllAsync();
            return View(identifications);
        }

        // GET: Identifications/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var identification = await _bll.Identifications.FindAllIncludedAsync(id);

            if (identification == null)
            {
                return NotFound();
            }

            return View(identification);
        }

        // GET: Identifications/Create
        public async Task<IActionResult> Create()
        {
            var vm = new IdentificationCreateViewModel()
            {
                AppUserSelectList = new SelectList(await _bll.AppUsers.AllAsync(), nameof(AppUser.Id), nameof(AppUser.Id))
            };
            
            return View(vm);
        }

        // POST: Identifications/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(IdentificationCreateViewModel vm)
        {
            if (ModelState.IsValid)
            {
                await _bll.Identifications.AddAsync(vm.Identification);
                await _bll.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            vm.AppUserSelectList = new SelectList(await _bll.AppUsers.AllAsync(), nameof(AppUser.Id),
                nameof(AppUser.Id), vm.Identification.AppUserId);
      
            return View(vm);
        }

        // GET: Identifications/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var identification = await _bll.Identifications.FindAsync(id);
            if (identification == null)
            {
                return NotFound();
            }
            var vm = new IdentificationEditViewModel()
            {
                AppUserSelectList = new SelectList(await _bll.AppUsers.AllAsync(), nameof(AppUser.Id), 
                    nameof(AppUser.Id), identification.AppUserId),
            };
           
            return View(vm);

        }

        // POST: Identifications/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, IdentificationEditViewModel vm)
        {
            if (id != vm.Identification.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _bll.Identifications.Update(vm.Identification);
                await _bll.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            vm.AppUserSelectList = new SelectList(await _bll.AppUsers.AllAsync(), nameof(AppUser.Id),
                nameof(AppUser.Id), vm.Identification.AppUserId);
        
            return View(vm);
        }

        // GET: Identifications/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var identification = await _bll.Identifications.FindAllIncludedAsync(id);

            if (identification == null)
            {
                return NotFound();
            }

            return View(identification);
        }

        // POST: Identifications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            _bll.Identifications.Remove(id);
            await _bll.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
