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
    public class IdentificationsController : Controller
    {
        private readonly AppDbContext _context;

        public IdentificationsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Identifications
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Identifications.Include(i => i.IdentificationType).Include(i => i.User);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Identifications/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var identification = await _context.Identifications
                .Include(i => i.IdentificationType)
                .Include(i => i.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (identification == null)
            {
                return NotFound();
            }

            return View(identification);
        }

        // GET: Identifications/Create
        public IActionResult Create()
        {
            ViewData["IdentificationTypeId"] = new SelectList(_context.IdentificationTypes, "Id", "Name");
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Email");
            return View();
        }

        // POST: Identifications/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DocumentNumber,Start,End,Comment,UserId,IdentificationTypeId,Id")] Identification identification)
        {
            if (ModelState.IsValid)
            {
                _context.Add(identification);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdentificationTypeId"] = new SelectList(_context.IdentificationTypes, "Id", "Name", identification.IdentificationTypeId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Email", identification.UserId);
            return View(identification);
        }

        // GET: Identifications/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var identification = await _context.Identifications.FindAsync(id);
            if (identification == null)
            {
                return NotFound();
            }
            ViewData["IdentificationTypeId"] = new SelectList(_context.IdentificationTypes, "Id", "Name", identification.IdentificationTypeId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Email", identification.UserId);
            return View(identification);
        }

        // POST: Identifications/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DocumentNumber,Start,End,Comment,UserId,IdentificationTypeId,Id")] Identification identification)
        {
            if (id != identification.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(identification);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IdentificationExists(identification.Id))
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
            ViewData["IdentificationTypeId"] = new SelectList(_context.IdentificationTypes, "Id", "Name", identification.IdentificationTypeId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Email", identification.UserId);
            return View(identification);
        }

        // GET: Identifications/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var identification = await _context.Identifications
                .Include(i => i.IdentificationType)
                .Include(i => i.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (identification == null)
            {
                return NotFound();
            }

            return View(identification);
        }

        // POST: Identifications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var identification = await _context.Identifications.FindAsync(id);
            _context.Identifications.Remove(identification);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IdentificationExists(int id)
        {
            return _context.Identifications.Any(e => e.Id == id);
        }
    }
}
