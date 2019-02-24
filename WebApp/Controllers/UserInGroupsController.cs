using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DAL;
using Domain;

namespace WebApp.Controllers
{
    public class UserInGroupsController : Controller
    {
        private readonly AppDbContext _context;

        public UserInGroupsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: UserInGroups
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.UserInGroups.Include(u => u.User).Include(u => u.UserGroup);
            return View(await appDbContext.ToListAsync());
        }

        // GET: UserInGroups/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userInGroup = await _context.UserInGroups
                .Include(u => u.User)
                .Include(u => u.UserGroup)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userInGroup == null)
            {
                return NotFound();
            }

            return View(userInGroup);
        }

        // GET: UserInGroups/Create
        public IActionResult Create()
        {
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Email");
            ViewData["UserGroupId"] = new SelectList(_context.UserGroups, "Id", "Name");
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
                _context.Add(userInGroup);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Email", userInGroup.UserId);
            ViewData["UserGroupId"] = new SelectList(_context.UserGroups, "Id", "Name", userInGroup.UserGroupId);
            return View(userInGroup);
        }

        // GET: UserInGroups/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userInGroup = await _context.UserInGroups.FindAsync(id);
            if (userInGroup == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Email", userInGroup.UserId);
            ViewData["UserGroupId"] = new SelectList(_context.UserGroups, "Id", "Name", userInGroup.UserGroupId);
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
                try
                {
                    _context.Update(userInGroup);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserInGroupExists(userInGroup.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Email", userInGroup.UserId);
            ViewData["UserGroupId"] = new SelectList(_context.UserGroups, "Id", "Name", userInGroup.UserGroupId);
            return View(userInGroup);
        }

        // GET: UserInGroups/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userInGroup = await _context.UserInGroups
                .Include(u => u.User)
                .Include(u => u.UserGroup)
                .FirstOrDefaultAsync(m => m.Id == id);
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
            var userInGroup = await _context.UserInGroups.FindAsync(id);
            _context.UserInGroups.Remove(userInGroup);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserInGroupExists(int id)
        {
            return _context.UserInGroups.Any(e => e.Id == id);
        }
    }
}
