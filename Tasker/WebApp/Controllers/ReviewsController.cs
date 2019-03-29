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
    public class ReviewsController : Controller
    {
        private readonly IAppUnitOfWork _uow;

        public ReviewsController(IAppUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: Reviews
        public async Task<IActionResult> Index()
        {
            var reviews = await _uow.Reviews.AllAsync();

//            var appDbContext = _context.Reviews
//                .Include(r => r.AppUser)
//                .Include(r => r.Task);
            return View(reviews);
        }

        // GET: Reviews/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

//            var review = await _context.Reviews
//                .Include(r => r.AppUser)
//                .Include(r => r.Task)
//                .FirstOrDefaultAsync(m => m.Id == id);

            var review = await _uow.Reviews.FindAsync(id);

            if (review == null)
            {
                return NotFound();
            }

            return View(review);
        }

        // GET: Reviews/Create
        public IActionResult Create()
        {
            ViewData["AppUserId"] = new SelectList(_context.Users, "Id", "FirstName");
            ViewData["TaskId"] = new SelectList(_context.Tasks, "Id", "Id");
            return View();
        }

        // POST: Reviews/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Rating,Comment,TaskId,AppUserId,Id")] Review review)
        {
            if (ModelState.IsValid)
            {
                await _uow.Reviews.AddAsync(review);
                await _uow.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AppUserId"] = new SelectList(_context.Users, "Id", "FirstName", review.AppUserId);
            ViewData["TaskId"] = new SelectList(_context.Tasks, "Id", "Id", review.TaskId);
            return View(review);
        }

        // GET: Reviews/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var review = await _uow.Reviews.FindAsync(id);
            if (review == null)
            {
                return NotFound();
            }
            ViewData["AppUserId"] = new SelectList(_context.Users, "Id", "FirstName", review.AppUserId);
            ViewData["TaskId"] = new SelectList(_context.Tasks, "Id", "Id", review.TaskId);
            return View(review);
        }

        // POST: Reviews/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Rating,Comment,TaskId,AppUserId,Id")] Review review)
        {
            if (id != review.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _uow.Reviews.Update(review);
                await _uow.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            ViewData["AppUserId"] = new SelectList(_context.Users, "Id", "FirstName", review.AppUserId);
            ViewData["TaskId"] = new SelectList(_context.Tasks, "Id", "Id", review.TaskId);
            return View(review);
        }

        // GET: Reviews/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var review = await _uow.Reviews.FindAsync(id);
            if (review == null)
            {
                return NotFound();
            }

            return View(review);
        }

        // POST: Reviews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            _uow.Reviews.Remove(id);
            await _uow.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
