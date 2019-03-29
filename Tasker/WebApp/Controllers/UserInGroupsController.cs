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

namespace WebApp.Controllers
{
    public class UserInGroupsController : Controller
    {
        private readonly IAppUnitOfWork _uow;

        public UserInGroupsController(IAppUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: UserInGroups
        public async Task<IActionResult> Index()
        {
            var userInGroups = await _uow.UserInGroups.AllAsync();

//            var appDbContext = _context.UserInGroups
//                .Include(u => u.User)
//                .Include(u => u.UserGroup);
            return View(userInGroups);
        }

        // GET: UserInGroups/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

//            var userInGroup = await _context.UserInGroups
//                .Include(u => u.User)
//                .Include(u => u.UserGroup)
//                .FirstOrDefaultAsync(m => m.Id == id);

            var userInGroup = await _uow.UserInGroups.FindAsync(id);

            if (userInGroup == null)
            {
                return NotFound();
            }

            return View(userInGroup);
        }

        // GET: UserInGroups/Create
        public IActionResult Create()
        {
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id");
            ViewData["UserGroupId"] = new SelectList(_context.UserGroups, "Id", "Id");
            return View();
        }

        // POST: UserInGroups/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Start,End,UserId,UserGroupId,Id")] UserInGroup userInGroup)
        {
            if (ModelState.IsValid)
            {
                await _uow.UserInGroups.AddAsync(userInGroup);
                await _uow.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", userInGroup.UserId);
            ViewData["UserGroupId"] = new SelectList(_context.UserGroups, "Id", "Id", userInGroup.UserGroupId);
            return View(userInGroup);
        }

        // GET: UserInGroups/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userInGroup = await _uow.UserInGroups.FindAsync(id);
            if (userInGroup == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", userInGroup.UserId);
            ViewData["UserGroupId"] = new SelectList(_context.UserGroups, "Id", "Id", userInGroup.UserGroupId);
            return View(userInGroup);
        }

        // POST: UserInGroups/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Start,End,UserId,UserGroupId,Id")] UserInGroup userInGroup)
        {
            if (id != userInGroup.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _uow.UserInGroups.Update(userInGroup);
                await _uow.SaveChangesAsync();
   
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", userInGroup.UserId);
            ViewData["UserGroupId"] = new SelectList(_context.UserGroups, "Id", "Id", userInGroup.UserGroupId);
            return View(userInGroup);
        }

        // GET: UserInGroups/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userInGroup = await _uow.UserInGroups.FindAsync(id);
            if (userInGroup == null)
            {
                return NotFound();
            }

            return View(userInGroup);
        }

        // POST: UserInGroups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            _uow.UserInGroups.Remove(id);
            await _uow.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
