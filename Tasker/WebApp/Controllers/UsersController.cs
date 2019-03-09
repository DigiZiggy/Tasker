using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DAL;
using DAL.App.EF;
using Domain;
using Microsoft.AspNetCore.Authorization;
using WebApp.ViewModels;

namespace WebApp.Controllers
{
    [Authorize]
    public class UsersController : Controller
    {
        private readonly AppDbContext _context;

        public UsersController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Users
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Users
                .Include(u => u.HourlyRate)
                .Include(u => u.UserType);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Users/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users
                .Include(u => u.HourlyRate)
                .Include(u => u.UserType)
                .FirstOrDefaultAsync(m => m.Id == id);
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
                HourlyRateSelectList = new SelectList(_context.HourlyRates, nameof(HourlyRate.Id), nameof(HourlyRate.PriceListId)),
                UserTypeSelectList = new SelectList(_context.UserTypes, nameof(UserType.Id), nameof(UserType.Name))
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
            if (ModelState.IsValid)
            {
                _context.Add(vm.User);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            vm.UserTypeSelectList = new SelectList(_context.UserTypes, nameof(UserType.Id),
                nameof(UserType.Name), vm.User.UserTypeId);
            vm.HourlyRateSelectList = new SelectList(_context.HourlyRates, nameof(HourlyRate.Id),
                nameof(HourlyRate.PriceListId), vm.User.HourlyRateId);

//            ViewData["HourlyRateId"] = new SelectList(_context.HourlyRates, "Id", "Id", user.HourlyRateId);
//            ViewData["UserTypeId"] = new SelectList(_context.UserTypes, "Id", "Name", user.UserTypeId);
            return View(vm);
        }

        // GET: Users/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            ViewData["HourlyRateId"] = new SelectList(_context.HourlyRates, "Id", "Id", user.HourlyRateId);
            ViewData["UserTypeId"] = new SelectList(_context.UserTypes, "Id", "Name", user.UserTypeId);
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FirstName,LastName,Email,Phone,UserTypeId,HourlyRateId,Id")] User user)
        {
            if (id != user.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(user);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(user.Id))
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
            ViewData["HourlyRateId"] = new SelectList(_context.HourlyRates, "Id", "Id", user.HourlyRateId);
            ViewData["UserTypeId"] = new SelectList(_context.UserTypes, "Id", "Name", user.UserTypeId);
            return View(user);
        }

        // GET: Users/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users
                .Include(u => u.HourlyRate)
                .Include(u => u.UserType)
                .FirstOrDefaultAsync(m => m.Id == id);
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
            var user = await _context.Users.FindAsync(id);
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
    }
}
