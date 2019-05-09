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
using WebApp.ViewModels;

namespace WebApp.Controllers
{
    public class UserSkillsController : Controller
    {
        private readonly IAppUnitOfWork _uow;

        public UserSkillsController(IAppUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: UserSkills
        public async Task<IActionResult> Index()
        {
            var userSkills = await _uow.UserSills.AllAsync();

            return View(userSkills);
        }

        // GET: UserSkills/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userSkill = await _uow.UserSills.FindAllIncludedAsync(id);


            if (userSkill == null)
            {
                return NotFound();
            }

            return View(userSkill);
        }

        // GET: UserSkills/Create
        public async Task<IActionResult> Create()
        {
            var vm = new UserSkillCreateViewModel()
            {
                AppUserSelectList = new SelectList(await _uow.BaseRepositoryAsync<AppUser>().AllAsync(), "Id", "Id"),
                SkillSelectList = new SelectList(await _uow.BaseRepositoryAsync<Skill>().AllAsync(), "Id", "Id"),

            };
            return View(vm);
        }


        // POST: UserSkills/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UserSkillCreateViewModel vm)
        {
            if (ModelState.IsValid)
            {
                await _uow.UserSills.AddAsync(vm.UserSkill);
                await _uow.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            vm.AppUserSelectList = new SelectList(await _uow.BaseRepositoryAsync<AppUser>().AllAsync(), "Id",
                "Id", vm.UserSkill.AppUserId);
            vm.SkillSelectList = new SelectList(await _uow.BaseRepositoryAsync<Skill>().AllAsync(), "Id", "Id", vm.UserSkill.SkillId);

            return View(vm);
        }

        // GET: UserSkills/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userSkill = await _uow.UserSills.FindAsync(id);
            if (userSkill == null)
            {
                return NotFound();
            }
            var vm = new UserSkillEditViewModel()
            {
                AppUserSelectList = new SelectList(await _uow.BaseRepositoryAsync<AppUser>().AllAsync(), "Id", "Id", userSkill.AppUserId),
                SkillSelectList = new SelectList(await _uow.BaseRepositoryAsync<Skill>().AllAsync(), "Id", "Id", userSkill.SkillId),
            };

            return View(vm);
        }

        // POST: UserSkills/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, UserSkillEditViewModel vm)
        {
            if (id != vm.UserSkill.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _uow.UserSills.Update(vm.UserSkill);
                await _uow.SaveChangesAsync();
                    
                return RedirectToAction(nameof(Index));
            }
            vm.AppUserSelectList = new SelectList(await _uow.BaseRepositoryAsync<AppUser>().AllAsync(), "Id",
                "Id", vm.UserSkill.AppUserId);
            vm.SkillSelectList = new SelectList(await _uow.BaseRepositoryAsync<Skill>().AllAsync(), "Id", "Id", vm.UserSkill.SkillId);
            
            return View(vm);

        }

        // GET: UserSkills/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userSkill = await _uow.UserSills.FindAllIncludedAsync(id);

            if (userSkill == null)
            {
                return NotFound();
            }

            return View(userSkill);
        }

        // POST: UserSkills/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            _uow.UserSills.Remove(id);
            await _uow.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
