using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DAL.App.EF;
using Domain;

namespace WebApp.Controllers
{
    public class UserOnAddressesController : Controller
    {
        private readonly AppDbContext _context;

        public UserOnAddressesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: UserOnAddresses
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.UserOnAddresses.Include(u => u.Address).Include(u => u.User);
            return View(await appDbContext.ToListAsync());
        }

        // GET: UserOnAddresses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userOnAddress = await _context.UserOnAddresses
                .Include(u => u.Address)
                .Include(u => u.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userOnAddress == null)
            {
                return NotFound();
            }

            return View(userOnAddress);
        }

        // GET: UserOnAddresses/Create
        public IActionResult Create()
        {
            ViewData["AddressId"] = new SelectList(_context.Addresses, "Id", "District");
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Email");
            return View();
        }

        // POST: UserOnAddresses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Start,End,UserId,AddressId,Id")] UserOnAddress userOnAddress)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userOnAddress);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AddressId"] = new SelectList(_context.Addresses, "Id", "District", userOnAddress.AddressId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Email", userOnAddress.UserId);
            return View(userOnAddress);
        }

        // GET: UserOnAddresses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userOnAddress = await _context.UserOnAddresses.FindAsync(id);
            if (userOnAddress == null)
            {
                return NotFound();
            }
            ViewData["AddressId"] = new SelectList(_context.Addresses, "Id", "District", userOnAddress.AddressId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Email", userOnAddress.UserId);
            return View(userOnAddress);
        }

        // POST: UserOnAddresses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Start,End,UserId,AddressId,Id")] UserOnAddress userOnAddress)
        {
            if (id != userOnAddress.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userOnAddress);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserOnAddressExists(userOnAddress.Id))
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
            ViewData["AddressId"] = new SelectList(_context.Addresses, "Id", "District", userOnAddress.AddressId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Email", userOnAddress.UserId);
            return View(userOnAddress);
        }

        // GET: UserOnAddresses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userOnAddress = await _context.UserOnAddresses
                .Include(u => u.Address)
                .Include(u => u.User)
                .FirstOrDefaultAsync(m => m.Id == id);
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
            var userOnAddress = await _context.UserOnAddresses.FindAsync(id);
            _context.UserOnAddresses.Remove(userOnAddress);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserOnAddressExists(int id)
        {
            return _context.UserOnAddresses.Any(e => e.Id == id);
        }
    }
}
