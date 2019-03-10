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
    public class UserOnTasksController : Controller
    {
        private readonly AppDbContext _context;

        public UserOnTasksController(AppDbContext context)
        {
            _context = context;
        }

        // GET: UserOnTasks
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.UserOnTasks.Include(u => u.Task).Include(u => u.TaskGiver).Include(u => u.Tasker);
            return View(await appDbContext.ToListAsync());
        }

        // GET: UserOnTasks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userOnTask = await _context.UserOnTasks
                .Include(u => u.Task)
                .Include(u => u.TaskGiver)
                .Include(u => u.Tasker)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userOnTask == null)
            {
                return NotFound();
            }

            return View(userOnTask);
        }

        // GET: UserOnTasks/Create
        public IActionResult Create()
        {
            ViewData["TaskId"] = new SelectList(_context.Tasks, "Id", "Address");
            ViewData["TaskGiverId"] = new SelectList(_context.Users, "Id", "Email");
            ViewData["TaskerId"] = new SelectList(_context.Users, "Id", "Email");
            return View();
        }

        // POST: UserOnTasks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Start,End,TaskId,TaskGiverId,TaskerId,Id")] UserOnTask userOnTask)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userOnTask);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TaskId"] = new SelectList(_context.Tasks, "Id", "Address", userOnTask.TaskId);
            ViewData["TaskGiverId"] = new SelectList(_context.Users, "Id", "Email", userOnTask.TaskGiverId);
            ViewData["TaskerId"] = new SelectList(_context.Users, "Id", "Email", userOnTask.TaskerId);
            return View(userOnTask);
        }

        // GET: UserOnTasks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userOnTask = await _context.UserOnTasks.FindAsync(id);
            if (userOnTask == null)
            {
                return NotFound();
            }
            ViewData["TaskId"] = new SelectList(_context.Tasks, "Id", "Address", userOnTask.TaskId);
            ViewData["TaskGiverId"] = new SelectList(_context.Users, "Id", "Email", userOnTask.TaskGiverId);
            ViewData["TaskerId"] = new SelectList(_context.Users, "Id", "Email", userOnTask.TaskerId);
            return View(userOnTask);
        }

        // POST: UserOnTasks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Start,End,TaskId,TaskGiverId,TaskerId,Id")] UserOnTask userOnTask)
        {
            if (id != userOnTask.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userOnTask);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserOnTaskExists(userOnTask.Id))
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
            ViewData["TaskId"] = new SelectList(_context.Tasks, "Id", "Address", userOnTask.TaskId);
            ViewData["TaskGiverId"] = new SelectList(_context.Users, "Id", "Email", userOnTask.TaskGiverId);
            ViewData["TaskerId"] = new SelectList(_context.Users, "Id", "Email", userOnTask.TaskerId);
            return View(userOnTask);
        }

        // GET: UserOnTasks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userOnTask = await _context.UserOnTasks
                .Include(u => u.Task)
                .Include(u => u.TaskGiver)
                .Include(u => u.Tasker)
                .FirstOrDefaultAsync(m => m.Id == id);
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
            var userOnTask = await _context.UserOnTasks.FindAsync(id);
            _context.UserOnTasks.Remove(userOnTask);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserOnTaskExists(int id)
        {
            return _context.UserOnTasks.Any(e => e.Id == id);
        }
    }
}
