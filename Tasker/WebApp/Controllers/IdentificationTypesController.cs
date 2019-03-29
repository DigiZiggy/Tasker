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
    public class IdentificationTypesController : Controller
    {
        private readonly IAppUnitOfWork _uow;

        public IdentificationTypesController(IAppUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: IdentificationTypes
        public async Task<IActionResult> Index()
        {
            var identificationTypes = await _uow.IdentificationTypes.AllAsync();

            return View(identificationTypes);
        }

        // GET: IdentificationTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

//            var identificationType = await _context.IdentificationTypes
//                .FirstOrDefaultAsync(m => m.Id == id);

            var identificationType = await _uow.IdentificationTypes.FindAsync(id);

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
                await _uow.IdentificationTypes.AddAsync(identificationType);
                await _uow.SaveChangesAsync();
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

            var identificationType = await _uow.IdentificationTypes.FindAsync(id);
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
                _uow.IdentificationTypes.Update(identificationType);
                await _uow.SaveChangesAsync();

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

            var identificationType = _uow.IdentificationTypes.FindAsync(id);
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
            _uow.IdentificationTypes.Remove(id);
            await _uow.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
