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
using Domain.Identity;
using Identity;
using WebApp.ViewModels;

namespace WebApp.Controllers
{
    public class UsersController : Controller
    {
        private readonly IAppUnitOfWork _uow;

        public UsersController(IAppUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: Users
        public async Task<IActionResult> Index()
        {
            var users = await _uow.Users.AllAsync(User.GetUserId());

            return View(users);
        }

        // GET: Users/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _uow.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // GET: Users/Create
        public IActionResult Create()
        {
            var vm = new UserCreateViewModel()
            {
                AppUserSelectList = new SelectList(_uow.BaseRepository<AppUser>().All(), "Id", "FirstName"),
                HourlyRateSelectList = new SelectList(_uow.BaseRepository<HourlyRate>().All(), "Id", "Id"),
                UserTypeSelectList = new SelectList(_uow.BaseRepository<UserType>().All(), "Id", "Id")

            };
            
            return View(vm);
        }

        // POST: Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UserCreateViewModel vm)
        {
            vm.User.AppUserId = User.GetUserId();
            
            if (ModelState.IsValid)
            {
                await _uow.Users.AddAsync(vm.User);
                await _uow.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            
            vm.AppUserSelectList = new SelectList(await _uow.BaseRepository<AppUser>().AllAsync(), "Id",
                "FirstName", vm.User.AppUserId);
            vm.UserTypeSelectList = new SelectList(await _uow.BaseRepository<UserType>().AllAsync(), "Id", "Id", vm.User.UserTypeId);
            vm.HourlyRateSelectList = new SelectList(await _uow.BaseRepository<HourlyRate>().AllAsync(), "Id", "Id", vm.User.HourlyRateId);

            return View(vm);
        }

        // GET: Users/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _uow.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            
            var vm = new UserEditViewModel()
            {
                AppUserSelectList = new SelectList(_uow.BaseRepository<AppUser>().All(), "Id", "FirstName", user.AppUserId),
                HourlyRateSelectList = new SelectList(_uow.BaseRepository<HourlyRate>().All(), "Id", "Id", user.HourlyRateId),
                UserTypeSelectList = new SelectList(_uow.BaseRepository<UserType>().All(), "Id", "Id", user.UserTypeId)

            };
            
            return View(vm);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, UserEditViewModel vm)
        {
            if (id != vm.User.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _uow.Users.Update(vm.User);
                await _uow.SaveChangesAsync();
                    
                return RedirectToAction(nameof(Index));
            }
            
            vm.AppUserSelectList = new SelectList(await _uow.BaseRepository<AppUser>().AllAsync(), "Id",
                "FirstName", vm.User.AppUserId);
            vm.UserTypeSelectList = new SelectList(await _uow.BaseRepository<UserType>().AllAsync(), "Id", "Id", vm.User.UserTypeId);
            vm.HourlyRateSelectList = new SelectList(await _uow.BaseRepository<HourlyRate>().AllAsync(), "Id", "Id", vm.User.HourlyRateId);

            return View(vm);
        }

        // GET: Users/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _uow.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            _uow.Users.Remove(id);
            await _uow.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
