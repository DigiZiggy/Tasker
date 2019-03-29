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
    public class UserOnAddressesController : Controller
    {
        private readonly IAppUnitOfWork _uow;

        public UserOnAddressesController(IAppUnitOfWork uow)
        {
            _uow = uow;
        }
        // GET: UserOnAddresses
        public async Task<IActionResult> Index()
        {
            var userOnAddresses = await _uow.UserOnAddresses.AllAsync();

//            var appDbContext = _context.UserOnAddresses
//                .Include(u => u.Address)
//                .Include(u => u.AppUser)
//                .Include(u => u.User);
            return View(userOnAddresses);
        }

        // GET: UserOnAddresses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
//
//            var userOnAddress = await _context.UserOnAddresses
//                .Include(u => u.Address)
//                .Include(u => u.AppUser)
//                .Include(u => u.User)
//                .FirstOrDefaultAsync(m => m.Id == id);

            var userOnAddress = await _uow.UserOnAddresses.FindAsync(id);

            if (userOnAddress == null)
            {
                return NotFound();
            }

            return View(userOnAddress);
        }

        // GET: UserOnAddresses/Create
        public IActionResult Create()
        {
            ViewData["AddressId"] = new SelectList(_context.Addresses, "Id", "Id");
            ViewData["AppUserId"] = new SelectList(_context.Users, "Id", "FirstName");
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: UserOnAddresses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Start,End,UserId,AddressId,AppUserId,Id")] UserOnAddress userOnAddress)
        {
            if (ModelState.IsValid)
            {
                await _uow.UserOnAddresses.AddAsync(userOnAddress);
                await _uow.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AddressId"] = new SelectList(_context.Addresses, "Id", "Id", userOnAddress.AddressId);
            ViewData["AppUserId"] = new SelectList(_context.Users, "Id", "FirstName", userOnAddress.AppUserId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", userOnAddress.UserId);
            return View(userOnAddress);
        }

        // GET: UserOnAddresses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userOnAddress = await _uow.UserOnAddresses.FindAsync(id);
            if (userOnAddress == null)
            {
                return NotFound();
            }
            ViewData["AddressId"] = new SelectList(_context.Addresses, "Id", "Id", userOnAddress.AddressId);
            ViewData["AppUserId"] = new SelectList(_context.Users, "Id", "FirstName", userOnAddress.AppUserId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", userOnAddress.UserId);
            return View(userOnAddress);
        }

        // POST: UserOnAddresses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Start,End,UserId,AddressId,AppUserId,Id")] UserOnAddress userOnAddress)
        {
            if (id != userOnAddress.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _uow.UserOnAddresses.Update(userOnAddress);
                await _uow.SaveChangesAsync();
  
                return RedirectToAction(nameof(Index));
            }
            ViewData["AddressId"] = new SelectList(_context.Addresses, "Id", "Id", userOnAddress.AddressId);
            ViewData["AppUserId"] = new SelectList(_context.Users, "Id", "FirstName", userOnAddress.AppUserId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", userOnAddress.UserId);
            return View(userOnAddress);
        }

        // GET: UserOnAddresses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userOnAddress = await _uow.UserOnAddresses.FindAsync(id);
            if (userOnAddress == null)
            {
                return NotFound();
            }

            return View(userOnAddress);
        }

        // POST: UserOnAddresses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            _uow.UserOnAddresses.Remove(id);
            await _uow.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
