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

namespace WebApp.Controllers
{
    public class IdentificationTypesController : Controller
    {
        private readonly AppDbContext _context;

        public IdentificationTypesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: IdentificationTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.IdentificationTypes.ToListAsync());
        }

        // GET: IdentificationTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var identificationType = await _context.IdentificationTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (identificationType == null)
            {
                return NotFound();
            }

            return View(identificationType);
        }

        // GET: IdentificationTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: IdentificationTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Comment,Id")] IdentificationType identificationType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(identificationType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(identificationType);
        }

        // GET: IdentificationTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var identificationType = await _context.IdentificationTypes.FindAsync(id);
            if (identificationType == null)
            {
                return NotFound();
            }
            return View(identificationType);
        }

        // POST: IdentificationTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,Comment,Id")] IdentificationType identificationType)
        {
            if (id != identificationType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(identificationType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IdentificationTypeExists(identificationType.Id))
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
            return View(identificationType);
        }

        // GET: IdentificationTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var identificationType = await _context.IdentificationTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (identificationType == null)
            {
                return NotFound();
            }

            return View(identificationType);
        }

        // POST: IdentificationTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var identificationType = await _context.IdentificationTypes.FindAsync(id);
            _context.IdentificationTypes.Remove(identificationType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IdentificationTypeExists(int id)
        {
            return _context.IdentificationTypes.Any(e => e.Id == id);
        }
    }
}
