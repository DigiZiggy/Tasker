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
    public class TasksController : Controller
    {
        private readonly IAppUnitOfWork _uow;

        public TasksController(IAppUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: Tasks
        public async Task<IActionResult> Index()
        {
            var tasks = await _uow.Tasks.AllAsync();

//            var appDbContext = _context.Tasks
//                .Include(t => t.AppUser)
//                .Include(t => t.TaskType);
            return View(tasks);
        }

        // GET: Tasks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

//            var task = await _context.Tasks
//                .Include(t => t.AppUser)
//                .Include(t => t.TaskType)
//                .FirstOrDefaultAsync(m => m.Id == id);

            var task = await _uow.Tasks.FindAsync(id);

            if (task == null)
            {
                return NotFound();
            }

            return View(task);
        }

        // GET: Tasks/Create
        public IActionResult Create()
        {
            ViewData["AppUserId"] = new SelectList(_context.Users, "Id", "FirstName");
            ViewData["TaskTypeId"] = new SelectList(_context.TaskTypes, "Id", "Id");
            return View();
        }

        // POST: Tasks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Description,TimeEstimate,Address,TaskTypeId,AppUserId,Id")] Domain.Task task)
        {
            if (ModelState.IsValid)
            {
                await _uow.Tasks.AddAsync(task);
                await _uow.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AppUserId"] = new SelectList(_context.Users, "Id", "FirstName", task.AppUserId);
            ViewData["TaskTypeId"] = new SelectList(_context.TaskTypes, "Id", "Id", task.TaskTypeId);
            return View(task);
        }

        // GET: Tasks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var task = await _uow.Tasks.FindAsync(id);
            if (task == null)
            {
                return NotFound();
            }
            ViewData["AppUserId"] = new SelectList(_context.Users, "Id", "FirstName", task.AppUserId);
            ViewData["TaskTypeId"] = new SelectList(_context.TaskTypes, "Id", "Id", task.TaskTypeId);
            return View(task);
        }

        // POST: Tasks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Description,TimeEstimate,Address,TaskTypeId,AppUserId,Id")] Domain.Task task)
        {
            if (id != task.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _uow.Tasks.Update(task);
                await _uow.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            ViewData["AppUserId"] = new SelectList(_context.Users, "Id", "FirstName", task.AppUserId);
            ViewData["TaskTypeId"] = new SelectList(_context.TaskTypes, "Id", "Id", task.TaskTypeId);
            return View(task);
        }

        // GET: Tasks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var task = await _uow.Tasks.FindAsync(id);
            if (task == null)
            {
                return NotFound();
            }

            return View(task);
        }

        // POST: Tasks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            _uow.Tasks.Remove(id);
            await _uow.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
