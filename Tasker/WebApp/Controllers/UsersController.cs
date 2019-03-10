using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.DAL.App;
using Contracts.DAL.App.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DAL.App.EF;
using Domain;
using Domain.Identity;
using Identity;
using Microsoft.AspNetCore.Authorization;

namespace WebApp.Controllers
{
    [Authorize]
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
//            var users = await _context.Users
//                .Include(u => u.AppUser)
//                .Include(u => u.HourlyRate)
//                .Include(u => u.UserType)
//                .Where(u => u.AppUserId == User.GetUserId()).ToListAsync();
//            
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

//            var user = await _context.Users
//                .Include(u => u.AppUser)
//                .Include(u => u.HourlyRate)
//                .Include(u => u.UserType)
//                .FirstOrDefaultAsync(m => m.Id == id);

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
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FirstName,LastName,Email,Phone,UserTypeId,HourlyRateId,Id")] User user)
        {
            user.AppUserId = User.GetUserId();
            
            if (ModelState.IsValid)
            {
                await _uow.Users.AddAsync(user);
                await _uow.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
     
            return View(user);
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
            ViewData["AppUserId"] = new SelectList(await _uow.BaseRepository<AppUser>().AllAsync(), "Id", "FirstName", user.AppUserId);
            ViewData["HourlyRateId"] = new SelectList(await _uow.BaseRepository<HourlyRate>().AllAsync(), "Id", "Id", user.HourlyRateId);
            ViewData["UserTypeId"] = new SelectList(await _uow.BaseRepository<UserType>().AllAsync(), "Id", "Name", user.UserTypeId);
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FirstName,LastName,Email,Phone,UserTypeId,AppUserId,HourlyRateId,Id")] User user)
        {
            if (id != user.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _uow.Users.Update(user);
                await _uow.SaveChangesAsync();
   
                return RedirectToAction(nameof(Index));
            }
            ViewData["AppUserId"] = new SelectList(await _uow.BaseRepository<AppUser>().AllAsync(), "Id", "FirstName", user.AppUserId);
            ViewData["HourlyRateId"] = new SelectList(await _uow.BaseRepository<HourlyRate>().AllAsync(), "Id", "Id", user.HourlyRateId);
            ViewData["UserTypeId"] = new SelectList(await _uow.BaseRepository<UserType>().AllAsync(), "Id", "Name", user.UserTypeId);
            return View(user);
        }

        // GET: Users/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _uow.Users.FindAsync();
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
