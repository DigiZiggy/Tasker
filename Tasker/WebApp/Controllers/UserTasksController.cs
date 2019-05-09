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
using WebApp.ViewModels;

namespace WebApp.Controllers
{
    public class UserTasksController : Controller
    {
        private readonly IAppUnitOfWork _uow;

        public UserTasksController(IAppUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: UserTasks
        public async Task<IActionResult> Index()
        {
            var userTasks = await _uow.UserTasks.AllAsync();

            return View(userTasks);
        }

        // GET: UserTasks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userTask = await _uow.UserTasks.FindAllIncludedAsync(id);

            if (userTask == null)
            {
                return NotFound();
            }

            return View(userTask);
        }

        // GET: UserTasks/Create
        public async Task<IActionResult> Create()
        {
            var vm = new UserTaskCreateViewModel()
            {
                TaskGiverSelectList = new SelectList(await _uow.BaseRepositoryAsync<TaskerTask>().AllAsync(), "Id", "Id"),
                TaskerSelectList = new SelectList(await _uow.BaseRepositoryAsync<TaskerTask>().AllAsync(), "Id", "Id")

            };          
            return View(vm);
        }

        // POST: UserTasks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UserTaskCreateViewModel vm)
        {
            if (ModelState.IsValid)
            {
                await _uow.UserTasks.AddAsync(vm.UserTask);
                await _uow.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            vm.TaskerSelectList = new SelectList(await _uow.BaseRepositoryAsync<TaskerTask>().AllAsync(), "Id", "Id", vm.UserTask.TaskerId);
            vm.TaskGiverSelectList = new SelectList(await _uow.BaseRepositoryAsync<TaskerTask>().AllAsync(), "Id", "Id", vm.UserTask.TaskGiverId);

            return View(vm);
        }

        // GET: UserTasks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userTask = await _uow.UserTasks.FindAsync(id);
            if (userTask == null)
            {
                return NotFound();
            }
            var vm = new UserTaskEditViewModel()
            {
                TaskGiverSelectList = new SelectList(await _uow.BaseRepositoryAsync<TaskerTask>().AllAsync(), "Id", "Id", userTask.TaskGiverId),
                TaskerSelectList = new SelectList(await _uow.BaseRepositoryAsync<TaskerTask>().AllAsync(), "Id", "Id", userTask.TaskerId)
            };
            
            return View(vm);
        }

        // POST: UserTasks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, UserTaskEditViewModel vm)
        {
            if (id != vm.UserTask.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _uow.UserTasks.Update(vm.UserTask);
                await _uow.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            vm.TaskerSelectList = new SelectList(await _uow.BaseRepositoryAsync<TaskerTask>().AllAsync(), "Id", "Id", vm.UserTask.TaskerId);
            vm.TaskGiverSelectList = new SelectList(await _uow.BaseRepositoryAsync<TaskerTask>().AllAsync(), "Id", "Id", vm.UserTask.TaskGiverId);

            return View(vm);
        }

        // GET: UserTasks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userTask = await _uow.UserTasks.FindAllIncludedAsync(id);

            if (userTask == null)
            {
                return NotFound();
            }

            return View(userTask);
        }

        // POST: UserTasks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            _uow.UserTasks.Remove(id);
            await _uow.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
