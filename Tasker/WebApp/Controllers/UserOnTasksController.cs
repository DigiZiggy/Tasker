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
    public class UserOnTasksController : Controller
    {
        private readonly IAppUnitOfWork _uow;

        public UserOnTasksController(IAppUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: UserOnTasks
        public async Task<IActionResult> Index()
        {
            var userOnTasks = await _uow.UserOnTasks.AllAsync();

//            var appDbContext = _context.UserOnTasks
//                .Include(u => u.AppUser).Include(u => u.Task)
//                .Include(u => u.TaskGiver)
//                .Include(u => u.Tasker);
            return View(userOnTasks);
        }

        // GET: UserOnTasks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

//            var userOnTask = await _context.UserOnTasks
//                .Include(u => u.AppUser)
//                .Include(u => u.Task)
//                .Include(u => u.TaskGiver)
//                .Include(u => u.Tasker)
//                .FirstOrDefaultAsync(m => m.Id == id);

            var userOnTask = await _uow.UserOnTasks.FindAsync(id);

            if (userOnTask == null)
            {
                return NotFound();
            }

            return View(userOnTask);
        }

        // GET: UserOnTasks/Create
        public IActionResult Create()
        {
            ViewData["AppUserId"] = new SelectList(_context.Users, "Id", "FirstName");
            ViewData["TaskId"] = new SelectList(_context.Tasks, "Id", "Id");
            ViewData["TaskGiverId"] = new SelectList(_context.Users, "Id", "Id");
            ViewData["TaskerId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: UserOnTasks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Start,End,TaskId,TaskGiverId,TaskerId,AppUserId,Id")] UserOnTask userOnTask)
        {
            if (ModelState.IsValid)
            {
                await _uow.UserOnTasks.AddAsync(userOnTask);
                await _uow.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AppUserId"] = new SelectList(_context.Users, "Id", "FirstName", userOnTask.AppUserId);
            ViewData["TaskId"] = new SelectList(_context.Tasks, "Id", "Id", userOnTask.TaskId);
            ViewData["TaskGiverId"] = new SelectList(_context.Users, "Id", "Id", userOnTask.TaskGiverId);
            ViewData["TaskerId"] = new SelectList(_context.Users, "Id", "Id", userOnTask.TaskerId);
            return View(userOnTask);
        }

        // GET: UserOnTasks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userOnTask = await _uow.UserOnTasks.FindAsync(id);
            if (userOnTask == null)
            {
                return NotFound();
            }
            ViewData["AppUserId"] = new SelectList(_context.Users, "Id", "FirstName", userOnTask.AppUserId);
            ViewData["TaskId"] = new SelectList(_context.Tasks, "Id", "Id", userOnTask.TaskId);
            ViewData["TaskGiverId"] = new SelectList(_context.Users, "Id", "Id", userOnTask.TaskGiverId);
            ViewData["TaskerId"] = new SelectList(_context.Users, "Id", "Id", userOnTask.TaskerId);
            return View(userOnTask);
        }

        // POST: UserOnTasks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Start,End,TaskId,TaskGiverId,TaskerId,AppUserId,Id")] UserOnTask userOnTask)
        {
            if (id != userOnTask.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _uow.UserOnTasks.Update(userOnTask);
                await _uow.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            ViewData["AppUserId"] = new SelectList(_context.Users, "Id", "FirstName", userOnTask.AppUserId);
            ViewData["TaskId"] = new SelectList(_context.Tasks, "Id", "Id", userOnTask.TaskId);
            ViewData["TaskGiverId"] = new SelectList(_context.Users, "Id", "Id", userOnTask.TaskGiverId);
            ViewData["TaskerId"] = new SelectList(_context.Users, "Id", "Id", userOnTask.TaskerId);
            return View(userOnTask);
        }

        // GET: UserOnTasks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userOnTask = await _uow.UserOnTasks.FindAsync(id);
            if (userOnTask == null)
            {
                return NotFound();
            }

            return View(userOnTask);
        }

        // POST: UserOnTasks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            _uow.UserOnTasks.Remove(id);
            await _uow.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
