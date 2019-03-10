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
using Domain.Identity;
using Identity;
using Task = Domain.Task;

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
//            var appDbContext = _context.Reviews.Include(r => r.Task);

            var reviews = await _uow.Reviews.AllAsync();

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
//            ViewData["TaskId"] = new SelectList(_context.Tasks, "Id", "Address");
            return View();
        }

        // POST: Reviews/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Rating,Comment,TaskId,Id")] Review review)
        {
            review.AppUserId = User.GetUserId();

            if (ModelState.IsValid)
            {
                await _uow.Reviews.AddAsync(review);
                await _uow.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TaskId"] = new SelectList(await _uow.BaseRepository<Domain.Task>().AllAsync(), "Id", "Address", review.TaskId);
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
            ViewData["TaskId"] = new SelectList(await _uow.BaseRepository<Task>().AllAsync(), "Id", "Address", review.TaskId);
            return View(review);
        }

        // POST: Reviews/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Rating,Comment,TaskId,Id")] Review review)
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
            ViewData["AppUserId"] = new SelectList(await _uow.BaseRepository<AppUser>().AllAsync(), "Id", "FirstName", review.AppUserId);
            ViewData["TaskId"] = new SelectList(await _uow.BaseRepository<Task>().AllAsync(), "Id", "Address", review.TaskId);
            return View(review);
        }

        // GET: Reviews/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var review = await _uow.Reviews.FindAsync();

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
