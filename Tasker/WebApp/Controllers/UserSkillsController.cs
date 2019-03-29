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
using Identity;
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

//            var appDbContext = _context.UserSkills
//                .Include(u => u.AppUser)
//                .Include(u => u.Skill)
//                .Include(u => u.User);
            return View(userSkills);
        }

        // GET: UserSkills/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

//            var userSkill = await _context.UserSkills
//                .Include(u => u.AppUser)
//                .Include(u => u.Skill)
//                .Include(u => u.User)
//                .FirstOrDefaultAsync(m => m.Id == id);

            var userSkill = await _uow.UserSills.FindAsync(id);

            if (userSkill == null)
            {
                return NotFound();
            }

            return View(userSkill);
        }

        // GET: UserSkills/Create
        public IActionResult Create()
        {
            var vm = new UserSkillCreateViewModel()
            {
                UserSelectList = new SelectList(_uow.Users.Where(p => p.AppUserId == User.GetUserId()), "Id", "FirstName"),
                SkillSelectList = new SelectList(_uow.Skills, "Id", "Id"),
                AppUserSelectList = new SelectList(_uow.Users, "Id", "Id")

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

            vm.UserSelectList = new SelectList(_uow.Users.Where(p => p.AppUserId == User.GetUserId()), "Id",
                "FirstName", vm.UserSkill.UserId);
            vm.SkillSelectList = new SelectList(_uow.Skills, "Id", "Id", vm.UserSkill.SkillId);
            vm.AppUserSelectList = new SelectList(_uow.Users, "Id", "Id", vm.UserSkill.AppUserId);

//            ViewData["AppUserId"] = new SelectList(_context.Users, "Id", "FirstName", userSkill.AppUserId);
//            ViewData["SkillId"] = new SelectList(_context.Skills, "Id", "Id", userSkill.SkillId);
//            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", userSkill.UserId);
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
            ViewData["AppUserId"] = new SelectList(_context.Users, "Id", "FirstName", userSkill.AppUserId);
            ViewData["SkillId"] = new SelectList(_context.Skills, "Id", "Id", userSkill.SkillId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", userSkill.UserId);
            return View(userSkill);
        }

        // POST: UserSkills/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,Start,End,Comment,UserId,SkillId,AppUserId,Id")] UserSkill userSkill)
        {
            if (id != userSkill.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _uow.UserSills.Update(userSkill);
                await _uow.SaveChangesAsync();
                    
                return RedirectToAction(nameof(Index));
            }
            ViewData["AppUserId"] = new SelectList(_context.Users, "Id", "FirstName", userSkill.AppUserId);
            ViewData["SkillId"] = new SelectList(_context.Skills, "Id", "Id", userSkill.SkillId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", userSkill.UserId);
            return View(userSkill);
        }

        // GET: UserSkills/Delete/5
        public async Task<IActionResult> Delete(int? id)
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
