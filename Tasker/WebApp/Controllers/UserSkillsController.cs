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
    public class UserSkillsController : Controller
    {
        private readonly IAppBLL _bll;

        public UserSkillsController(IAppBLL bll)
        {
            _bll = bll;
        }

        // GET: UserSkills
        public async Task<IActionResult> Index()
        {
            var userSkills = await _bll.UserSkills.AllAsync();

            return View(userSkills);
        }

        // GET: UserSkills/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userSkill = await _bll.UserSkills.FindAllIncludedAsync(id);


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
                AppUserSelectList = new SelectList(await _bll.AppUsers.AllAsync(), 
                    nameof(BLL.App.DTO.Identity.AppUser.Id), 
                    nameof(BLL.App.DTO.Identity.AppUser.Id)),
                SkillSelectList = new SelectList(await _bll.Skills.AllAsync(), 
                    nameof(BLL.App.DTO.Skill.Id), 
                    nameof(BLL.App.DTO.Skill.Id)),

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
                await _bll.UserSkills.AddAsync(vm.UserSkill);
                await _bll.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            vm.AppUserSelectList = new SelectList(await _bll.AppUsers.AllAsync(), 
                nameof(BLL.App.DTO.Identity.AppUser.Id),
                nameof(BLL.App.DTO.Identity.AppUser.Id), 
                vm.UserSkill.AppUserId);
            vm.SkillSelectList = new SelectList(await _bll.Skills.AllAsync(), 
                nameof(BLL.App.DTO.Skill.Id), 
                nameof(BLL.App.DTO.Skill.Id), 
                vm.UserSkill.SkillId);

            return View(vm);
        }

        // GET: UserSkills/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userSkill = await _bll.UserSkills.FindAsync(id);
            if (userSkill == null)
            {
                return NotFound();
            }
            var vm = new UserSkillEditViewModel()
            {
                AppUserSelectList = new SelectList(await _bll.AppUsers.AllAsync(), 
                    nameof(BLL.App.DTO.Identity.AppUser.Id), 
                    nameof(BLL.App.DTO.Identity.AppUser.Id), 
                    userSkill.AppUserId),
                SkillSelectList = new SelectList(await _bll.Skills.AllAsync(), 
                    nameof(BLL.App.DTO.Skill.Id), 
                    nameof(BLL.App.DTO.Skill.Id), 
                    userSkill.SkillId),
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
                _bll.UserSkills.Update(vm.UserSkill);
                await _bll.SaveChangesAsync();
                    
                return RedirectToAction(nameof(Index));
            }
            vm.AppUserSelectList = new SelectList(await _bll.AppUsers.AllAsync(), 
                nameof(BLL.App.DTO.Identity.AppUser.Id),
                nameof(BLL.App.DTO.Identity.AppUser.Id), 
                vm.UserSkill.AppUserId);
            vm.SkillSelectList = new SelectList(await _bll.Skills.AllAsync(), 
                nameof(BLL.App.DTO.Skill.Id), 
                nameof(BLL.App.DTO.Skill.Id), 
                vm.UserSkill.SkillId);
            
            return View(vm);

        }

        // GET: UserSkills/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userSkill = await _bll.UserSkills.FindAllIncludedAsync(id);

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
            _bll.UserSkills.Remove(id);
            await _bll.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
